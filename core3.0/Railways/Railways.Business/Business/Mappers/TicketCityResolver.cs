using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Railways.Entities;
using Railways.Entities.DTO;

namespace Railways.Business.Business.Mappers
{
    public class TicketArrivalCityResolver : IValueResolver<Ticket, TicketDto, string>
    {
        public string Resolve(Ticket source, TicketDto destination, string member, ResolutionContext context)
        {
            return $"{source.ArrivalRoutePoint.Station.City.Name} - {source.ArrivalRoutePoint.Station.Name}";
        }
    }

    public class TicketDepartureCityResolver : IValueResolver<Ticket, TicketDto, string>
    {
        public string Resolve(Ticket source, TicketDto destination, string member, ResolutionContext context)
        {
            return $"{source.DepartureRoutePoint.Station.City.Name} - {source.DepartureRoutePoint.Station.Name}";
        }
    }
}