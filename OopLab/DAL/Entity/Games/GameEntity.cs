using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopLab.OopLab.BLL.Accounts;

namespace OopLab.DB.Entity.Games
{
    public class GameEntity
    {
        public int Id { get; set; }
        public GameAccount Player1 { get; set; }
        public GameAccount Player2 { get; set; }
        public int PlayRating { get; set; }
        public int Indicator { get; set; }
    }
}
