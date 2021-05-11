using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggingPlatform.Infrastructure.Ef.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Slug);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Slug);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostSlug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TagSlug = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostSlug, x.TagSlug });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostSlug",
                        column: x => x.PostSlug,
                        principalTable: "Posts",
                        principalColumn: "Slug",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagSlug",
                        column: x => x.TagSlug,
                        principalTable: "Tags",
                        principalColumn: "Slug",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Slug", "Body", "Description", "Title" },
                values: new object[,]
                {
                    { "augmented-reality-ios-application", "The app is simple to use, and will help you decide on your best furniture fit.", "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality iOS app.", "Augmented Reality iOS Application" },
                    { "augmented-reality-web-application", "The app is simple to use, and will help you decide on your best furniture fit.", "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality Web app.", "Augmented Reality Web Application" },
                    { "augmented-reality-android-application", "The app is simple to use, and will help you decide on your best furniture fit.", "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality Android app.", "Augmented Reality Android Application" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Slug", "Name" },
                values: new object[,]
                {
                    { "ios", "iOS" },
                    { "awesome", "Awesome" },
                    { "ar", "AR" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostSlug", "TagSlug" },
                values: new object[] { "augmented-reality-ios-application", "ios" });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostSlug", "TagSlug" },
                values: new object[] { "augmented-reality-ios-application", "awesome" });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostSlug", "TagSlug" },
                values: new object[] { "augmented-reality-android-application", "ar" });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagSlug",
                table: "PostTags",
                column: "TagSlug");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
