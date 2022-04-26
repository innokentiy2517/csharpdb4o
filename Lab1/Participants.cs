using System;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;

namespace Lab1
{
    public partial class Participants : Form
    {
        Session session;
        public Participants(Session session)
        {
            InitializeComponent();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery q = db.Query();
                q.Constrain(typeof(Session));
                q.Descend("place").Constrain(session.Place);
                q.Descend("date").Descend("Date").Constrain(session.Date);
                q.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                IObjectSet ses = q.Execute();
                this.session = (Session)ses.Next();
            }
            refreshGV();
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
                IQuery q = db.Query();
                q.Constrain(typeof(Session));
                q.Descend("place").Constrain(session.Place);
                q.Descend("date").Descend("Date").Constrain(session.Date);
                q.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                IObjectSet sesRes = q.Execute();
                Session ses = (Session)sesRes.Next();
                if (ses.SessionParticipants.Count == 0||ses.SessionParticipants == null) return;
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
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Session)).CascadeOnUpdate(true);
            string[] FIO = commissionMemberCombo.SelectedItem.ToString().Split();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config,Form1.dbName))
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
                query = db.Query();
                query.Constrain(typeof(Session));
                query.Descend("place").Constrain(session.Place);
                query.Descend("date").Descend("Date").Constrain(session.Date);
                query.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                IObjectSet sessionSet = query.Execute();
                Session sessionRes = (Session)sessionSet.Next();
                sessionRes.SessionParticipants.Add(cm);
                db.Store(sessionRes);
                db.Close();
            }
            refreshGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Session)).CascadeOnUpdate(true);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config,Form1.dbName))
            {
                string[] FIO = participantsGV.CurrentRow.Cells[0].Value.ToString().Split();
                IQuery query = db.Query();
                query.Constrain(typeof(CommissionMember));
                query.Descend("commission").Descend("_commissionName").Constrain(participantsGV.CurrentRow.Cells[1].Value.ToString());
                query.Descend("person").Descend("firstName").Constrain(FIO[1]);
                query.Descend("person").Descend("middleName").Constrain(FIO[2]);
                query.Descend("person").Descend("secondName").Constrain(FIO[0]);
                query.Descend("exitDate").Constrain(DateTime.MinValue);
                IObjectSet result = query.Execute();
                CommissionMember cm = (CommissionMember)result.Next();
                query = db.Query();
                query.Constrain(typeof(Session));
                query.Descend("place").Constrain(session.Place);
                query.Descend("date").Descend("Date").Constrain(session.Date);
                query.Descend("commission").Descend("_commissionName").Constrain(session.Commission.CommissionName);
                IObjectSet sessionSet = query.Execute();
                Session sessionRes = (Session)sessionSet.Next();
                for (int i = 0; i<sessionRes.SessionParticipants.Count; i++)
                {
                    CommissionMember participantToDelete = sessionRes.SessionParticipants[i];
                    bool areEqual = participantToDelete == cm;
                    if (
                        participantToDelete.Person.FirstName == cm.Person.FirstName
                        && participantToDelete.Person.MiddleName == cm.Person.MiddleName
                        && participantToDelete.Person.SecondName == cm.Person.SecondName
                        && participantToDelete.EntryDate == cm.EntryDate
                        )
                    {
                        sessionRes.SessionParticipants.Remove(participantToDelete);
                    }
                }
                db.Store(sessionRes);
                db.Close();
            }
            refreshGV();
        }
    }
}