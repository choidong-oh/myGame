using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMaster gameMaster = new GameMaster();
            Player myplayer = new Player(100000);
            Ai ai = new Ai(100000);



            gameMaster.first(myplayer,ai);
            

            while (true)
            {
                gameMaster.gamestart();
                if (gameMaster.gamefinish() == true)
                { 
                    break;
                }
            }














        }
    }
}
