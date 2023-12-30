using OopLab.Services;
using OopLab.OopLab.BLL.Accounts;
using OopLab.OopLab.DAL;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class ChooseGameUI : IAction
    {
        IGameService _gameService;
        IGameAccountService _accountService;
        GameAccount _player1;
        GameAccount _player2;

        public ChooseGameUI(IGameService gameService, IGameAccountService accountService)
        {
            _gameService = gameService;
            _accountService = accountService;
        }
        public void Action()
        {
            _player1 = _accountService.GetById(_accountService.GetAll().Count - 2);
            _player2 = _accountService.GetById(_accountService.GetAll().Count - 1);
            Console.WriteLine("\nВиберіть вид гри: ");
            Console.WriteLine("1)гра на рейтинг;");
            Console.WriteLine("2) гра без рейтингу;");
            Console.WriteLine("3) гра, у якій в одного гравця змінюється рейтин;\n");
            int temp = Convert.ToInt32(Console.ReadLine());
            GameFactory gameFactory = new GameFactory();
            if (temp == 1)
                _gameService.Create(gameFactory.CreateGame(_player1, _player2, _gameService));
            else if (temp == 2)
                _gameService.Create(gameFactory.CreateGameWithoutRating(_player1, _player2, _gameService));
            else if (temp == 3)
                _gameService.Create(gameFactory.CreateGameOnePlayerRating(_player1, _player2, _gameService));
            else
            {
                Console.WriteLine("\nВведене неправильне значення!");
                Action();
            }

        }
    }
}
