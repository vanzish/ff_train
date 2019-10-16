using System.Threading.Tasks;
using NUnit.Framework;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;

namespace Railways.Tests
{
    [TestFixture]
    public class SeatsApiTests : BaseApiTests
    {
        private const string ApiMethod = "seats";

        [Test]
        public async Task GetAvailableSeats()
        {
            var options = new SeatsOptions() { RunId = 1 };
            var result = await InvokeApi<SeatsResult>(BuildUrl(ApiMethod), "POST", Serialize(options));

            Assert.IsNotEmpty(result.Seats);
        }
    }
}