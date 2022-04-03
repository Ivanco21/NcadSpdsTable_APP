using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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
        public void SummUserOrAllTable(McObjectId[] SelectedTable, int CountTrimRowsInTitle)
        {

            // проверка что количество строк обрезаемых меньше кол-ва строк в таблице
            for (int i = 0; i < SelectedTable.Length; i++)
            {
                McObject tmpCheckRows = McObjectManager.GetObject(SelectedTable[i]);
                McTable CheckRows = tmpCheckRows as McTable;

                if (CheckRows.Rows.Count <= CountTrimRowsInTitle)
               {
                   MessageBox.Show("Количество обрезаемых строк \n превышает кол-во строк таблицы");
                   return;
               }

            }
            
            //определение числа общего количества строк для всех таблиц и кол-ва столбцов в первой таблице.
            int CountAllTable = SelectedTable.Length; // количество таблиц
            int SummAllRows = 0;
            int CountСolumsFirstTable = 0;

            McObject tmpOutObjForColums = McObjectManager.GetObject(SelectedTable[0]);
            McTable OutObjForColums = tmpOutObjForColums as McTable;
            CountСolumsFirstTable = OutObjForColums.Columns.Count;

            for (int i = 0; i < SelectedTable.Length; i++)
            {
                McObject tmpOutObjForRows = McObjectManager.GetObject(SelectedTable[i]);
                McTable OutObjForRows = tmpOutObjForRows as McTable; 
                SummAllRows = SummAllRows + OutObjForRows.Rows.Count;
            }

            //создание таблицы по сумме всех строк 
            McTable Bigtable = new McTable();
            int RowCount = SummAllRows;
            int ColCount = CountСolumsFirstTable;
            int RowCountForBigTable = SummAllRows - (CountAllTable * CountTrimRowsInTitle); // здесь  число строк в шапке
            Bigtable.Rows.AddRange(0, RowCountForBigTable);
            Bigtable.Columns.AddRange(0, ColCount);


            McUndoPoint undo = new McUndoPoint();
            undo.Start();
            int rowsStartCount = 0;
            for (int i = 0; i < SelectedTable.Length; i++)
            {
                McObject tmpoutObj = McObjectManager.GetObject(SelectedTable[i]);
                McTable outObj = tmpoutObj as McTable;
                outObj.Rows.DeleteRange(0, CountTrimRowsInTitle); // здесь CountTrimRowsInTitle число строк в шапке, вводимое пользователем.
                rowsStartCount = rowsStartCount + outObj.Rows.Count;
                Bigtable.InsertSubtable(outObj, rowsStartCount - outObj.Rows.Count, 0, InsertionModeEnum.CellByCell);
            }
            undo.Undo();
            Bigtable.PlaceObject(McEntity.PlaceFlags.Silent);

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