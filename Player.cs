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
        public string staticjokboname;
        public Player(int money)
        {
            hasmoney = money;
        }
       

    }
}
