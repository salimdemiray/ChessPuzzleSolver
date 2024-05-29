using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;

namespace ChessPuzzleSearcher.Taslar
{
    public class Fil : TasBase
    {
        public override string TasHarf => "F";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).ToFil(board.Length).Hamleler();
        }
    }

}
