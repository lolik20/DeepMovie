using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeepMovie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{filmID}")]
        public async Task<ActionResult<GetFilmResponse>> Film(int filmID)
        {
            var response = await _mediator.Send(new GetFilmRequest
            {
                ID = filmID
            });
            return Ok(response);
        }

        [HttpGet("films")]
        public async Task<ActionResult<GetFilmsResponse>> Films()
        {
            var response = await _mediator.Send(new GetFilmsRequest { });
            return Ok(response);
        }
        [HttpGet("{filmID}/portal/all")]
        public async Task<ActionResult<IEnumerable<ContentResponse>>> GetPortalAll(int filmID)
        {
            var response = await _mediator.Send(new GetPortalRequest { FilmID = filmID, ContentType = Common.Entities.ContentType.None });
            return Ok(response);
        }
        [HttpGet("{filmID}/portal/image")]
        public async Task<ActionResult<IEnumerable<ContentResponse>>> GetPortalImage(int filmID)
        {
            var response = await _mediator.Send(new GetPortalRequest { FilmID = filmID, ContentType = Common.Entities.ContentType.PortalImage });
            return Ok(response);
        }
        [HttpGet("{filmID}/portal/video")]
        public async Task<ActionResult<IEnumerable<ContentResponse>>> GetPortalVideo(int filmID)
        {
            var response = await _mediator.Send(new GetPortalRequest { FilmID = filmID, ContentType = Common.Entities.ContentType.PortalVideo });
            return Ok(response);
        }
        [HttpGet("{filmID}/portal/backStage")]
        public async Task<ActionResult<IEnumerable<ContentResponse>>> GetPortalBackStage(int filmID)
        {
            var response = await _mediator.Send(new GetPortalRequest { FilmID = filmID, ContentType = Common.Entities.ContentType.PortalBackStage });
            return Ok(response);
        }
    }
}
