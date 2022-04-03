using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

namespace NcadSpdsTable_APP
{
    public partial class GlobalFormApp : Form
    {
        public GlobalFormApp()
        {
            InitializeComponent();
        }

        private void btnMergeAllTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbRowsInTitleTable.Text))
                {
                    MessageBox.Show("Введите количество строк в шапке таблицы,\n если их нет то введите 0");
                    return;
                }
                GetTable WorkTableInForms = new GetTable();
                ProcessingSpdsTable WorkProcessTable = new ProcessingSpdsTable();

                int RowsInTitleInputUser = Convert.ToInt32(tbRowsInTitleTable.Text);

                WorkTableInForms.GetAllTableInModelspace();
                WorkProcessTable.SummUserOrAllTable(WorkTableInForms.SelectedTableForWork, RowsInTitleInputUser);
            }
            catch( Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return;
            }         
        }
        
        private void btnMergeUserTable_Click(object sender, EventArgs e)
        {
            try
            {
                GetTable WorkTableInForms = new GetTable();
                ProcessingSpdsTable WorkProcessTable = new ProcessingSpdsTable();

                if(string.IsNullOrEmpty(tbRowsInTitleTable.Text))
                {
                    MessageBox.Show("Введите количество строк в шапке таблицы \n если их нет то введите 0");
                    return;
                }

                int RowsInTitleInputUser = Convert.ToInt32(tbRowsInTitleTable.Text);

                WorkTableInForms.GetUserSeveralTable();
                WorkProcessTable.SummUserOrAllTable(WorkTableInForms.SelectedTableForWork, RowsInTitleInputUser);
            }
            catch( Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return;
            }
        }

        private void btnMergeUserTableHorizontal_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbRowsInTitleTable.Text))
                {
                    MessageBox.Show("Введите количество строк в шапке таблицы,\n если их нет то введите 0");
                    return;
                }
                GetTable WorkTableInForms = new GetTable();
                ProcessingSpdsTable WorkProcessTable = new ProcessingSpdsTable();

                int RowsInTitleInputUser = Convert.ToInt32(tbRowsInTitleTable.Text);

                WorkTableInForms.GetUserSeveralTable();
                WorkProcessTable.SummUserOrAllTableHorizontaly(WorkTableInForms.SelectedTableForWork, RowsInTitleInputUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return;
            }
        }

        private void tbRowsInTitleTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            // проверка символов по таблице ANSI
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar !=13)
                e.Handled = true;
        }


    }
}
