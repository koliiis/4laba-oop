using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OopLab.OopLab.BLL.Accounts;
using OopLab.Services.Abstract;
using OopLab.UI;
using OopLab.UI.Base;

namespace OopLab.OopLab.BLL.Games
{
    // Клас, що представляє гру між двома гравцями.
    public class Game
    {
        public int Id { get; set; }
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public GameAccount Winner { get; set; }
        public int playRating { get; set; } = 0;
        public IGameService _service { get; set; }
        public int Indicator { get; set; }
        public Game(GameAccount player1, GameAccount player2, IGameService service, int indicator = 0)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
            Indicator = indicator;
        }

        public virtual int getPlayRating(GameAccount player) { return playRating; }
        // Розпочати гру між гравцями.

        public virtual string Play()
        {
            var str = "";
            Random random = new Random();
            int player1Roll = random.Next(1, 7);
            int player2Roll = random.Next(1, 7);
            str += $"{player1.UserName} кинув кубик і випало {player1Roll}\n";
            str += $"{player2.UserName} кинув кубик і випало {player2Roll}\n";
            if (player1Roll > player2Roll)
            {
                player1.WinGame(player2.UserName, this);
                player2.LoseGame(player1.UserName, this);
                Winner = player1;
                _service.Create(this);
                str += $"Переміг {player1.UserName}!\n";
                str += player1.GetStats();
                str += player2.GetStats();
            }
            else if (player1Roll < player2Roll)
            {
                player2.WinGame(player1.UserName, this);
                player1.LoseGame(player2.UserName, this);
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

