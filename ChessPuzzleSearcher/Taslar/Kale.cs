using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;
using System;

namespace ChessPuzzleSearcher.Taslar
{
    [Serializable]
    public class Kale : TasBase
    {
        public override string TasHarf => "K";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).ToKale(board.Length).Hamleler();
        }
    }

}
