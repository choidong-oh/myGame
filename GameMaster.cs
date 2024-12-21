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
        public int basicbettingmoney;//기본배팅금


        public void gamestart()
        {
            player = new Player(10000);
            ai = new Ai(9000);

            //섞고
            deck.shuffledeck();
            //기본 배팅//만원깍음
            basicbetting();

            //1번째 1장분배
            player.AddCard(deck.drawcard()); 
            ai.AddCard(deck.drawcard());

            //2번쨰 1장분배
            player.AddCard(deck.drawcard());
            ai.AddCard(deck.drawcard());

            //승리로직
            winnerSystem.winner(player,ai);

            if(winnerSystem.winner(player, ai) == "draw")
            {
                Console.WriteLine("재경기");
                //덱에 있는 16장패에서 4장분배
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

        //게임리셋
        public void gamereset()
        {
            deck.shuffledeck();
        }
        //기본배팅
        public void basicbetting()
        {
            basicbettingmoney = 1000;
            player.hasmoney -= basicbettingmoney; ;
            ai.hasmoney -= basicbettingmoney;
            totalbettingmoney = basicbettingmoney * 2;
        }

        public void showgamemoney()
        {
            Console.WriteLine("player money : " + player.hasmoney);
            Console.WriteLine("ai money : " + ai.hasmoney);
            Console.WriteLine("totalbettingmoney : " + totalbettingmoney);

        }





    }
}
