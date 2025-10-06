using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UOB.Repository.Migrations
{
    /// <inheritdoc />
    public partial class table_change_MemberRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRecords_Books_BookId",
                table: "BorrowRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRecords_Members_MemberId",
                table: "BorrowRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowRecords",
                table: "BorrowRecords");

            migrationBuilder.RenameTable(
                name: "BorrowRecords",
                newName: "MemberRecords");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRecords_MemberId",
                table: "MemberRecords",
                newName: "IX_MemberRecords_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowRecords_BookId",
                table: "MemberRecords",
                newName: "IX_MemberRecords_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberRecords",
                table: "MemberRecords",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c61ed09-34ce-47ef-9635-2c1b54e098c2"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9d4a5683-cf70-4122-9e8c-64b4a5b22867"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a129c1ff-2b7a-46e7-bcf3-18e2ab774f6f"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4859));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c493d6b4-41f0-4e5c-bc88-687c6927b3ce"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e9a8ce3b-9c2b-4dcb-a8ce-1b4fc3b02e5b"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4862));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("4f45b7b6-8c59-4b9a-bf55-88b9c1f08fa3"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 16, 20, 38, 355, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRecords_Books_BookId",
                table: "MemberRecords",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberRecords_Members_MemberId",
                table: "MemberRecords",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberRecords_Books_BookId",
                table: "MemberRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberRecords_Members_MemberId",
                table: "MemberRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberRecords",
                table: "MemberRecords");

            migrationBuilder.RenameTable(
                name: "MemberRecords",
                newName: "BorrowRecords");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRecords_MemberId",
                table: "BorrowRecords",
                newName: "IX_BorrowRecords_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberRecords_BookId",
                table: "BorrowRecords",
                newName: "IX_BorrowRecords_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowRecords",
                table: "BorrowRecords",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c61ed09-34ce-47ef-9635-2c1b54e098c2"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9d4a5683-cf70-4122-9e8c-64b4a5b22867"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(9));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a129c1ff-2b7a-46e7-bcf3-18e2ab774f6f"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c493d6b4-41f0-4e5c-bc88-687c6927b3ce"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 772, DateTimeKind.Utc).AddTicks(9987));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e9a8ce3b-9c2b-4dcb-a8ce-1b4fc3b02e5b"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: new Guid("4f45b7b6-8c59-4b9a-bf55-88b9c1f08fa3"),
                column: "CreatedDate",
                value: new DateTime(2025, 10, 6, 15, 26, 30, 773, DateTimeKind.Utc).AddTicks(133));

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRecords_Books_BookId",
                table: "BorrowRecords",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRecords_Members_MemberId",
                table: "BorrowRecords",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
