using Microsoft.EntityFrameworkCore.Migrations;

namespace RevCookBookASP.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Pieczywo" },
                    { 2, "Nabiał" }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "DishId", "Name", "Time" },
                values: new object[] { 1, "Kanapka z masłem", "2 min" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Name" },
                values: new object[,]
                {
                    { 1, "Chleb" },
                    { 2, "Masło" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "LanguageCode" },
                values: new object[,]
                {
                    { 1, "EN" },
                    { 2, "PL" }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "DishId", "IngredientId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "CategoryId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "DishId", "LanguageId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, "Do a sandwitch" },
                    { 2, 1, 2, "Zrób kanapkę" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumns: new[] { "DishId", "IngredientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "DishId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "LanguageId",
                keyValue: 2);
        }
    }
}
