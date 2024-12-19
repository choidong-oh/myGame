using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Player
    {
        //PLAYER의 카드가 존재해야함
        //리스트를 하고 그 중 맨윗값 추가함
        public Deck deck= new Deck();
        List<Card> decks = new List<Card>();
        
        
        public Player()
        {
            if (deck.usedeck[0] == null)
            {
                //첫장 둘째장 player리스트에 추가
                decks.Add(deck.usedeck[0]);
                decks.Add(deck.usedeck[1]);

            }


        }






    }
}
