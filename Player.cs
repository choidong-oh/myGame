﻿using System;
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
        public int hasmoney;

        public Player(int money)
        {
            hasmoney = money;
        }


        //덱에 한장 추가
        public void AddCard(Card card)
        {
            Console.WriteLine("패에 카드 한장 드로우");
            hascard.Add(card);

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
