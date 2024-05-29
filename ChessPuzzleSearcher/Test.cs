using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar;
using ChessPuzzleSearcher.Taslar.HamleOps;
using System;
using System.Linq;

namespace ChessPuzzleSearcher
{
    public class Test
    {
        void TestKaleMove()
        {
            var b = new Board(8);

            var v1_1 = new Vezir();
            var v8_1 = new Vezir();

            b.SetCell(1, 1, v1_1);
            b.SetCell(8, 1, v8_1);

            var v1_2 = new Vezir();
            var v4_2 = new Vezir();
            var v8_2 = new Vezir();

            b.SetCell(1, 2, v1_2);
            b.SetCell(4, 2, v4_2);
            b.SetCell(8, 2, v8_2);


            var v1_8 = new Vezir();
            b.SetCell(1, 8, v1_8);

            Console.WriteLine(b.BoardText());






            //var h11 = HamleHelper.Init(v1_1, b).ToRight().Hamleler();

            //Console.WriteLine(string.Join("|", h11.Select(n => n.ToString())));

            //var h81 = HamleHelper.Init(v8_1, b).ToLeft().Hamleler();
            //Console.WriteLine(string.Join("|", h81.Select(n => n.ToString())));

            //var h45 = HamleHelper.Init(v4_2, b).ToKale().Hamleler();
            //Console.WriteLine(string.Join("|", h45.Select(n => n.ToString())));
            //Console.WriteLine(string.Join("|", v4_2.OlasiHamleler(b).Select(n => n.ToString())));


            var h12 = HamleHelper.Init(v1_2, b).ToKale(8).Hamleler();
            Console.WriteLine(string.Join("|", h12.Select(n => n.ToString())));
        }

        void FillTest()
        {
            var b = new Board(8);

            b.SetCell(1, 1, new Vezir());
            b.SetCell(8, 1, new Vezir());
            b.SetCell(1, 8, new Vezir());
            b.SetCell(8, 8, new Vezir());

            Console.WriteLine(b.BoardText());

            var h11 = HamleHelper.Init(b.GetCell(8, 8).Tas, b).ToLeftUp(8).Hamleler();

            Console.WriteLine("ToLeftUp:" + string.Join("|", h11.Select(n => n.ToString())));

            h11 = HamleHelper.Init(b.GetCell(8, 1).Tas, b).ToLeftDown(8).Hamleler();

            Console.WriteLine("ToLeftDown:" + string.Join("|", h11.Select(n => n.ToString())));


            h11 = HamleHelper.Init(b.GetCell(1, 8).Tas, b).ToRightUp(8).Hamleler();

            Console.WriteLine("ToRightUp:" + string.Join("|", h11.Select(n => n.ToString())));

            h11 = HamleHelper.Init(b.GetCell(1, 1).Tas, b).ToRightDown(8).Hamleler();

            Console.WriteLine("ToRightDown:" + string.Join("|", h11.Select(n => n.ToString())));


            b.SetCell(3, 3, new Vezir());
            b.SetCell(4, 3, new Vezir());
            b.SetCell(5, 3, new Vezir());

            b.SetCell(3, 4, new Vezir());
            b.SetCell(4, 4, new Vezir());
            b.SetCell(5, 4, new Vezir());

            b.SetCell(3, 5, new Vezir());
            b.SetCell(4, 5, new Vezir());
            b.SetCell(5, 5, new Vezir());

            Console.WriteLine(b.BoardText());
            h11 = HamleHelper.Init(b.GetCell(4, 4).Tas, b).ToFil(8).Hamleler();

            Console.WriteLine("ToFil:" + string.Join("|", h11.Select(n => n.ToString())));

            h11 = b.GetCell(4, 4).Tas.OlasiHamleler(b);

            Console.WriteLine("ToVezir:" + string.Join("|", h11.Select(n => n.ToString())));

            //var v1_1 = new Vezir();
        }

        void AtTest()
        {
            var b = new Board(8);

            for (int c = 2; c <= 6; c++)
                for (int r = 2; r <= 6; r++)
                {
                    b.SetCell(c, r, new Piyon());
                }


            b.SetCell(4, 4, new At());

            Console.WriteLine(b.BoardText());

            var h11 = HamleHelper.Init(b.GetCell(4, 4).Tas, b).AtMove().Hamleler();

            Console.WriteLine("ToRightDown:" + string.Join("|", h11.Select(n => n.ToString())));

        }
    }
}
