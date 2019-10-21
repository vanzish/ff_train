using Railways.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Railways.Data.Interfaces
{
    public interface ISeatsService
    {
        Task<Run> GetTrainSeats(int runId);
    }
}