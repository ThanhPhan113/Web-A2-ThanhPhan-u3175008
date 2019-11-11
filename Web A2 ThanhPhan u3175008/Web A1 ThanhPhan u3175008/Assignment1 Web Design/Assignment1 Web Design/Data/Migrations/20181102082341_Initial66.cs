using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assignment1_Web_Design.Data.Migrations
{
    public partial class Initial66 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmergingTechFB",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agree = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Disagree = table.Column<int>(nullable: false),
                    EmergingTechnologyName = table.Column<string>(nullable: true),
                    FeedBack = table.Column<string>(nullable: false),
                    Heading = table.Column<string>(nullable: false),
                    StarRating = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    isAgreeAdded = table.Column<bool>(nullable: false),
                    isDisagreeAdded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergingTechFB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmergingTechFB");
        }
    }
}
