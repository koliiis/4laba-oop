using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopLab.Services.Abstract;

namespace OopLab.OopLab.BLL.Accounts
{
    public class AccountWithStreek : GameAccount
    {
        IGameAccountService _service;
        public AccountWithStreek(IGameAccountService service, int ID, int gamesCount = 0, int indicator = 2) : base(service, ID, gamesCount, indicator)
        {
            _service = service;
            Id = ID;
        }

        public override int PointsCalculate(int rating)
        {
            return rating = rating * (1 + WinStreek);
        }
    }
}
