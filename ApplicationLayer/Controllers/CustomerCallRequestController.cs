using DataAccessLayer.Contacts;
using DataAccessLayer.DTOs.InputModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCallRequestController : ControllerBase
    {
        private readonly ICustomerCallRequestRepository _customerCallRequestRepository;

        public CustomerCallRequestController(ICustomerCallRequestRepository customerCallRequestRepository)
        {
            _customerCallRequestRepository = customerCallRequestRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var result = await _customerCallRequestRepository.GetAllRequestsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var result = await _customerCallRequestRepository.GetRequestByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] CustomerCallRequestInputModel inputModel)
        {
            var result = await _customerCallRequestRepository.AddRequestAsync(inputModel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] CustomerCallRequestInputModel inputModel)
        {
            var result = await _customerCallRequestRepository.UpdateRequestAsync(id, inputModel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var result = await _customerCallRequestRepository.DeleteRequestAsync(id);
            return Ok(result);
        }
    }

}
