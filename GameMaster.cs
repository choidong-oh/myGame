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
        Card card = new Card(); 
        WinnerSystem winnerSystemclass = new WinnerSystem();
        CardIMage cardIMageclass = new CardIMage();  
        public int totalbettingmoney;//판돈
        public int basicbettingmoney = 1000;//기본배팅금
        Betting bettingclass = new Betting();
        public static string playeranswerbettingname;
        public static string aianswerbettingname;
        


        public static bool isdraw = false;
        public void testnum()
        { 
            //37 47 49
            player.hascard[0].CardNum = 4;
            player.hascard[0].isGwang = true;
            player.hascard[1].CardNum = 9;
            player.hascard[1].isGwang = true;




            ai.hascard[0].CardNum = 4;
            ai.hascard[0].isGwang = false;
            ai.hascard[1].CardNum = 7;
            ai.hascard[1].isGwang = false;


        }


        public void gamestart()
        {
            while (true)
            {


                //1. 메인창
                showprint();
                deck.shuffledeck();//섞고
                Timedelay(1);

                if (isdraw == false)
                {
                    //2. 기본배팅창
                    totalbettingmoney = basicbettingmoney;
                    Console.WriteLine("기본 배팅 할거면 1번");
                    int a = int.Parse(Console.ReadLine());
                    bettingclass.basicbetting(player, ai, this);
                }
                showprint();
                Timedelay(1);




                //3. 1번째 카드분배, 이미지
                player.AddCard(deck.drawcard());
                ai.AddCard(deck.drawcard());
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                Timedelay(0.5);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                Timedelay(1);

                //4. 1번째 배팅
                if (bettingclass.playerbettingname(player, ai, this) == 3)//다이시 리겜
                {
                    playeranswerbettingname = "die";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.aiwin();
                    Timedelay(5);
                    gamereset();
                    break;
                }
                if (bettingclass.aibettingname(player, ai, this) == 3)//다이시 리겜
                {
                    aianswerbettingname = "die";
                    player.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.playerwin();
                    Timedelay(5);
                    gamereset();
                    break;
                }
                showprint();



                //5. 2번쨰 1장분배, 이미지
                player.AddCard(deck.drawcard());
                ai.AddCard(deck.drawcard());
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
                    playeranswerbettingname = "die";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.aiwin();
                    Timedelay(3);
                    gamereset();
                    break;
                }
                if (bettingclass.aibettingname(player, ai, this) == 3)//다이시 리겜
                {
                    aianswerbettingname = "die";
                    player.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.playerwin();
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

            //7.승판결로직 이미지 // 이긴쪽 보여주기
            //deck.showDack();//덱카드 확인용

            player.hascard.Clear();
            ai.hascard.Clear();



        }

        public void first(Player out1, Ai out2)
        {
            ai = out2;
            player = out1;
            //player,ai할당
            //Player myplayer = new Player(51000);
            //Ai ai = new Ai(51000);
        }

        public void fristmainbackground()
        {

            Console.WriteLine("싱글 섯다");
            Console.WriteLine("아무거나 눌르세요");
            Console.ReadLine();
        }


        public void playerfold()
        {
            ai.hasmoney += totalbettingmoney;
        }
        public void aifold()
        {
            player.hasmoney += totalbettingmoney;
        }

        public void bagwinner()
        {
            if (winnerSystemclass.winner(player, ai) == "playerwin")
            {
                Console.Clear();
                showprint();
                player.hasmoney += totalbettingmoney;
                cardIMageclass.playerwin();
            }
            else if (winnerSystemclass.winner(player, ai) == "aiwin")
            {
                Console.Clear();
                showprint();
                ai.hasmoney += totalbettingmoney;
                cardIMageclass.aiwin();
            }
            else if (winnerSystemclass.winner(player, ai) == "draw")
            {
                Console.Clear();
                showprint();
                cardIMageclass.draw();
                isdraw = true;
            }
            else if (winnerSystemclass.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }


        }


        public void bagwinnerfirst()
        {
            if (winnerSystemclass.winner(player, ai) == "playerwin")
            {
                Console.Clear();
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                player.hasmoney += totalbettingmoney;
            }
            else if (winnerSystemclass.winner(player, ai) == "aiwin")
            {
                Console.Clear();
                showprint();
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                ai.hasmoney += totalbettingmoney;
            }
            else if (winnerSystemclass.winner(player, ai) == "draw")
            {
                Console.Clear();
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                isdraw = true;
            }
            else if (winnerSystemclass.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }
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
            Console.SetCursorPosition(8, 8);
            Console.WriteLine(">ai카드");
            Console.SetCursorPosition(8, 13);
            Console.Write("판돈 : $" + totalbettingmoney );
            Console.SetCursorPosition(8, 18);
            Console.WriteLine(">player카드");
            Console.WriteLine();
            Console.WriteLine();
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
       


        public void showgamemoney()
        {
            Console.WriteLine("player money : " + player.hasmoney);
            Console.WriteLine("ai money : " + ai.hasmoney);
            Console.WriteLine("totalbettingmoney : " + totalbettingmoney);

        }

        //게임리셋
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
            Console.Clear();
        }

    }
}
