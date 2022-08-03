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
    public class GetFilmsHandler : IRequestHandler<GetFilmsRequest, IEnumerable<GetFilmsResponse>>
    {
        private readonly ApplicationContext _context;
        public GetFilmsHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GetFilmsResponse>> Handle(GetFilmsRequest request, CancellationToken cancellationToken)
        {

            var result = _context.Films.Select(x => new GetFilmsResponse
            {

                Description = x.Description,
                Categories = string.Join(", ", x.FilmCategories.Select(x => x.Category.Title)),
                DonationStages = x.DonationStages
                .Select(x => new DonationStageResponse
                {
                    Title = x.Title,
                    DateTo = x.DateTo.ToShortDateString(),
                    ID = x.ID
                }),
                ID = x.ID,
                Time = new TimeSpan(0, x.Minutes, 0).Hours.ToString() + " ч " + (x.Minutes % (new TimeSpan(0, x.Minutes, 0).Hours * 60)).ToString() + " мин",
                Title = x.Title,
                Year = x.Year,
                PosterURL = x.Contents.FirstOrDefault(x => x.ContentType == Common.Entities.ContentType.Poster).URL,
                PercentCollected = (int)((x.FundRaised * 100) / x.FundTotal)

            });

            return result;
        }
    }
}
