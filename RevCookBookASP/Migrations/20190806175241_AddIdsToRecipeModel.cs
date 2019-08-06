using Microsoft.EntityFrameworkCore.Migrations;

namespace RevCookBookASP.Migrations
{
    public partial class AddIdsToRecipeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Dishes_DishId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Languages_LanguageId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Dishes_DishId",
                table: "Recipes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Languages_LanguageId",
                table: "Recipes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Dishes_DishId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Languages_LanguageId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DishId",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Dishes_DishId",
                table: "Recipes",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Languages_LanguageId",
                table: "Recipes",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
