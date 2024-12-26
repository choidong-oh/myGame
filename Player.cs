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
        public Deck deck;
        public List<Card> hascard = new List<Card>();
        public int hasmoney;//소지돈
        public int playerbettingmoney;//각판 플레이어 배팅 머니

        public Player(int money)
        {
            hasmoney = money;
        }


        //덱에 한장 추가
        public void AddCard(Card card)
        {
           // Console.WriteLine("패에 카드 한장 드로우");
            hascard.Add(card);
            //카드정렬
            if(hascard.Count >= 2 )
            {
                if (hascard[0].CardNum > hascard[1].CardNum)
                {
                    int temp = hascard[0].CardNum;
                    hascard[0].CardNum = hascard[1].CardNum;
                    hascard[1].CardNum = temp;

                    var temp1 = hascard[0].isGwang;
                    hascard[0].isGwang = hascard[1].isGwang;
                    hascard[1].isGwang = temp1;


                }
            }
            

        }
        //덱 초기화
        public void clercard()
        {
            Console.WriteLine("패에 카드 초기화");
            hascard.Clear();
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
