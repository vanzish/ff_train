using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Railways.Entities;
using Railways.Entities.DTO;

namespace Railways.Business.Business.Mappers
{
    public class SeatBusyResolver : IValueResolver<Seat, SeatDto, bool>
    {
        public bool Resolve(Seat source, SeatDto destination, bool member, ResolutionContext context)
        {
            return source.Ticket != null;
        }
    }
}