using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ISeatsService
    {
        Task<IEnumerable<Run>> GetTrainSeats(int runId);
    }
}