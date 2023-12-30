using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopLab.OopLab.BLL.Accounts;
using OopLab.OopLab.BLL.Games;
using OopLab.Services.Abstract;

namespace OopLab.OopLab.DAL
{
    public class GameFactory
    {
        public Game CreateGame(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new Game(player1, player2, service);
        }
        public Game CreateGameWithoutRating(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new GameWithoutRating(player1, player2, service);
        }

        public Game CreateGameOnePlayerRating(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new GameOnePlayerRating(player1, player2, service);
        }

    }
}
