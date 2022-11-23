using ShippingApp.Application.Dto.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingApp.Application.Services;
using ShippingApp.Application.Utilities;
using System.Security.Claims;

namespace dp_shipping.Controllers
{
    [Authorize(Policy = Policies.MustHaveId)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService service;
        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<TokenDto> LogIn([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = service.Authenticate(loginDto);
                return Ok(token.Token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<AdminDto> GetAdmin([FromRoute] int id)
        {
            try
            {
                return service.GetAdmin(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("admins")]
        public ActionResult<IEnumerable<AdminDto>> GetAdmins()
        {
            try
            {
                return Ok(service.GetAdmins());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("create-admin")]
        public ActionResult<AdminDto> CreateAdmin([FromBody] CreateAdminDto dto)
        {
            int id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var admin = service.CreateAdmin(dto, id);
                return Created($"api/v1/admin/login/", admin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit-admin/{id:int}")]
        public ActionResult<AdminDto> EditAdmin([FromBody] CreateAdminDto dto, [FromRoute] int id)
        {
            int adminId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(service.EditAdmin(dto, id, adminId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete-admin/{id:int}")]
        public ActionResult DeleteAdmin(int id)
        {
            int adminId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        
            try
            {
                service.DeleteAdmin(id, adminId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}