using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryServiceEF.Data.Migrations
{
    public partial class NewField_Trigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER Orders_INSERT
                                    ON Orders
                                    INSTEAD OF INSERT
                                    AS
                                    INSERT INTO Orders (ClientId,ClientNumber,TotalPrice,Date,Status)
                                    SELECT ClientId, ClientNumber, TotalPrice, Date, 'New'
                                    FROM INSERTED");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Manufacturers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER Orders_INSERT");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Manufacturers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
