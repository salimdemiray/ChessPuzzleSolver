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
                SoliterChessSolver solver1 = new SoliterChessSolver(b);
                solver1.Solve();
                return;
            }

            //Soliter Çözümleri
            //SetBord(b, "C6:F;C5:K,C4:A;C3:F,D4:A,D3:P;e5:Ş;F5:P");
            //SetBord(b, "C6:A;C4:F;D6:K;D3:A;e4:Ş;E3:P;f5:p;f3:K");
            //SetBord(b, "D6:K;D4:K;F4:F;C3:F"); 

            //Puzzle1(b);


            //Solo Çözümleri
            //SetBord(b, "C6:Ş;D6:P;E6:P;D5:F;D4:A");
            SetBord(b, " C6:Ş;D5:F;E5:K;F5:F;C4:P;D4:A;F4:A;E3:P");

            //SetBord(b, "C6:PB;D5:FB;E5:KB;F5:F;C4:P;D4:A;F4:A;E3:P");
            //SetBord(b, "C6:PB;D5:FB");
            var s = new SoloChessSolver(b);
            s.Solve();
            Console.WriteLine(b.BoardText());


            //SoliterChessSolver solver = new SoliterChessSolver(b);
            //solver.Solve();
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
            int index = 1;
            foreach (var hamleText in hamleTextleri)
            {
                var sdHamle = hamleText.Split(':');
                if (sdHamle.Length != 2) throw new ArithmeticException(hamleText + " Hamle Hatalı");

                var cellName = sdHamle[0].ToUpper();
                var tasBilgisi = sdHamle[1];

                var tasText = tasBilgisi.Trim()[0].ToString().ToUpper();

                var ColorText = "W";

                if (tasBilgisi.Length == 2)
                {
                    ColorText = tasBilgisi.Substring(1, 1).ToUpper();
                }

                TasBase tas = TasBase.TextToTas(tasText);

                if (ColorText == "B") tas.Renk = TasRenk.Black;
                tas.SetTasId(index++);
                b.SetCell(cellName, tas);
            }
        }


    }
}
