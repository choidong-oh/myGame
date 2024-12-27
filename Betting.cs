using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Betting
    {
        public static string staticaibettingname;
        public static string staticplayerbettingname;
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
        public int aibettingname(Player player, Ai ai, GameMaster master)
        {
            Random random = new Random();
            int answer;
            while(true)
            {
                answer = random.Next(1,5);
                if(answer == 3)
                {
                    answer = random.Next(1, 5);
                }
                switch (answer)
                {
                    case 1:
                        if (ai.hasmoney <= player.playerbettingmoney)
                        {
                            //ai 하프 안되는데 함
                            continue;
                        }
                        else if (ai.hasmoney > player.playerbettingmoney)
                        {
                            Console.WriteLine("Half발동");
                            //앞사람 배팅금 + 전체배팅금/2
                            ai.playerbettingmoney = player.playerbettingmoney + master.totalbettingmoney / 2;

                            ai.hasmoney -= ai.playerbettingmoney;
                            master.totalbettingmoney += ai.playerbettingmoney;
                        }
                        staticaibettingname = "Half";
                        break;
                    case 2:
                        //앞사람 배팅금
                        if (ai.hasmoney <= player.playerbettingmoney)
                        {
                            ai.playerbettingmoney =  ai.hasmoney;
                            ai.hasmoney = 0;
                            staticaibettingname = "All In";
                        }
                
                        else if (ai.hasmoney > player.playerbettingmoney)
                        {
                            ai.playerbettingmoney = player.playerbettingmoney;
                            ai.hasmoney -= ai.playerbettingmoney;
                            staticaibettingname = "Call";
                        }

                        master.totalbettingmoney += ai.playerbettingmoney;
                        break;
                    case 3:
                        staticaibettingname = "Fold";
                        break;
                    case 4:
                        ai.playerbettingmoney = ai.hasmoney;
                        ai.hasmoney = 0;
                        master.totalbettingmoney += ai.playerbettingmoney;
                        staticaibettingname = "All In";

                        break;

                }
                break;
            }
            
            return answer;



        }
       




        public int playerbettingname(Player player, Ai ai, GameMaster master)
        {
            int answer;


            while (true)
            {
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("                                                            ");
                Console.WriteLine("배팅 뭐할래? 1번 : Half, 2번 : Call, 3번 : Fold, 4번 : All IN");
                Console.SetCursorPosition(0, 27);
                answer = int.Parse(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        if(staticaibettingname == "All In")
                        {
                            Console.WriteLine("콜,다이 만됌");
                            continue;
                        }
                        else if (player.hasmoney <= ai.playerbettingmoney)
                        {
                            Console.WriteLine("배팅할 돈이 안됩니다. 다시 선택 해주세요");
                            GameMaster.Timedelay(2);
                            continue;
                        }
                        else if (player.hasmoney > ai.playerbettingmoney)
                        {

                            Console.WriteLine("Half발동");
                            //앞사람 배팅금 + 전체배팅금/2
                            player.playerbettingmoney = ai.playerbettingmoney + master.totalbettingmoney / 2;

                            player.hasmoney -= player.playerbettingmoney;
                            master.totalbettingmoney += player.playerbettingmoney;
                        }
                        staticplayerbettingname = "Half";
                        break;
                    case 2:
                        Console.WriteLine("Call발동");
                        //앞사람 배팅금
                        if (player.hasmoney <= ai.playerbettingmoney)
                        {
                            player.playerbettingmoney = player.hasmoney;
                            player.hasmoney = 0;
                            staticplayerbettingname = "All In";
                        }
                        else if (player.hasmoney > ai.playerbettingmoney)
                        {
                            player.playerbettingmoney = ai.playerbettingmoney;
                            player.hasmoney -= player.playerbettingmoney;
                            staticplayerbettingname = "Call";
                        }
                        master.totalbettingmoney += player.playerbettingmoney;
                        break;
                    case 3:
                        Console.WriteLine("Fold발동");
                        staticplayerbettingname = "Fold";
                        break;
                    case 4:
                        Console.WriteLine("올인");
                        player.playerbettingmoney = player.hasmoney;
                        player.hasmoney = 0;

                        master.totalbettingmoney += player.playerbettingmoney;
                        staticplayerbettingname = "All In";
                        break;


                }

                break;

            }

            return answer;

        }


    }
}
