using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bidding.Service.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bidding");

            migrationBuilder.CreateSequence(
                name: "propertyseq",
                schema: "bidding",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "BiddingProperty",
                schema: "bidding",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo),
                    Title = table.Column<string>(nullable: false),
                    AskingPrice = table.Column<decimal>(nullable: false),
                    IsBiddingActive = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiddingProperty", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiddingProperty",
                schema: "bidding");

            migrationBuilder.DropSequence(
                name: "propertyseq",
                schema: "bidding");
        }
    }
}
