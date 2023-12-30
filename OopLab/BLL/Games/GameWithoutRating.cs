using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopLab;
using OopLab.OopLab.BLL.Accounts;
using OopLab.Services.Abstract;
using OopLab.UI;

namespace OopLab.OopLab.BLL.Games
{
    public class GameWithoutRating : Game
    {
        public GameWithoutRating(GameAccount player1, GameAccount player2, IGameService service, int indicator = 2) : base(player1, player2, service, indicator)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        override public string Play()
        {
            var str = "";
            playRating = 0;
            player1.CurrentRating = 0;
            player2.CurrentRating = 0;
            // Симуляція кидання кубиків і визначення переможця.
            Random random = new Random();
            int player1Roll = random.Next(1, 7);
            int player2Roll = random.Next(1, 7);
            str += $"{player1.UserName} кинув кубик і отримав {player1Roll}\n";
            str += $"{player2.UserName} кинув кубик і отримав {player2Roll}\n";

            if (player1Roll > player2Roll)
            {
                player1.WinGame(player2.UserName);
                player2.LoseGame(player1.UserName);
                Winner = player1;
                _service.Create(this);
                str += $"Переміг {player1.UserName}!\n";
                str += player1.GetStats();
                str += player2.GetStats();
            }
            else if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.UserName);
                player1.LoseGame(player2.UserName);
                Winner = player2;
                _service.Create(this);
                str += $"Переміг {player2.UserName}!\n";
                str += player1.GetStats();
                str += player2.GetStats();
            }
            else if (player1Roll == player2Roll)
            {
                player1.draw(player2.UserName);
                player2.draw(player1.UserName);
                str += "Нічия";
            }
            return str;
        }
    }
}
