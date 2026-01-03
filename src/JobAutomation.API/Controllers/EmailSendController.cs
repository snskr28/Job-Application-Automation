using JobAutomation.Application.Interfaces.Email;
using JobAutomation.Application.Interfaces.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSendController : ControllerBase
    {
        private readonly IEmailDraftRepository _draftRepository;
        private readonly IEmailSender _emailSender;

        public EmailSendController(
            IEmailDraftRepository draftRepository,
            IEmailSender emailSender)
        {
            _draftRepository = draftRepository;
            _emailSender = emailSender;
        }

        [HttpPost("send/{draftId}")]
        public async Task<IActionResult> Send(
            Guid draftId,
            [FromQuery] string to,
            CancellationToken cancellationToken)
        {
            var draft = await _draftRepository
                .GetByIdAsync(draftId, cancellationToken);

            if (draft == null)
                return NotFound("Draft not found");

            await _emailSender.SendAsync(
                to,
                draft.Subject,
                draft.Body,
                cancellationToken);

            return Ok("Email sent successfully");
        }
    }
}
