using Core.Application.DTOs;
using Core.Application.Interfaces.Identity;
using Core.Application.Interfaces.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IServiceBase<AppointmentDto> _appointmentService;

        public AppointmentController(
            ILogger<AuthController> logger,
            IAuthService authService,
            IUserService userService,
            IServiceBase<AppointmentDto> appointmentService)
        {
            _logger = logger;
            _authService = authService;
            _userService = userService;
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Create(AppointmentDto request)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await _appointmentService.CreateAsync(request);
                    return Ok();
                }
                return Unauthorized();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appointmentService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _appointmentService.GetAllAsync();
            return Ok(results);
        }
    }
}