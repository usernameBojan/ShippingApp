using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingApp.Application.Dto.Company;
using ShippingApp.Application.Services;
using ShippingApp.Application.Utilities;

namespace ShippingApp.API.Controllers
{
    [Authorize(Policy = Policies.MustHaveId)]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet("{name}")]
        public ActionResult<CompanyDto> GetCompany([FromRoute] string name)
        {
            try
            {
                return Ok(companyService.GetCompany(name));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("companies")]
        public ActionResult<IEnumerable<CompanyDto>> GetCompanies()
        {
            try
            {
                return Ok(companyService.GetCompanies());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create-company")]
        public ActionResult<CompanyDto> CreateCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var company = companyService.CreateCompany(createCompanyDto);
                return Created("api/v1/company/company", company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("edit-company/{name}")]
        public ActionResult<CompanyDto> EditCompanyDetails([FromBody] CreateCompanyDto dto, [FromRoute] string name)
        {
            try
            {
                
                return Ok(companyService.EditCompany(dto, name));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("delete-company/{name}")]
        public ActionResult DeleteCompany([FromRoute] string name)
        {
            try
            {
                companyService.DeleteCompany(name);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}