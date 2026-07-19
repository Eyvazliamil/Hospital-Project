using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.HelperClasses
{
    public class MenuHelper
    {
        public static short ShowMenu(string[] items, string header = "")
        { 
            short selected = 0;
            while (true)
            {
                Console.Clear();
                if (header != "") 
                    ShowHospitalTitle(header); 

                for (short i = 0; i < items.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"  >> {items[i]} <<");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"    {items[i]}");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && selected > 0) selected--;
                if (key.Key == ConsoleKey.DownArrow && selected < items.Length - 1) selected++; 
                if (key.Key == ConsoleKey.Enter) return selected;
            }
        } 

        public static void ShowHospitalTitle(string title = "")
        {
            int width = title.Length + 8;
            if (width < 25) width = 25;

            string border = new string('=', width);
            int padding = (width - title.Length - 2) / 2;
            string paddedTitle = "||" + new string(' ', padding) + title + new string(' ', width - title.Length - 4 - padding) + "||";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(border);
            Console.WriteLine(paddedTitle);
            Console.WriteLine(border);
            Console.ResetColor();
        }

        public static short ShowWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine(@"     █████╗ ███╗   ███╗██╗██╗     ");
            Console.WriteLine(@"    ██╔══██╗████╗ ████║██║██║     ");
            Console.WriteLine(@"    ███████║██╔████╔██║██║██║     ");
            Console.WriteLine(@"    ██╔══██║██║╚██╔╝██║██║██║     ");
            Console.WriteLine(@"    ██║  ██║██║ ╚═╝ ██║██║███████╗");
            Console.WriteLine(@"    ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚══════╝");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"    ██╗  ██╗ ██████╗ ███████╗██████╗ ██╗████████╗ █████╗ ██╗     ");
            Console.WriteLine(@"    ██║  ██║██╔═══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║     ");
            Console.WriteLine(@"    ███████║██║   ██║███████╗██████╔╝██║   ██║   ███████║██║     ");
            Console.WriteLine(@"    ██╔══██║██║   ██║╚════██║██╔═══╝ ██║   ██║   ██╔══██║██║     ");
            Console.WriteLine(@"    ██║  ██║╚██████╔╝███████║██║     ██║   ██║   ██║  ██║███████╗");
            Console.WriteLine(@"    ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝     ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                 Your health is our priority.");
            Console.ResetColor();
            Console.WriteLine();
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

            string[] startMenu = { "Continue...", "Exit" };
            short sm = ShowMenu(startMenu, "");
            return sm;
        }
    }
}
