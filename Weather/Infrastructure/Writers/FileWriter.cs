using Microsoft.Extensions.Options;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Infrastructure.AppSettings;
using Weather.ServiceProviders.Base.Models;

namespace Weather.Infrastructure.Writers
{
    public class FileWriter : IWriter
    {
        private const string DefaultFileName = "output.txt";

        private readonly FileSettings _fileSettings;

        public FileWriter(IOptions<FileSettings> fileSettingsOtions)
        {
            _fileSettings = fileSettingsOtions.Value;
        }

        public async Task WriteAsync(ServiceProviderWeatherResponse weatherResponse, double executionTime)
        {
            string folderPath = string.IsNullOrEmpty(_fileSettings.FolderPath) || !Directory.Exists(_fileSettings.FolderPath)
                ? Directory.GetCurrentDirectory()
                : _fileSettings.FolderPath;
            string fileName = string.IsNullOrEmpty(_fileSettings.FileName)
                ? DefaultFileName
                : _fileSettings.FileName;

            string fullPath = Path.Combine(folderPath, fileName);

            await using (StreamWriter streamWriter =
                    new StreamWriter(fullPath, true))
            {
                string data = JsonSerializer.Serialize(weatherResponse);

                await streamWriter.WriteLineAsync("Total Execution Time: " + executionTime + ", Data: " + data);
            }
        }
    }
}
