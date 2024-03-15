using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.Menus
{
    // Logic for displaying the categories menu
    internal class CategoriesMenu
    {
        public static void DisplayCategoriesMenu(CategoryModel[] categories)
        {
            Table table = new();
            _ = table.AddColumn("Categories");
            foreach (CategoryModel category in categories)
            {
                _ = table.AddRow(category.StrCategory);
            }
            AnsiConsole.Write(table);
        }
    }
}
