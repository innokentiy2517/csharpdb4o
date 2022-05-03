using System;
using System.Linq;
using System.Windows.Forms;
using Perst;

namespace Lab1
{
    public class CommissionMember: Persistent
    {
        private int id;
        private Person person;
        private Commission commission;
        private bool isChairman;
        private DateTime 
            entryDate,
            exitDate,
            chairStartDate,
            chairEndDate;

        public CommissionMember(
                Person person,
                Commission commission,
                bool isChairman,
                DateTime entryDate,
                int id
            )
        {
            this.Person = person;
            this.Commission = commission;
            this.IsChairman = isChairman;
            this.EntryDate = entryDate;
            this.Id = id;
        }

        public int Id { get => id; set => id = value; }
        public bool IsChairman { get => isChairman; set => isChairman = value; }
        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
        public DateTime ExitDate { get => exitDate; set => exitDate = value; }
        public DateTime ChairStartDate { get => chairStartDate; set => chairStartDate = value; }
        public DateTime ChairEndDate { get => chairEndDate; set => chairEndDate = value; }
        internal Person Person { get => person; set => person = value; }
        internal Commission Commission { get => commission; set => commission = value; }

        private static int uniqueId(int id, MyRoot Root)
        {
            int unique = Root.index_commissionMember.Cast<CommissionMember>().Count(cm => cm.Id == id);
            return unique;
        }
        
        public static void addCommissionMember
        (
            Person person,
            Commission commission,
            int id,
            Storage db
        )
        {
            MyRoot Root = HelperDb<CommissionMember>.CreateRoot(db);
            db.Open(Form1.dbName);
            if (uniqueId(id, Root) != 0) { id++;}

            CommissionMember newCommissionMember =
                new CommissionMember(person, commission, false, DateTime.Today.Date, id);
            Root.index_commissionMember.Put(newCommissionMember);
            MessageBox.Show("Запись о члене комиссии успешно создана");
            Root.Modify();
            db.Close();
        }

        public static void assignChair(int id, Storage db)
        {
            MyRoot Root = HelperDb<CommissionMember>.CreateRoot(db);
            db.Open(Form1.dbName);
            CommissionMember toEdit = (CommissionMember)Root.index_commissionMember[id];
            if (toEdit.isChairman)
            {
                MessageBox.Show("Член комиссии уже является председателем");
                db.Close();
                return;
            }
            toEdit.IsChairman = true;
            toEdit.chairStartDate = DateTime.Today.Date;
            toEdit.ChairEndDate = DateTime.MinValue.Date;
            toEdit.Modify();
            db.Close();
            MessageBox.Show("Председатель назначен", "Сообщение", MessageBoxButtons.OK);
        }

        public static void deassignChair(int id, Storage db)
        {
            MyRoot Root = HelperDb<CommissionMember>.CreateRoot(db);
            db.Open(Form1.dbName);
            CommissionMember toEdit = (CommissionMember)Root.index_commissionMember[id];
            if (!toEdit.IsChairman)
            {
                MessageBox.Show("Член комиссии не является председателем");
                db.Close();
                return;
            }
            toEdit.IsChairman = false;
            toEdit.ChairEndDate = DateTime.Today.Date;
            toEdit.Modify();
            db.Close();
            MessageBox.Show("Председатель успешно снят с должности");
        }

        public static void exileMember(int id, Storage db)
        {
            MyRoot Root = HelperDb<CommissionMember>.CreateRoot(db);
            db.Open(Form1.dbName);
            CommissionMember toEdit = (CommissionMember)Root.index_commissionMember[id];
            if (toEdit.ExitDate != DateTime.MinValue)
            {
                MessageBox.Show("Член комиссии уже не состоит в комисии");
                db.Close();
                return;
            }
            if (toEdit.ChairEndDate == DateTime.MinValue&&toEdit.IsChairman)
            {
                toEdit.IsChairman = false;
                toEdit.ChairEndDate = DateTime.Today.Date;
            }
            toEdit.ExitDate = DateTime.Today.Date;
            toEdit.Modify();
            db.Close();
            MessageBox.Show("Член комиссии успешно исключен");
        }
    }
}
