using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_3
{
    public class Class1
    {
        // Ввести n целых чисел. Найти разницу чисел. Результат вывести на экран.
        public static int Go(DataGridView sourceTable)
        {
            int dop,
                rez = -1;
            if (Int32.TryParse(Convert.ToString(sourceTable[0, 0].Value), out rez))
            {
                for (int i = 1; i < sourceTable.ColumnCount; i++)
                {
                    if (Int32.TryParse(Convert.ToString(sourceTable[i, 0].Value), out dop))
                    {
                        rez -= dop;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка конвертации!");
                        return rez;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка конвертации!");
                return rez;
            }
            return rez;
        }
    }
}
