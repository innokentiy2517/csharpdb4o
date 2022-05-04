using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Participants : Form
    {
        Session session;
        public Participants(int id)
        {
            InitializeComponent();
            Form1.dbHelper.db.Open(Form1.dbName);
            foreach (Session s in Form1.root.index_session.Cast<Session>().Where(s=>s.Id==id))
            {
                session = s;
            }
            Form1.dbHelper.db.Close();
        }

        private void commissionMemberCombo_DropDown(object sender, EventArgs e)
        {
            commissionMemberCombo.Items.Clear();
            Form1.dbHelper.db.Open(Form1.dbName);
            foreach (CommissionMember cm in Form1.root.index_commissionMember.Cast<CommissionMember>().Where(cm=>cm.Commission.Id==session.Commission.Id&&cm.ExitDate==DateTime.MinValue.Date))
            {
                commissionMemberCombo.Items.Add(cm.Person.SecondName + " " + cm.Person.FirstName + " " +
                                                cm.Person.MiddleName);
            }
            Form1.dbHelper.db.Close();
        }

        private void refreshGV()
        {
            participantsGV.Rows.Clear();
            if (participantsGV.Columns.Count == 0)
            {
                participantsGV.Columns.Add("Id", "Id");
                participantsGV.Columns.Add("PersonName", "ФИО Члена комиссии");
                participantsGV.Columns.Add("CommissionName", "Комиссия");
                participantsGV.Columns.Add("EntryDate", "Дата вступления");
                participantsGV.Columns.Add("ExitDate", "Дата выхода");
                participantsGV.Columns.Add("IsChairman", "Председатель");
                participantsGV.Columns.Add("ChairStartDate", "Дата начала председательлства");
                participantsGV.Columns.Add("ChairEndDate", "Дата конца председательлства");
            }

            Form1.dbHelper.db.Open(Form1.dbName);
            Session ses = null;
            foreach (Session s in Form1.root.index_session
                         .Cast<Session>()
                         .Where(s=>s.Id==session.Id))
            {
                ses = s;
            }

            foreach (CommissionMember cm in ses.SessionParticipants)
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

                participantsGV.Rows.Add(cm.Id,
                    cm.Person.SecondName + " " + cm.Person.FirstName + " " + cm.Person.MiddleName,
                    cm.Commission.CommissionName,
                    cm.EntryDate.Date,
                    exitDate,
                    cm.IsChairman,
                    chairStartDate,
                    chairEndDate
                );
            }
            Form1.dbHelper.db.Close();
        }
        
        private void Participants_Load(object sender, EventArgs e)
        {
            refreshGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void addParticipant_Click(object sender, EventArgs e)
        {
            string[] FIO = commissionMemberCombo.SelectedItem.ToString().Split();
            Form1.dbHelper.db.Open(Form1.dbName);
            CommissionMember part = null;
            foreach (CommissionMember cm in Form1.root.index_commissionMember
                         .Cast<CommissionMember>()
                         .Where(
                             cm=>
                                 cm.Person.SecondName==FIO[0]&&
                                 cm.Person.FirstName==FIO[1]&&
                                 cm.Person.MiddleName==FIO[2]&&
                                 cm.ExitDate==DateTime.MinValue&&
                                 cm.Commission.Id==session.Commission.Id))
            {
                part = cm;
            }

            Session ses = null;
            foreach (Session s in Form1.root.index_session
                         .Cast<Session>()
                         .Where(s=>s.Id==session.Id))
            {
                ses = s;
            }

            if (ses.SessionParticipants.Contains(part))
            {
                MessageBox.Show("Данный участник уже участвует в собрании!");
                Form1.dbHelper.db.Close();
                return;
            }
            ses.SessionParticipants.Add(part);
            ses.Modify();
            Form1.dbHelper.db.Close();
            refreshGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] FIO = participantsGV.CurrentRow.Cells[1].Value.ToString().Split();
            Form1.dbHelper.db.Open(Form1.dbName);
            CommissionMember part = null;
            foreach (CommissionMember cm in Form1.root.index_commissionMember
                         .Cast<CommissionMember>()
                         .Where(
                             cm=>
                                 cm.Person.SecondName==FIO[0]&&
                                 cm.Person.FirstName==FIO[1]&&
                                 cm.Person.MiddleName==FIO[2]&&
                                 cm.ExitDate==DateTime.MinValue&&
                                 cm.Commission.Id==session.Commission.Id))
            {
                part = cm;
            }
            Session ses = null;
            foreach (Session s in Form1.root.index_session
                         .Cast<Session>()
                         .Where(s=>s.Id==session.Id))
            {
                ses = s;
            }

            ses.SessionParticipants.Remove(part);
            ses.Modify();
            Form1.dbHelper.db.Close();
            refreshGV();
        }
    }
}