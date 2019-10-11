using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Railways.Data.Migrations
{
    public partial class _Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CityTimeZone = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Position = table.Column<int>(nullable: false),
                    IsOutboard = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Runs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RunTime = table.Column<DateTime>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runs_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carriages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    TrainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carriages_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArrivalOffset = table.Column<TimeSpan>(nullable: false),
                    DepartureOffset = table.Column<TimeSpan>(nullable: false),
                    RouteId = table.Column<int>(nullable: false),
                    StationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutePoints_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutePoints_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    CarriageId = table.Column<int>(nullable: false),
                    SeatTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Carriages_CarriageId",
                        column: x => x.CarriageId,
                        principalTable: "Carriages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_SeatTypes_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<Guid>(nullable: false),
                    RunId = table.Column<int>(nullable: false),
                    ArrivalRoutePointId = table.Column<int>(nullable: false),
                    DepartureRoutePointId = table.Column<int>(nullable: false),
                    ArrivalDateTime = table.Column<DateTime>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    SeatId = table.Column<int>(nullable: false),
                    HasLinen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_RoutePoints_ArrivalRoutePointId",
                        column: x => x.ArrivalRoutePointId,
                        principalTable: "RoutePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_RoutePoints_DepartureRoutePointId",
                        column: x => x.DepartureRoutePointId,
                        principalTable: "RoutePoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Runs_RunId",
                        column: x => x.RunId,
                        principalTable: "Runs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityTimeZone", "Name" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 3, 0, 0, 0), "Москва" },
                    { 15, new TimeSpan(0, 10, 0, 0, 0), "Владивосток" },
                    { 14, new TimeSpan(0, 10, 0, 0, 0), "Уссурийск" },
                    { 13, new TimeSpan(0, 10, 0, 0, 0), "Хабаровск" },
                    { 12, new TimeSpan(0, 9, 0, 0, 0), "Чита" },
                    { 10, new TimeSpan(0, 8, 0, 0, 0), "Ирутск" },
                    { 9, new TimeSpan(0, 7, 0, 0, 0), "Красноярск" },
                    { 11, new TimeSpan(0, 8, 0, 0, 0), "Улан-Удэ" },
                    { 7, new TimeSpan(0, 6, 0, 0, 0), "Омск" },
                    { 6, new TimeSpan(0, 5, 0, 0, 0), "Тюмень" },
                    { 5, new TimeSpan(0, 5, 0, 0, 0), "Екатеринбург" },
                    { 4, new TimeSpan(0, 5, 0, 0, 0), "Пермь" },
                    { 3, new TimeSpan(0, 3, 0, 0, 0), "Киров" },
                    { 2, new TimeSpan(0, 3, 0, 0, 0), "Кострома" },
                    { 8, new TimeSpan(0, 7, 0, 0, 0), "Новосибирск" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Москва - Владивосток" });

            migrationBuilder.InsertData(
                table: "SeatTypes",
                columns: new[] { "Id", "IsOutboard", "Position" },
                values: new object[,]
                {
                    { 4, false, 0 },
                    { 1, true, 1 },
                    { 2, true, 0 },
                    { 3, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Number" },
                values: new object[] { 1, "25AT" });

            migrationBuilder.InsertData(
                table: "Carriages",
                columns: new[] { "Id", "Number", "TrainId" },
                values: new object[,]
                {
                    { 2, 3, 1 },
                    { 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Runs",
                columns: new[] { "Id", "RouteId", "RunTime" },
                values: new object[] { 1, 1, new DateTime(2019, 10, 24, 0, 35, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 15, 15, "Вокзал Владивосток" },
                    { 14, 14, "Вокзал Уссурийск" },
                    { 13, 13, "Вокзал Хабаровск-1" },
                    { 12, 12, "Вокзал Чита-2" },
                    { 11, 11, "Вокзал Улан-Удэ" },
                    { 10, 10, "Вокзал Иркутск-Пассажирский" },
                    { 9, 9, "Вокзал Красноярск" },
                    { 7, 7, "Вокзал Омск" },
                    { 6, 6, "Вокзал Тюмень" },
                    { 5, 5, "Вокзал Екатеринбург" },
                    { 4, 4, "Вокзал Пермь - 2" },
                    { 3, 3, "Вокзал Киров" },
                    { 2, 2, "Вокзал Кострома" },
                    { 8, 8, "Вокзал Новосибирск-Главный" },
                    { 1, 1, "Ярославский вокзал" }
                });

            migrationBuilder.InsertData(
                table: "RoutePoints",
                columns: new[] { "Id", "ArrivalOffset", "DepartureOffset", "RouteId", "StationId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0), 1, 1 },
                    { 15, new TimeSpan(6, 22, 28, 0, 0), new TimeSpan(6, 22, 28, 0, 0), 1, 15 },
                    { 14, new TimeSpan(6, 20, 8, 0, 0), new TimeSpan(6, 20, 27, 0, 0), 1, 14 },
                    { 13, new TimeSpan(6, 7, 45, 0, 0), new TimeSpan(6, 8, 55, 0, 0), 1, 13 },
                    { 12, new TimeSpan(4, 10, 18, 0, 0), new TimeSpan(4, 10, 54, 0, 0), 1, 12 },
                    { 10, new TimeSpan(3, 14, 56, 0, 0), new TimeSpan(3, 15, 31, 0, 0), 1, 10 },
                    { 9, new TimeSpan(2, 19, 46, 0, 0), new TimeSpan(2, 20, 21, 0, 0), 1, 9 },
                    { 11, new TimeSpan(3, 23, 11, 0, 0), new TimeSpan(3, 23, 41, 0, 0), 1, 11 },
                    { 7, new TimeSpan(1, 22, 41, 0, 0), new TimeSpan(1, 22, 57, 0, 0), 1, 7 },
                    { 6, new TimeSpan(1, 14, 32, 0, 0), new TimeSpan(1, 14, 52, 0, 0), 1, 6 },
                    { 5, new TimeSpan(1, 8, 41, 0, 0), new TimeSpan(1, 9, 35, 0, 0), 1, 5 },
                    { 4, new TimeSpan(1, 2, 45, 0, 0), new TimeSpan(1, 3, 5, 0, 0), 1, 4 },
                    { 3, new TimeSpan(0, 17, 37, 0, 0), new TimeSpan(0, 17, 57, 0, 0), 1, 3 },
                    { 2, new TimeSpan(0, 5, 57, 0, 0), new TimeSpan(0, 6, 49, 0, 0), 1, 2 },
                    { 8, new TimeSpan(2, 7, 11, 0, 0), new TimeSpan(2, 8, 7, 0, 0), 1, 8 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 9, 2, 1, 1 },
                    { 14, 2, 6, 2 },
                    { 13, 2, 5, 1 },
                    { 12, 2, 4, 4 },
                    { 11, 2, 3, 3 },
                    { 10, 2, 2, 2 },
                    { 8, 1, 8, 4 },
                    { 1, 1, 1, 1 },
                    { 6, 1, 6, 2 },
                    { 5, 1, 5, 1 },
                    { 4, 1, 4, 4 },
                    { 3, 1, 3, 3 },
                    { 2, 1, 2, 2 },
                    { 15, 2, 7, 3 },
                    { 7, 1, 7, 3 },
                    { 16, 2, 8, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carriages_TrainId",
                table: "Carriages",
                column: "TrainId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_RouteId",
                table: "RoutePoints",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_StationId",
                table: "RoutePoints",
                column: "StationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runs_RouteId",
                table: "Runs",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CarriageId",
                table: "Seats",
                column: "CarriageId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CityId",
                table: "Stations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ArrivalRoutePointId",
                table: "Tickets",
                column: "ArrivalRoutePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DepartureRoutePointId",
                table: "Tickets",
                column: "DepartureRoutePointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RunId",
                table: "Tickets",
                column: "RunId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "RoutePoints");

            migrationBuilder.DropTable(
                name: "Runs");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Carriages");

            migrationBuilder.DropTable(
                name: "SeatTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
