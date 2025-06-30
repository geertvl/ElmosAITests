using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using MigrationProcessor.FunctionApp;

namespace MigrationProcessor.FunctionApp.Tests
{
    public class MigrationZipFoundTests
    {
        [Fact]
        public void Run_LogsBlobInformation()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<MigrationZipFound>>();
            var function = new MigrationZipFound(loggerMock.Object);
            var blobName = "test.zip";
            var blobContent = new byte[] { 1, 2, 3, 4, 5 };

            // Act
            function.Run(blobContent, blobName);

            // Assert
            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(blobName) && v.ToString().Contains(blobContent.Length.ToString())),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
} 