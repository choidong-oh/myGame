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

            //            메인화면
            //기본배팅
            //카드분배돼면
            //폴드로지는거보여주고
            //콜로 이기는거 보여주고
            //올인을박고
            //다음배팅때 하프를 눌르면안되는거 보여주고
            //콜박고
            //38광떙으로 이기고 마무리

            //추가로멍터구리구사
            //예외처리 땡잡이 보야주면댐


            //사이드팟, ai배팅
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
