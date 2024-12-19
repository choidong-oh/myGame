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
        public Deck deck;
        List<Deck> decks = new List<Deck>();
        
        
        public Player()
        {
            deck = new Deck();
            decks.Add(deck.usedeck[0]);


        }






    }
}
