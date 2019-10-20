using AutoMapper;
using Railways.Entities;
using Railways.Entities.DTO;
using Railways.Entities.DTO.Results.Runs;

namespace Railways.Business.Business.Mappers
{
    public class RailwayProfile : Profile
    {
        public RailwayProfile()
        {
            CreateMap<Run, RunDto>();
            CreateMap<Carriage, CarriageDto>();
            CreateMap<Route, RouteDto>();
            CreateMap<Seat, SeatDto>().ForMember(x => x.IsBusy, opt => opt.MapFrom<SeatBusyResolver>());
            CreateMap<SeatType, SeatTypeDto>();
            CreateMap<Train, TrainDto>();
            CreateMap<City, CityDto>();
            CreateMap<RunWithSeats, RunWithSeatsDto>();
            CreateMap<Ticket, TicketDto>().ForMember(x => x.ArrivalRoutePoint, opt => opt.MapFrom<TicketArrivalCityResolver>())
                                          .ForMember(x => x.DepartureRoutePoint, opt => opt.MapFrom<TicketDepartureCityResolver>());
        }
    }
}