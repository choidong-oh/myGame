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
            //사이드팟, 시간상 각각의족보이름
            GameMaster gameMaster = new GameMaster();
            Player myplayer = new Player(100000);
            Ai ai = new Ai(100000);


            gameMaster.first(myplayer,ai);//player,ai의 값을 할당
            gameMaster.fristmainbackground();
            while (true)
            {
                gameMaster.gamestart();

                if (GameMaster.isdraw == false)
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
