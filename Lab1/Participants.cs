using System;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

namespace Lab1
{
    public partial class Participants : Form
    {
        Session session;
        public Participants(Session session)
        {
            InitializeComponent();
            
            this.session = session;
        }

        private void commissionMemberCombo_DropDown(object sender, EventArgs e)
        {
            commissionMemberCombo.Items.Clear();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(CommissionMember));
                query.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                query.Descend("exitDate").Constrain(DateTime.MinValue);
                IObjectSet result = query.Execute();
                foreach (CommissionMember cm in result)
                {
                    commissionMemberCombo.Items.Add(cm.Person.SecondName +" "+ cm.Person.FirstName +" "+ cm.Person.MiddleName);
                }
                db.Close();
            }
        }

        private void refreshGV()
        {
            if (session.SessionParticipants.Count == 0||session.SessionParticipants == null) return;
            participantsGV.Rows.Clear();
            if (participantsGV.Columns.Count == 0)
            {
                participantsGV.Columns.Add("PersonName", "ФИО Члена комиссии");
                participantsGV.Columns.Add("CommissionName", "Комиссия");
                participantsGV.Columns.Add("EntryDate", "Дата вступления");
                participantsGV.Columns.Add("ExitDate", "Дата выхода");
                participantsGV.Columns.Add("IsChairman", "Председатель");
                participantsGV.Columns.Add("ChairStartDate", "Дата начала председательлства");
                participantsGV.Columns.Add("ChairEndDate", "Дата конца председательлства");
            }

            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                /*IQuery query = db.Query();
                query.Constrain(typeof(Session));
                query.
                IObjectSet commissionMembers = query.Execute();*/
                foreach (CommissionMember cm in session.SessionParticipants)
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

                    participantsGV.Rows.Add(
                        cm.Person.SecondName + " " + cm.Person.FirstName + " " + cm.Person.MiddleName,
                        cm.Commission.CommissionName,
                        cm.EntryDate.Date,
                        exitDate,
                        cm.IsChairman,
                        chairStartDate,
                        chairEndDate
                    );
                }               
                db.Close();
            }
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
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(CommissionMember));
                query.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                query.Descend("person").Descend("firstName").Constrain(FIO[1]);
                query.Descend("person").Descend("middleName").Constrain(FIO[2]);
                query.Descend("person").Descend("secondName").Constrain(FIO[0]);
                query.Descend("exitDate").Constrain(DateTime.MinValue);
                IObjectSet result = query.Execute();
                CommissionMember cm = (CommissionMember)result.Next();
                session.SessionParticipants.Add(cm);
                db.Close();
            }
            refreshGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Session));
                query.Descend("place").Constrain(session.Place);
                query.Descend("date").Constrain(Convert.ToDateTime(session.Date.ToString()));
                // query.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                IObjectSet sessionSet = query.Execute();
                Session sessionRes = (Session)sessionSet.Next();
                // sessionRes.SessionParticipants = session.SessionParticipants;
                // db.Store(sessionRes);
                // db.Close();
            }
        }
    }
}