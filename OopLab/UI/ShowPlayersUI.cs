using OopLab.DB.Entity;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class ShowPlayerUI
    {
        IGameAccountService _accountService;
        public ShowPlayerUI(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            var listAccounts = _accountService.GetAll();
            foreach (var account in listAccounts)
            {
                if (account != null)
                {
                    Console.WriteLine(account.GetStats());
                }
            }
        }
    }
}
