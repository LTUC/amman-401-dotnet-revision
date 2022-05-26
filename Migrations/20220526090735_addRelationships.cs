using Microsoft.EntityFrameworkCore.Migrations;

namespace SoundLibrary.Migrations
{
    public partial class addRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Blog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupPerson",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPerson", x => new { x.GroupsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_GroupPerson_Group_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPerson_Person_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_BlogId",
                table: "Post",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_PersonId",
                table: "Blog",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupPerson_PersonsId",
                table: "GroupPerson",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Person_PersonId",
                table: "Blog",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Person_PersonId",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Blog_BlogId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "GroupPerson");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Post_BlogId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Blog_PersonId",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Blog");
        }
    }
}
