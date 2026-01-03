using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAutomation.Application.Interfaces.FileSystem
{
    public interface IPromptReader
    {
        Task<string> ReadAsync(string promptName, CancellationToken cancellationToken = default);
    }
}
