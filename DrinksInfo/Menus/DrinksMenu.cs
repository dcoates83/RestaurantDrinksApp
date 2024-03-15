using DrinksInfo.Models;
using Spectre.Console;

namespace DrinksInfo.Menus
{
    // Logic for displaying the drinks menu after a category is selected
    public class DrinksMenu
    {
        public static void DisplayDrinksMenu(DrinksModel[] drinks)
        {
            Table table = new();
            _ = table.AddColumn("Drinks");
            foreach (DrinksModel drink in drinks)
            {
                _ = table.AddRow(drink.StrDrink);
            }
            AnsiConsole.Write(table);

        }
    }
}
