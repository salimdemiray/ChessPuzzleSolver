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
        public TasRenk Renk { get; set; }

        protected TasBase()
        {
            //TasId = TaskCounter++;
            Renk = TasRenk.White;
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

        public string PrintTas()
        {
            return Renk == TasRenk.White ? TasHarf.ToUpper() : TasHarf.ToLower();
        }

        public static TasBase Copy(TasBase source)
        {
            if (source == null) return null;

            var target = (TasBase)Activator.CreateInstance(source.GetType());

            target.SetTasId(source.TasId);
            target.Renk = source.Renk;

            return target;
        }

        public static TasBase TextToTas(string tasText)
        {
            TasBase tas = null;
            switch (tasText)
            {
                case "K":
                    tas = new Kale();
                    break;
                case "A":
                    tas = new At();
                    break;
                case "F":
                    tas = new Fil();
                    break;
                case "Ş":
                    tas = new Sah();
                    break;
                case "V":
                    tas = new Vezir();
                    break;
                case "P":
                    tas = new Piyon();
                    break;


                default:
                    throw new ArithmeticException(tasText + " Taş Tanımı Yok");
            }

            return tas;
        }

    }
}
