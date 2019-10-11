﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Railways.Data;

namespace Railways.Data.Migrations
{
    [DbContext(typeof(RailwaysContext))]
    [Migration("20191011152505__Initial")]
    partial class _Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Railways.Entities.Carriage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Carriages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 2,
                            TrainId = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = 3,
                            TrainId = 1
                        });
                });

            modelBuilder.Entity("Railways.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("CityTimeZone")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityTimeZone = new TimeSpan(0, 3, 0, 0, 0),
                            Name = "Москва"
                        },
                        new
                        {
                            Id = 2,
                            CityTimeZone = new TimeSpan(0, 3, 0, 0, 0),
                            Name = "Кострома"
                        },
                        new
                        {
                            Id = 3,
                            CityTimeZone = new TimeSpan(0, 3, 0, 0, 0),
                            Name = "Киров"
                        },
                        new
                        {
                            Id = 4,
                            CityTimeZone = new TimeSpan(0, 5, 0, 0, 0),
                            Name = "Пермь"
                        },
                        new
                        {
                            Id = 5,
                            CityTimeZone = new TimeSpan(0, 5, 0, 0, 0),
                            Name = "Екатеринбург"
                        },
                        new
                        {
                            Id = 6,
                            CityTimeZone = new TimeSpan(0, 5, 0, 0, 0),
                            Name = "Тюмень"
                        },
                        new
                        {
                            Id = 7,
                            CityTimeZone = new TimeSpan(0, 6, 0, 0, 0),
                            Name = "Омск"
                        },
                        new
                        {
                            Id = 8,
                            CityTimeZone = new TimeSpan(0, 7, 0, 0, 0),
                            Name = "Новосибирск"
                        },
                        new
                        {
                            Id = 9,
                            CityTimeZone = new TimeSpan(0, 7, 0, 0, 0),
                            Name = "Красноярск"
                        },
                        new
                        {
                            Id = 10,
                            CityTimeZone = new TimeSpan(0, 8, 0, 0, 0),
                            Name = "Ирутск"
                        },
                        new
                        {
                            Id = 11,
                            CityTimeZone = new TimeSpan(0, 8, 0, 0, 0),
                            Name = "Улан-Удэ"
                        },
                        new
                        {
                            Id = 12,
                            CityTimeZone = new TimeSpan(0, 9, 0, 0, 0),
                            Name = "Чита"
                        },
                        new
                        {
                            Id = 13,
                            CityTimeZone = new TimeSpan(0, 10, 0, 0, 0),
                            Name = "Хабаровск"
                        },
                        new
                        {
                            Id = 14,
                            CityTimeZone = new TimeSpan(0, 10, 0, 0, 0),
                            Name = "Уссурийск"
                        },
                        new
                        {
                            Id = 15,
                            CityTimeZone = new TimeSpan(0, 10, 0, 0, 0),
                            Name = "Владивосток"
                        });
                });

            modelBuilder.Entity("Railways.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Routes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Москва - Владивосток"
                        });
                });

            modelBuilder.Entity("Railways.Entities.RoutePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<TimeSpan>("ArrivalOffset")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("DepartureOffset")
                        .HasColumnType("interval");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.HasIndex("StationId")
                        .IsUnique();

                    b.ToTable("RoutePoints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalOffset = new TimeSpan(0, 0, 0, 0, 0),
                            DepartureOffset = new TimeSpan(0, 0, 0, 0, 0),
                            RouteId = 1,
                            StationId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalOffset = new TimeSpan(0, 5, 57, 0, 0),
                            DepartureOffset = new TimeSpan(0, 6, 49, 0, 0),
                            RouteId = 1,
                            StationId = 2
                        },
                        new
                        {
                            Id = 3,
                            ArrivalOffset = new TimeSpan(0, 17, 37, 0, 0),
                            DepartureOffset = new TimeSpan(0, 17, 57, 0, 0),
                            RouteId = 1,
                            StationId = 3
                        },
                        new
                        {
                            Id = 4,
                            ArrivalOffset = new TimeSpan(1, 2, 45, 0, 0),
                            DepartureOffset = new TimeSpan(1, 3, 5, 0, 0),
                            RouteId = 1,
                            StationId = 4
                        },
                        new
                        {
                            Id = 5,
                            ArrivalOffset = new TimeSpan(1, 8, 41, 0, 0),
                            DepartureOffset = new TimeSpan(1, 9, 35, 0, 0),
                            RouteId = 1,
                            StationId = 5
                        },
                        new
                        {
                            Id = 6,
                            ArrivalOffset = new TimeSpan(1, 14, 32, 0, 0),
                            DepartureOffset = new TimeSpan(1, 14, 52, 0, 0),
                            RouteId = 1,
                            StationId = 6
                        },
                        new
                        {
                            Id = 7,
                            ArrivalOffset = new TimeSpan(1, 22, 41, 0, 0),
                            DepartureOffset = new TimeSpan(1, 22, 57, 0, 0),
                            RouteId = 1,
                            StationId = 7
                        },
                        new
                        {
                            Id = 8,
                            ArrivalOffset = new TimeSpan(2, 7, 11, 0, 0),
                            DepartureOffset = new TimeSpan(2, 8, 7, 0, 0),
                            RouteId = 1,
                            StationId = 8
                        },
                        new
                        {
                            Id = 9,
                            ArrivalOffset = new TimeSpan(2, 19, 46, 0, 0),
                            DepartureOffset = new TimeSpan(2, 20, 21, 0, 0),
                            RouteId = 1,
                            StationId = 9
                        },
                        new
                        {
                            Id = 10,
                            ArrivalOffset = new TimeSpan(3, 14, 56, 0, 0),
                            DepartureOffset = new TimeSpan(3, 15, 31, 0, 0),
                            RouteId = 1,
                            StationId = 10
                        },
                        new
                        {
                            Id = 11,
                            ArrivalOffset = new TimeSpan(3, 23, 11, 0, 0),
                            DepartureOffset = new TimeSpan(3, 23, 41, 0, 0),
                            RouteId = 1,
                            StationId = 11
                        },
                        new
                        {
                            Id = 12,
                            ArrivalOffset = new TimeSpan(4, 10, 18, 0, 0),
                            DepartureOffset = new TimeSpan(4, 10, 54, 0, 0),
                            RouteId = 1,
                            StationId = 12
                        },
                        new
                        {
                            Id = 13,
                            ArrivalOffset = new TimeSpan(6, 7, 45, 0, 0),
                            DepartureOffset = new TimeSpan(6, 8, 55, 0, 0),
                            RouteId = 1,
                            StationId = 13
                        },
                        new
                        {
                            Id = 14,
                            ArrivalOffset = new TimeSpan(6, 20, 8, 0, 0),
                            DepartureOffset = new TimeSpan(6, 20, 27, 0, 0),
                            RouteId = 1,
                            StationId = 14
                        },
                        new
                        {
                            Id = 15,
                            ArrivalOffset = new TimeSpan(6, 22, 28, 0, 0),
                            DepartureOffset = new TimeSpan(6, 22, 28, 0, 0),
                            RouteId = 1,
                            StationId = 15
                        });
                });

            modelBuilder.Entity("Railways.Entities.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RunTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Runs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RouteId = 1,
                            RunTime = new DateTime(2019, 10, 24, 0, 35, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Railways.Entities.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CarriageId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("SeatTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarriageId");

                    b.HasIndex("SeatTypeId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarriageId = 1,
                            Number = 1,
                            SeatTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CarriageId = 1,
                            Number = 2,
                            SeatTypeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CarriageId = 1,
                            Number = 3,
                            SeatTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            CarriageId = 1,
                            Number = 4,
                            SeatTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            CarriageId = 1,
                            Number = 5,
                            SeatTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            CarriageId = 1,
                            Number = 6,
                            SeatTypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            CarriageId = 1,
                            Number = 7,
                            SeatTypeId = 3
                        },
                        new
                        {
                            Id = 8,
                            CarriageId = 1,
                            Number = 8,
                            SeatTypeId = 4
                        },
                        new
                        {
                            Id = 9,
                            CarriageId = 2,
                            Number = 1,
                            SeatTypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            CarriageId = 2,
                            Number = 2,
                            SeatTypeId = 2
                        },
                        new
                        {
                            Id = 11,
                            CarriageId = 2,
                            Number = 3,
                            SeatTypeId = 3
                        },
                        new
                        {
                            Id = 12,
                            CarriageId = 2,
                            Number = 4,
                            SeatTypeId = 4
                        },
                        new
                        {
                            Id = 13,
                            CarriageId = 2,
                            Number = 5,
                            SeatTypeId = 1
                        },
                        new
                        {
                            Id = 14,
                            CarriageId = 2,
                            Number = 6,
                            SeatTypeId = 2
                        },
                        new
                        {
                            Id = 15,
                            CarriageId = 2,
                            Number = 7,
                            SeatTypeId = 3
                        },
                        new
                        {
                            Id = 16,
                            CarriageId = 2,
                            Number = 8,
                            SeatTypeId = 4
                        });
                });

            modelBuilder.Entity("Railways.Entities.SeatType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsOutboard")
                        .HasColumnType("boolean");

                    b.Property<int>("Position")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SeatTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOutboard = true,
                            Position = 1
                        },
                        new
                        {
                            Id = 2,
                            IsOutboard = true,
                            Position = 0
                        },
                        new
                        {
                            Id = 3,
                            IsOutboard = false,
                            Position = 1
                        },
                        new
                        {
                            Id = 4,
                            IsOutboard = false,
                            Position = 0
                        });
                });

            modelBuilder.Entity("Railways.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Ярославский вокзал"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            Name = "Вокзал Кострома"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            Name = "Вокзал Киров"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            Name = "Вокзал Пермь - 2"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            Name = "Вокзал Екатеринбург"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 6,
                            Name = "Вокзал Тюмень"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 7,
                            Name = "Вокзал Омск"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 8,
                            Name = "Вокзал Новосибирск-Главный"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 9,
                            Name = "Вокзал Красноярск"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 10,
                            Name = "Вокзал Иркутск-Пассажирский"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 11,
                            Name = "Вокзал Улан-Удэ"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 12,
                            Name = "Вокзал Чита-2"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 13,
                            Name = "Вокзал Хабаровск-1"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 14,
                            Name = "Вокзал Уссурийск"
                        },
                        new
                        {
                            Id = 15,
                            CityId = 15,
                            Name = "Вокзал Владивосток"
                        });
                });

            modelBuilder.Entity("Railways.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("ArrivalRoutePointId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DepartureRoutePointId")
                        .HasColumnType("integer");

                    b.Property<bool>("HasLinen")
                        .HasColumnType("boolean");

                    b.Property<Guid>("Number")
                        .HasColumnType("uuid");

                    b.Property<int>("RunId")
                        .HasColumnType("integer");

                    b.Property<int>("SeatId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalRoutePointId");

                    b.HasIndex("DepartureRoutePointId");

                    b.HasIndex("RunId");

                    b.HasIndex("SeatId")
                        .IsUnique();

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Railways.Entities.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Trains");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "25AT"
                        });
                });

            modelBuilder.Entity("Railways.Entities.Carriage", b =>
                {
                    b.HasOne("Railways.Entities.Train", "Train")
                        .WithMany("Carriages")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Railways.Entities.RoutePoint", b =>
                {
                    b.HasOne("Railways.Entities.Route", "Route")
                        .WithMany("RoutePoints")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Railways.Entities.Station", "Station")
                        .WithOne("RoutePoint")
                        .HasForeignKey("Railways.Entities.RoutePoint", "StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Railways.Entities.Run", b =>
                {
                    b.HasOne("Railways.Entities.Route", "Route")
                        .WithMany("Runs")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Railways.Entities.Seat", b =>
                {
                    b.HasOne("Railways.Entities.Carriage", "Carriage")
                        .WithMany("Seats")
                        .HasForeignKey("CarriageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Railways.Entities.SeatType", "SeatType")
                        .WithMany("Seats")
                        .HasForeignKey("SeatTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Railways.Entities.Station", b =>
                {
                    b.HasOne("Railways.Entities.City", "City")
                        .WithMany("Stations")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Railways.Entities.Ticket", b =>
                {
                    b.HasOne("Railways.Entities.RoutePoint", "ArrivalRoutePoint")
                        .WithMany("ArrivalTickets")
                        .HasForeignKey("ArrivalRoutePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Railways.Entities.RoutePoint", "DepartureRoutePoint")
                        .WithMany("DepartureTickets")
                        .HasForeignKey("DepartureRoutePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Railways.Entities.Run", "Run")
                        .WithMany()
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Railways.Entities.Seat", "Seat")
                        .WithOne("Ticket")
                        .HasForeignKey("Railways.Entities.Ticket", "SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}