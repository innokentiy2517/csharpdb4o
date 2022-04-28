using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Perst;

namespace Lab1
{
    public class Commission : Persistent

    {
    private string _commissionName;
    private int id;

    public Commission(string name, int id)
    {
        this.Id = id;
        this.CommissionName = name;
    }

    /*public static void getComissions(DataGridView dataGridView, IObjectContainer db)
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
    }*/

    public static void AddCommission(string name, int id, Storage db)
    {
        MyRoot Root = HelperDb<Commission>.CreateRoot(db);
        db.Open(Form1.dbName);
        if (uniqueId(id, Root) != 0)
        {
            id++;
            
        }

        Commission newCommission = new Commission(name, id);
        Root.index_commission.Put(newCommission);
        /*using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
        {
            Commission commission = new Commission(name);
            db.Store(commission);
            db.Close();
        }*/
        MessageBox.Show("Комиссия создана");
        db.Close();
    }

    public static void UpdateCommission(Commission toEdit, Storage db, int id)
    {
        MyRoot Root = HelperDb<Commission>.CreateRoot(db);
        db.Open(Form1.dbName);
        Commission commission = null;
        foreach (Commission c in Root.index_commission.Cast<Commission>().Where(c=>c.Id == id))
        {
            commission = c;
        }

        commission.CommissionName = toEdit.CommissionName;
        commission.Modify();
        /*if (dgv.SelectedRows.Count != 0)
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

        }
        else MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        MessageBox.Show("Изменения сохранены");
        db.Close();
    }

    public static void DeleteCommission(DataGridView dgv, Storage db)
    {
        int id = (int)dgv.CurrentRow.Cells[0].Value;
        MyRoot Root = HelperDb<Commission>.CreateRoot(db);
        db.Open(Form1.dbName);
        Commission commission = null;
        foreach (Commission c in Root.index_commission.Cast<Commission>().Where(c=>c.Id==id))
        {
            commission = c;
        }

        Root.index_commission.Remove(commission);
        MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButtons.OK);
        db.Close();
        /*Commission commissionToDelete = new Commission(dgv.CurrentRow.Cells[0].Value.ToString());
        if (MessageBox.Show("ОПАСНА. ВЫ ХОТИТЕ УДАЛИТЬ ЗАПИСЬ?", "АХТУНГ", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
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

            MessageBox.Show(
                "С удалением этой записи нить вашей судьбы обрывается. Загрузите предыдущий бекап базы данных дабы восстановаить течение судьбы, или живите дальше в проклятом мире, который сами и создали");
        }*/
    }

    private static int uniqueId(int id, MyRoot Root)
    {
        int unique = Root.index_commission.Cast<Commission>().Count(c => c.Id == id);
        return unique;
    }
    
    public string CommissionName
    {
        get => _commissionName;
        set => _commissionName = value;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }
    }
}
