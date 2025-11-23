using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Longheng.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cvfields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    Values = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvfields", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cvtemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cvtemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cvtemplates_users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usertemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usertemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usertemplates_cvtemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "cvtemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usertemplates_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fieldvalues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true),
                    UserTemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fieldvalues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fieldvalues_cvfields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "cvfields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fieldvalues_usertemplates_UserTemplateId",
                        column: x => x.UserTemplateId,
                        principalTable: "usertemplates",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cvtemplates_CreatorId",
                table: "cvtemplates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_fieldvalues_FieldId",
                table: "fieldvalues",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_fieldvalues_UserTemplateId",
                table: "fieldvalues",
                column: "UserTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_usertemplates_TemplateId",
                table: "usertemplates",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_usertemplates_UserId",
                table: "usertemplates",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fieldvalues");

            migrationBuilder.DropTable(
                name: "cvfields");

            migrationBuilder.DropTable(
                name: "usertemplates");

            migrationBuilder.DropTable(
                name: "cvtemplates");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
