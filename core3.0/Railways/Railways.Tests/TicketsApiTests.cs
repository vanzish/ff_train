using System.Threading.Tasks;
using NUnit.Framework;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;

namespace Railways.Tests
{
    [TestFixture]
    public class TicketsApiTests : BaseApiTests
    {
        private const string ApiMethod = "tickets";

        [Test]
        public async Task GetAvailableSeats()
        {
            var options = new TicketsOptions { RunId = 1, Seats = new[] { 4, 5 }, DepartureCityId = 3, ArrivalCityId = 5 };
            var result = await InvokeApi<TicketsResult>(BuildUrl(ApiMethod), "POST", Serialize(options));

            Assert.IsNotEmpty(result.Tickets);
        }
    }
}