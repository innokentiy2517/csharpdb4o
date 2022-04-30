using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Perst;

namespace Lab1
{
    public class Session : Persistent
    {
        private int id;
        Commission commission;
        DateTime date;
        string place;
        public Commission Commission {get => commission;set => commission = value;}

        public DateTime Date {get => date; set => date = value; }

        public string Place {get => place;set => place = value;}
        public Session(
            Commission commission,
            DateTime date,
            string place,
            int id
            )
        {
            this.Id = id;
            this.Commission = commission;
            this.Date = date;
            this.Place = place;
        }

        

        private Link sessionParticipants;
        public Link SessionParticipants
        {
            get => sessionParticipants;
            set => sessionParticipants = value;
        }

        public int Id { get => id; set => id = value; }

        private static int uniqueId(int id, MyRoot Root)
        {
            int unique = Root.index_session.Cast<Session>().Count(s => s.Id == id);
            return unique;
        }
        public static void addSession(Commission commission,DateTime date,string place, int id, Storage db)
        {
            MyRoot Root = HelperDb<Session>.CreateRoot(db);
            db.Open(Form1.dbName);
            if (uniqueId(id, Root) != 0)
            {
                id++;
            }

            Session newSession = new Session(commission, date, place, id);
            newSession.SessionParticipants = db.CreateLink();
            Root.index_session.Put(newSession);
            Root.multiSession.Put(newSession);
            MessageBox.Show("Запись о собрании успешно создана");
            db.Close();
        }

        public static void updateSession(DataGridView dgv, Session toEdit, Storage db)
        {
            if (dgv.SelectedRows.Count != 0)
            {
                MyRoot Root = HelperDb<Session>.CreateRoot(db);
                db.Open(Form1.dbName);
                Session sessionToEdit = (Session)Root.index_session[(int)dgv.CurrentRow.Cells[0].Value];
                sessionToEdit.Commission = toEdit.Commission;
                sessionToEdit.Date = toEdit.Date;
                sessionToEdit.Place = toEdit.Place;
                sessionToEdit.Modify();
                db.Close();
                MessageBox.Show("Изменения сохранены");
            }
            else MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void deleteSession(DataGridView dgv, Storage db)
        {
            int id = (int)dgv.CurrentRow.Cells[0].Value;
            MyRoot Root = HelperDb<Session>.CreateRoot(db);
            db.Open(Form1.dbName);
            Session session = null;
            foreach (Session s in Root.index_session.Cast<Session>().Where(s=>s.Id==id))
            {
                session = s;
            }

            Root.index_session.Remove(session);
            Root.index_session.Modify();
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButtons.OK);
            db.Close();
        }
    }
}