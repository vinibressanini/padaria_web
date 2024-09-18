using Microsoft.AspNetCore.Mvc;
using PadariaWebAPI.DTO;
using PadariaWebAPI.Models;
using PadariaWebAPI.Repositories;

namespace PadariaWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsController : ControllerBase
    {

        private readonly ILogger<PointsController> _logger;
        private readonly CustomerRepository _repo;

        public PointsController(ILogger<PointsController> logger,CustomerRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost()]
        public async Task<ActionResult<LoyalCustomer>> Post([FromBody]UserPointsPostRequestBody dto)
        {
            try
            {
                var customer = await _repo.UpdateUserPoints(dto);
                return Ok(customer);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<LoyalCustomer>> Get([FromQuery] int id)
        {
            LoyalCustomer? customer = await _repo.GetCustomerPoints(id);

            if (customer == null) return NotFound("User Not Found");
            return Ok(customer);
        }
    }
}
