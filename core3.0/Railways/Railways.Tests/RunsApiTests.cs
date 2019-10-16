using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;

namespace Railways.Tests
{
    [TestFixture]
    public class RunsApiTests : BaseApiTests
    {
        private const string ApiMethod = "runs";

        [Test]
        public async Task RunsApiTests_GetAllRuns()
        {
            var options = new RunsOptions
            {
                DepartureCityId = 1,
                DestinationCityId = 12,
                DepartureDate = new DateTime(2019, 10, 24)
            };
            var result = await InvokeApi<RunsResult>(BuildUrl(ApiMethod), "POST", Serialize(options));

            Assert.IsNotEmpty(result.Runs);
        }

        [Test]
        public async Task RunsApiTests_InvalidParams()
        {
            var options = new RunsOptions();

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                var result = await InvokeApi<RunsResult>(BuildUrl(ApiMethod), "POST", Serialize(options));
            });
            Assert.AreEqual("Request parameters missing or have incorrect format", ex.Message);
        }
    }
}