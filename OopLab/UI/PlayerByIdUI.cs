using OopLab.OopLab.BLL.Accounts;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class PlayerByIdUI : IAction
    {
        IGameAccountService _accountService;
        int _id;
        public PlayerByIdUI(IGameAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Action()
        {
            Console.Write("Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            _id = id;
            GameAccount acc = _accountService.GetById(_id);
            Console.WriteLine(acc.GetStats()); 
        }
    }
}
