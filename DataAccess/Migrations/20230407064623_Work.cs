using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Work : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tovari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    Descryption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tovari__3214EC279FF06789", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phonenumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Auth = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC27B0C13CDF", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sklad",
                columns: table => new
                {
                    IDSkalda = table.Column<int>(type: "int", nullable: false),
                    Idtovara = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sklad", x => x.IDSkalda);
                    table.ForeignKey(
                        name: "FK_Sklad_Tovari",
                        column: x => x.Idtovara,
                        principalTable: "Tovari",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__D7CB621FC22E83DA", x => new { x.UserId, x.GoodId });
                    table.ForeignKey(
                        name: "FK__Comments__GoodId__300424B4",
                        column: x => x.GoodId,
                        principalTable: "Tovari",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Comments__UserId__2F10007B",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SavedAdresses",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    House = table.Column<int>(type: "int", nullable: false),
                    Building = table.Column<int>(type: "int", nullable: true),
                    Apartament = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SavedAdr__CD64864A75CB1880", x => new { x.UserId, x.City });
                    table.ForeignKey(
                        name: "FK__SavedAdre__UserI__267ABA7A",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TovariList",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GoodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TovariLi__D7CB621F3DEA98CA", x => new { x.UserId, x.GoodId });
                    table.ForeignKey(
                        name: "FK__TovariLis__GoodI__2C3393D0",
                        column: x => x.GoodId,
                        principalTable: "Tovari",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__TovariLis__UserI__2B3F6F97",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_GoodId",
                table: "Comments",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Sklad_Idtovara",
                table: "Sklad",
                column: "Idtovara");

            migrationBuilder.CreateIndex(
                name: "IX_TovariList_GoodId",
                table: "TovariList",
                column: "GoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SavedAdresses");

            migrationBuilder.DropTable(
                name: "Sklad");

            migrationBuilder.DropTable(
                name: "TovariList");

            migrationBuilder.DropTable(
                name: "Tovari");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
