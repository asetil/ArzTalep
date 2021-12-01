using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArzTalep.BusinessLayer.Migrations
{
    public partial class baseentitty_upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "RecordDate",
                table: "Campaigns",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Campaigns",
                newName: "UserModified");

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModified",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "MailTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "MailTemplates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "MailTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "MailTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModified",
                table: "MailTemplates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Lookup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Lookup",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Lookup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "Lookup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModified",
                table: "Lookup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Campaigns",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Campaigns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "Campaigns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreated",
                table: "Applicatin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModified",
                table: "Applicatin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileRelations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCreated = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    SortOrder = table.Column<string>(nullable: true),
                    RelationType = table.Column<int>(nullable: false),
                    RelationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileRelations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCreated = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserModified = table.Column<int>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_ProductID",
                table: "Campaigns",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Products_ProductID",
                table: "Campaigns",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Products_ProductID",
                table: "Campaigns");

            migrationBuilder.DropTable(
                name: "FileRelations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_ProductID",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "MailTemplates");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "MailTemplates");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MailTemplates");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "MailTemplates");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "MailTemplates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Lookup");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "UserCreated",
                table: "Applicatin");

            migrationBuilder.DropColumn(
                name: "UserModified",
                table: "Applicatin");

            migrationBuilder.RenameColumn(
                name: "UserModified",
                table: "Campaigns",
                newName: "OwnerID");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Campaigns",
                newName: "RecordDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Lookup",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Campaigns",
                nullable: true);
        }
    }
}
