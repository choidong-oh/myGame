using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Player
    {
        //PLAYER의 카드가 존재해야함
        //리스트를 하고 그 중 맨윗값 추가함
        Money money;
        public Deck deck;
        List<Card> decks = new List<Card>();
        public int hasmoney;
        betting playerbetting;

        public Player()
        {
            if (deck.usedeck[0] == null)
            {
                decks = new List<Card>();
                //첫장 둘째장 player리스트에 추가
                decks.Add(deck.usedeck[0]);
                decks.Add(deck.usedeck[1]);

            }

        }

        public void betting(Money money, betting betting)
        {
            money = new Money();
            this.hasmoney = money.don;//돈을담음
            playerbetting = new betting();
            this.playerbetting = betting.half;

            //배팅함수
            //this.hasmoney -= bettingmoney;
            Console.WriteLine("배팅을 하프 했습니다");



        } 

        //가지고있는돈이 0원이면
        public void nomoney(int havemoney)
        {
            if (hasmoney <= 0)
            {
                hasmoney = 0;
                Console.WriteLine("오링~~~~!!!!!");
            }
        }






    }
}
