using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingApp.Application.Dto.Order;
using ShippingApp.Application.Dto.Parcel;
using ShippingApp.Application.Services;
using ShippingApp.Application.Utilities;

namespace ShippingApp.API.Controllers
{
    [Authorize(Policy = Policies.MustHaveId)]
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelService parcelService;
        public ParcelController(IParcelService parcelService)
        {
            this.parcelService = parcelService;
        }

        [AllowAnonymous]
        [HttpGet("statistics/{id:int}")]
        public ActionResult<ParcelInquiryStatisticsDto> GetParcelInquiry([FromRoute] int id)
        {
            try
            {
                return Ok(parcelService.GetParcelInquiry(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("statistics")]
        public ActionResult<IEnumerable<ParcelInquiryStatisticsDto>> GetParcelInquiryStatistics()
        {
            try
            {
                return Ok(parcelService.GetParcelInquiryStatistics());
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost("price")]
        public ActionResult<ParcelPriceDto> CalculateParcelPrice([FromBody] ParcelInquiryDto dto)
        {
            try
            {
                return Ok(parcelService.CalculateParcelPrice(dto));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders")]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            try
            {
                return Ok(parcelService.GetOrders());
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpPost("create-order")]
        public ActionResult<OrderDto> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                return Ok(parcelService.CreateOrder(createOrderDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}