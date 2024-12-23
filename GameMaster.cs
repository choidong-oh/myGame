using System;
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
        public void testnum()
        {
            //37 47 49
            player.hascard[0].CardNum = 3;
            player.hascard[0].isGwang = true;
            player.hascard[1].CardNum = 8;
            player.hascard[1].isGwang = true;




            ai.hascard[0].CardNum = 4;
            ai.hascard[0].isGwang = true;
            ai.hascard[1].CardNum = 7;
            ai.hascard[1].isGwang = true;


        }




        public void gamestart()
        {
            GameMaster master = new GameMaster();
            
            ai = new Ai(51000);
            player = new Player(51000);

            //1. 메인창
            showprint();
            Timedelay(2);
            totalbettingmoney = basicbettingmoney;
            deck.shuffledeck();//섞고


            //2. 기본배팅창
            Console.WriteLine("기본 배팅 할거면 1번");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine(totalbettingmoney);
            bettingclass.basicbetting(player,ai, master);
            //basicbetting();//기본 배팅//천원깍음
            Console.WriteLine(totalbettingmoney);
            Timedelay(50);
            showprint();
            Timedelay(1);



            //3. 1번째 카드분배, 이미지
            player.AddCard(deck.drawcard()); 
            ai.AddCard(deck.drawcard());
            showprint();
            cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum);
            Timedelay(0.5);
            cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum);
            Timedelay(1);


            //4. 1번째 배팅
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("배팅 뭐할래? 1번 : 콜, 2번 : 하프, 3번 : 다이");
            a = int.Parse(Console.ReadLine());
            betting();
            //bettingclass.bettingname("half");
            showprint();



            //5. 2번쨰 1장분배, 이미지
            player.AddCard(deck.drawcard());
            ai.AddCard(deck.drawcard());
            showprint();
            cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum);
            cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum);
            cardIMageclass.PlayerCardnumimage2(player.hascard[1].CardNum);
            Timedelay(0.5);
            cardIMageclass.AiCardnumimage2(ai.hascard[1].CardNum);
            Timedelay(1);

            //임의 카드 수정
            testnum();

            //6. 2번쨰 배팅
            Console.SetCursorPosition(0, 27);
            Console.WriteLine("배팅 뭐할래? 1번 : 콜, 2번 : 하프, 3번 : 다이");
            a = int.Parse(Console.ReadLine());
            betting();

            Console.Clear();
            Console.WriteLine("승리 판결 ing~");
            Timedelay(3);
            

            //7.승판결로직 이미지 // 이긴쪽 보여주기
            if (winnerSystemclass.winner(player, ai) == "playerwin")
            {
                Console.Clear();
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum);
                cardIMageclass.PlayerCardnumimage2(player.hascard[1].CardNum);
                //Console.WriteLine("플레이어윈");
            }
            else if (winnerSystemclass.winner(player, ai) == "aiwin")
            {
                Console.Clear();
                showprint();
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum);
                cardIMageclass.AiCardnumimage2(ai.hascard[1].CardNum);
                //Console.WriteLine("에이아이 윈");
            }
            else if (winnerSystemclass.winner(player, ai) == "draw")
            {
                Console.Clear();
                showprint();
                cardIMageclass.PlayerCardnumimage1(player.hascard[0].CardNum);
                cardIMageclass.PlayerCardnumimage2(player.hascard[1].CardNum);
                cardIMageclass.AiCardnumimage1(ai.hascard[0].CardNum);
                cardIMageclass.AiCardnumimage2(ai.hascard[1].CardNum);
                //Console.WriteLine("드로우");
            }
            else if (winnerSystemclass.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }
            //deck.showDack();//덱카드 확인용
        }

        public void gameing()
        {

        }
       
        public void showprint()
        {
            //Console.Clear();
            Console.WriteLine("AI");
            Console.WriteLine("aimoney : " + ai.hasmoney);
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
            Console.WriteLine("playermoney : " + player.hasmoney);


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
       


        //배팅클래스로 나누기
        //player가 선언마다 하면 될듯// 하프,콜,다이 넣으면될듯
        public void betting()
        {
            //예) 하프
            //기본만 올인 생각안함// 
            player.playerbettingmoney *=   2;
            player.hasmoney -= player.playerbettingmoney;

            //콜
            ai.playerbettingmoney = player.playerbettingmoney;
            ai.hasmoney -= ai.playerbettingmoney;

            //기본배팅
            totalbettingmoney +=ai.playerbettingmoney + player.playerbettingmoney;

            Console.WriteLine("배팅함");


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
        }
        //기본배팅
        //public void basicbetting()
        //{
        //    //기본금 뺴고, 판돈에 기본금 추가
        //    player.hasmoney -= basicbettingmoney;
        //    player.playerbettingmoney = basicbettingmoney;
        //    ai.hasmoney -= basicbettingmoney;
        //    ai.playerbettingmoney = basicbettingmoney;
        //    totalbettingmoney = basicbettingmoney * 2;
        //}

    }
}
