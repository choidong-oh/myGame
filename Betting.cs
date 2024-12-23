using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Betting
    {
       
        public void basicbetting(Player player,Ai ai, GameMaster master)
        {
            int two = 2;
            //기본금 뺴고, 판돈에 기본금 추가
            player.hasmoney -= master.basicbettingmoney;
            player.playerbettingmoney = master.basicbettingmoney;
            ai.hasmoney -= master.basicbettingmoney;
            ai.playerbettingmoney = master.basicbettingmoney;
            master.totalbettingmoney =master.basicbettingmoney*two;
            Console.WriteLine("master.totalbettingmoney : "+ master.totalbettingmoney);
        }




        //public void bettingname(string answer)
        //{
        //    //예) 하프
        //    if(answer == "half")
        //    {
        //        //앞사람 배팅금 + 전체배팅금/2
        //        player.playerbettingmoney = ai.playerbettingmoney + master.totalbettingmoney;

        //        player.hasmoney -= player.playerbettingmoney;
        //        master.totalbettingmoney += player.playerbettingmoney;
        //    }
        //    else if(answer == "call")
        //    {
        //        //앞사람 배팅금
        //        player.playerbettingmoney = ai.playerbettingmoney;

        //        player.hasmoney -= player.playerbettingmoney;
        //        master.totalbettingmoney += player.playerbettingmoney;
        //    }
        //    else if(answer == "bbing")
        //    {
        //        //기본머니만큼 배팅
        //        player.playerbettingmoney = master.basicbettingmoney;

        //    }
        //    else if (answer == "fold")
        //    {
        //        //die
        //    }
       // }






    }
}
