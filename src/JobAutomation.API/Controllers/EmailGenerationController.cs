using JobAutomation.Application.Features.EmailGeneration;
using JobAutomation.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobAutomation.API.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailGenerationController : ControllerBase
    {
        private readonly GenerateEmailHandler _handler;

        public EmailGenerationController(GenerateEmailHandler handler)
        {
            _handler = handler;
        }
        
    }
}
