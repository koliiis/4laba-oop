using OopLab.DB.Entity;
using OopLab.OopLab.BLL.Accounts;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class ChoosePlayerUI : IAction
    {
        IGameAccountService _accountService;
        public ChoosePlayerUI(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            Console.WriteLine("\nВиберіть акаунт гравця: ");
            Console.WriteLine("1) звичайний акаунт;");
            Console.WriteLine("2) акаунт, у якого змінюється у два рази менше балів;");
            Console.WriteLine("3) акаунт, з серією перемог;\n");
            int temp = Convert.ToInt32(Console.ReadLine());
            var id = _accountService.GetAll().Count();
            if (temp == 1)
            {
                var gameAccount = new GameAccount(_accountService, id);
                _accountService.Create(gameAccount);
            }
            else if (temp == 2)
            {
                var gameAccount = new AccountHalfRating(_accountService, id);
                _accountService.Create(gameAccount);
            }
            else if (temp == 3)
            {
                var gameAccount = new AccountWithStreek(_accountService, id);
                _accountService.Create(gameAccount);
            }
            else 
            {
                Console.WriteLine("\nВведене невірне значення!");
                Action();
            }
        }
    }
}
