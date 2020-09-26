using System;
namespace Шахматы
{
    class Program
    {
        static void Main()
        {
            int figura;
            bool result;
            int word = 64;   // Код буквы A в юникоде -1
            int count = 48;  // Код цифры 1 в юникоде -1

            for ( ; ; )      // Бесконечный цикл
            {
                do
                {
                    Console.WriteLine("Выберите фигуру, которой хотите сходить:\n1)Конь\n2)Слон\n3)Ладья\n4)Король\n5)Ферзь\n6)Пешка\n");
                    result = int.TryParse(Console.ReadLine(), out figura);   
                }
                while ((figura <= 0 || figura >= 7) || result == false);
                
                int a; int b; int c; int d;   // Ход фигуры (A1-B2) A=a 1=b  b=c d=2

                do
                {
                    Console.WriteLine("\nВведите ваш ход");
                    string moving = Console.ReadLine();   // Ввод хода пользователем

                    if (moving.Length == 5)   // Длина строки ввода хода
                    {
                        a = symbols(moving[0], word);
                        b = symbols(moving[1], count);
                        c = symbols(moving[3], word);
                        d = symbols(moving[4], count);
                    }
                    else 
                    {
                        a = 0; b = 0; c = 0; d = 0;
                    }
                    if (a == c && b == d)
                    {
                        a = 0; b = 0; c = 0; d = 0;
                    }

                } while (a == 0 || b == 0 || c == 0 || d == 0);

                switch (figura)
                {
                    case 1: horse(a, b, c, d); break;
                    case 2: bishop(a, b, c, d); break;
                    case 3: rook(a, b, c, d); break;
                    case 4: king(a, b, c, d); break;
                    case 5: queen(a, b, c, d); break;
                    case 6: peshka(a, b, c, d); break;
                }
            }

            int symbols(char move, int w_or_count)              //Преобразование буквы или цифры в число = [1;8]
            {
                int num;
                num = Convert.ToInt32(move) - w_or_count;
                if (num < 0 || num >= 9) num = 0;
                return num;
            }

            void yes()
            { Console.WriteLine("\nВерно\n"); }

            void no()
            { Console.WriteLine("\nНеверно\n"); }
  
            void horse(int q, int w, int e, int r)
            {
                if (Math.Abs(q - e) == 1)
                {
                    if (Math.Abs(w - r) == 2) yes();
                    else no();
                }
                else if (Math.Abs(q - e) == 2)
                {
                    if (Math.Abs(w - r) == 1) yes();
                    else no();
                }
                else no();
            }

            void bishop(int q, int w, int e, int r)
            {
                if   (Math.Abs(q - e) == Math.Abs(w - r))
                    yes();
                else
                    no();
            }

            void rook(int q, int w, int e, int r)
            {
                if
                    (q == e || w == r)
                    yes();
                else
                    no();
            }

            void king(int q, int w, int e, int r)
            {  
                if (Math.Abs(q - e) == 1 || q == e)
                    { 
                    if (Math.Abs(w - r) == 1 || w == r)
                        yes();
                    else no();
                    } 
                else no(); 
            }

            void queen(int q, int w, int e, int r)
            {
               
                
                    if (Math.Abs(q - e) == Math.Abs(w - r)
                        || q == e
                        || w == r)
                         yes();
                    else
                         no();
               
            }

            void peshka(int q, int w, int e, int r)
            {
                Console.WriteLine("Цвет ваших фигур:\n1)Белый\n2)Черный\n");
                int color = int.Parse(Console.ReadLine());
                if (color == 1)
                {
                    if (r - w == 1 && q == e && q != 1) yes();
                    else if (r - w == 1 && Math.Abs(e - q) == 1) Console.WriteLine("\nВерно, если вы рубите фигуру соперника\n");
                    else if (w == 2 && r == 4 && q == e) yes();
                    else no();
                }
                else if (color == 2)

                {
                    if (w - r == 1 && q == e && q != 8) yes();
                    else if (w - r == 1 && Math.Abs(q - e) == 1) Console.WriteLine("\nВерно, если вы рубите фигуру соперника\n");
                    else if (w == 7 && r == 5 && q == e) yes();
                    else no();
                }
                else Console.WriteLine("\nВы неправильно ввели цвет\n");
            }
        }
    }
}
