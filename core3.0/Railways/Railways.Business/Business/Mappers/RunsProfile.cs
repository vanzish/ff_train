using AutoMapper;
using Railways.Entities;
using Railways.Entities.DTO;
using Railways.Entities.DTO.Results.Runs;

namespace Railways.Business.Business.Mappers
{
    public class RunsProfile : Profile
    {
        public RunsProfile()
        {
            CreateMap<Run, RunDto>();
            CreateMap<Carriage, CarriageDto>();
            CreateMap<Route, RouteDto>();
            CreateMap<Seat, SeatDto>();
            CreateMap<SeatType, SeatTypeDto>();
            CreateMap<Train, TrainDto>();
            CreateMap<RunWithSeats, RunWithSeatsDto>();
        }
    }
}