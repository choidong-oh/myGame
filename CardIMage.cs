using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class CardIMage
    {
        //카드이미지
        WinnerSystem WinnerSystem;
        string[,,] str = new string[11, 7, 7]
            {
                //1
                {
                {"■","■","■","■","■","■","■"},
                {"■","■","■","　","■","■","■"},
                {"■","■","　","　","■","■","■"},
                {"■","■","■","　","■","■","■"},
                {"■","■","■","　","■","■","■"},
                {"■","■","　","　","　","■","■"},
                {"■","■","■","■","■","■","■"},
                },

                 //2
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //3
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                 //4
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //5
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                 //6
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //7
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                 //8
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //9
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","　","　","　","　","■"},
                {"■","　","■","■","■","　","■"},
                {"■","　","　","　","　","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //10
                {
                {"■","■","■","■","■","■","■"},
                {"■","　","■","　","　","　","■"},
                {"■","　","■","　","■","　","■"},
                {"■","　","■","　","■","　","■"},
                {"■","　","■","　","■","　","■"},
                {"■","　","■","　","　","　","■"},
                {"■","■","■","■","■","■","■"},
                },

                //playerwin
                {
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                {"■","■","■","■","■","■","■"},
                },


            };
        public void PlayerCardnumimage1(int firstcard, bool isgwang)
        {
            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(33 + 2 * k, 15 + j);
                    Console.Write(str[firstcard - 1, j, k]);
                }
                Console.WriteLine();
            }
            if (isgwang == true)
            {
                Console.SetCursorPosition(33, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("■");
                Console.ResetColor();
            }
        }
        public void PlayerCardnumimage2(int secondcard,bool isgwang)
        {
            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(55 + 2 * k, 15 + j);
                    Console.Write(str[secondcard - 1, j, k]);
                }
                Console.WriteLine();
            }
            if (isgwang == true)
            {
                Console.SetCursorPosition(55, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("■");
                Console.ResetColor();
            }



        }

        public void AiCardnumimage1(int firstcard,bool isgwang)
        {

            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(33 + 2 * k, 5 + j);
                    Console.Write(str[firstcard - 1, j, k]);
                }
                Console.WriteLine();
            }
            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(33 + 2 * k, 5 + j);
                    Console.Write(str[firstcard - 1, j, k]);
                }
                Console.WriteLine();
            }
            if (isgwang == true)
            {
                Console.SetCursorPosition(33, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("■");
                Console.ResetColor();
            }
            
            
        }

        public void AiCardnumimage2(int secondcard, bool isgwang)
        {

            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(55 + 2 * k, 5 + j);
                    Console.Write(str[secondcard - 1, j, k]);
                }
                Console.WriteLine();
            }


            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    Console.SetCursorPosition(55 + 2 * k, 5 + j);
                    Console.Write(str[secondcard - 1, j, k]);
                }
                Console.WriteLine();
            }
            if (isgwang == true)
            {
                Console.SetCursorPosition(55, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("■");
                Console.ResetColor();
            }



        }

       



    }
}
