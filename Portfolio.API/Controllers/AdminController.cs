using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IContactMessageRepository _repository;
        private readonly IEmailServices _emailService;

        public AdminController(IContactMessageRepository repository, IEmailServices emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var messages = await _repository.GetAllContactAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var message = await _repository.GetByIdContactAsync(id);
            if (message == null)
                return NotFound();
            return Ok(message);
        }
        [HttpPost("{id}/reply")]
        public async Task<IActionResult> ReplyMessage(int id, [FromBody] ReplyMessageDto dto)
        {
            var message = await _repository.GetByIdContactAsync(id);

            if (message == null)
                return NotFound();

            message.AdminReply = dto.Reply;
            message.RepliedAt = DateTime.UtcNow;

            await _emailService.SendEmailAsync(message.Email, "Yanıtınız Var", dto.Reply);
            await _repository.UpdateContactAsync(message);

            return Ok(new { success = true, message = "Yanıt gönderildi." });
        }
    }
}
