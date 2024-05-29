using ChessPuzzleSearcher.Taslar;
using ChessPuzzleSearcher.Tahta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPuzzleSearcher.Tahta
{
    public class Board
    {
        public TasBase[] Taslar()
        {
            List<TasBase> taslar = new List<TasBase>();

            for (int r = 0; r < Length; r++)
            {
                for (int c = 0; c < Length; c++)
                {
                    var cell = Cells[c, r];
                    if (cell.Tas == null) continue;
                    taslar.Add(cell.Tas);
                }

            }

            return taslar.ToArray();
        }


        /// <summary>
        /// Hücreler Sutun, Satır
        /// </summary>
        public Cell[,] Cells { get; }

        public int Length { get; }

        public Board(int length)
        {
            Length = length;

            Cells = new Cell[Length, Length];
            InitCell();
        }


        void InitCell()
        {
            for (int c = 0; c < Length; c++)
            {
                for (int r = 0; r < Length; r++)
                {
                    Cells[c, r] = new Cell(c + 1, r + 1);
                }
            }
        }


        Cell FindCellFormName(string cellName)
        {
            for (int c = 0; c < Length; c++)
            {
                for (int r = 0; r < Length; r++)
                {
                    var ce = Cells[c, r];
                    if (ce.CellName.Equals(cellName)) return ce;

                }
            }
            throw new ArgumentNullException(cellName + " Hücresi Bulunamadı");

        }

        public void SetCell(int c, int r, TasBase tas)
        {
            Cell cell = Cells[c - 1, r - 1];
            cell.Tas = tas;
            tas?.SetCell(cell);
        }


        public void SetCell(Cell hedef, TasBase tasKaynak)
        {
            SetCell(hedef.Col, hedef.Row, tasKaynak);
        }

        public void SetCell(string CellName, TasBase tasKaynak)
        {
            var cellFind = FindCellFormName(CellName);
            SetCell(cellFind.Col, cellFind.Row, tasKaynak);
        }


        public Cell GetCell(int c, int r)
        {
            return Cells[c - 1, r - 1];
        }



        public string BoardText()
        {
            var sb = new StringBuilder();
            for (int r = 0; r < Length; r++)
            {
                for (int c = 0; c < Length; c++)
                {
                    var cell = Cells[c, r];
                    sb.Append(cell.CellDisplayText());
                }
                sb.AppendLine();
            }

            return sb.ToString();

        }


    }
}
