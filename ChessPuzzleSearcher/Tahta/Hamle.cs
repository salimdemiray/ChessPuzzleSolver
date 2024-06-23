using ChessPuzzleSearcher.Taslar;
using System;

namespace ChessPuzzleSearcher.Tahta
{
    public class Hamle
    {
        public Hamle(Cell kaynak, Cell hedef)
        {
            Kaynak = kaynak;
            Hedef = hedef;
            TasKaynak = TasBase.Copy(kaynak.Tas);
            TasHedef = TasBase.Copy(hedef.Tas);

        }

        public TasBase TasKaynak { get; set; }
        public TasBase TasHedef { get; }
        public Cell Kaynak { get; set; }
        public Cell Hedef { get; set; }

        public override int GetHashCode()
        {
            return string.Join("-", TasKaynak.GetHashCode(), Kaynak.GetHashCode(), Hedef.GetHashCode()).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hamle)) return false;
            return (obj as Hamle)?.GetHashCode() == GetHashCode();
        }

        public override string ToString()
        {
            return string.Join("-", TasKaynak.TasHarf, Kaynak.CellName, Hedef.CellName);
        }
    }
}