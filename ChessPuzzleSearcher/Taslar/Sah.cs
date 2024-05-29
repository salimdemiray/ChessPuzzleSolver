using ChessPuzzleSearcher.Tahta;
using ChessPuzzleSearcher.Taslar.HamleOps;

namespace ChessPuzzleSearcher.Taslar
{
    public class Sah : TasBase
    {
        public override string TasHarf => "$";

        public override Hamle[] OlasiHamleler(Board board)
        {
            return HamleHelper.Init(this, board).ToKale(1).ToFil(1).Hamleler();
        }
    }

}
