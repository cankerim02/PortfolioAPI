using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactMessageRepository _repository;

        public ContactController(IContactMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage(ContactMessageDto dto)
        {
            var message = new ContactMessage
            {
                Name = dto.Name,
                Email = dto.Email,
                Message = dto.Message,
                CreatedAt = DateTime.UtcNow,
            };

            await _repository.AddContactAsync(message);
            return Ok(new { success = true, message = "Mesaj gönderildi" });
        }
    }
}
