﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace mirror_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    LevelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LevelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "LevelGroups",
                columns: table => new
                {
                    MLevelId = table.Column<int>(nullable: false),
                    MGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelGroups", x => new { x.MGroupId, x.MLevelId });
                    table.ForeignKey(
                        name: "FK_LevelGroups_Groups_MGroupId",
                        column: x => x.MGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelGroups_Levels_MLevelId",
                        column: x => x.MLevelId,
                        principalTable: "Levels",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassroomTitle = table.Column<string>(nullable: true),
                    AccessCode = table.Column<string>(nullable: true),
                    ColorPicker = table.Column<string>(nullable: true),
                    LevelGroupMGroupId = table.Column<int>(nullable: true),
                    LevelGroupMLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ClassroomId);
                    table.ForeignKey(
                        name: "FK_Classrooms_LevelGroups_LevelGroupMGroupId_LevelGroupMLevelId",
                        columns: x => new { x.LevelGroupMGroupId, x.LevelGroupMLevelId },
                        principalTable: "LevelGroups",
                        principalColumns: new[] { "MGroupId", "MLevelId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_LevelGroupMGroupId_LevelGroupMLevelId",
                table: "Classrooms",
                columns: new[] { "LevelGroupMGroupId", "LevelGroupMLevelId" });

            migrationBuilder.CreateIndex(
                name: "IX_LevelGroups_MLevelId",
                table: "LevelGroups",
                column: "MLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "LevelGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
