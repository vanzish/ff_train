using NUnit.Framework;
using Railways.Entities.DTO.Options;
using Railways.Entities.DTO.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Tests
{
    [TestFixture]
    public class TicketsApiTests : BaseApiTests
    {
        private const string ApiMethod = "tickets";

        [Test]
        public async Task GetAvailableTickets()
        {
            var options = new TicketsOptions
            {
                RunId = 1,
                PassengersData = new List<Passenger>()
                    { new Passenger() { SeatId = 4, FullName = "First" }, new Passenger() { SeatId = 5, FullName = "Second" } },
                DepartureCityId = 3, ArrivalCityId = 5
            };
            var result = await InvokeApi<TicketsResult>(BuildUrl(ApiMethod), "POST", Serialize(options));

            Assert.IsNotEmpty(result.Tickets);
        }
    }
}