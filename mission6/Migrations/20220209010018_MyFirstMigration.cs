using Microsoft.EntityFrameworkCore.Migrations;

namespace mission6.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Categoryid = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskName = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    Categoryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "Categoryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Categoryid", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Categoryid", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 1, 2, false, "2/9", 1, "Mission 6 Project" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Categoryid", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[] { 2, 2, false, "2/10", 2, "Authorization Lab" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_Categoryid",
                table: "Tasks",
                column: "Categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
