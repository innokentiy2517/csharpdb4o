using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Perst;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public static HelperDb<object> dbHelper;
        public static MyRoot root;
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
            }else if (type == typeof(Person))
            {
                dgv.Rows.Clear();
                if (dgv.Columns.Count == 0)
                {
                    dgv.Columns.Add("ID", "ID");
                    dgv.Columns.Add("FirstName", "Имя");
                    dgv.Columns.Add("MiddleName", "Отчество");
                    dgv.Columns.Add("SecondName", "Фамилия");
                    dgv.Columns.Add("AddressCity", "Город");
                    dgv.Columns.Add("AddressStreet", "Улица");
                    dgv.Columns.Add("AddressHouseNumber", "№ Дома");
                    dgv.Columns.Add("AddressAppartmentNumber", "№ Квартиры");
                    dgv.Columns.Add("PhoneHome", "Домашний номер телефона");
                    dgv.Columns.Add("PhoneWork", "Рабочий номер телефона");
                }
                foreach (Person p in dbHelper.Read(root.index_Person))
                {
                    dgv.Rows.Add(p.Id, p.FirstName, p.MiddleName, p.SecondName, p.AddressCity, p.AddressStreet,
                        p.AddressHouseNumber, p.AddressAppartmentNumber, p.PhoneHome, p.PhoneWork);
                }
            }else if (type == typeof(Commission))
            {
                dgv.Rows.Clear();
                if (dgv.Columns.Count==0)
                {
                    dgv.Columns.Add("ID", "ID");
                    dgv.Columns.Add("CommissionName", "Название комиссии");
                }
                foreach (Commission c in dbHelper.Read(root.index_commission))
                {
                    dgv.Rows.Add(c.Id, c.CommissionName);
                }
            } else if (type == typeof(CommissionMember))
            {
                dgv.Rows.Clear();
                if (dgv.Columns.Count == 0)
                {
                    dgv.Columns.Add("ID", "ID");
                    dgv.Columns.Add("PersonName", "ФИО Члена комиссии");
                    dgv.Columns.Add("CommissionName", "Комиссия");
                    dgv.Columns.Add("EntryDate", "Дата вступления");
                    dgv.Columns.Add("ExitDate", "Дата выхода");
                    dgv.Columns.Add("IsChairman", "Председатель");
                    dgv.Columns.Add("ChairStartDate", "Дата начала председательлства");
                    dgv.Columns.Add("ChairEndDate", "Дата конца председательлства");
                }
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
                        cm.Person.SecondName+" "+cm.Person.FirstName+" "+cm.Person.MiddleName,
                        cm.Commission.CommissionName,
                        cm.EntryDate.Date.ToString(),
                        exitDate,
                        cm.IsChairman,
                        chairStartDate,
                        chairEndDate);
                }
            } else if (type == typeof(Session))
            {
                dgv.Rows.Clear();
                if (dgv.Columns.Count == 0)
                {
                    dgv.Columns.Add("ID", "ID");
                    dgv.Columns.Add("sessionCommission", "Комиссия");
                    dgv.Columns.Add("sessionDate", "Дата собрания");
                    dgv.Columns.Add("sessionPlace", "Место проведения");
                }
                foreach (Session s in dbHelper.Read(root.index_session))
                {
                    dgv.Rows.Add(
                        s.Id,
                        s.Commission.CommissionName,
                        s.Place,
                        s.Date);
                }
            }
            dbHelper.db.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadF(commissionGridView, typeof(Commission));
            ReadF(personGridView,typeof(Person));
            ReadF(commissionMemberDGV, typeof(CommissionMember));
            ReadF(sessionGV,typeof(Session));
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void editPersonButton_Click(object sender, EventArgs e)
        {
            dbHelper.db.Open(dbName);
            List<Person> personSet = root.index_Person.Cast<Person>().Where(p =>
                p.PhoneHome == phoneHomeTextBox.Text || p.PhoneWork == phoneWorkTextBox.Text).ToList();
            dbHelper.db.Close();
            if (personSet.Count > 0)
            {
                MessageBox.Show("Номера телефона должны быть уникальными");
                return;
            }
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
            firstNameTextBox.Text = personGridView.CurrentRow.Cells[1].Value.ToString();
            middleNameTextBox.Text = personGridView.CurrentRow.Cells[2].Value.ToString();
            secondNameTextBox.Text = personGridView.CurrentRow.Cells[3].Value.ToString();
            cityTextBox.Text = personGridView.CurrentRow.Cells[4].Value.ToString();
            streetTextBox.Text = personGridView.CurrentRow.Cells[5].Value.ToString();
            houseNumberTextBox.Text = personGridView.CurrentRow.Cells[6].Value.ToString();
            appartNumberTextBox.Text = personGridView.CurrentRow.Cells[7].Value.ToString();
            phoneHomeTextBox.Text = personGridView.CurrentRow.Cells[8].Value.ToString();
            phoneWorkTextBox.Text = personGridView.CurrentRow.Cells[9].Value.ToString();
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(houseNumberTextBox.Text);
                Convert.ToInt32(appartNumberTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Номер дома и квартиры не должен содержать буквы");
                return;
            }
            dbHelper.db.Open(dbName);
            List<Person> personSet = root.index_Person.Cast<Person>().Where(p =>
                p.PhoneHome == phoneHomeTextBox.Text || p.PhoneWork == phoneWorkTextBox.Text).ToList();
            dbHelper.db.Close();
            if (personSet.Count > 0)
            {
                MessageBox.Show("Номера телефона должны быть уникальными");
                return;
            }
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
            if (textBox1.Text.Length == 0) {MessageBox.Show("Название комиссии не должно быть пустым"); return;}
            string name = textBox1.Text;
            bool unique = true;
            dbHelper.db.Open(dbName);
            foreach (Commission c in dbHelper.Read(root.index_commission))
            {
                if (c.CommissionName == textBox1.Text) unique = false;
            }
            dbHelper.db.Close();
            if (!unique)
            {
                MessageBox.Show("Комиссия с таким названием уже есть");
                return;
            }
            Commission.AddCommission(name,commissionGridView.Rows.Count,dbHelper.db);
            ReadF(commissionGridView, typeof(Commission));
        }

        private void editCommissionButton_Click(object sender, EventArgs e)
        {
            bool unique = true;
            dbHelper.db.Open(dbName);
            foreach (Commission c in dbHelper.Read(root.index_commission))
            {
                if (c.CommissionName == textBox1.Text) unique = false;
            }
            dbHelper.db.Close();
            if (!unique)
            {
                MessageBox.Show("Комиссия с таким названием уже есть");
                return;
            }
            Commission edit = new Commission(textBox1.Text,0);
            Commission.UpdateCommission(edit, dbHelper.db,(int)commissionGridView.CurrentRow.Cells[0].Value);
            ReadF(commissionGridView, typeof(Commission));
        }

        private void commissionGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (commissionGridView.Rows.Count == 0) return;
            textBox1.Text = commissionGridView.CurrentRow.Cells[1].Value.ToString();
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
            dbHelper.db.Open(dbName);
            personComboBox.Items.Clear();
            foreach (Person p in dbHelper.Read(root.index_Person))
            {
                personComboBox.Items.Add(p.SecondName + " " + p.FirstName + " " + p.MiddleName);
            }
            dbHelper.db.Close();
        }

        private void commissionDropDown_DropDown(object sender, EventArgs e)
        {
            dbHelper.db.Open(dbName);
            commissionDropDown.Items.Clear();
            foreach (Commission c in dbHelper.Read(root.index_commission))
            {
                commissionDropDown.Items.Add(c.CommissionName);
            }
            dbHelper.db.Close();
        }

        private void assignChairmanButton_Click(object sender, EventArgs e)
        {
            CommissionMember.assignChair((int)commissionMemberDGV.CurrentRow.Cells[0].Value,dbHelper.db);
            ReadF(commissionMemberDGV, typeof(CommissionMember));
        }

        private void addCommissionMemberButton_Click(object sender, EventArgs e)
        {
            dbHelper.db.Open(dbName);
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

            List<CommissionMember> cmSet = root.index_commissionMember.Cast<CommissionMember>().Where(cm =>
                cm.Person == person && cm.ExitDate == DateTime.MinValue).ToList();
            dbHelper.db.Close();
            bool isBusy = cmSet.Count > 0;

            if (isBusy)
            {
                MessageBox.Show("Данный член гордумы уже состоит в комиссии!");
                return;
            }
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
            dbHelper.db.Open(dbName);
            sessionCommissionCombo.Items.Clear();
            foreach (Commission c in dbHelper.Read(root.index_commission))
            {
                sessionCommissionCombo.Items.Add(c.CommissionName);
            }
            dbHelper.db.Close();
        }
        
        private void sessionCommissionCombo_DropDown(object sender, EventArgs e)
        {
            sessionCommisisonComboSet();
        }

        private void addSessionButton_Click(object sender, EventArgs e)
        {
            dbHelper.db.Open(dbName);
            string place = sessionPlaceTextBox.Text;
            DateTime date = sessionDatePicker.Value;
            Commission commissionRes = null;
            foreach (Commission c in root.index_commission.Cast<Commission>().Where(c=>c.CommissionName==sessionCommissionCombo.SelectedItem.ToString()))
            {
                commissionRes = c;
            }
            dbHelper.db.Close();
            Session.addSession(
                commissionRes,
                date,
                place,
                sessionGV.Rows.Count,
                dbHelper.db
                );
            ReadF(sessionGV,typeof(Session));
        }

        private void sessionGV_mouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sessionCommisisonComboSet();
            if (commissionGridView.Rows.Count == 0) return;
            sessionCommissionCombo.SelectedIndex = sessionCommissionCombo.FindStringExact(sessionGV.CurrentRow.Cells[1].Value.ToString());
            sessionDatePicker.Value = Convert.ToDateTime(sessionGV.CurrentRow.Cells[3].Value.ToString());
            sessionPlaceTextBox.Text = sessionGV.CurrentRow.Cells[2].Value.ToString();
        }

        private void updateSessionButton_Click(object sender, EventArgs e)
        {
            dbHelper.db.Open(dbName);
            DateTime date = sessionDatePicker.Value;
            string place = sessionPlaceTextBox.Text;
            Commission commissionRes = null;
            foreach (Commission c in root.index_commission.Cast<Commission>().Where(c=>c.CommissionName==sessionCommissionCombo.SelectedItem.ToString()))
            {
                commissionRes = c;
            }
            dbHelper.db.Close();
            Session edit = new Session(commissionRes, date, place,0);
            Session.updateSession(sessionGV,edit,dbHelper.db);
            ReadF(sessionGV,typeof(Session));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Session.deleteSession(sessionGV, dbHelper.db);
            ReadF(sessionGV,typeof(Session));
        }

        private void openParticipants_Click(object sender, EventArgs e)
        {
            Form p = new Participants((int)sessionGV.CurrentRow.Cells[0].Value);
            p.Show();
        }

        private void log(object sender, EventArgs e)
        {
            ReadF(commissionGridView, typeof(Commission));
            ReadF(personGridView,typeof(Person));
            ReadF(commissionMemberDGV, typeof(CommissionMember));
            ReadF(sessionGV,typeof(Session));
        }

        private void indexQuery(DataGridView dgv, Storage db, DateTime dateFrom, DateTime dateTo)
        {
            dgv.Rows.Clear();
            MyRoot Root = HelperDb<Session>.CreateRoot(db);
            db.Open(dbName);

            /*List<Session> session = Root.index_session.Cast<Session>()
                .Where(s => s.Date >= dateFrom.Date&&s.Date<=dateTo.Date).ToList();*/
            List<Session> sessions = Root.multiSession
                .Range(
                    new Key(new object[] { dateFrom, "" }),
                    new Key(new object[] { dateTo, "" }),
                    IterationOrder.DescentOrder)
                .Cast<Session>()
                .ToList();
            
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add("CommissionName", "Комиссия");
                dgv.Columns.Add("Place", "Место");
                dgv.Columns.Add("Date", "Дата");
            }

            foreach (Session s in sessions)
            {
                dgv.Rows.Add(s.Commission.CommissionName, s.Place, s.Date);
            }
            db.Close();
        }

        private void indexQueryButton_Click(object sender, EventArgs e)
        {
            indexQuery(indexQueryDGV, dbHelper.db, fromDatePicker.Value, toDatePicker.Value);
        }

        private void JSQLQuery(DataGridView dgv, Storage db)
        {
            dgv.Rows.Clear();
            // MyRoot Root = HelperDb<Session>.CreateRoot(db);
            db.Open(dbName);
            if (dgv.Columns.Count == 0)
            {
                dgv.Columns.Add("FIO", "ФИО");
                dgv.Columns.Add("commission", "Название комиссии");
            }
            foreach (CommissionMember cm in root.index_commissionMember.Cast<CommissionMember>().Where(cm=>cm.ExitDate==DateTime.MinValue))
            {
                int missed = 0;
                foreach (Session s in root.index_session.Cast<Session>().Where(ses=>!ses.SessionParticipants.Contains(cm)&&ses.Commission.Id==cm.Commission.Id))
                {
                    missed++;
                }

                if (missed >= 2)
                {
                    dgv.Rows.Add(cm.Person.SecondName + " " + cm.Person.FirstName + " " + cm.Person.MiddleName,
                        cm.Commission.CommissionName);
                }
            }
            db.Close();
        }

        private void JSQLQueryButton_Click(object sender, EventArgs e)
        {
            JSQLQuery(JSQLQueryGV,dbHelper.db);
        }
    }
}
