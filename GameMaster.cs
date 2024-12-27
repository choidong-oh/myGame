using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyGame
{
    internal class GameMaster
    {
        //기본배팅 => 카드1장분배 => 배팅 => 카드1장분배 => 배팅 => 승판결
        Player player;
        Ai ai;
        Deck deck = new Deck();
        WinnerSystem winnerSystemclass = new WinnerSystem();
        CardIMage cardIMageclass = new CardIMage();  
        public int totalbettingmoney;//판돈
        public int basicbettingmoney = 1000;//기본배팅금
        Betting bettingclass = new Betting();
        public static bool isdraw = false;

        public void testnum()
        { 
            //37 47 49
            player.hascard[0].CardNum = 4;
            player.hascard[0].isGwang = true;
            player.hascard[1].CardNum = 9;
            player.hascard[1].isGwang = true;




            ai.hascard[0].CardNum = 1;
            ai.hascard[0].isGwang = true;
            ai.hascard[1].CardNum = 7;
            ai.hascard[1].isGwang = true;


        }


        public void gamestart()
        {
            while (true)
            {
                //1. 메인창
                showprint();
                deck.shuffledeck();//섞고
                Timedelay(1);

                //2. 기본배팅창
                if (isdraw == false)
                {
                    totalbettingmoney = basicbettingmoney;
                    while (true)
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("기본 배팅 할거면 1번");
                        int.TryParse(Console.ReadLine(), out int a);
                        if (a == 1)
                        {
                            break;
                        }
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("                                             ");
                        Console.SetCursorPosition(0, 27);
                        Console.WriteLine("                                             ");

                    }
                    bettingclass.basicbetting(player, ai, this);
                }
                showprint();
                Timedelay(1);
                



                //3. 1번째 카드분배, 이미지
                deck.AddCard(deck.drawcard(),player);
                deck.AddCard(deck.drawcard(),ai);
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                Timedelay(0.5);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                Timedelay(1);

                //4. 1번째 배팅
                if (bettingclass.playerbettingname(player, ai, this) == 3)//다이시 리겜
                {
                    Betting.staticplayerbettingname = "Fold";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    aiwinprint();
                    Timedelay(5);
                    gamereset();
                    break;
                }
                if (bettingclass.aibettingname(player, ai, this) == 3)//다이시 리겜
                {
                    Betting.staticaibettingname = "Fold";
                    player.hasmoney += totalbettingmoney;
                    showprint();
                    playerwinprint();
                    Timedelay(5);
                    gamereset();
                    break;
                }
                showprint();



                //5. 2번쨰 1장분배, 이미지
                deck.AddCard(deck.drawcard(),player);
                deck.AddCard(deck.drawcard(),ai);

                //족보이름생성
                winnerSystemclass.playerjokbo(ai);
                winnerSystemclass.playerjokbo(player);

                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                cardIMageclass.PlayerCardnumimage2(player.hascard[1].CardNum, player.hascard[1].isGwang);
                Timedelay(0.5);
                cardIMageclass.AiCardnumimage2(ai.hascard[1].CardNum, ai.hascard[1].isGwang);
                Timedelay(1);

                //임의 카드 수정
                testnum();

                //6. 2번쨰 배팅
                if (bettingclass.playerbettingname(player, ai, this) == 3)//다이시 리겜
                {
                    Betting.staticplayerbettingname = "Fold";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    aiwinprint();   
                    Timedelay(3);
                    gamereset();
                    break;
                }
                if (bettingclass.aibettingname(player, ai, this) == 3)//다이시 리겜
                {
                    Betting.staticaibettingname = "Fold";
                    player.hasmoney += totalbettingmoney;
                    showprint();
                    playerwinprint();
                    Timedelay(3);
                    gamereset();
                    break;
                }
                showprint();
                Console.SetCursorPosition(55, 10);
                Console.WriteLine("승리 판결 ing~");
                Timedelay(3);
                bagwinner();
                showprint();
                player.staticjokboname = "";
                ai.staticjokboname = "";
                //draw시 재경기
                if (isdraw == true)
                {
                    break;
                }
                else if(isdraw == false)
                {
                    if (gamefinish() == true)
                    {
                        break;
                    }
                }

                gamereset();
               
            }

            //7.승판결로직 이미지
            player.hascard.Clear();
            ai.hascard.Clear();



        }

        public void aiwinprint()
        {
            //2장의 카드가 있어 족보이름이 있을경우
            if (player.hascard.Count ==2 || ai.hascard.Count == 2)
            {
                Console.SetCursorPosition(55, 10);
                var a = winnerSystemclass.playerjokbo(ai)[0];
            }
            Console.SetCursorPosition(55, 11);
            Console.WriteLine("ai win");
            Timedelay(1.5);
        }
        public void playerwinprint()
        {
            if (player.hascard.Count == 2 || ai.hascard.Count == 2)
            {
                Console.SetCursorPosition(55, 10);
                var a = winnerSystemclass.playerjokbo(player)[0];

            }
            Console.SetCursorPosition(55, 11);
            Console.WriteLine("player win");
            Timedelay(1.5);
        }
        public void drawprint()
        {
            Console.SetCursorPosition(55, 10);
            Console.WriteLine("draw 재경기");
            Timedelay(1.5);
        }


        public void first(Player out1, Ai out2)
        {
            this.ai = out2;
            this.player = out1;
            //main에서 player,ai할당
            //Player myplayer = new Player(51000);
            //Ai ai = new Ai(51000);
        }

        public void fristmainbackground()
        {

            Console.WriteLine("싱글 섯다");
            Console.WriteLine("아무거나 눌르세요");
            Console.ReadLine();
        }

        public void bagwinner()
        {
            if (winnerSystemclass.winner(player, ai) == "playerwin")
            {
                Console.Clear();
                showprint();
                player.hasmoney += totalbettingmoney;
                playerwinprint();
            }
            else if (winnerSystemclass.winner(player, ai) == "aiwin")
            {
                Console.Clear();
                showprint();
                ai.hasmoney += totalbettingmoney;
                aiwinprint();
            }
            else if (winnerSystemclass.winner(player, ai) == "draw")
            {
                Console.Clear();
                showprint();
                drawprint();
                isdraw = true;
            }
            else if (winnerSystemclass.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }
            Timedelay(1.5);

        }


        

        public  bool gamefinish()
        {
            Console.Clear();
            if (ai.hasmoney <= 0)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("playerwin");
                Console.WriteLine("playerhasmoney : " + player.hasmoney);
                Console.WriteLine("============================================");
                return true;
            }
            else if (player.hasmoney <= 0)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("ai win");
                Console.WriteLine("aihasmoney : " + ai.hasmoney);
                Console.WriteLine("============================================");
                return true;
            }



            return false;
        }
       
        public void showprint()
        {
            Console.Clear();
            Console.WriteLine("AI");
            Console.Write("aimoney : " + ai.hasmoney);
            Console.WriteLine(" aibettingmoney : " + ai.playerbettingmoney);
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("ai betting : " + Betting.staticaibettingname);
            Console.WriteLine("ai jokbo : "+ai.staticjokboname);
            Console.SetCursorPosition(8, 8);
            Console.WriteLine(">ai카드");
            Console.SetCursorPosition(8, 13);
            Console.Write("판돈 : $" + totalbettingmoney );
            Console.SetCursorPosition(8, 18);
            Console.WriteLine(">player카드");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("player jokbo : " + player.staticjokboname);
            Console.WriteLine("player betting : " + Betting.staticplayerbettingname);
            Console.WriteLine("=============================");
            Console.WriteLine("Player");
            Console.Write("playermoney : " + player.hasmoney);
            Console.WriteLine(" playerbettingmoney : " + player.playerbettingmoney);


        }

        //~초 기달림
        public static void Timedelay(double second)
        {
            Stopwatch watch = new Stopwatch();
            //시간=0
            watch.Start();
            //시간적 여유
            while (true)
            {
                if (watch.ElapsedMilliseconds >= 1000 * second)
                {
                    watch.Restart();
                    break;
                }
            }
        }

        //게임리셋//드로우 제외
        public void gamereset()
        {
            Console.Clear();
            //판돈 초기화
            player.playerbettingmoney = 0;
            ai.playerbettingmoney = 0;
            totalbettingmoney = 0;
            //가지고있는 카드 초기화
            player.hascard.Clear();
            ai.hascard.Clear();
            isdraw = false;
            Betting.staticplayerbettingname = "";
            Betting.staticaibettingname = "";
            player.staticjokboname = "";
            ai.staticjokboname = "";
            Console.Clear();
        }

    }
}
