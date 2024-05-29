using ChessPuzzleSearcher.Tahta;
using System.Collections.Generic;
using System.Linq;

namespace ChessPuzzleSearcher.Taslar.HamleOps
{
    public class HamleHelper
    {
        readonly TasBase _Tas;
        readonly Board _Board;
        readonly List<Hamle> _Hamleler;

        public HamleHelper(TasBase tas, Board board)
        {
            _Tas = tas;
            _Board = board;
            _Hamleler = new List<Hamle>();
        }

        public static HamleHelper Init(TasBase tas, Board board)
        {
            return new HamleHelper(tas, board);
        }

        #region Kale
        public HamleHelper ToLeft(int length)
        {
            var curCell = _Tas.Cell.Col;

            for (int i = 1; i <= length; i++)
            {
                curCell--;
                if (curCell <= 0) break;
                var cell = _Board.GetCell(curCell, _Tas.Cell.Row);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToRight(int length)
        {
            var curCell = _Tas.Cell.Col;

            for (int i = 1; i <= length; i++)
            {
                curCell++;
                if (curCell > _Board.Length) break;
                var cell = _Board.GetCell(curCell, _Tas.Cell.Row);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToDown(int length)
        {
            var curCell = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                curCell++;
                if (curCell > _Board.Length) break;
                var cell = _Board.GetCell(_Tas.Cell.Col, curCell);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToUp(int length)
        {
            var curCell = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                curCell--;
                if (curCell <= 0) break;
                var cell = _Board.GetCell(_Tas.Cell.Col, curCell);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToKale(int length)
        {
            return ToLeft(length).ToRight(length).ToDown(length).ToUp(length);
        }
        #endregion

        #region Fil

        public HamleHelper ToLeftUp(int length)
        {
            var cCol = _Tas.Cell.Col;
            var cRow = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                cCol--;
                cRow--;

                if (cCol <= 0 || cRow <= 0) break;
                var cell = _Board.GetCell(cCol, cRow);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToLeftDown(int length)
        {
            var cCol = _Tas.Cell.Col;
            var cRow = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                cCol--;
                cRow++;

                if (cCol <= 0 || cRow > _Board.Length) break;
                var cell = _Board.GetCell(cCol, cRow);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }



        public HamleHelper ToRightUp(int length)
        {
            var cCol = _Tas.Cell.Col;
            var cRow = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                cCol++;
                cRow--;

                if (cRow <= 0 || cCol > _Board.Length) break;
                var cell = _Board.GetCell(cCol, cRow);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToRightDown(int length)
        {
            var cCol = _Tas.Cell.Col;
            var cRow = _Tas.Cell.Row;

            for (int i = 1; i <= length; i++)
            {
                cCol++;
                cRow++;

                if (cRow > _Board.Length || cCol > _Board.Length) break;
                var cell = _Board.GetCell(cCol, cRow);
                if (cell.Tas == null) continue;

                _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));
                break;
            }
            return this;
        }

        public HamleHelper ToFil(int length)
        {
            return ToRightDown(length).ToRightUp(length).ToLeftDown(length).ToLeftUp(length);
        }





        #endregion


        #region At Hamle

        readonly int[] Hamle2 = { -2, 2 };
        readonly int[] Hamle1 = { -1, 1 };

        public HamleHelper AtMove()
        {
            var cCol = _Tas.Cell.Col;
            var cRow = _Tas.Cell.Row;

            for (int sira = 1; sira <= 2; sira++)
                foreach (var h2 in Hamle2)
                    foreach (var h1 in Hamle1)
                    {
                        int c, r;

                        switch (sira)
                        {
                            case 1: //2 Yi Satıra Ekle

                                c = _Tas.Cell.Col + h2;
                                r = _Tas.Cell.Row + h1;
                                break;

                            default:
                                c = _Tas.Cell.Col + h1;
                                r = _Tas.Cell.Row + h2;
                                break;
                        }
                        // if (cRow > _Board.Length || cCol > _Board.Length) break;

                        if (c <= 0 || c > _Board.Length || r <= 0 || r > _Board.Length) continue;
                        var cell = _Board.GetCell(c, r);
                        if (cell.Tas == null) continue;
                        _Hamleler.Add(new Hamle(_Tas, _Tas.Cell, cell));

                    }
            return this;
        }


        #endregion


        public Hamle[] Hamleler()
        {
            return _Hamleler.Distinct().ToArray();
        }

    }


}
