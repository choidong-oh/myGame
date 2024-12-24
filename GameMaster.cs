﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string playeranswerbettingname;
        string aianswerbettingname;
        public void testnum()
        {
            //37 47 49
            player.hascard[0].CardNum = 3;
            player.hascard[0].isGwang = true;
            player.hascard[1].CardNum = 8;
            player.hascard[1].isGwang = true;




            ai.hascard[0].CardNum = 4;
            ai.hascard[0].isGwang = false;
            ai.hascard[1].CardNum = 7;
            ai.hascard[1].isGwang = false;


        }

        
        public void first(Player out1,Ai out2)
        {
            ai = out2;
            player = out1;
            //player,ai할당
            //Player myplayer = new Player(51000);
            //Ai ai = new Ai(51000);
        }



        public void gamestart()
        {
            while (true)
            {
                
                Console.WriteLine("처음메인 아무거나 누르셈");
                Console.ReadLine();

                //1. 메인창
                showprint();
                Timedelay(2);
                totalbettingmoney = basicbettingmoney;
                deck.shuffledeck();//섞고


                //2. 기본배팅창
                Console.WriteLine("기본 배팅 할거면 1번");
                int a = int.Parse(Console.ReadLine());
                bettingclass.basicbetting(player, ai, this);
                showprint();
                Timedelay(1);



                //3. 1번째 카드분배, 이미지
                player.AddCard(deck.drawcard());
                ai.AddCard(deck.drawcard());
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                Timedelay(0.5);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                Timedelay(1);

                //4. 1번째 배팅
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("1배팅 뭐할래? 1번 : 하프, 2번 : 콜, 3번 : 다이, 4번 : 올인");
                a = int.Parse(Console.ReadLine());
                //player선택
               
                if (a == 3)
                {
                    playeranswerbettingname = "die";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.aiwin();
                    Timedelay(5);
                    break;
                }


                bettingclass.playerbettingname(player, ai, this, a);
                bettingclass.aibettingname(player, ai, this, 2);
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
                //testnum();

                //6. 2번쨰 배팅
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("1배팅 뭐할래? 1번 : 하프, 2번 : 콜, 3번 : 다이, 4번 : 올인");
                a = int.Parse(Console.ReadLine());
                if (a == 3)//player 3다이
                {
                    playeranswerbettingname = "die";
                    ai.hasmoney += totalbettingmoney;
                    showprint();
                    cardIMageclass.aiwin();
                    Timedelay(5);
                    break;
                }
                bettingclass.playerbettingname(player, ai, this, 1);
                bettingclass.aibettingname(player, ai, this, 2);
                showprint();
                Timedelay(1.5);



                Console.Clear();
                Console.WriteLine("승리 판결 ing~");
                Timedelay(3);
                bagwinner();
                gamereset();
            }

            //7.승판결로직 이미지 // 이긴쪽 보여주기
            //deck.showDack();//덱카드 확인용

            player.hascard.Clear();
            ai.hascard.Clear();




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
                //Console.WriteLine("플레이어윈");
            }
            else if (winnerSystemclass.winner(player, ai) == "aiwin")
            {
                Console.Clear();
                showprint();
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                ai.hasmoney += totalbettingmoney;
                //Console.WriteLine("에이아이 윈");
            }
            else if (winnerSystemclass.winner(player, ai) == "draw")
            {
                Console.Clear();
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum, player.hascard[0].isGwang);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum, ai.hascard[0].isGwang);
                //Console.WriteLine("드로우");
            }
            else if (winnerSystemclass.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }
        }


        public bool gamefinish()
        {
            Timedelay(1.5);
            Console.Clear();
            if (ai.hasmoney <= 0)
            {
                player.hasmoney = 0;
                Console.WriteLine("============================================");
                Console.WriteLine("playerwin");
                Console.WriteLine("playerhasmoney : " + player.hasmoney);
                Console.WriteLine("============================================");
                return true;
            }
            else if (player.hasmoney <= 0)
            {
                ai.hasmoney = 0;
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
            Console.SetCursorPosition(8, 8);
            Console.WriteLine(">ai카드");
            Console.SetCursorPosition(8, 13);
            Console.Write("판돈 : $" + totalbettingmoney );
            Console.SetCursorPosition(8, 18);
            Console.WriteLine(">player카드");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("Player");
            Console.Write("playermoney : " + player.hasmoney);
            Console.WriteLine(" playerbettingmoney : " + player.playerbettingmoney);


        }

        //~초 기달림
        static void Timedelay(double second)
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
            //덱 초기화
            deck.shuffledeck();
            //판돈 초기화
            player.playerbettingmoney = 0;
            ai.playerbettingmoney = 0;
            totalbettingmoney = 0;
            //가지고있는 카드 초기화
            player.hascard.Clear();
            ai.hascard.Clear();
            Timedelay(1.5);
            Console.Clear();
        }

    }
}
