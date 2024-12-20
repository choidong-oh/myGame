using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class bettingmanager
    {
        betting betting;
        public void bettingname(betting betting)
        {
            betting = new betting();
            if (betting.half)
            {
                Console.WriteLine("배팅을 하프 하였습니다");
            }
            else if (betting.die)
            {
                Console.WriteLine("배팅을 다이 하였습니다");
            }

        }



    }
}
