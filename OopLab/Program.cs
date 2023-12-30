using OopLab.DB;
using OopLab.Services;
using OopLab.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OopLab
{
    public class Program
    {
        static void Main(string[] args)
        {

            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            // Встановлюємо кодування консолі на UTF-8 для підтримки спеціальних символів.
            Console.OutputEncoding = Encoding.UTF8;
            var starterChoose = new StartChooseUI(accountService, gameService);
            starterChoose.Action();
        }

    }
}
