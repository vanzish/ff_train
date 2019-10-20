using Microsoft.EntityFrameworkCore;
using Railways.Entities;
using System;

namespace Railways.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Cities

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Москва", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 3) },
                new City { Id = 2, Name = "Кострома", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 3) },
                new City { Id = 3, Name = "Киров", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 3) },
                new City { Id = 4, Name = "Пермь", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 5) },
                new City { Id = 5, Name = "Екатеринбург", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 5) },
                new City { Id = 6, Name = "Тюмень", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 5) },
                new City { Id = 7, Name = "Омск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 6) },
                new City { Id = 8, Name = "Новосибирск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 7) },
                new City { Id = 9, Name = "Красноярск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 7) },
                new City { Id = 10, Name = "Ирутск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 8) },
                new City { Id = 11, Name = "Улан-Удэ", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 8) },
                new City { Id = 12, Name = "Чита", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 9) },
                new City { Id = 13, Name = "Хабаровск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 10) },
                new City { Id = 14, Name = "Уссурийск", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 10) },
                new City { Id = 15, Name = "Владивосток", CityTimeZone = new TimeSpan(TimeSpan.TicksPerHour * 10) });

            #endregion

            #region Stations

            modelBuilder.Entity<Station>().HasData(
                new Station { Id = 1, CityId = 1, Name = "Ярославский вокзал" },
                new Station { Id = 2, CityId = 2, Name = "Вокзал Кострома" },
                new Station { Id = 3, CityId = 3, Name = "Вокзал Киров" },
                new Station { Id = 4, CityId = 4, Name = "Вокзал Пермь - 2" },
                new Station { Id = 5, CityId = 5, Name = "Вокзал Екатеринбург" },
                new Station { Id = 6, CityId = 6, Name = "Вокзал Тюмень" },
                new Station { Id = 7, CityId = 7, Name = "Вокзал Омск" },
                new Station { Id = 8, CityId = 8, Name = "Вокзал Новосибирск-Главный" },
                new Station { Id = 9, CityId = 9, Name = "Вокзал Красноярск" },
                new Station { Id = 10, CityId = 10, Name = "Вокзал Иркутск-Пассажирский" },
                new Station { Id = 11, CityId = 11, Name = "Вокзал Улан-Удэ" },
                new Station { Id = 12, CityId = 12, Name = "Вокзал Чита-2" },
                new Station { Id = 13, CityId = 13, Name = "Вокзал Хабаровск-1" },
                new Station { Id = 14, CityId = 14, Name = "Вокзал Уссурийск" },
                new Station { Id = 15, CityId = 15, Name = "Вокзал Владивосток" });

            #endregion

            modelBuilder.Entity<Route>().HasData(
                new Route { Id = 1, Name = "Москва - Владивосток" });

            #region RoutePoints

            modelBuilder.Entity<RoutePoint>().HasData(
                new RoutePoint
                    { Id = 1, RouteId = 1, StationId = 1, ArrivalOffset = TimeSpan.Zero, DepartureOffset = TimeSpan.Zero },
                // time in run 5 ч 57 м, wait time 52 м
                new RoutePoint
                {
                    Id = 2, RouteId = 1, StationId = 2,
                    ArrivalOffset = new TimeSpan(TimeSpan.TicksPerHour * 5 + TimeSpan.TicksPerMinute * 57),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerHour * 5 + TimeSpan.TicksPerMinute * (57 + 52))
                },
                // time in run 17 ч 37 м, wait time 20 м
                new RoutePoint
                {
                    Id = 3, RouteId = 1, StationId = 3,
                    ArrivalOffset = new TimeSpan(TimeSpan.TicksPerHour * 17 + TimeSpan.TicksPerMinute * 37),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerHour * 17 + TimeSpan.TicksPerMinute * (37 + 20))
                },
                // time in run 1 д 2 ч 45 м, wait time 20 м
                new RoutePoint
                {
                    Id = 4, RouteId = 1, StationId = 4,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 2 + TimeSpan.TicksPerMinute * 45),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 2 +
                                                   TimeSpan.TicksPerMinute * (45 + 20))
                },
                // time in run 1 д 8 ч 41 м, wait time 54 м
                new RoutePoint
                {
                    Id = 5, RouteId = 1, StationId = 5,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 8 + TimeSpan.TicksPerMinute * 41),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 8 +
                                                   TimeSpan.TicksPerMinute * (41 + 54))
                },
                // time in run 	1 д 14 ч 32 м, wait time 20 м
                new RoutePoint
                {
                    Id = 6, RouteId = 1, StationId = 6,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 14 + TimeSpan.TicksPerMinute * 32),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 14 +
                                                   TimeSpan.TicksPerMinute * (32 + 20))
                },
                // time in run 1 д 22 ч 41 м, wait time 16 м
                new RoutePoint
                {
                    Id = 7, RouteId = 1, StationId = 7,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 22 + TimeSpan.TicksPerMinute * 41),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 1 + TimeSpan.TicksPerHour * 22 +
                                                   TimeSpan.TicksPerMinute * (41 + 16))
                },
                // time in run 2 д 7 ч 11 м, wait time 56 м
                new RoutePoint
                {
                    Id = 8, RouteId = 1, StationId = 8,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 2 + TimeSpan.TicksPerHour * 7 + TimeSpan.TicksPerMinute * 11),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 2 + TimeSpan.TicksPerHour * 7 +
                                                   TimeSpan.TicksPerMinute * (11 + 56))
                },
                // time in run 	2 д 19 ч 46 м, wait time 35 м
                new RoutePoint
                {
                    Id = 9, RouteId = 1, StationId = 9,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 2 + TimeSpan.TicksPerHour * 19 + TimeSpan.TicksPerMinute * 46),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 2 + TimeSpan.TicksPerHour * 19 +
                                                   TimeSpan.TicksPerMinute * (46 + 35))
                },
                // time in run 	3 д 14 ч 56 м, wait time 35 м
                new RoutePoint
                {
                    Id = 10, RouteId = 1, StationId = 10,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 3 + TimeSpan.TicksPerHour * 14 + TimeSpan.TicksPerMinute * 56),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 3 + TimeSpan.TicksPerHour * 14 +
                                                   TimeSpan.TicksPerMinute * (56 + 35))
                },
                // time in run 	3 д 23 ч 11 м, wait time 30 м
                new RoutePoint
                {
                    Id = 11, RouteId = 1, StationId = 11,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 3 + TimeSpan.TicksPerHour * 23 + TimeSpan.TicksPerMinute * 11),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 3 + TimeSpan.TicksPerHour * 23 +
                                                   TimeSpan.TicksPerMinute * (11 + 30))
                },
                // time in run 	4 д 10 ч 18 м, wait time 36 м
                new RoutePoint
                {
                    Id = 12, RouteId = 1, StationId = 12,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 4 + TimeSpan.TicksPerHour * 10 + TimeSpan.TicksPerMinute * 18),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 4 + TimeSpan.TicksPerHour * 10 +
                                                   TimeSpan.TicksPerMinute * (18 + 36))
                },
                // time in run 	6 д 7 ч 45 м, wait time 1 ч 10 м
                new RoutePoint
                {
                    Id = 13, RouteId = 1, StationId = 13,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 7 + TimeSpan.TicksPerMinute * 45),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * (7 + 1) +
                                                   TimeSpan.TicksPerMinute * (45 + 10))
                },
                // time in run 	6 д 20 ч 8 м, wait time 19 м
                new RoutePoint
                {
                    Id = 14, RouteId = 1, StationId = 14,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 20 + TimeSpan.TicksPerMinute * 8),
                    DepartureOffset = new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * (20) +
                                                   TimeSpan.TicksPerMinute * (8 + 19))
                },
                // time in run 	6 д 22 ч 28 м, wait time 19 м
                new RoutePoint
                {
                    Id = 15, RouteId = 1, StationId = 15,
                    ArrivalOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 22 + TimeSpan.TicksPerMinute * 28),
                    DepartureOffset =
                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * (22) + TimeSpan.TicksPerMinute * (28))
                }
            );

            #endregion

            #region SeatTypes

            modelBuilder.Entity<SeatType>().HasData(
                new SeatType { Id = 1, Position = SeatPositionEnum.Bottom, IsOutboard = true },
                new SeatType { Id = 2, Position = SeatPositionEnum.Top, IsOutboard = true },
                new SeatType { Id = 3, Position = SeatPositionEnum.Bottom, IsOutboard = false },
                new SeatType { Id = 4, Position = SeatPositionEnum.Top, IsOutboard = false });

            #endregion

            #region Seats

            modelBuilder.Entity<Seat>().HasData(
                new Seat { Id = 1, SeatTypeId = 1, CarriageId = 1, Number = 1 },
                new Seat { Id = 2, SeatTypeId = 2, CarriageId = 1, Number = 2 },
                new Seat { Id = 3, SeatTypeId = 3, CarriageId = 1, Number = 3 },
                new Seat { Id = 4, SeatTypeId = 4, CarriageId = 1, Number = 4 },
                new Seat { Id = 5, SeatTypeId = 1, CarriageId = 1, Number = 5 },
                new Seat { Id = 6, SeatTypeId = 2, CarriageId = 1, Number = 6 },
                new Seat { Id = 7, SeatTypeId = 3, CarriageId = 1, Number = 7 },
                new Seat { Id = 8, SeatTypeId = 4, CarriageId = 1, Number = 8 },
                new Seat { Id = 9, SeatTypeId = 1, CarriageId = 2, Number = 1 },
                new Seat { Id = 10, SeatTypeId = 2, CarriageId = 2, Number = 2 },
                new Seat { Id = 11, SeatTypeId = 3, CarriageId = 2, Number = 3 },
                new Seat { Id = 12, SeatTypeId = 4, CarriageId = 2, Number = 4 },
                new Seat { Id = 13, SeatTypeId = 1, CarriageId = 2, Number = 5 },
                new Seat { Id = 14, SeatTypeId = 2, CarriageId = 2, Number = 6 },
                new Seat { Id = 15, SeatTypeId = 3, CarriageId = 2, Number = 7 },
                new Seat { Id = 16, SeatTypeId = 4, CarriageId = 2, Number = 8 }
            );

            #endregion

            #region Carriages

            modelBuilder.Entity<Carriage>().HasData(
                new Carriage { Id = 1, Number = 2, TrainId = 1 },
                new Carriage { Id = 2, Number = 3, TrainId = 1 }
            );

            #endregion

            #region Trains

            modelBuilder.Entity<Train>().HasData(
                new Train { Id = 1, Number = "25AT" }
            );

            #endregion

            modelBuilder.Entity<Run>().HasData(new Run
            {
                Id = 1, TrainId = 1, RouteId = 1, RunTime = new DateTime(2019, 10, 24, 0, 35, 0)
            });

            #region Tickets

            modelBuilder.Entity<Ticket>().HasData(new Ticket
                                                  {
                                                      Id = 1,
                                                      RunId = 1,
                                                      PassengerName = "Passenger First",
                                                      ArrivalRoutePointId = 1,
                                                      DepartureRoutePointId = 15,
                                                      DepartureDateTime =
                                                          new DateTime(2019, 10, 24, 0, 35, 0),
                                                      ArrivalDateTime = new DateTime(2019, 10, 24, 0, 35, 0) +
                                                                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 22 +
                                                                                     TimeSpan.TicksPerMinute * 28),
                                                      SeatId = 1, HasLinen = true, IsPurchased = true
                                                  },
                                                  new Ticket
                                                  {
                                                      Id = 2,
                                                      RunId = 1,
                                                      ArrivalRoutePointId = 1,
                                                      PassengerName = "Passenger Second",
                                                      DepartureRoutePointId = 15,
                                                      DepartureDateTime =
                                                          new DateTime(2019, 10, 24, 0, 35, 0),
                                                      ArrivalDateTime = new DateTime(2019, 10, 24, 0, 35, 0) +
                                                                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 22 +
                                                                                     TimeSpan.TicksPerMinute * 28),
                                                      SeatId = 2,
                                                      HasLinen = true,
                                                      IsPurchased = true
                                                  }, new Ticket
                                                  {
                                                      Id = 3,
                                                      RunId = 1,
                                                      PassengerName = "Passenger Third",
                                                      ArrivalRoutePointId = 1,
                                                      DepartureRoutePointId = 15,
                                                      DepartureDateTime =
                                                          new DateTime(2019, 10, 24, 0, 35, 0),
                                                      ArrivalDateTime = new DateTime(2019, 10, 24, 0, 35, 0) +
                                                                        new TimeSpan(TimeSpan.TicksPerDay * 6 + TimeSpan.TicksPerHour * 22 +
                                                                                     TimeSpan.TicksPerMinute * 28),
                                                      SeatId = 3,
                                                      HasLinen = true,
                                                      IsPurchased = true
                                                  });

            #endregion

            modelBuilder.Entity<Configuration>().HasData(new Configuration
            {
                Id = 1, ConfigName = "TicketReservation", CancelReservationOffset = new TimeSpan(1, 0, 0, 0)
            });
        }
    }
}