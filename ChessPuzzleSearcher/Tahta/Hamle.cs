using System;
using ChessPuzzleSearcher.Taslar;
using Newtonsoft.Json;

namespace ChessPuzzleSearcher.Tahta
{
    public class Hamle
    {
        public Hamle(TasBase tas, Cell kaynak, Cell hedef)
        {
            TasKaynak = (TasBase)Activator.CreateInstance(tas.GetType());
            Kaynak = kaynak;
            Hedef = hedef;
            TasHedef = (TasBase)Activator.CreateInstance(hedef.Tas.GetType());
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




    //using Newtonsoft.Json;


}
