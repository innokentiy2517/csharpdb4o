using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Internal.Query;
using Db4objects.Db4o.Query;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public static string dbName = "Gorduma.yap";
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void refreshCommissionGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                Commission.getComissions(commissionGridView, db);
                db.Close();
            }
        }

        private void refreshPersonGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                Person.getPersons(personGridView, db);
                db.Close();
            }
        }
        
        private void refreshCommissionMemberGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                CommissionMember.getCommissionMembers(commissionMemberDGV, db);
                db.Close();
            }
        }

        private void refreshSessionGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(dbName))
            {
                Session.getSessions(sessionGV,db);
                db.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshCommissionGV();
            refreshPersonGV();
            refreshCommissionMemberGV();
            refreshSessionGV();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void editPersonButton_Click(object sender, EventArgs e)
        {
            Person edit = new Person(
                firstName:firstNameTextBox.Text,
                middleName:middleNameTextBox.Text,
                secondName:secondNameTextBox.Text,
                addressCity:cityTextBox.Text,
                addressStreet:streetTextBox.Text,
                phoneHome: phoneHomeTextBox.Text,
                phoneWork: phoneWorkTextBox.Text,
                addressHouseNumber: Convert.ToInt32(houseNumberTextBox.Text),
                addressAppartmentNumber: Convert.ToInt32(appartNumberTextBox.Text)
                );
            Person.UpdatePerson(personGridView, edit);
            refreshPersonGV();
        }

        private void personGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (personGridView.Rows.Count == 0) return;
            firstNameTextBox.Text = personGridView.CurrentRow.Cells[0].Value.ToString();
            middleNameTextBox.Text = personGridView.CurrentRow.Cells[1].Value.ToString();
            secondNameTextBox.Text = personGridView.CurrentRow.Cells[2].Value.ToString();
            cityTextBox.Text = personGridView.CurrentRow.Cells[3].Value.ToString();
            streetTextBox.Text = personGridView.CurrentRow.Cells[4].Value.ToString();
            houseNumberTextBox.Text = personGridView.CurrentRow.Cells[5].Value.ToString();
            appartNumberTextBox.Text = personGridView.CurrentRow.Cells[6].Value.ToString();
            phoneHomeTextBox.Text = personGridView.CurrentRow.Cells[7].Value.ToString();
            phoneWorkTextBox.Text = personGridView.CurrentRow.Cells[8].Value.ToString();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            Person.addPerson(
                firstNameTextBox.Text,
                middleNameTextBox.Text,
                secondNameTextBox.Text,
                cityTextBox.Text,
                streetTextBox.Text,
                Convert.ToInt32(houseNumberTextBox.Text),
                Convert.ToInt32(appartNumberTextBox.Text),
                phoneHomeTextBox.Text,
                phoneWorkTextBox.Text
                );
            firstNameTextBox.Clear();
            secondNameTextBox.Clear();
            middleNameTextBox.Clear();
            cityTextBox.Clear();
            streetTextBox.Clear();
            houseNumberTextBox.Clear();
            appartNumberTextBox.Clear();
            phoneHomeTextBox.Clear();
            phoneWorkTextBox.Clear();
            refreshPersonGV();
        }

        private void deletePersonButton_Click(object sender, EventArgs e)
        {
            Person.DeletePerson(personGridView);
            refreshPersonGV();
        }

        private void addCommissionButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Commission.AddCommission(name);
            refreshCommissionGV();
        }

        private void editCommissionButton_Click(object sender, EventArgs e)
        {
            Commission edit = new Commission(textBox1.Text);
            Commission.UpdateCommission(commissionGridView, edit);
            refreshCommissionGV();
        }

        private void commissionGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (commissionGridView.Rows.Count == 0) return;
            textBox1.Text = commissionGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void commissionDeleteButton_Click(object sender, EventArgs e)
        {
            Commission.DeleteCommission(commissionGridView);
            refreshCommissionGV();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void personComboBox_DropDown(object sender, EventArgs e)
        {
            personComboBox.Items.Clear();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Person));
                IObjectSet personsSet = query.Execute();
                foreach (Person person in personsSet)
                {
                    personComboBox.Items.Add(person.SecondName +" "+ person.FirstName +" "+ person.MiddleName);
                }
                db.Close();
            }
        }

        private void commissionDropDown_DropDown(object sender, EventArgs e)
        {
            commissionDropDown.Items.Clear();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Commission));
                IObjectSet commissionSet = query.Execute();
                foreach (Commission c in commissionSet)
                {
                    commissionDropDown.Items.Add(c.CommissionName);
                }
                db.Close();
            }
        }

        private void assignChairmanButton_Click(object sender, EventArgs e)
        {
            CommissionMember.assignChair(commissionMemberDGV);
            refreshCommissionMemberGV();
        }

        private void addCommissionMemberButton_Click(object sender, EventArgs e)
        {
            string personFIO = personComboBox.SelectedItem.ToString();
            string[] FIO = personFIO.Split();
            string firstName = FIO[1];
            string middleName = FIO[2];
            string secondName = FIO[0];
            Person personProto = new Person()
                { FirstName = firstName, SecondName = secondName, MiddleName = middleName };
            Commission commissionProto = new Commission(commissionDropDown.SelectedItem.ToString());
            IObjectSet person;
            IObjectSet commission;
            Person resPerson;
            Commission resCommission;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                person = db.QueryByExample(personProto);
                resPerson = (Person)person.Next();
                commission = db.QueryByExample(commissionProto);
                resCommission = (Commission)commission.Next();
                db.Close();
            }
            CommissionMember.addCommissionMember(resPerson,resCommission);
            refreshCommissionMemberGV();
        }

        private void deassignChairmanButton_Click(object sender, EventArgs e)
        {
            CommissionMember.deassignChair(commissionMemberDGV);
            refreshCommissionMemberGV();
        }

        private void removeFromCommissionButton_Click(object sender, EventArgs e)
        {
            CommissionMember.exileMember(commissionMemberDGV);
            refreshCommissionMemberGV();
        }

        private void sessionCommisisonComboSet()
        {
            sessionCommissionCombo.Items.Clear();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Commission));
                IObjectSet commissionSet = query.Execute();
                foreach (Commission c in commissionSet)
                {
                    sessionCommissionCombo.Items.Add(c.CommissionName);
                }
                db.Close();
            }
        }
        
        private void sessionCommissionCombo_DropDown(object sender, EventArgs e)
        {
            sessionCommisisonComboSet();
        }

        private void addSessionButton_Click(object sender, EventArgs e)
        {
            Commission commissionProto = new Commission(sessionCommissionCombo.SelectedItem.ToString());
            DateTime date = sessionDatePicker.Value;
            string place = sessionPlaceTextBox.Text;
            Commission commissionRes;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(dbName))
            {
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                commissionRes = (Commission)commissionSet.Next();
                db.Close();
            }
            Session.addSession(commissionRes,date,place);
            refreshSessionGV();
        }

        private void sessionGV_mouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sessionCommisisonComboSet();
            if (commissionGridView.Rows.Count == 0) return;
            sessionCommissionCombo.SelectedIndex = sessionCommissionCombo.FindStringExact(sessionGV.CurrentRow.Cells[0].Value.ToString());
            sessionDatePicker.Value = Convert.ToDateTime(sessionGV.CurrentRow.Cells[1].Value.ToString());
            sessionPlaceTextBox.Text = sessionGV.CurrentRow.Cells[2].Value.ToString();
        }

        private void updateSessionButton_Click(object sender, EventArgs e)
        {
            Commission commissionProto = new Commission(sessionCommissionCombo.SelectedItem.ToString());
            DateTime date = sessionDatePicker.Value;
            string place = sessionPlaceTextBox.Text;
            Commission commissionRes;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(dbName))
            {
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                commissionRes = (Commission)commissionSet.Next();
            }

            Session edit = new Session(commissionRes, date, place);
            Session.updateSession(sessionGV,edit);
            refreshSessionGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Session.deleteSession(sessionGV);
            refreshSessionGV();
        }

        private void openParticipants_Click(object sender, EventArgs e)
        {
            string commissionName = sessionGV.CurrentRow.Cells[0].Value.ToString();
            DateTime date = Convert.ToDateTime(sessionGV.CurrentRow.Cells[1].Value.ToString());
            string place = sessionGV.CurrentRow.Cells[2].Value.ToString();
            Commission commissionProto = new Commission(commissionName);
            Form p;
            Session sessionProto;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(dbName))
            {
                IObjectSet commissionSet = db.QueryByExample(commissionProto);
                Commission commissionRes = (Commission)commissionSet.Next();
                sessionProto = new Session(commissionRes, date, place);
                IObjectSet sessionSet = db.QueryByExample(sessionProto);
                db.Close();
            }
            p = new Participants(sessionProto);
            p.Show();
        }

        private void log(object sender, EventArgs e)
        {
            refreshCommissionGV();
            refreshPersonGV();
            refreshCommissionMemberGV();
            refreshSessionGV();
        }

        private void request1Button_Click(object sender, EventArgs e)
        {
            request1GV.Rows.Clear();
            if (request1GV.Columns.Count == 0)
            {
                request1GV.Columns.Add("commissionName", "Название комисcии");
                request1GV.Columns.Add("cmCount", "Количество членов");
            }
            if (requestTextBox.Text == "")return;
            string startsWith = requestTextBox.Text;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Commission));
                query.Descend("_commissionName").Constrain(startsWith).StartsWith(false);
                IObjectSet comSet = query.Execute();
                foreach (Commission com in comSet)
                {
                    query = db.Query();
                    query.Constrain(typeof(CommissionMember));
                    query.Descend("commission").Descend("_commissionName").Constrain(com.CommissionName);
                    query.Descend("exitDate").Constrain(DateTime.MinValue);
                    IObjectSet cmSet = query.Execute();
                    int cmCount = 0;
                    foreach (CommissionMember cm in cmSet)
                    {
                        cmCount++;
                    }

                    if (cmCount >= 10) continue;
                    request1GV.Rows.Add(com.CommissionName, cmCount);
                }
            }
        }
    }
}
