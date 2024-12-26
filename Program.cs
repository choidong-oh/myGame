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

            //draw나올시 ,올인나올시, 이미지

            gameMaster.first(myplayer,ai);

            gameMaster.fristmainbackground();
            while (true)
            {
                gameMaster.gamestart();
                if (GameMaster.isdraw == true)
                {

                }
                else if (GameMaster.isdraw == false)
                {
                    if (gameMaster.gamefinish() == true)
                    {
                        break;
                    }
                }
            }














        }
    }
}
