using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileConverter.DatabaseProvider.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TpepPickupDatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TpepDropoffDatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PULocationID = table.Column<int>(type: "integer", nullable: false),
                    DOLocationID = table.Column<int>(type: "integer", nullable: false),
                    FareAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TipAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PassengerCount = table.Column<int>(type: "integer", nullable: false),
                    TripDistance = table.Column<double>(type: "double precision", nullable: false),
                    StoreAndFwdFlag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
