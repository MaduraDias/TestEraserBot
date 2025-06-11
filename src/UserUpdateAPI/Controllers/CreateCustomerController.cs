using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserUpdateAPI.Services;

namespace UserUpdateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateCustomerController : ControllerBase
    {
        private readonly ICreateCustomerService _createCustomerService;

        public CreateCustomerController(ICreateCustomerService createCustomerService)
        {
            _createCustomerService = createCustomerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var result = await _createCustomerService.CreateCustomerAsync(request);

            if (result.IsSuccess)
            {
                return StatusCode(result.StatusCode, result);
            }

            return StatusCode(result.StatusCode, result.Message);
        }
    }
}