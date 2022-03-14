using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InExTypes",
                columns: table => new
                {
                    InExTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InExName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InExTypes", x => x.InExTypeID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImageBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InExTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeExpenses_InExTypes_InExTypeID",
                        column: x => x.InExTypeID,
                        principalTable: "InExTypes",
                        principalColumn: "InExTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InExTypes",
                columns: new[] { "InExTypeID", "InExName" },
                values: new object[] { 1, "Gelir" });

            migrationBuilder.InsertData(
                table: "InExTypes",
                columns: new[] { "InExTypeID", "InExName" },
                values: new object[] { 2, "Gider" });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeExpenses_InExTypeID",
                table: "IncomeExpenses",
                column: "InExTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeExpenses");

            migrationBuilder.DropTable(
                name: "InExTypes");
        }
    }
}
