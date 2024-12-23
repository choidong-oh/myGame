using System;
using System.Collections.Generic;
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
        WinnerSystem winnerSystem = new WinnerSystem();
        public int totalbettingmoney;//판돈
        public int basicbettingmoney = 1000;//기본배팅금
        

        public void gamestart()
        {
            totalbettingmoney = basicbettingmoney;
            //판돈 보유
            player = new Player(51000);
            ai = new Ai(51000);

            //섞고
            deck.shuffledeck();
            //기본 배팅//천원깍음
            basicbetting();

            //1번째 1장분배
            player.AddCard(deck.drawcard()); 
            ai.AddCard(deck.drawcard());

            //배팅
            betting();

            //2번쨰 1장분배
            player.AddCard(deck.drawcard());
            ai.AddCard(deck.drawcard());

            //배팅
            betting();

            ///승리로직
            //winnerSystem.winner(player, ai);
            if (winnerSystem.winner(player, ai) == "playerwin")
            {
                Console.WriteLine("플레이어윈");
            }
            else if (winnerSystem.winner(player, ai) == "aiwin")
            {
                Console.WriteLine("에이아이 윈");
            }

            if (winnerSystem.winner(player, ai) == "null")
            {
                Console.WriteLine("null반환");
            }



            if (winnerSystem.winner(player, ai) == "draw")
            {
                Console.WriteLine("재경기");
                //덱에 있는 16장패에서 4장분배
                //덱에있는 20장으로 바꿔야댐 오류??
                player.AddCard(deck.drawcard());
                ai.AddCard(deck.drawcard());

                player.AddCard(deck.drawcard());
                ai.AddCard(deck.drawcard());


            }

            //각각의 돈 출력
            showgamemoney();
            //각각 패 출력
            Console.WriteLine("player 카드 : "+ player.hascard[0].CardNum+ " "+ player.hascard[1].CardNum);
            Console.WriteLine("ai 카드 : "+ ai.hascard[0].CardNum+" "+ ai.hascard[1].CardNum);
            //현재덱 출력
            deck.showDack();
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
        public void basicbetting()
        {
            //기본금 뺴고, 판돈에 기본금 추가
            player.hasmoney -= basicbettingmoney;
            player.playerbettingmoney = basicbettingmoney;
            ai.hasmoney -= basicbettingmoney;
            ai.playerbettingmoney = basicbettingmoney;
            totalbettingmoney = basicbettingmoney * 2;
        }






    }
}
