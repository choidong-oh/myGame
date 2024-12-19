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
        
        //메서드나 생성자로 카드생성20장
        public Deck()
        {
            //card할당 돼야댐

            //덱초기화
            //모든카드 제거
            usedeck.Clear();
            
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

        public void showDack()
        {
            foreach(var ele in usedeck)
            {
                Console.WriteLine("카드 : " + ele.CardNum);
            }



        }





    }
}
