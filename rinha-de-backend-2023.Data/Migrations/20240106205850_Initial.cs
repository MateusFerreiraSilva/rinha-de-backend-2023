using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rinha_de_backend_2023.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Apelido = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nascimento = table.Column<string>(type: "text", nullable: false),
                    Searchable = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.UniqueConstraint("AK_Pessoas_Apelido", x => x.Apelido);
                    table.CheckConstraint("CK_Pessoas_Nascimento_RegularExpression", "\"Nascimento\" ~ '^(19|20)\\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12]\\d|3[01])$'");
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PessoaTechnology",
                columns: table => new
                {
                    PessoasId = table.Column<string>(type: "text", nullable: false),
                    TechnologiesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTechnology", x => new { x.PessoasId, x.TechnologiesId });
                    table.ForeignKey(
                        name: "FK_PessoaTechnology_Pessoas_PessoasId",
                        column: x => x.PessoasId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaTechnology_Technologies_TechnologiesId",
                        column: x => x.TechnologiesId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaTechnology_TechnologiesId",
                table: "PessoaTechnology",
                column: "TechnologiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PessoaTechnology");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
