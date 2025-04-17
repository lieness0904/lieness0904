using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Threading
{
    class Program
    {
        RefreshEventArgs _refreshEventArgs;
        static void Main(string[] args)
        {
            int[,] map =
        {
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,3,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,3,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,3,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,2,2,2,2,2,2,2,2,2,2,2,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},                
                {1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,1,1,1,1,1,1,1,1,1,1,1,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
        };
            int mapStartX = 0; 
            int mapStartY = 0; 

            for (int mapy = 0; mapy < map.GetLength(0); mapy++)
            {
                for (int mapx = 0; mapx < map.GetLength(1); mapx++)
                {
                    Console.SetCursorPosition(mapStartX + mapx * 2, mapStartY + mapy); // 2칸씩 띄우기
                    if (map[mapy, mapx] == 1)
                    {
                        Console.Write("■");
                    }
                    else if (map[mapy, mapx] == 2)
                    {
                        Console.Write("〓");
                    }
                    else if (map[mapy, mapx] == 3)
                    {
                        Console.Write("▒");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
            void Status(int hp, int Exp, int level)
            {
                int statusX = 34;
                int statusY = 1;

                int maxHp = 100;
                int heartCount = 5;
                int currentHearts = (int)Math.Round((double)hp / maxHp * heartCount);

                string hpBar = new string('■', currentHearts).PadRight(heartCount, '□'); // 빈 하트로 채움

                Console.SetCursorPosition(statusX, statusY);
                Console.Write($"HP  : {hpBar}");

                Console.SetCursorPosition(statusX, statusY + 1);
                Console.Write($"LV  : {level}");

                Console.SetCursorPosition(statusX, statusY + 2);
                Console.Write($"EXP : {Exp}");
            }
            Status(100, 0, 1);

            int x = 2, y = 0; // 채팅
            Console.SetCursorPosition(x, y);
            Console.Write("★");
            int Chat1x = 28, Chat1y = 8;
            Console.SetCursorPosition(Chat1x, Chat1y);
            Console.Write("적이 공격하였습니다.");
            int Chat2x = 28, Chat2y = 9;
            Console.SetCursorPosition(Chat2x, Chat2y);
            Console.Write("[ 10 ] 의 데미지를 입었습니다.");
            int Chat3x = 28, Chat3y = 10;
            Console.SetCursorPosition(Chat3x, Chat3y);
            Console.Write("적이 공격하려 합니다.");
            
            //적의 상태정보
            int Chat5x = 28, Chat5y = 13;
            Console.SetCursorPosition(Chat5x, Chat5y);
            Console.Write("적의 체력이 [ 20 ] 남았습니다.");
            
            //승리 보상목록등
            int win0x = 28, win0y = 16;
            Console.SetCursorPosition(win0x, win0y);
            Console.Write("승리하였습니다.");
            int win1x = 28, win1y = 17;
            Console.SetCursorPosition(win1x, win1y);
            Console.Write("100 골드를 얻었습니다.");
            int win2x = 28, win2y = 18;
            Console.SetCursorPosition(win2x, win2y);
            Console.Write("[15]의 경험치를 얻었습니다.");
            
            Console.ReadKey();
            ConsoleKeyInfo Key;
            
            while (true)
            {
                Console.CursorVisible = false;
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.SetCursorPosition(x, y);
                Console.Write("  ");

                switch (key.Key) // 조작
                {
                    case ConsoleKey.LeftArrow:
                        if (x > 2 && map[y, (x - 2) / 2] == 0) x -= 2;
                        break;

                    case ConsoleKey.RightArrow:
                        if (x < 100 && map[y, (x + 2) / 2] == 0) x += 2;
                        break;

                    case ConsoleKey.UpArrow:
                        if (y > 0 && map[y - 1, x / 2] == 0) y--;
                         break;

                    case ConsoleKey.DownArrow:
                        if (y < 100 && map[y + 1, x / 2] == 0) y++;
                        break;

                    case ConsoleKey.Q:
                        return;
                }
                Console.SetCursorPosition(x, y);
                Console.Write("★");
            }
        }
    }
}


