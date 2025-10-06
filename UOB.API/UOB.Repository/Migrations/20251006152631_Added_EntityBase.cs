using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UOB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Added_EntityBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Members",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BorrowRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BorrowRecords",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BorrowRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Books",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c61ed09-34ce-47ef-9635-2c1b54e098c2"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(8), null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9d4a5683-cf70-4122-9e8c-64b4a5b22867"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(9), null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a129c1ff-2b7a-46e7-bcf3-18e2ab774f6f"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(3), null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c493d6b4-41f0-4e5c-bc88-687c6927b3ce"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 772, DateTimeKind.Utc).AddTicks(9987), null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e9a8ce3b-9c2b-4dcb-a8ce-1b4fc3b02e5b"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(6), null, null });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("4f45b7b6-8c59-4b9a-bf55-88b9c1f08fa3"),
                columns: new[] { "CreatedDate", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(133), null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Books");
        }
    }
}
