using ChessPuzzleSearcher.Tahta;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ChessPuzzleSearcher.Taslar
{
    [Serializable]
    public abstract class TasBase
    {
        //static int TaskCounter = 1;
        public int TasId { get; private set; }
        public abstract string TasHarf { get; }
        public Cell Cell { get; private set; }

        protected TasBase()
        {
            //TasId = TaskCounter++;
        }

        public void SetCell(Cell cell)
        {
            Cell = cell;
        }

        public abstract Hamle[] OlasiHamleler(Board board);

        protected Hamle[] KaleHamleleri()
        {
            return null;
        }

        protected Hamle[] FilHamleleri()
        {
            return null;
        }

        public override int GetHashCode()
        {
            return TasId;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TasBase)) return false;
            return (obj as TasBase).TasId == TasId;
        }

        public void SetTasId(int tasId)
        {
            TasId = tasId;
        }

    }


}
