using OopLab.OopLab.BLL.Games;
using OopLab.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLab.UI
{
    public class ShowInfoUI : IAction
    {
        IGameAccountService _accountService;
        IGameService _gameService;
        public ShowInfoUI(IGameAccountService accountService, IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Action()
        {
            ChooseGameUI gameUI;
            ChoosePlayerUI playerUI;
            PlayGameUI playGameUI;
            StartGameUI startGameUI;

            gameUI = new ChooseGameUI(_gameService, _accountService);
            playerUI = new ChoosePlayerUI(_accountService);
            playGameUI = new PlayGameUI(_accountService, _gameService);
            startGameUI = new StartGameUI(_accountService, _gameService);

            playerUI.Action();
            playerUI.Action();
            gameUI.Action();
            startGameUI.Action();
            playGameUI.Action();
        }
    }
}
