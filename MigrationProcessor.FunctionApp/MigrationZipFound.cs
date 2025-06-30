using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Extensions.Storage.Blobs;
using Microsoft.Extensions.Logging;

namespace MigrationProcessor.FunctionApp
{
    public class MigrationZipFound
    {
        private readonly ILogger<MigrationZipFound> _logger;

        public MigrationZipFound(ILogger<MigrationZipFound> logger)
        {
            _logger = logger;
        }

        [Function("MigrationZipFound")]
        public void Run([
            BlobTrigger("Migration/{name}", Connection = "MigrationConnection")
        ] byte[] blob, string name)
        {
            _logger.LogInformation($"Blob trigger function processed blob\n Name: {name} \n Size: {blob.Length} Bytes");
        }
    }
} 