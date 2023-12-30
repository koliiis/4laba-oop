using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI.Base
{
    public class EnterRatingUI : IAction
    {
        IGameService _gameService;
        public EnterRatingUI(IGameService gameService) 
        { 
            _gameService = gameService;
        }
        public void Action()
        {
            var game = _gameService.GetById(_gameService.GetAll().Count - 1);
            Console.WriteLine("\n--------------------------------------------------------\n");
            Console.Write("Введіть рейтинг на який граєте: ");
            game.playRating = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (game.playRating < 0)
            {
                Console.WriteLine("Невірне значення. Введіть додатнє число.");
               Action();
            }
            if (game.playRating > game.player1.CurrentRating - 1 || game.playRating > game.player2.CurrentRating - 1)
            {
                Console.WriteLine("У одного з гравців замало рейтингу.");
                Action();
            }
            Console.WriteLine(game.playRating);
            _gameService.Update(game);
        }
    }
}
