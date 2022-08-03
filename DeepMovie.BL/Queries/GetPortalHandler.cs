using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using DeepMovie.DAL;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeepMovie.BL.Queries
{
    public class GetPortalHandler : IRequestHandler<GetPortalRequest, IEnumerable<ContentResponse>>
    {
        private readonly ApplicationContext _context;
        public GetPortalHandler(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContentResponse>> Handle(GetPortalRequest request, CancellationToken cancellationToken)
        {
            switch (request.ContentType)
            {
                case Common.Entities.ContentType.None:
                    var resultAll = _context.Content.Where(x => x.FilmID == request.FilmID).Select(x => new ContentResponse
                    {
                        ID = x.ID,
                        URL = x.URL
                    });
                    return resultAll;
                case Common.Entities.ContentType.Image:
                    var resultImage = _context.Content.Where(x => x.FilmID == request.FilmID && x.ContentType == Common.Entities.ContentType.Image)
                        .Select(x => new ContentResponse
                        {
                            ID = x.ID,
                            URL = x.URL
                        });
                    return resultImage;
                case Common.Entities.ContentType.PortalBackStage:
                    var resultBackStage = _context.Content.Where(x => x.FilmID == request.FilmID && x.ContentType == Common.Entities.ContentType.PortalBackStage)
                        .Select(x => new ContentResponse
                        {
                            ID = x.ID,
                            URL = x.URL
                        });
                    return resultBackStage;
                case Common.Entities.ContentType.Video:
                    var resultVideo = _context.Content.Where(x => x.FilmID == request.FilmID && x.ContentType == Common.Entities.ContentType.Video)
                        .Select(x => new ContentResponse
                        {
                            ID = x.ID,
                            URL = x.URL
                        });
                    return resultVideo;
            }
            return null;
        }
    }
}
