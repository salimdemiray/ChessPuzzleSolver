using ChessPuzzleSearcher.Taslar;

namespace ChessPuzzleSearcher.Tahta
{
    public class Cell
    {
        public int Row { get; }
        public int Col { get; }

        public TasBase Tas { get; set; }

        public string CellName { get; }

        public Cell(int col, int row)
        {
            Row = row;
            Col = col;

            CellName = string.Format("{0}{1}", (char)('A' + Col - 1), 9 - Row);
        }

        public string CellDisplayText()
        {
            return Tas == null ? "_" : Tas.PrintTas();
        }

        public override int GetHashCode()
        {
            return CellName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Cell)) return false;
            return (obj as Cell)?.GetHashCode() == GetHashCode();
        }

        public override string ToString()
        {
            return CellName;
        }


    }
}
