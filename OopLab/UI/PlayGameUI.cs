using OopLab.OopLab.BLL.Accounts;
using OopLab.Services.Abstract;
using OopLab.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class PlayGameUI
    {
        IGameAccountService _accountService;
        GameAccount _player1;
        GameAccount _player2;
        IGameService _gameService;
        public PlayGameUI(IGameAccountService accountService, IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Action()
        {
            _player1 = _accountService.GetById(_accountService.GetAll().Count - 2);
            _player2 = _accountService.GetById(_accountService.GetAll().Count - 1);

            var game = _gameService.GetById(_gameService.GetAll().Count - 1);
            if (game.Indicator == 0)
            {
                var enterPlayrating = new EnterRatingUI(_gameService);
                enterPlayrating.Action();
            }
            else if (game.Indicator == 1)
            {
                var enterPlayrating = new EnterRatingUI(_gameService);
                enterPlayrating.Action();
                var chooseOnePlayer = new ChooseOnePlayerUI(_gameService);
                chooseOnePlayer.Action();
            }
            else { }
            game = _gameService.GetById(_gameService.GetAll().Count - 1);
            Console.WriteLine(game.Play());
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Хочете зіграти ще одну гру? (Так/Ні): ");
            string playAgainResponse = Console.ReadLine().Trim();

            bool playAgain = true;
            if (!playAgainResponse.Equals("Так", StringComparison.OrdinalIgnoreCase))
            {
                playAgain = false;
            }
            if (playAgain) Action();
        }
    }
}
