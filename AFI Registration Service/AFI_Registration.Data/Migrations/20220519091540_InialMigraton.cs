using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AFI_Registration.Data.Migrations
{
    public partial class InialMigraton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "CustomerId",
                schema: "shared",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "PolicyHolderDetails",
                columns: table => new
                {
                    PolicyHolderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR shared.CustomerId")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHolderDetails", x => x.PolicyHolderDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyHolderDetails");

            migrationBuilder.DropSequence(
                name: "CustomerId",
                schema: "shared");
        }
    }
}
