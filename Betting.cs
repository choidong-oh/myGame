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
            //기본금 뺴고, 판돈에 기본금 추가
            player.hasmoney -= master.basicbettingmoney;
            player.playerbettingmoney = master.basicbettingmoney;
            ai.hasmoney -= master.basicbettingmoney;
            ai.playerbettingmoney = master.basicbettingmoney;
            master.totalbettingmoney =master.basicbettingmoney*2;
            Console.WriteLine("master.totalbettingmoney : "+ master.totalbettingmoney);
        }
        public void aibettingname(Player player, Ai ai, GameMaster master, string answer)
        {
            switch (answer)
            {
                case "half":
                    Console.WriteLine("half발동");
                    //앞사람 배팅금 + 전체배팅금/2
                    ai.playerbettingmoney = player.playerbettingmoney + master.totalbettingmoney / 2;

                    ai.hasmoney -= ai.playerbettingmoney;
                    master.totalbettingmoney += ai.playerbettingmoney;
                    break;
                case "call":
                    Console.WriteLine("call발동");
                    //앞사람 배팅금
                    ai.playerbettingmoney = player.playerbettingmoney;

                    ai.hasmoney -= ai.playerbettingmoney;
                    master.totalbettingmoney += ai.playerbettingmoney;
                    break;
                case "bbing":
                    Console.WriteLine("bbing발동");
                    //기본머니만큼 배팅
                    ai.playerbettingmoney = master.basicbettingmoney;

                    ai.hasmoney -= ai.playerbettingmoney;
                    master.totalbettingmoney += ai.playerbettingmoney;
                    break;
                case "fold":
                    Console.WriteLine("fold발동");
                    break;

            }




        }





        public void playerbettingname(Player player, Ai ai, GameMaster master, string answer)
        {
            switch (answer)
            {
                case "half":
                    Console.WriteLine("half발동");
                    //앞사람 배팅금 + 전체배팅금/2
                    player.playerbettingmoney = ai.playerbettingmoney + master.totalbettingmoney/2;

                    player.hasmoney -= player.playerbettingmoney;
                    master.totalbettingmoney += player.playerbettingmoney;
                    break;
                case "call":
                    Console.WriteLine("call발동");
                    //앞사람 배팅금
                    player.playerbettingmoney = ai.playerbettingmoney;

                    player.hasmoney -= player.playerbettingmoney;
                    master.totalbettingmoney += player.playerbettingmoney;
                    break;
                case "bbing":
                    Console.WriteLine("bbing발동");
                    //기본머니만큼 배팅
                    player.playerbettingmoney = master.basicbettingmoney;

                    player.hasmoney -= player.playerbettingmoney;
                    master.totalbettingmoney += player.playerbettingmoney;
                    break;
                case "fold":
                    Console.WriteLine("fold발동");
                    break;

            }




        }







    }
}
