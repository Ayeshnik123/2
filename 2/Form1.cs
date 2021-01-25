using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibMas;
using Lib_3;

namespace _2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // при загрузке формы определяем размер таблиц
        private void Form1_Shown(object sender, EventArgs e)
        {
            table.ColumnCount = 5;
            table.RowCount = 1;
        }

        // заполнить таблицу
        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int min,
                max;

            min = Convert.ToInt32(nUDMin.Value);
            max = Convert.ToInt32(nUDMax.Value);

            LibMas.WorkingWithArray.Fill(table, min, max);
        }

        // очистить таблицу
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.Clear(table);
        }

        // расчиттать 
        private void расчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rez = Class1.Go(table);
            textBox1.Text = rez.ToString();
        }

        // сохранить исходную таблицу
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.SaveFile(table);
        }

        // открыть исходную таблицу
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibMas.WorkingWithArray.OpenFile(table);
        }

        // при изменении диапазона на форме изменять кол-во столбцов обеих таблиц
        private void nUDColumn_ValueChanged(object sender, EventArgs e)
        {
            table.ColumnCount = Convert.ToInt32(nUDColumn.Value);
        }

        // о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ввести n целых чисел. Найти разницу чисел. Результат вывести на экран.");
        }
        string dop;
        private void table_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (table.CurrentCell.Value != null) dop = table.CurrentCell.Value.ToString();
        }

        private void table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(table.CurrentCell.Value);
            }
            catch
            {
                // выводим подсказку 
                MessageBox.Show("Введите целое число");
                // возвращаем ячейке предыдущее значение (до измемения)
                table.CurrentCell.Value = dop;
            }
        }
    }
}
