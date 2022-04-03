using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using Multicad;
using Multicad.AplicationServices;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;
using Multicad.Geometry;
using Multicad.Runtime;
using Multicad.Symbols;
using Multicad.Symbols.Tables;

namespace NcadSpdsTable_APP
{
    class ProcessingSpdsTable
    {
        public void SummUserOrAllTable(McObjectId[] tables, int cntTrimRowsInTitle)
        {

            if (CheckTrimRowsCountForAllTbl(tables, cntTrimRowsInTitle) == false)
            {
                return;
            }

            //определение числа общего количества строк для всех таблиц и кол-ва столбцов в первой таблице.
            int countAllTable = tables.Length; // количество таблиц
            int SummAllRows = 0;
            int CountСolumsFirstTable = 0;

            McObject tmpOutObjForColums = McObjectManager.GetObject(tables[0]);
            McTable OutObjForColums = tmpOutObjForColums as McTable;
            CountСolumsFirstTable = OutObjForColums.Columns.Count;

            for (int i = 0; i < tables.Length; i++)
            {
                McObject tmpOutObjForRows = McObjectManager.GetObject(tables[i]);
                McTable OutObjForRows = tmpOutObjForRows as McTable; 
                SummAllRows = SummAllRows + OutObjForRows.Rows.Count;
            }

            //создание таблицы по сумме всех строк 
            McTable Bigtable = new McTable();
            int RowCount = SummAllRows;
            int ColCount = CountСolumsFirstTable;
            int RowCountForBigTable = SummAllRows - (countAllTable * cntTrimRowsInTitle); // здесь  число строк в шапке
            Bigtable.Rows.AddRange(0, RowCountForBigTable);
            Bigtable.Columns.AddRange(0, ColCount);


            McUndoPoint undo = new McUndoPoint();
            undo.Start();
            int rowsStartCount = 0;
            for (int i = 0; i < tables.Length; i++)
            {
                McObject tmpoutObj = McObjectManager.GetObject(tables[i]);
                McTable outObj = tmpoutObj as McTable;
                outObj.Rows.DeleteRange(0, cntTrimRowsInTitle); // здесь CountTrimRowsInTitle число строк в шапке, вводимое пользователем.
                rowsStartCount = rowsStartCount + outObj.Rows.Count;
                Bigtable.InsertSubtable(outObj, rowsStartCount - outObj.Rows.Count, 0, InsertionModeEnum.CellByCell);
            }
            undo.Undo();
            Bigtable.PlaceObject(McEntity.PlaceFlags.Silent);

        }

        public void SummUserOrAllTableHorizontaly(McObjectId[] tablesObj, int cntTrimRowsInTitle)
        {
            if (CheckTrimRowsCountForAllTbl(tablesObj, cntTrimRowsInTitle) == false) 
            {
                return;
            }

            //Cast
            List<McTable> tables = new List<McTable>();
            for (int i = 0; i < tablesObj.Length; i++)
            {
                McObject tmpObj = McObjectManager.GetObject(tablesObj[i]);
                McTable tmpTbl = tmpObj as McTable;
                tables.Add(tmpTbl);
            }

            int maxRows = tables.Max(tbl => tbl.Rows.Count) - cntTrimRowsInTitle;
            int maxColumns = tables.Sum(tbl => tbl.Columns.Count);

            //создание таблицы по сумме всех столбцов
            McTable bigTbl = new McTable();
            bigTbl.Rows.AddRange(0, maxRows);
            bigTbl.Columns.AddRange(0, maxColumns);

            McUndoPoint undo = new McUndoPoint();
            undo.Start();
            foreach (McTable tbl in tables)
            {
                tbl.Rows.DeleteRange(0, cntTrimRowsInTitle);

                //for (int i = 0; i < tbl.Columns.Count; i++)
                //{
                //    bigTbl.Columns[i].Cells. = tbl.Columns
                //}
                //foreach (var item in tbl.Columns)
                //{
                //    bigTbl.Columns[i].Cells = 
                //    bigTbl.
                //}
                bigTbl.InsertSubtable(tbl, maxRows, tbl.Columns.Count, InsertionModeEnum.CellByCell);
            }
            undo.Undo();
            bigTbl.PlaceObject(McEntity.PlaceFlags.Silent);

        }

        // проверка что количество строк обрезаемых меньше кол-ва строк в таблице
        private bool CheckTrimRowsCountForAllTbl(McObjectId[] tables, int cntTrimRowsInTitle)
        {
            bool isTblsCanTrimmed = true;

            for (int i = 0; i < tables.Length; i++)
            {
                McObject tmpCheckRows = McObjectManager.GetObject(tables[i]);
                McTable tbl = tmpCheckRows as McTable;

                if (tbl.Rows.Count <= cntTrimRowsInTitle)
                {
                    MessageBox.Show("Количество обрезаемых строк \n превышает кол-во строк таблицы");
                    isTblsCanTrimmed = false;
                }

            }

            return isTblsCanTrimmed;
        }

        public void AutoSummValueInTableRows(McTable SelectTable)
        {
            //сортировка?
            bool x = true;
            x= SelectTable.Rows.UpToDown;

            McTable ResultTable = new McTable();


            for(int  i=1; i< SelectTable.Rows.Count; i++ )
            {
                string TableCellValue1 = SelectTable[i,2].ToString();
                string TableCellValue2 = SelectTable[i+1,2].ToString();

                //сравниваем
               int Result = TableCellValue1.CompareTo(TableCellValue2);
                if(Result != 0)
                {
                    // здесь нужно вносить данные в суммирующую таблицу
                    // надо счетчик добавлений строк в новой таблице как то сделать
                }
            }


        }
    }
}