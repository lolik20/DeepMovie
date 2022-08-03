using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;
using Facebook;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeepMovie.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private HttpClient Client = new HttpClient();

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("vk")]
        public async Task<IActionResult> VK()
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                var response = await Client.GetAsync($"https://api.vk.com/method/users.get?access_token={token}&fields=verified");
                string json = await response.Content.ReadAsStringAsync();
                dynamic content = JsonConvert.DeserializeObject(json);
                var result = await _mediator.Send(new AuthorizeSocialRequest
                {
                    Params = content,
                    Social = "vk"
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("google")]
        public async Task<IActionResult> Google()
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

                var response = await Client.GetAsync($"https://www.googleapis.com/oauth2/v1/userinfo?access_token={token}");
                string json = await response.Content.ReadAsStringAsync();
                dynamic content = JsonConvert.DeserializeObject(json);
                var result = await _mediator.Send(new AuthorizeSocialRequest
                {
                    Params = content,
                    Social = "google"
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("facebook")]
        public async Task<IActionResult> Facebook()
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                var client = new FacebookClient(token);
                dynamic response = client.Get("me", new { fields = "id, name" });
                var result = await _mediator.Send(new AuthorizeSocialRequest
                {
                    Params = response,
                    Social = "facebook"
                });
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet("credentials")]
        public async Task<IActionResult> Credentials()
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                token = token.ToString().Replace("Bearer ", "");
                var response = await _mediator.Send(new CredentialsRequest
                {
                    Token = token
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpGet("userProfile")]
        public async Task<ActionResult<GetUserProfileResponse>> UserProfile()
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                token = token.ToString().Replace("Bearer ", "");
                var response = await _mediator.Send(new GetUserProfileRequest
                {
                    Token = token
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpPut("userProfile")]
        public async Task<ActionResult<GetUserProfileResponse>> UserProfileUpdate([FromBody] UpdateUserProfileRequest request)
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                token = token.ToString().Replace("Bearer ", "");
                request.Token = token;
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpPost("changePassword")]
        public async Task<ActionResult<GetUserProfileResponse>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
                token = token.ToString().Replace("Bearer ", "");
                request.Token = token;
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
