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
        private static HelperDb<object> dbHelper;
        private static MyRoot root;
        public static string dbName = "Gorduma.dbs";
        public Form1()
        {
            InitializeComponent();
            dbHelper = new HelperDb<object>(true);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public void ReadF(DataGridView dgv, Type type)
        {
            dbHelper.db.Open(dbName);
            root = (MyRoot)dbHelper.db.Root;
            if (dbHelper.db.Root == null)
            {
                dbHelper.db.Root = new MyRoot(dbHelper.db);
            }

            if (type == typeof(Person))
            {
                dgv.Rows.Clear();
                foreach (Person p in dbHelper.Read(root.index_Person))
                {
                    dgv.Rows.Add(p.Id, p.SecondName, p.FirstName, p.MiddleName, p.AddressCity, p.AddressStreet,
                        p.AddressHouseNumber, p.AddressAppartmentNumber, p.PhoneHome, p.PhoneWork);
                }
            }

            if (type == typeof(Commission))
            {
                dgv.Rows.Clear();
                foreach (Commission c in dbHelper.Read(root.index_commission))
                {
                    dgv.Rows.Add(c.Id, c.CommissionName);
                }
            }

            if (type == typeof(CommissionMember))
            {
                dgv.Rows.Clear();
                foreach (CommissionMember cm in dbHelper.Read(root.index_commissionMember))
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
                    dgv.Rows.Add(cm.Id,
                        cm.Person.SecondName,
                        cm.Person.FirstName,
                        cm.Person.MiddleName,
                        cm.Commission.CommissionName,
                        cm.EntryDate.Date.ToString(),
                        exitDate,
                        cm.IsChairman,
                        chairStartDate,
                        chairEndDate);
                }
            }
            dbHelper.db.Close();
        }
        
        /*private void refreshCommissionGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                Commission.getComissions(commissionGridView, db);
                db.Close();
            }
        }*/

        /*private void refreshPersonGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                Person.getPersons(personGridView, db);
                db.Close();
            }
        }*/
        
        /*private void refreshCommissionMemberGV()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                CommissionMember.getCommissionMembers(commissionMemberDGV, db);
                db.Close();
            }
        }*/

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
            ReadF(commissionGridView, typeof(Commission));
            ReadF(personGridView,typeof(Person));
            ReadF(commissionMemberDGV, typeof(CommissionMember));
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
                addressAppartmentNumber: Convert.ToInt32(appartNumberTextBox.Text),
                id: 0
                );
            Person.UpdatePerson(edit,dbHelper.db, (int)personGridView.CurrentRow.Cells[0].Value);
            ReadF(personGridView, typeof(Person));
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
                FirstName: firstNameTextBox.Text,
                MiddleName: middleNameTextBox.Text,
                SecondName: secondNameTextBox.Text,
                AddressCity: cityTextBox.Text,
                AddressStreet: streetTextBox.Text,
                AddressHouseNumber:Convert.ToInt32(houseNumberTextBox.Text),
                AddressAppartmentNumber:Convert.ToInt32(appartNumberTextBox.Text),
                PhoneHome:phoneHomeTextBox.Text,
                PhoneWork:phoneWorkTextBox.Text,
                id: personGridView.Rows.Count,
                db: dbHelper.db
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
            ReadF(personGridView, typeof(Person));
        }

        private void deletePersonButton_Click(object sender, EventArgs e)
        {
            Person.DeletePerson(personGridView, dbHelper.db);
            ReadF(personGridView, typeof(Person));
        }

        private void addCommissionButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            Commission.AddCommission(name,commissionGridView.Rows.Count,dbHelper.db);
            ReadF(commissionGridView, typeof(Commission));
        }

        private void editCommissionButton_Click(object sender, EventArgs e)
        {
            Commission edit = new Commission(textBox1.Text,0);
            Commission.UpdateCommission(edit, dbHelper.db,(int)commissionGridView.CurrentRow.Cells[0].Value);
            ReadF(commissionGridView, typeof(Commission));
        }

        private void commissionGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (commissionGridView.Rows.Count == 0) return;
            textBox1.Text = commissionGridView.CurrentRow.Cells[0].Value.ToString();
        }

        private void commissionDeleteButton_Click(object sender, EventArgs e)
        {
            Commission.DeleteCommission(commissionGridView, dbHelper.db);
            ReadF(commissionGridView,typeof(Commission));
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void personComboBox_DropDown(object sender, EventArgs e)
        {
            personComboBox.Items.Clear();
            foreach (Person p in root.index_Person.Cast<Person>())
            {
                personComboBox.Items.Add(p.SecondName + " " + p.FirstName + " " + p.MiddleName);
            }
            /*using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Person));
                IObjectSet personsSet = query.Execute();
                foreach (Person person in personsSet)
                {
                    personComboBox.Items.Add(person.SecondName +" "+ person.FirstName +" "+ person.MiddleName);
                }
                db.Close();
            }*/
        }

        private void commissionDropDown_DropDown(object sender, EventArgs e)
        {
            commissionDropDown.Items.Clear();
            foreach (Commission c in root.index_commission.Cast<Commission>())
            {
                commissionDropDown.Items.Add(c.CommissionName);
            }
            /*using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Commission));
                IObjectSet commissionSet = query.Execute();
                foreach (Commission c in commissionSet)
                {
                    commissionDropDown.Items.Add(c.CommissionName);
                }
                db.Close();
            }*/
        }

        private void assignChairmanButton_Click(object sender, EventArgs e)
        {
            CommissionMember.assignChair((int)commissionMemberDGV.CurrentRow.Cells[0].Value,dbHelper.db);
            ReadF(commissionMemberDGV, typeof(CommissionMember));
        }

        private void addCommissionMemberButton_Click(object sender, EventArgs e)
        {
            string personFIO = personComboBox.SelectedItem.ToString();
            string[] FIO = personFIO.Split();
            string firstName = FIO[1];
            string middleName = FIO[2];
            string secondName = FIO[0];
            Person person = null;
            Commission commission = null;
            foreach (Person p in root.index_Person.Cast<Person>().Where(p=>p.FirstName==firstName && p.MiddleName==middleName && p.SecondName==secondName))
            {
                person = p;
            }

            foreach (Commission c in root.index_commission.Cast<Commission>().Where(c=>c.CommissionName==commissionDropDown.SelectedItem.ToString()))
            {
                commission = c;
            }
            /*Person personProto = new Person()
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
            }*/
            
            CommissionMember.addCommissionMember(person, commission,commissionMemberDGV.Rows.Count, dbHelper.db);
            ReadF(commissionMemberDGV, typeof(CommissionMember));
        }

        private void deassignChairmanButton_Click(object sender, EventArgs e)
        {
            CommissionMember.deassignChair((int)commissionMemberDGV.CurrentRow.Cells[0].Value,dbHelper.db);
            ReadF(commissionMemberDGV, typeof(CommissionMember));
        }

        private void removeFromCommissionButton_Click(object sender, EventArgs e)
        {
            CommissionMember.exileMember((int)commissionMemberDGV.CurrentRow.Cells[0].Value,dbHelper.db);
            ReadF(commissionMemberDGV, typeof(CommissionMember));
        }

        private void sessionCommisisonComboSet()
        {
            sessionCommissionCombo.Items.Clear();
            foreach (Commission c in root.index_commission.Cast<Commission>())
            {
                sessionCommissionCombo.Items.Add(c.CommissionName);
            }
            /*using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                IQuery query = db.Query();
                query.Constrain(typeof(Commission));
                IObjectSet commissionSet = query.Execute();
                foreach (Commission c in commissionSet)
                {
                    sessionCommissionCombo.Items.Add(c.CommissionName);
                }
                db.Close();
            }*/
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
            ReadF(commissionGridView, typeof(Commission));
            ReadF(personGridView,typeof(Person));
            ReadF(commissionMemberDGV, typeof(CommissionMember));
            refreshSessionGV();
        }
    }
}
