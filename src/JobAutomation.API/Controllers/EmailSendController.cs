using JobAutomation.Application.Interfaces.Email;
using JobAutomation.Application.Interfaces.Persistence;
using JobAutomation.Infrastructure.Persistence.Repositories;
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
        private readonly IUserRepository _userRepository;

        public EmailSendController(
            IEmailDraftRepository draftRepository,
            IEmailSender emailSender,
            IUserRepository userRepository)
        {
            _draftRepository = draftRepository;
            _emailSender = emailSender;
            _userRepository = userRepository;
        }

        [HttpPost("send/{draftId}")]
        public async Task<IActionResult> Send(
            Guid draftId,
            [FromQuery] string to,
            [FromQuery] bool attachResume,
            CancellationToken cancellationToken)
        {
            var draft = await _draftRepository.GetByIdAsync(draftId, cancellationToken);
            if (draft == null) return NotFound();

            var user = await _userRepository.GetByIdAsync(draft.UserId, cancellationToken);

            attachResume = true;

            await _emailSender.SendAsync(
                to,
                draft.Subject,
                draft.Body,
                attachResume ? user.ResumePath : null,
                cancellationToken);

            return Ok("Email sent");
        }
    }
}
