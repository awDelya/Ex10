using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_methods;

namespace SliyanieTrees
{
    class Program
    {
        public static Random rnd = new Random();
        public static int HowCreate = 0, size1, size2, i = 0;
        public static Tree idTree1 = null, idTree2 = null, idTree = null;
        public static Tree[] mas;
        public static void Create()
        {
            Color.Print("\nВведите количество элементов для первого дерева: ", ConsoleColor.Yellow);
            size1 = Number.Check(1, int.MaxValue);
            Color.Print("\nВведите количество элементов для второго дерева: ", ConsoleColor.Yellow);
            size2 = Number.Check(1, int.MaxValue);
            mas = new Tree[size1 + size2];
            Color.Print("\nВыберите способ заполнения: \n\n ", ConsoleColor.Yellow);
            Color.Print("1) Ручной ввод \n 2) Случайный \n Номер:  ");
            HowCreate = Number.Check(1, 2);
            Console.Clear();
        }

        static Tree IdealTree(int size, Tree p, int typeCreate)
        {
            Tree r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }
            nl = size / 2;
            nr = size - nl - 1;
            Tree d = MakeTree();
            r = d;
            mas[i] = r; i++;
            r.left = IdealTree(nl, r.left, typeCreate);

            r.right = IdealTree(nr, r.right, typeCreate);
            p = r;
            return p;
        }
        static Tree IdealTree(int size, Tree p)
        {
            Tree r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }
            nl = size / 2;
            nr = size - nl - 1;
            Tree d = mas[i];
            i++;
            r = d;
            r.left = IdealTree(nl, r.left);

            r.right = IdealTree(nr, r.right);
            p = r;
            return p;
        }
        static Tree MakeTree()
        {
            double x;
            if (HowCreate == 1)
            {

                Color.Print("\tВведите элемент: ", ConsoleColor.Yellow);
                x = Number.Check(double.MinValue, double.MaxValue);
                Color.Print("\n Добавленo! ", ConsoleColor.Cyan);
                return new Tree(x);
            }
            else
            {
                x = rnd.Next(-100, 100);
                x = x / 10;
                return new Tree(x);
            }
        }
        static void Main()
        {

        }
    }
}
