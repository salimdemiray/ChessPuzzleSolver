using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;

namespace ChessPuzzleSearcher.Taslar
{
    public class At : TasBase
    {
        public override string TasHarf => "A";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).AtMove().Hamleler();
        }
    }

}
