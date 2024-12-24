using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMaster gameMaster = new GameMaster();

            gameMaster.first();
            

            while (true)
            {
                gameMaster.gamestart();

            }














        }
    }
}
