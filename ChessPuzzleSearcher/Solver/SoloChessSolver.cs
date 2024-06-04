using System;
using System.Collections.Generic;
using System.Linq;
using ChessPuzzleSearcher.Tahta;

namespace ChessPuzzleSearcher.Solver
{
    /// <summary>
    /// Solo Kuralları
    /// 1 Taş Sadece 2 kere oynayabilir
    /// ve Hiç bir Taş Şahı Yiyemez
    /// </summary>
    public class SoloChessSolver : IChessPuzzleSolver
    {
        readonly Board _Board;
        readonly List<Hamle> Cozum = new List<Hamle>();
        readonly Dictionary<int, int> PiecePlayCount;



        public SoloChessSolver(Board board)
        {
            _Board = board;
            PiecePlayCount = new Dictionary<int, int>();
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

                if (PiecePlayCount.TryGetValue(tas.TasId, out int OutCount) && OutCount == 2)
                {
                    continue;
                }

                //if (LockedTast.Contains(tas)) continue;

                foreach (var hamle in hamleler)
                {
                    if (hamle.TasHedef is Taslar.Sah) continue;


                    _Board.SetCell(hamle.Hedef, hamle.TasKaynak);
                    _Board.SetCell(hamle.Kaynak, null);

                    Cozum.Add(hamle);

                    OutCount++;
                    PiecePlayCount[tas.TasId] = OutCount;

                    var canMove = Solve();
                    if (canMove) return canMove;

                    Cozum.Remove(hamle);
                    PiecePlayCount[tas.TasId] = --OutCount;
                    _Board.SetCell(hamle.Hedef, hamle.TasHedef);
                    _Board.SetCell(hamle.Kaynak, hamle.TasKaynak);

                    //if (isLocked) LockedTast.Remove(preTas);
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
