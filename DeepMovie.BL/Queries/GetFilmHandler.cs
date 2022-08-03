using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using DeepMovie.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepMovie.BL.Queries
{
    public class GetFilmHandler : IRequestHandler<GetFilmRequest, GetFilmResponse>
    {
        private readonly ApplicationContext _context;
        public GetFilmHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetFilmResponse> Handle(GetFilmRequest request, CancellationToken cancellationToken)
        {



            var result = _context.Films.Select(model => new GetFilmResponse
            {

                Description = model.Description,
                ID = model.ID,
                Sound = model.Sound,
                AgeRating = model.AgeRating,
                USAFees = model.USAFees.ToString(),
                Country = model.Country,
                FundRaised = model.FundRaised,
                FundTotal = model.FundTotal,
                Format = model.Format,
                IsImmersive = model.IsImmersive,
                RussiaFees = model.RussiaFees.ToString(),
                RussiaPremiere = model.RussiaPremiere.ToShortDateString(),
                TotalBudget = model.TotalBudget.ToString(),
                MainActors = string.Join(", ", model.FilmMembers.Where(x => x.MemberRole == Common.Entities.MemberRole.Actor).Select(x => x.Member.FIO).Take(2)),
                Director = model.FilmMembers.Where(x => x.MemberRole == Common.Entities.MemberRole.Director).Select(x => x.Member.FIO).FirstOrDefault(),
                TotalFees = model.TotalFees.ToString(),
                TotalPremiere = model.TotalPremiere.ToShortDateString(),
                Time = new TimeSpan(0, model.Minutes, 0).Hours.ToString() + " ч " + (model.Minutes % (new TimeSpan(0, model.Minutes, 0).Hours * 60)).ToString() + " мин",
                Title = model.Title,
                Year = model.Year,
                DonationStages = model.DonationStages.Select(x => new DonationStageResponse
                {
                    DateTo = x.DateTo.ToShortDateString(),
                    ID = x.ID,
                    Title = x.Title
                }),
                Reviews = model.Reviews.Select(x => new ReviewResponse
                {

                    Description = x.Description,
                    ID = x.ID,
                    ImageURL = x.Image.URL,
                    Label = x.Label,
                    Link = x.Link,
                    Title = x.Title
                }),
                Links = model.Links.Select(x => new LinkResponse
                {
                    Title = x.Title,
                    URL = x.URL
                }),
                Categories = string.Join(", ", model.FilmCategories.Select(x => x.Category.Title)),
                Photos = model.Contents.Where(x => x.ContentType == Common.Entities.ContentType.Image).Select(x => new ContentResponse
                {
                    ID = x.ID,
                    URL = x.URL
                }),
                Videos = model.Contents.Where(x => x.ContentType == Common.Entities.ContentType.Video).Select(x => new ContentResponse
                {
                    ID = x.ID,
                    URL = x.URL
                }),

                PercentCollected = (int)((model.FundRaised * 100) / model.FundTotal)
            }).FirstOrDefault(x => x.ID == request.ID);
            if (result == null)
            {
                return null;
            }
            for (int i = result.TotalBudget.Length - 3; i > 0; i -= 3)
            {
                result.TotalBudget = result.TotalBudget.Insert(i, " ");
            }
            for (int i = result.RussiaFees.Length - 3; i > 0; i -= 3)
            {
                result.RussiaFees = result.RussiaFees.Insert(i, " ");
            }
            for (int i = result.USAFees.Length - 3; i > 0; i -= 3)
            {
                result.USAFees = result.USAFees.Insert(i, " ");
            }
            for (int i = result.TotalFees.Length - 3; i > 0; i -= 3)
            {
                result.TotalFees = result.TotalFees.Insert(i, " ");
            }
            result.Creators = _context.FilmMember.Include(x => x.Member).ThenInclude(x => x.Photo).Where(x => x.FilmID == request.ID).ToList().GroupBy(x => x.MemberRole, (key, items) => new CreatorsResponse
            {
                Title = ((MemberRoleResponse)key).ToString().Replace("ъ", " "),
                ID = key.ToString().ToLower(),
                Data = items.Select(x => new FilmMemberResponse
                {
                    Description = x.Description,
                    FIO = x.Member.FIO,
                    ID = x.Member.ID,
                    PhotoURL = x.Member.Photo.URL,
                    Role = x.MemberRole.ToString(),
                    URL = x.Member.URL

                })
            });

            if (result == null)
            {
                return null;
            }
            return result;
        }
    }

}
