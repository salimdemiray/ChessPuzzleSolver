using ChessPuzzleSearcher.Solver;
using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar;
using ChessPuzzleSearcher.Taslar.HamleOps;
using System;
using System.Linq;

namespace ChessPuzzleSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new Board(8);
            if (args.Length > 0)
            {
                SetBord(b, args[0]);
                ChessSoliterSolver solver1 = new ChessSoliterSolver(b);
                solver1.Solve();
                return;
            }


            //SetBord(b, "C6:F;C5:K,C4:A;C3:F,D4:A,D3:P;e5:Ş;F5:P");
            //SetBord(b, "C6:A;C4:F;D6:K;D3:A;e4:Ş;E3:P;f5:p;f3:K");
            SetBord(b, "D6:K;D4:K;F4:F;C3:F");

            //Puzzle1(b);

            Console.WriteLine(b.BoardText());


            ChessSoliterSolver solver = new ChessSoliterSolver(b);
            solver.Solve();
            Console.ReadLine();
        }

        static void SetBord(Board b, string boardText)
        {
            var taslar = b.Taslar();

            foreach (var tas in taslar)
            {
                b.SetCell(tas.Cell, null);
            }

            var hamleTextleri = boardText.Split(";,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Trim())
                .ToArray();

            //C6:F;C5:K,C4:A;C3:F,D4:A,D3:P;e5:Ş;F5:P

            foreach (var hamleText in hamleTextleri)
            {
                var sdHamle = hamleText.Split(':');
                if (sdHamle.Length != 2) throw new ArithmeticException(hamleText + " Hamle Hatalı");

                var cellName = sdHamle[0].ToUpper();
                var tasText = sdHamle[1].ToUpper();

                TasBase tas = null;
                switch (tasText)
                {
                    case "K":
                        tas = new Kale();
                        break;
                    case "A":
                        tas = new At();
                        break;
                    case "F":
                        tas = new Fil();
                        break;
                    case "Ş":
                        tas = new Sah();
                        break;
                    case "V":
                        tas = new Vezir();
                        break;
                    case "P":
                        tas = new Piyon();
                        break;


                    default:
                        throw new ArithmeticException(tasText + " Taş Tanımı Yok");
                }
                b.SetCell(cellName, tas);
            }
        }



        static void Puzzle1(Board b)
        {
            b.SetCell(5, 3, new Kale());
            b.SetCell(5, 4, new Piyon());
            b.SetCell(6, 5, new At());
            b.SetCell(5, 6, new Piyon());
        }

        static void Puzzle2(Board b)
        {
            b.SetCell(5, 3, new Kale());
            b.SetCell(5, 4, new Piyon());
            b.SetCell(6, 5, new At());
            b.SetCell(5, 6, new Piyon());
        }



    }
}
