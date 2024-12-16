using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPool.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookedRides",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedRides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfferRides",
                columns: table => new
                {
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideValidFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RideValidTill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsRideBooked = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferRides", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "IntermediaryStop",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DBOfferRideOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntermediaryStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntermediaryStop_OfferRides_DBOfferRideOwnerId",
                        column: x => x.DBOfferRideOwnerId,
                        principalTable: "OfferRides",
                        principalColumn: "OwnerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntermediaryStop_DBOfferRideOwnerId",
                table: "IntermediaryStop",
                column: "DBOfferRideOwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedRides");

            migrationBuilder.DropTable(
                name: "IntermediaryStop");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OfferRides");
        }
    }
}
