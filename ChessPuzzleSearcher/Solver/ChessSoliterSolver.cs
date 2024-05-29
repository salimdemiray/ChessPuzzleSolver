using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPuzzleSearcher.Tahta;

namespace ChessPuzzleSearcher.Solver
{
    public class ChessSoliterSolver
    {
        readonly Board _Board;
        readonly List<Hamle> Cozum = new List<Hamle>();

        public ChessSoliterSolver(Board board)
        {
            _Board = board;

        }

        public bool Solve()
        {
            var taslar = _Board.Taslar();
            if (taslar.Length == 1)
            {
                WriteSolver();

                return true;
            }

            foreach (var tas in taslar)
            {
                var hamleler = tas.OlasiHamleler(_Board);
                if (hamleler.Length == 0) continue;

                foreach (var hamle in hamleler)
                {
                    _Board.SetCell(hamle.Hedef, hamle.TasKaynak);
                    _Board.SetCell(hamle.Kaynak, null);

                    Cozum.Add(hamle);

                    var canMove = Solve();
                    if (canMove) return canMove;

                    Cozum.Remove(hamle);
                    _Board.SetCell(hamle.Hedef, hamle.TasHedef);
                    _Board.SetCell(hamle.Kaynak, hamle.TasKaynak);
                }
            }
            return false;
        }

        void WriteSolver()
        {
            Console.WriteLine("Çözüm");

            foreach (var h in Cozum)
            {
                Console.WriteLine(h);
            }

            var totalText = string.Join(" ", Cozum.Select(n => n.Kaynak.ToString().ToLower() + n.Hedef.ToString().ToLower()));
            Console.WriteLine(totalText);
        }
    }
}
