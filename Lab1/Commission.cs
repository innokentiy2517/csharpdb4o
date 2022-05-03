using System.Linq;
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
        Root.Store();
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
