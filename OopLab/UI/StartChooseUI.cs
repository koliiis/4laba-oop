using OopLab.DB.Entity;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class StartChooseUI : IAction
    {
        ShowPlayerUI showPlayerUI;
        ShowInfoUI showInfoUI;
        IGameAccountService _accountService;
        IGameService _gameService;
        public StartChooseUI(IGameAccountService accountService, IGameService gameService) 
        {
            _accountService= accountService;
            _gameService= gameService;
           
            showPlayerUI = new ShowPlayerUI(_accountService);
            showInfoUI = new ShowInfoUI(_accountService, _gameService);
        }
        public void Action()
        {
            Console.WriteLine("1) почати гру;");
            Console.WriteLine("2) вивести всіх гавців;");
            Console.WriteLine("3) вивести гравця по айді;\n");
            int temp = Convert.ToInt32(Console.ReadLine());

            if (temp == 1)
            {
                showInfoUI.Action();
            }
            else if (temp == 2)
            {
                showPlayerUI.Action();
            }
            else if (temp == 3)
            {
                var showPlayerByIdUI = new PlayerByIdUI(_accountService);
                showPlayerByIdUI.Action();
            }
            else
            {
                Console.WriteLine("\nВведене некоректне значення!");
                Action();
            }
            
            Action();
            
        }
    }
}
