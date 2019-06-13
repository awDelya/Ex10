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
        private static Random rnd = new Random();
        private static int HowCreate = 0, size1, size2, i = 0;
        private static Tree idTree1 = null, idTree2 = null, idTree = null;
        private static Tree[] mas;
        private static void Create()
        {
            Color.Print("\n Введите количество элементов для первого дерева: ", ConsoleColor.Yellow);
            size1 = Number.Check(1, int.MaxValue);
            Color.Print("\n Введите количество элементов для второго дерева: ", ConsoleColor.Yellow);
            size2 = Number.Check(1, int.MaxValue);
            mas = new Tree[size1 + size2];
            HowCreate = Text.HowAdd();
            Console.Clear();
        }

        private static Tree IdealTree(int size, Tree p, int typeCreate)
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
        private static Tree IdealTree(int size, Tree p)
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
        private static Tree MakeTree()
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
        private static void ShowTree(Tree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);//переход к левому поддереву
                for (int i = 0; i < l; i++) Console.Write(" ");
                Color.Print(Convert.ToString(p.data) + "\n", ConsoleColor.Cyan);
                ShowTree(p.right, l + 3);//переход к правому поддереву
            }
        }
        private static void Rezult()
        {
            Console.Clear();
            Color.Print("\n Дерево 1:\n\n", ConsoleColor.Green);
            ShowTree(idTree1, 6);
            Color.Print("\n Дерево 2:\n\n", ConsoleColor.Green);
            ShowTree(idTree2, 6);
            i = 0;
            idTree = IdealTree(size1 + size2, idTree);
            Color.Print("\n Итог:\n\n", ConsoleColor.Green);
            ShowTree(idTree, 6);
        }
        static void Main()
        {
            Create();
            idTree1 = IdealTree(size1, idTree1, HowCreate);
            idTree2 = IdealTree(size2, idTree2, HowCreate);
            Rezult();
            Text.GoBackMenu();
        }
    }
}
