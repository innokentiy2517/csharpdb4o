using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public class Person
    {
        private string
            firstName,
            middleName,
            secondName,
            addressCity,
            addressStreet,
            phoneHome,
            phoneWork;
        private int
            addressHouseNumber,
            addressAppartmentNumber;

        public Person(){}
        public Person(
            string firstName,
            string middleName,
            string secondName,
            string addressCity,
            string addressStreet,
            string phoneHome,
            string phoneWork,
            int? addressHouseNumber,
            int? addressAppartmentNumber
            )
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.SecondName = secondName;
            this.AddressCity = addressCity;
            this.AddressStreet = addressStreet;
            this.PhoneHome = phoneHome;
            this.PhoneWork = phoneWork;
            this.AddressHouseNumber = (int)addressHouseNumber;
            this.AddressAppartmentNumber = (int)addressAppartmentNumber;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string AddressCity { get => addressCity; set => addressCity = value; }
        public string AddressStreet { get => addressStreet; set => addressStreet = value; }
        public string PhoneHome { get => phoneHome; set => phoneHome = value; }
        public string PhoneWork { get => phoneWork; set => phoneWork = value; }
        public int AddressHouseNumber { get => addressHouseNumber; set => addressHouseNumber = value; }
        public int AddressAppartmentNumber { get => addressAppartmentNumber; set => addressAppartmentNumber = value; }

        public static void addPerson(
            string FirstName,
            string MiddleName,
            string SecondName,
            string AddressCity,
            string AddressStreet,
            int AddressHouseNumber,
            int AddressAppartmentNumber,
            string PhoneHome,
            string PhoneWork
            )
        {
            Person newPerson = new Person(FirstName, MiddleName, SecondName, AddressCity, AddressStreet, PhoneHome, PhoneWork, AddressHouseNumber, AddressAppartmentNumber);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                db.Store(newPerson);
                db.Close();
            }
            MessageBox.Show("Запись о члене ГорДумы успешно создана!");
        }

        public static void getPersons(DataGridView dataGridView, IObjectContainer db)
        {
            dataGridView.Rows.Clear();
            if (dataGridView.Columns.Count == 0)
            {
                dataGridView.Columns.Add("FirstName", "Имя");
                dataGridView.Columns.Add("MiddleName", "Отчество");
                dataGridView.Columns.Add("SecondName", "Фамилия");
                dataGridView.Columns.Add("AddressCity", "Город");
                dataGridView.Columns.Add("AddressStreet", "Улица");
                dataGridView.Columns.Add("AddressHouseNumber", "№ Дома");
                dataGridView.Columns.Add("AddressAppartmentNumber", "№ Квартиры");
                dataGridView.Columns.Add("PhoneHome", "Домашний номер телефона");
                dataGridView.Columns.Add("PhoneWork", "Рабочий номер телефона");
            }

            IQuery query = db.Query();
            query.Constrain(typeof(Person));
            IObjectSet persons = query.Execute();
            foreach (Person p in persons)
            {
                dataGridView.Rows.Add(
                    p.FirstName,
                    p.MiddleName,
                    p.SecondName,
                    p.AddressCity,
                    p.AddressStreet,
                    p.AddressHouseNumber,
                    p.AddressAppartmentNumber,
                    p.PhoneHome,
                    p.PhoneWork
                    );
            }
        }

        public static void UpdatePerson(
            DataGridView dgv,
            Person toEdit
            )
        {
            if (dgv.SelectedRows.Count != 0)
            {
                Person person = new Person(
                dgv.CurrentRow.Cells[0].Value.ToString(),
                dgv.CurrentRow.Cells[1].Value.ToString(),
                dgv.CurrentRow.Cells[2].Value.ToString(),
                dgv.CurrentRow.Cells[3].Value.ToString(),
                dgv.CurrentRow.Cells[4].Value.ToString(),
                dgv.CurrentRow.Cells[7].Value.ToString(),
                dgv.CurrentRow.Cells[8].Value.ToString(),
                Convert.ToInt32(dgv.CurrentRow.Cells[5].Value),
                Convert.ToInt32(dgv.CurrentRow.Cells[6].Value));
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet temp = db.QueryByExample(person);
                    Person found = (Person)temp.Next();
                    found.FirstName = toEdit.FirstName;
                    found.MiddleName = toEdit.MiddleName;
                    found.SecondName = toEdit.SecondName;
                    found.AddressCity = toEdit.AddressCity;
                    found.AddressStreet = toEdit.AddressStreet;
                    found.AddressHouseNumber = toEdit.AddressHouseNumber;
                    found.AddressAppartmentNumber = toEdit.AddressAppartmentNumber;
                    found.PhoneHome = toEdit.PhoneHome;
                    found.PhoneWork = toEdit.PhoneWork;
                    db.Store(found);
                    db.Close();
                }
                MessageBox.Show("Изменения сохранены!");
            }
            else MessageBox.Show("Запись не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DeletePerson(DataGridView dgv)
        {
            Person personToDelete = new Person(
                dgv.CurrentRow.Cells[0].Value.ToString(),
                dgv.CurrentRow.Cells[1].Value.ToString(),
                dgv.CurrentRow.Cells[2].Value.ToString(),
                dgv.CurrentRow.Cells[3].Value.ToString(),
                dgv.CurrentRow.Cells[4].Value.ToString(),
                dgv.CurrentRow.Cells[7].Value.ToString(),
                dgv.CurrentRow.Cells[8].Value.ToString(),
                Convert.ToInt32(dgv.CurrentRow.Cells[5].Value),
                Convert.ToInt32(dgv.CurrentRow.Cells[6].Value));

            if (MessageBox.Show("ОПАСНА. ВЫ ХОТИТЕ УДАЛИТЬ ЗАПИСЬ?", "АХТУНГ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
                {
                    IObjectSet result = db.QueryByExample(personToDelete);
                    foreach (Person p in result)
                    {
                        db.Delete(p);
                    }
                    db.Close();
                }
                MessageBox.Show("С удалением этой записи нить вашей судьбы обрывается. Загрузите предыдущий бекап базы данных дабы восстановаить течение судьбы, или живите дальше в проклятом мире, который сами и создали");
            }
        }
    }
}
