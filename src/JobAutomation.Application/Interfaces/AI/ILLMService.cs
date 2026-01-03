using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAutomation.Application.Interfaces.AI
{
    public interface ILLMService
    {
        Task<string> GenerateAsync(string systemPrompt, string userPrompt, CancellationToken cancellationToken = default);
    }
}
