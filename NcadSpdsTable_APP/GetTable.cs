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
    class GetTable
    {
       public McObjectId[] SelectedTableForWork;
        public  void GetAllTableInModelspace() // Выбор всех объектов типа таблица
        {
             McObjectId[] SelectedTable = ObjectFilter.Create(true).AddType(McTable.TypeID).GetObjects().ToArray();
             
            if (SelectedTable == null || SelectedTable.Length == 0 || SelectedTable.Length == 1)
            {
                MessageBox.Show("В чертеже нет таблиц СПДС\n или таблица одна");
                return;
            }
          SelectedTableForWork = SelectedTable; 
         }
        public void GetUserSeveralTable() // пользовательский выбор нескольких таблиц 
        {
            McObjectId[] SelectedTable = McObjectManager.SelectObjects("Выберите таблицы и нажмите Enter");

          // получаем выбранное в объекты массива(для проверок)
          McObject[] TargetUserObj = new McObject[SelectedTable.Length];
          for(int i=0; i < SelectedTable.Length; i++)
          {
            TargetUserObj[i] = SelectedTable[i].GetObject();
          }

            // проверка что объектов больше одного
            if (SelectedTable.Length == 0 || SelectedTable.Length == 1)
            {
                MessageBox.Show("Не выбрано ни одного объекта или только один");
                return;
            }
  
            McTable TestTable = new McTable();
            for (int i = 0; i < TargetUserObj.Length; i++)
            {
                if (Object.ReferenceEquals(TargetUserObj[i].GetType(),TestTable.GetType()) == false)// проверка что таблицы в массив идут
               {
                   MessageBox.Show("Один из выбранных объектов не таблица");
                   return;
               }           
            }
            SelectedTableForWork = SelectedTable; 
        }

        public void GetUserOneTable()
        {
            McObjectId SelectTable = McObjectManager.SelectObject("Выберите таблицу и нажмите Enter");
            McTable TestTable = new McTable();

            if (Object.ReferenceEquals(SelectTable.GetType(), TestTable.GetType()))// проверка что таблицы в массив идут
            {
                SelectedTableForWork[0] = SelectTable;
            }
            else
            {
                MessageBox.Show("Выбрана не таблица");
                return;
            }

        }
   
    }
}
