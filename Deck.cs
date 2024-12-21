using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Deck
    {
        Card card;
        //카드 할당
        List<Card> unusedeck = new List<Card>(20);//확인용
        public List<Card> usedeck = new List<Card>(20);//사용할덱
        
        
        //사용덱 초기화, 섞기
        public void shuffledeck()
        {
            usedeck.Clear();
            Console.WriteLine("덱 카드 초기화");
            //임시용 카드 대입1~10, 1~10
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    card = new Card();
                    card.CardNum = j;
                    usedeck.Add(card);

                }
            }
        }
        public Card drawcard()
        {
            Console.WriteLine("카드 한장 뽑음");
            //마지막 패 뽑고 반환
            var temp = usedeck.Last();
            usedeck.Remove(temp);
            return temp;
        }




        public void showDack()
        {
            foreach(var ele in usedeck)
            {
                Console.WriteLine("카드 : " + ele.CardNum);
            }



        }





    }
}
