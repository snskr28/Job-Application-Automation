using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobAutomation.Application.Interfaces.FileSystem;

namespace JobAutomation.Infrastructure.FileSystem
{
    public class PromptFileReader : IPromptReader
    {
        private readonly string _promptsDirectory;

        public PromptFileReader(string promptsDirectory)
        {
            _promptsDirectory = promptsDirectory;
        }

        public async Task<string> ReadAsync(
            string promptName,
            CancellationToken cancellationToken = default)
        {
            var fileName = $"{promptName}.txt";
            var fullPath = Path.Combine(_promptsDirectory, fileName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException(
                    $"Prompt file not found: {fullPath}");
            }

            return await File.ReadAllTextAsync(
                fullPath,
                cancellationToken);
        }
    }
}
