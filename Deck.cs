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
        //List<Card> unusedeck = new List<Card>(20);//확인용
        public List<Card> usedeck = new List<Card>(20);//사용할덱
        
        
        //사용덱 초기화, 섞기
        public void shuffledeck()
        {
            Random rnd = new Random();

            //player카드를 정렬
            usedeck.Clear();
            Console.SetCursorPosition(55, 10);
            Console.WriteLine("덱 카드 초기화");
            Console.SetCursorPosition(0, 27);
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
            usedeck[0].isGwang = true;
            usedeck[2].isGwang = true;
            usedeck[7].isGwang = true;

            //피셔예이츠
            //랜덤부여
            for (int i = usedeck.Count - 1; i > 0; i--) //인덱스 역순
            {
                int j = rnd.Next(0, i + 1); // 0부터 i까지 랜덤 인덱스 선택
                // 배열 요소 교환
                var temp = usedeck[i];
                usedeck[i] = usedeck[j];
                usedeck[j] = temp;
            }

            //배팅 초기화
            Betting.staticplayerbettingname = "";
            Betting.staticaibettingname = "";



        }

        public Card drawcard()
        {
            //마지막 패 뽑고 반환
            var temp = usedeck.Last();
            usedeck.Remove(temp);
            return temp;
        }
        //덱에 한장 추가
        public void AddCard(Card card,Player player)
        {
            // Console.WriteLine("패에 카드 한장 드로우");
            player.hascard.Add(card);
            //카드정렬
            if (player.hascard.Count >= 2)
            {
                if (player.hascard[0].CardNum > player.hascard[1].CardNum)
                {
                    int temp = player.hascard[0].CardNum;
                    player.hascard[0].CardNum = player.hascard[1].CardNum;
                    player.hascard[1].CardNum = temp;

                    var temp1 = player.hascard[0].isGwang;
                    player.hascard[0].isGwang = player.hascard[1].isGwang;
                    player.hascard[1].isGwang = temp1;


                }
            }


        }



        //덱카드 확인용
        public void showDack()
        {
            int count = 1;
            foreach(var ele in usedeck)
            {
                Console.Write(count + " 카드 : " + ele.CardNum);
                Console.WriteLine("광여부 : " + ele.isGwang);
                count++;
            }

        }





    }
}
