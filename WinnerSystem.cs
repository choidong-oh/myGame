using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class WinnerSystem
    {
        Player player;
        Ai ai;

        //player마다 족보를 반환시키고 그거를 넣어서 비교해서 이기는 방향으로
        //족보 생성 반환
        public int playerjokbo(Player player)
        {
            if(player.hascard[0] != player.hascard[1])
            {
                return 50;// "5ttang";
            }


            return 50;// "5ttang";
        }

        //족보 생성 반환
        public int aijokbo(Ai ai)
        {
            if (ai.hascard[0] != ai.hascard[1])
            {
                return 30;// "3ttang";
            }


            return 30;// "3ttang";
        }

        //족보로 이기는 함수
        public string winner(Player player,Ai ai)
        {
            //50
            if(playerjokbo(player) > aijokbo(ai))
            {
                Console.WriteLine("5땡으로 플레이어 윈");
                return "playerwin";
            }
            else if(playerjokbo(player) > aijokbo(ai))
            {
                Console.WriteLine("3땡으로 ai 윈");
                return "aiwin";
            }
            else if(playerjokbo(player) == aijokbo(ai))
            {
                Console.WriteLine("draw");
                return "draw";
            }

            return null;
        }





    }
}
