using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

namespace Lab1
{
    class Session
    {
        public Session(
            Commission commission,
            DateTime date,
            string place
            )
        {
            this.Commission = commission;
            this.Date = date;
            this.Place = place;
        }

        public Commission Commission {get => commission;set => commission = value;}

        public DateTime Date {get => date; set => date = value; }

        public string Place {get => place;set => place = value;}

        Commission commission;
        DateTime date;
        string place;
        private List<CommissionMember> sessionParticipants;
        public List<CommissionMember> SessionParticipants
        {
            get => sessionParticipants;
            set => sessionParticipants = value;
        }

        public static void addParticipant(CommissionMember participant)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                
            }
        }
        
        public static void addSession(Commission commission,DateTime date,string place) 
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IObjectSet commissionSet = db.QueryByExample(commission);
                Commission resCommission = (Commission)commissionSet.Next();
                Session session = new Session(resCommission, date, place);
                db.Store(session);
                db.Close();
            }

            MessageBox.Show("Запись о собрании успешно создана");
        }

        public static void getSessions(DataGridView dgv, IObjectContainer db)
        {
            dgv.Rows.Clear();
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add("sessionCommission", "Комиссия");
                dgv.Columns.Add("sessionDate", "Дата собрания");
                dgv.Columns.Add("sessionPlace", "Место проведения");
            }

            IQuery query = db.Query();
            query.Constrain(typeof(Session));
            IObjectSet sessions = query.Execute();
            foreach (Session s in sessions)
            {
                dgv.Rows.Add(s.Commission.CommissionName, s.Date, s.Place);
            }
        }

        public static void updateSession(DataGridView dgv, Session toEdit)
        {
            if (dgv.SelectedRows.Count != 0)
            {
                Commission commissionProto = new Commission(dgv.CurrentRow.Cells[0].Value.ToString());
                DateTime date = Convert.ToDateTime(dgv.CurrentRow.Cells[1].Value);
                string place = dgv.CurrentRow.Cells[2].Value.ToString();
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet commissionSet = db.QueryByExample(commissionProto);
                    Commission commissionRes = (Commission)commissionSet.Next();
                    Session sessionProto = new Session(commissionRes, date, place);
                    IObjectSet sessionSet = db.QueryByExample(sessionProto);
                    Session sessionToEdit = (Session)sessionSet.Next();
                    IObjectSet commissionToSet = db.QueryByExample(new Commission(toEdit.Commission.CommissionName));
                    Commission resCommissionToSet = (Commission)commissionToSet.Next();
                    sessionToEdit.Commission = resCommissionToSet;
                    sessionToEdit.Date = toEdit.Date;
                    sessionToEdit.Place = toEdit.Place;
                    db.Store(sessionToEdit);
                    db.Close();
                }

                MessageBox.Show("Изменения сохранены");
            }
            else MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void deleteSession(DataGridView dgv)
        {
            if (MessageBox.Show("ОПАСНА. ВЫ ХОТИТЕ УДАЛИТЬ ЗАПИСЬ?", "АХТУНГ", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.OK)
            {
                Commission commissionProto = new Commission(dgv.CurrentRow.Cells[0].Value.ToString());
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet commissionSet = db.QueryByExample(commissionProto);
                    Commission commissionRes = (Commission)commissionSet.Next();
                    Session sessionToDelete = new Session(commissionRes,
                        Convert.ToDateTime(dgv.CurrentRow.Cells[1].Value), dgv.CurrentRow.Cells[2].Value.ToString());
                    IObjectSet result = db.QueryByExample(sessionToDelete);
                    foreach (Session s in result)
                    {
                        db.Delete(s);
                    }

                    db.Close();
                }

                MessageBox.Show(
                    "С удалением этой записи нить вашей судьбы обрывается. Загрузите предыдущий бекап базы данных дабы восстановаить течение судьбы, или живите дальше в проклятом мире, который сами и создали");
            }
        }
    }
}