using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;

namespace ChessPuzzleSearcher.Taslar
{
    public class Piyon : TasBase
    {
        public override string TasHarf => "P";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).ToLeftUp(1).ToRightUp(1).Hamleler();
        }
    }

}
