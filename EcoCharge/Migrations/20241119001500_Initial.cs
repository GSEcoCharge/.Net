using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoCharge.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GS_BOOKING",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChargingPointId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_BOOKING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_CHARGING_HISTORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChargingPointId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Date = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConsumedEnergy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AvoidedEmissions = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_CHARGING_HISTORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_CHARGING_POINT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ChargingStationId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConnectorType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChargingSpeed = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Availability = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Reservable = table.Column<bool>(type: "BOOLEAN", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_CHARGING_POINT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_CHARGING_POST",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Latitude = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Longitude = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OpenHours = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PaymentMethods = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AvarageRating = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_CHARGING_POST", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_EVALUATION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChargingPostId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rating = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RatingDate = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_EVALUATION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_STOPING_POINT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TravelId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ChargingPointId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Order = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_STOPING_POINT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_TRAVEL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StartPoint = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EndPoint = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RemainingAutonomy = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_TRAVEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProfileImage = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CreatedAt = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LastLocation = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GS_VEHICLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Brand = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Year = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Autonomy = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ConnectorType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GS_VEHICLE", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GS_BOOKING");

            migrationBuilder.DropTable(
                name: "GS_CHARGING_HISTORY");

            migrationBuilder.DropTable(
                name: "GS_CHARGING_POINT");

            migrationBuilder.DropTable(
                name: "GS_CHARGING_POST");

            migrationBuilder.DropTable(
                name: "GS_EVALUATION");

            migrationBuilder.DropTable(
                name: "GS_STOPING_POINT");

            migrationBuilder.DropTable(
                name: "GS_TRAVEL");

            migrationBuilder.DropTable(
                name: "GS_USER");

            migrationBuilder.DropTable(
                name: "GS_VEHICLE");
        }
    }
}
