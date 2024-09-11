using System;
using System.Diagnostics.Contracts;

class Programm
{
    static void Main()
    {
        bool exit = true;
        int allCount = 0;
        Random random = new Random();
        int z = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int[,] lab = new int[z,x];
        for(int i = 0; i < lab.GetLength(0); i++)
        {
            for(int j = 0; j < lab.GetLength(1); j++)
            {
                lab[i, j] = random.Next(1,4);
                if(lab[i, j] == 3)
                {
                    allCount++;
                }
            }
        }
        z = random.Next(0,lab.GetLength(0));
        x = random.Next(0, lab.GetLength(1));
        lab[z,x] = 0;
        int temp,count = 0;
        bool cheat = false;
        bool god = false;
        while (exit)
        {
            Pokaz(lab);
            char vibor = Char.ToLower((char)Console.ReadKey().Key);
            Console.Clear();
            Console.WriteLine();
            try
            {
                switch (vibor)
                {
                    case 'g': 
                        {
                            if (god)
                            {
                                Console.WriteLine("Режим не бога погна");
                                god = !god;
                            }
                            else
                            {
                                Console.WriteLine("Режим бога погна");
                                cheat = true;
                                god = !god;
                            }
                            break;
                        }
                    case 'w':
                        if (lab[z - 1, x] != 1)
                        {
                            temp = lab[z - 1, x];
                            lab[z - 1, x] = 0;
                            lab[z, x] = temp;
                            z--;
                        }
                        else if (god)
                        {
                            temp = lab[z - 1, x];
                            lab[z - 1, x] = 0;
                            lab[z, x] = temp;
                            z--;
                        }
                        if (lab[z + 1, x] == 3)
                        {
                            count++;
                            lab[z + 1, x] = 2;
                        }
                        else if (lab[z - 1, x] == 1)
                        {
                            Console.WriteLine("Движение вверх невозможно");
                        }
                        break;
                    case 's':
                        if (lab[z + 1, x] != 1)
                        {
                            temp = lab[z + 1, x];
                            lab[z + 1, x] = 0;
                            lab[z, x] = temp;
                            z++;
                        }
                        else if (god)
                        {
                            temp = lab[z + 1, x];
                            lab[z + 1, x] = 0;
                            lab[z, x] = temp;
                            z++;
                        }
                        else if (lab[z + 1, x] == 1)
                        {
                            Console.WriteLine("Движение вниз невозможно");
                        }
                        if (lab[z - 1, x] == 3)
                        {
                            count++;
                            lab[z -1, x] = 2;
                        }
                        break;
                    case 'a':
                        if (lab[z, x - 1] != 1)
                        {
                            temp = lab[z, x - 1];
                            lab[z, x - 1] = 0;
                            lab[z, x] = temp;
                            x--;
                        }
                        else if (god)
                        {
                            temp = lab[z, x - 1];
                            lab[z, x - 1] = 0;
                            lab[z, x] = temp;
                            x--;
                        }
                        if (lab[z, x + 1] == 3)
                        {
                            count++;
                            lab[z, x + 1] = 2;
                        }
                        else if (lab[z, x - 1] == 1)
                        {
                            Console.WriteLine("Движение влево невозможно");
                        }

                        break;
                    case 'd':
                        if (lab[z, x + 1] != 1)
                        {
                            temp = lab[z, x + 1];
                            lab[z, x + 1] = 0;
                            lab[z, x] = temp;
                            x++;
                        }
                        else if (god)
                        {
                            temp = lab[z, x + 1];
                            lab[z, x + 1] = 0;
                            lab[z, x] = temp;
                            x++;
                        }
                        else if (lab[z, x + 1] == 1)
                        {
                            Console.WriteLine("Движение вправо невозможно");
                        }
                        if (lab[z,x-1] == 3)
                        {
                            count ++;
                            lab[z, x-1] = 2;
                        }
                        break;
                    case 'z':
                        {
                            Console.WriteLine("игра окончена");
                            exit = false;
                        }
                        break;
                }
            }
            catch (Exception e) 
            {
                exit = false;
                Console.WriteLine($"Сокровищ: {count} из {allCount}");
                Console.WriteLine("Игра пройдена поздравляю");
                if(cheat)
                    Console.WriteLine("а без бога можно было?");
            }
        }
    }
    public static void Pokaz(int[,] lab) {
        for (int i = 0; i < lab.GetLength(0); i++)
        {
            for (int j = 0; j < lab.GetLength(1); j++)
            {
                if (lab[i, j] == 2)
                {
                    Console.Write(" " + "\t");
                }
                else if (lab[i, j] == 1)
                {
                    Console.Write("1" + "\t");
                }
                else if (lab[i, j] == 3)
                {
                    Console.Write("M" + "\t");
                }
                else if (lab[i, j] == 0)
                {
                    Console.Write(lab[i, j] + "\t");
                }
            }
            Console.WriteLine("");
        }
    }
}