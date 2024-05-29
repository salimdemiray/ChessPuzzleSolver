using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;

namespace ChessPuzzleSearcher.Taslar
{
    public class Vezir : TasBase
    {
        public override string TasHarf => "V";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).ToKale(board.Length).ToFil(board.Length).Hamleler();
        }
    }
}
