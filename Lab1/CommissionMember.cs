using System;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

namespace Lab1
{
    public class CommissionMember
    {
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
                DateTime entryDate
            )
        {
            this.Person = person;
            this.Commission = commission;
            this.IsChairman = isChairman;
            this.EntryDate = entryDate;
        }

        public bool IsChairman { get => isChairman; set => isChairman = value; }
        public DateTime EntryDate { get => entryDate; set => entryDate = value; }
        public DateTime ExitDate { get => exitDate; set => exitDate = value; }
        public DateTime ChairStartDate { get => chairStartDate; set => chairStartDate = value; }
        public DateTime ChairEndDate { get => chairEndDate; set => chairEndDate = value; }
        internal Person Person { get => person; set => person = value; }
        internal Commission Commission { get => commission; set => commission = value; }

        public static void addCommissionMember
        (
            Person person,
            Commission commission
        )
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IObjectSet personSet = db.QueryByExample(person);
                Person resPerson = (Person)personSet.Next();
                IObjectSet commissionSet = db.QueryByExample(commission);
                Commission resCommission = (Commission)commissionSet.Next();
                CommissionMember commissionMember = new CommissionMember(resPerson, resCommission, false, DateTime.Today);
                db.Store(commissionMember);
                db.Close();
            }
            MessageBox.Show("Запись о члене комиссии успешно создана");
        }

        public static void getCommissionMembers(DataGridView dgv, IObjectContainer db)
        {
            dgv.Rows.Clear();
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add("PersonName", "ФИО Члена комиссии");
                dgv.Columns.Add("CommissionName", "Комиссия");
                dgv.Columns.Add("EntryDate", "Дата вступления");
                dgv.Columns.Add("ExitDate", "Дата выхода");
                dgv.Columns.Add("IsChairman", "Председатель");
                dgv.Columns.Add("ChairStartDate", "Дата начала председательлства");
                dgv.Columns.Add("ChairEndDate", "Дата конца председательлства");
            }

            IQuery query = db.Query();
            query.Constrain(typeof(CommissionMember));
            IObjectSet commissionMembers = query.Execute();
            foreach (CommissionMember cm in commissionMembers)
            {
                string exitDate;
                string chairStartDate;
                string chairEndDate;
                if (cm.ExitDate.Date == DateTime.MinValue) exitDate = "";
                else exitDate = cm.ExitDate.ToString();
                if (cm.ChairStartDate.Date == DateTime.MinValue) chairStartDate = "";
                else chairStartDate = cm.ChairStartDate.ToString();
                if (cm.ChairEndDate.Date == DateTime.MinValue) chairEndDate = "";
                else chairEndDate = cm.ChairEndDate.ToString();
                
                dgv.Rows.Add(
                    cm.Person.SecondName + " " + cm.Person.FirstName + " " + cm.Person.MiddleName,
                    cm.Commission.CommissionName,
                    cm.EntryDate.Date,
                    exitDate,
                    cm.IsChairman,
                    chairStartDate,
                    chairEndDate
                );
            }
        }

        public static void assignChair(DataGridView dgv)
        {
            string[] personFIO = dgv.CurrentRow.Cells[0].Value.ToString().Split();
            Person personProto = new Person()
            {
                FirstName = personFIO[1],
                SecondName = personFIO[0],
                MiddleName = personFIO[2]
            };
            string commissionName = dgv.CurrentRow.Cells[1].Value.ToString();
            Commission commissionProto = new Commission(commissionName);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                bool isChairman;
                if (dgv.CurrentRow.Cells[4].Value.ToString() == "False")
                {
                    isChairman = false;
                }
                else
                {
                    MessageBox.Show("Данный член комиссии уже является председателем");
                    return;
                }

                IObjectSet personSet = db.QueryByExample(personProto);
                Person personRes = (Person)personSet.Next();
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                Commission commissionRes = (Commission)commissionSet.Next();
                CommissionMember commissionMemberProto = new CommissionMember(
                    personRes,
                    commissionRes,
                    isChairman,
                    Convert.ToDateTime(dgv.CurrentRow.Cells[2].Value.ToString())
                );
                IObjectSet cmResult = db.QueryByExample(commissionMemberProto);
                CommissionMember cm = (CommissionMember)cmResult.Next();
                cm.IsChairman = true;
                cm.ChairStartDate=DateTime.Today.Date;
                db.Store(cm);
                db.Close();
            }
            MessageBox.Show("Председатель успешно назначен");
        }

        public static void deassignChair(DataGridView dgv)
        {
            string[] personFIO = dgv.CurrentRow.Cells[0].Value.ToString().Split();
            Person personProto = new Person()
            {
                FirstName = personFIO[1],
                SecondName = personFIO[0],
                MiddleName = personFIO[2]
            };
            string commissionName = dgv.CurrentRow.Cells[1].Value.ToString();
            Commission commissionProto = new Commission(commissionName);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                bool isChairman;
                if (dgv.CurrentRow.Cells[4].Value.ToString() == "False")
                {
                    MessageBox.Show("Данный член комиссии не является председателем");
                    return;
                }
                else isChairman = true;

                IObjectSet personSet = db.QueryByExample(personProto);
                Person personRes = (Person)personSet.Next();
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                Commission commissionRes = (Commission)commissionSet.Next();
                CommissionMember commissionMemberProto = new CommissionMember(
                    personRes,
                    commissionRes,
                    isChairman,
                    Convert.ToDateTime(dgv.CurrentRow.Cells[2].Value.ToString())
                );
                commissionMemberProto.ChairStartDate = Convert.ToDateTime(dgv.CurrentRow.Cells[5].Value.ToString());
                IObjectSet cmResult = db.QueryByExample(commissionMemberProto);
                CommissionMember cm = (CommissionMember)cmResult.Next();
                cm.IsChairman = false;
                cm.ChairEndDate=DateTime.Today.Date;
                db.Store(cm);
                db.Close();
            }
            MessageBox.Show("Председатель успешно снят с должности");
        }

        public static void exileMember(DataGridView dgv)
        {
            string[] personFIO = dgv.CurrentRow.Cells[0].Value.ToString().Split();
            Person personProto = new Person()
            {
                FirstName = personFIO[1],
                SecondName = personFIO[0],
                MiddleName = personFIO[2]
            };
            string commissionName = dgv.CurrentRow.Cells[1].Value.ToString();
            Commission commissionProto = new Commission(commissionName);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                if (dgv.CurrentRow.Cells[4].Value.ToString() != "False")
                {
                    MessageBox.Show("Нельзя исключить из комиссии председателя");
                    return;
                }

                if (dgv.CurrentRow.Cells[3].Value.ToString() != "")
                {
                    MessageBox.Show("Член комиссии уже не состоит в комисии");
                    return;
                }
                IObjectSet personSet = db.QueryByExample(personProto);
                Person personRes = (Person)personSet.Next();
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                Commission commissionRes = (Commission)commissionSet.Next();
                CommissionMember commissionMemberProto = new CommissionMember(
                    personRes,
                    commissionRes,
                    false,
                    Convert.ToDateTime(dgv.CurrentRow.Cells[2].Value.ToString())
                );
                if (dgv.CurrentRow.Cells[5].Value.ToString() == "" && dgv.CurrentRow.Cells[6].Value.ToString() == "")
                {
                    commissionMemberProto.ChairStartDate = DateTime.MinValue;
                    commissionMemberProto.ChairEndDate = DateTime.MinValue;
                }
                else
                {
                    commissionMemberProto.ChairStartDate = Convert.ToDateTime(dgv.CurrentRow.Cells[5].Value.ToString());
                    commissionMemberProto.ChairEndDate = Convert.ToDateTime(dgv.CurrentRow.Cells[6].Value.ToString());
                }
                IObjectSet cmResult = db.QueryByExample(commissionMemberProto);
                CommissionMember cm = (CommissionMember)cmResult.Next();
                cm.ExitDate=DateTime.Today.Date;
                db.Store(cm);
                db.Close();
            }
            MessageBox.Show("Член комиссии успешно исключен");
        }
    }
}
