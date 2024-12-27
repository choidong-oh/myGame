using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class WinnerSystem
    {
        //player,ai 마다 족보점수를 반환하고 
        //족보점수로 비교후 string형으로 반환(playerwin, aiwin, draw)

        public List<int> playerjokbo(Player player)
        {
            List<int> jokboarray = new List<int>();
            var has1 = player.hascard[0];
            var has2 = player.hascard[1];
            jokboarray.Clear();//혹시 모를 가지고있는거 초기화
            //특수규칙 jokboarray[1] = 땡잡이1 ,암행어사2, 멍텅구리3
            if (has1.isGwang == true && has1.CardNum == 3&&has2.isGwang ==true&&has2.CardNum==8)
            {
                jokboarray.Add(1001);
                jokboarray.Add(0);
                player.staticjokboname = "38광땡";
                Console.WriteLine("38광땡");
                return jokboarray;
            }
            else if (has1.isGwang == true && has1.CardNum == 1 && has2.isGwang == true && has2.CardNum == 3)
            {
                jokboarray.Add(951);
                jokboarray.Add(0);
                player.staticjokboname = "13광땡";
                Console.WriteLine("13광땡");
                return jokboarray;

            }
            else if (has1.isGwang == true && has1.CardNum == 1 && has2.isGwang == true && has2.CardNum == 8)
            {
                jokboarray.Add(951);
                jokboarray.Add(0);
                player.staticjokboname = "18광땡";
                Console.WriteLine("18광땡");
                return jokboarray;

            }

            //떙
            else if(has1.CardNum ==10 &&has2.CardNum == 10)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "장땡";
                Console.WriteLine("장땡");
                return jokboarray;
            }
            else if (has1.CardNum == 9 && has2.CardNum == 9)
            {
                jokboarray.Add(100 + has1.CardNum *10);
                jokboarray.Add(0);
                player.staticjokboname = "9땡";
                Console.WriteLine("9땡");
                return jokboarray;
            }

            else if (has1.CardNum == 8 && has2.CardNum == 8)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "8땡";
                Console.WriteLine("8땡");
                return jokboarray;
            }

            else if (has1.CardNum == 7 && has2.CardNum == 7)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "7땡";
                Console.WriteLine("7땡");
                return jokboarray;
            }

            else if (has1.CardNum == 6 && has2.CardNum == 6)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "6땡";
                Console.WriteLine("6땡");
                return jokboarray;
            }

            else if (has1.CardNum == 5 && has2.CardNum == 5)
            {
                jokboarray.Add(100 + has1.CardNum*10 );
                jokboarray.Add(0);
                player.staticjokboname = "5땡";
                Console.WriteLine("5땡");
                return jokboarray;
            }
            else if (has1.CardNum == 4 && has2.CardNum == 4)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "4땡";
                Console.WriteLine("4땡");
                return jokboarray;
            }
            else if (has1.CardNum == 3 && has2.CardNum == 3)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "3땡";
                Console.WriteLine("3땡");
                return jokboarray;
            }
            else if (has1.CardNum == 2 && has2.CardNum == 2)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "2땡";
                Console.WriteLine("2땡");
                return jokboarray;
            }
            else if (has1.CardNum == 1 && has2.CardNum == 1)
            {
                jokboarray.Add(100 + has1.CardNum * 10);
                jokboarray.Add(0);
                player.staticjokboname = "1땡";
                Console.WriteLine("1땡");
                return jokboarray;//110
            }
           

            //
            else if (has1.CardNum == 1 && has2.CardNum == 2)
            {
                jokboarray.Add(56);
                jokboarray.Add(0);
                player.staticjokboname = "알리";
                Console.WriteLine("알리");
                return jokboarray;
            }
            else if (has1.CardNum == 1 && has2.CardNum == 4)
            {
                jokboarray.Add(55);
                jokboarray.Add(0);
                player.staticjokboname = "독사";
                Console.WriteLine("독사");
                return jokboarray;
            }
             else if (has1.CardNum == 1 && has2.CardNum == 9)
            {
                jokboarray.Add(54);
                jokboarray.Add(0);
                player.staticjokboname = "구삥";
                Console.WriteLine("구삥");
                return jokboarray;
            }
             else if (has1.CardNum == 1 && has2.CardNum == 10)
            {
                jokboarray.Add(53);
                jokboarray.Add(0);
                player.staticjokboname = "장삥";
                Console.WriteLine("장삥");
                return jokboarray;
            }
            else if (has1.CardNum == 4 && has2.CardNum == 10)
            {
                jokboarray.Add(52);
                jokboarray.Add(0);
                player.staticjokboname = "장사";
                Console.WriteLine("장사");
                return jokboarray;
            }
            else if (has1.CardNum == 4 && has2.CardNum == 6)
            {
                jokboarray.Add(51);
                jokboarray.Add(0);
                player.staticjokboname = "세륙";
                Console.WriteLine("세륙");
                return jokboarray;
            }

            //특수규칙
            else if (has1.CardNum == 3 && has2.CardNum == 7&&(has1.isGwang==true ||has2.isGwang ==true) )
            {
                //땡일때만 사용 // 0끗
                jokboarray.Add(0);
                jokboarray.Add(1);
                player.staticjokboname = "땡잡이";
                Console.WriteLine("땡잡이");
                return jokboarray;
            }
            
            else if (has1.CardNum == 4 && has2.CardNum == 7)
            {
                //??
                //13,18광떙일때 사용 //1끗
                jokboarray.Add(1);
                jokboarray.Add(2);
                player.staticjokboname = "암행어사";
                Console.WriteLine("암행어사");
                return jokboarray;
            }
            else if (has1.CardNum == 4 && has2.CardNum == 9)
            {
                //??
                //구땡이하 재경기
                jokboarray.Add(3);
                jokboarray.Add(3);
                player.staticjokboname = "멍텅구리 구사";
                Console.WriteLine("멍텅구리 구사");
                return jokboarray;
            }

            //끗
            else
            {
                var jokbopoint = has1.CardNum + has2.CardNum;

                //10초과일때 -10 // 17이면 => 7
                if(jokbopoint > 10)
                {
                    jokbopoint -= 10;
                }
                jokboarray.Add((int)jokbopoint);
                jokboarray.Add(0);
                player.staticjokboname = jokbopoint + "끗";
                Console.WriteLine("끗");
                return jokboarray;//7끗17
            }
             return jokboarray;
        }

       

        //족보로 이기는 함수
        public string winner(Player player,Ai ai)
        {
            var playerarray1 = playerjokbo(player)[0];//기본규칙
            var playerarray2 = playerjokbo(player)[1];//특수규칙
            var aiarray1 = playerjokbo(ai)[0];
            var aiarray2 = playerjokbo(ai)[1];
            //특수규칙인경우 아닌경우로 나눔
            if (playerjokbo(player)[1] != 0 || playerjokbo(ai)[1] != 0)//각2번째 요소가 0이아닌 특수규칙인경우
            {

                //player,ai가 떙잡이
                if (playerarray2 == 1)//aijokbo(ai)
                {
                    //반대인경우도 넣어야댐 ai가 이기는경우
                    if (aiarray1 != 200 && aiarray1 % 10 == 0 && aiarray1 != 0)//장땡 아니면서 땡이고 끗아닌
                    {
                        return "playerwin";
                    }
                    else
                    {
                        //49파토
                        if (aiarray2 == 3)
                        {
                            if (aiarray1 < 200)//장땡이하
                            {
                                return "draw";
                            }
                            else
                            {
                                return basicwinner(player, ai);
                            }
                        }
                        else
                        {
                            return basicwinner(player, ai);
                        }
                    }
                }
                else if (aiarray2 == 1)
                {
                    if (playerarray1 !=200 && playerarray1 % 10 == 0 && playerarray1 != 0)//장땡 아니면서 땡이고 끗아닌
                    {
                        return "aiwin";
                    }
                    else
                    {
                        //49파토
                        if (playerarray2 == 3)
                        {
                            if (playerarray1 < 200)//장땡이하
                            {
                                return "draw";
                            }
                            else
                            {
                                return basicwinner(player, ai);
                            }
                        }
                        else
                        {
                            return basicwinner(player, ai);
                        }
                    }
                }

                //player, ai 암행어사
                if (playerarray2 == 2)//aijokbo(ai)
                {
                    if (aiarray1 == 951)//13,18광떙이면
                    {
                        return "playerwin";
                    }
                    //49파토
                    if (aiarray2 == 3)
                    {
                        if (aiarray1 < 200)//장땡이하
                        {
                            return "draw";
                        }
                        else
                        {
                            return basicwinner(player, ai);
                        }
                    }
                    else
                    {
                        return basicwinner(player, ai);
                    }
                }
                else if (aiarray2 == 2)
                {
                    if (playerarray1 == 951)//13,18광떙이면
                    {
                        return "aiwin";
                    }
                    else
                    {
                        //49파토
                        if (playerarray2 == 3)
                        {
                            if (aiarray1 < 200)//장땡이하
                            {
                                return "draw";
                            }
                            else
                            {
                                return basicwinner(player, ai);
                            }
                        }
                        else
                        {
                            return basicwinner(player, ai);
                        }
                    }
                }

                //player,ai 멍텅구리
                if (playerarray2 == 3)//aijokbo(ai)
                {
                    if (aiarray1 < 200)//장땡이하
                    {
                        return "draw";
                    }
                    else
                    {
                        return basicwinner(player, ai);
                    }
                }
                else if (aiarray2 == 3)
                {
                    if (playerarray1 < 200)//장땡이하
                    {
                        return "draw";
                    }
                    else
                    {
                        return basicwinner(player, ai);
                    }
                }

            }

            else if (playerarray2 == 0)//&& ai ==0도 추가할거임
            {
                return basicwinner(player,ai);
            }
            return "null";
        }

        public string basicwinner(Player player, Ai ai)
        {
            if (playerjokbo(player)[0] > playerjokbo(ai)[0])
            {
                return "playerwin";
            }
            else if (playerjokbo(player)[0] < playerjokbo(ai)[0])
            {
                return "aiwin";
            }
            else if (playerjokbo(player)[0] == playerjokbo(ai)[0])
            {
                return "draw";
            }

            return "null";

        }
    }
}
