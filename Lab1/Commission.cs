using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    class Commission
    {
        private string _commissionName;

        public Commission(string name)
        {
            this.CommissionName = name;
        }

        public static void getComissions(DataGridView dataGridView, IObjectContainer db)
        {
            dataGridView.Rows.Clear();
            if (!dataGridView.Columns.Contains("CommissionName"))
            {
                dataGridView.Columns.Add("CommissionName", "Название комиссии");
            }
            IQuery query = db.Query();
            query.Constrain(typeof(Commission));
            IObjectSet commissions = query.Execute();
            foreach (Commission c in commissions)
            {
                dataGridView.Rows.Add(c.CommissionName);
            }
        }

        public static void AddCommission(string name)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                Commission commission = new Commission(name);
                db.Store(commission);
                db.Close();
            }
            MessageBox.Show("Комиссия создана");
        }

        public static void UpdateCommission(DataGridView dgv, Commission toEdit)
        {
            if (dgv.SelectedRows.Count != 0)
            {
                Commission commission = new Commission(dgv.CurrentRow.Cells[0].Value.ToString());
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet temp = db.QueryByExample(commission);
                    Commission found = (Commission)temp.Next();
                    found.CommissionName = toEdit.CommissionName;
                    db.Store(found);
                    db.Close();
                }
                MessageBox.Show("Изменения сохранены");
            }
            else MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DeleteCommission(DataGridView dgv)
        {
            Commission commissionToDelete = new Commission(dgv.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("ОПАСНА. ВЫ ХОТИТЕ УДАЛИТЬ ЗАПИСЬ?", "АХТУНГ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet result = db.QueryByExample(commissionToDelete);
                    foreach (Commission c in result)
                    {
                        db.Delete(c);
                    }
                    db.Close();
                }
                MessageBox.Show("С удалением этой записи нить вашей судьбы обрывается. Загрузите предыдущий бекап базы данных дабы восстановаить течение судьбы, или живите дальше в проклятом мире, который сами и создали");
            }
        }

        public string CommissionName { get => _commissionName; set => _commissionName = value; }
    }
}
