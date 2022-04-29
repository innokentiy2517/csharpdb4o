using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Perst;

namespace Lab1
{
    public class Person : Persistent
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
            id,
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
            int? id,
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
            this.Id = (int)id;
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
        public int Id { get => id; set => id = value; }

        private static int uniqueId(int id, MyRoot Root)
        {
            int unique = Root.index_Person.Cast<Person>().Count(p => p.Id == id);
            return unique;
        }

        public static void addPerson(
            string FirstName,
            string MiddleName,
            string SecondName,
            string AddressCity,
            string AddressStreet,
            int AddressHouseNumber,
            int AddressAppartmentNumber,
            string PhoneHome,
            string PhoneWork,
            int id,
            Storage db
            )
        {
            /*using (IObjectContainer db = Db4oEmbedded.OpenFile(Form1.dbName))
            {
                db.Store(newPerson);
                db.Close();
            }
            MessageBox.Show("Запись о члене ГорДумы успешно создана!");*/
            MyRoot Root = HelperDb<Person>.CreateRoot(db);
            db.Open(Form1.dbName);
            if (uniqueId(id, Root) != 0)
            {
                id++;
            }
            Person newPerson = new Person(FirstName, MiddleName, SecondName, AddressCity, AddressStreet, PhoneHome, PhoneWork, id, AddressHouseNumber, AddressAppartmentNumber);

            Root.index_Person.Put(newPerson);
            MessageBox.Show("Член ГорДумы создан","Сообщение", MessageBoxButtons.OK);
            db.Close();
        }
        
        public static void UpdatePerson(
            Person toEdit,
            Storage db,
            int id
            )
        {
            MyRoot Root = HelperDb<Person>.CreateRoot(db);
            db.Open(Form1.dbName);
            Person person = null;
            foreach (Person p in Root.index_Person.Cast<Person>().Where(p => p.Id == id))
            {
                person = p;
            }

            person.FirstName = toEdit.FirstName;
            person.MiddleName = toEdit.MiddleName;
            person.SecondName = toEdit.SecondName;
            person.AddressCity = toEdit.AddressCity;
            person.AddressStreet = toEdit.AddressStreet;
            person.AddressHouseNumber = toEdit.AddressHouseNumber;
            person.AddressAppartmentNumber = toEdit.AddressAppartmentNumber;
            person.PhoneHome = toEdit.PhoneHome;
            person.PhoneWork = toEdit.PhoneWork;
            person.Modify();
            MessageBox.Show("Запись изменена", "Сообщение", MessageBoxButtons.OK);
            db.Close();
        }

        public static void DeletePerson(DataGridView dgv, Storage db)
        {
            int id = (int)dgv.CurrentRow.Cells[0].Value;
            MyRoot Root = HelperDb<Person>.CreateRoot(db);
            db.Open(Form1.dbName);
            Person person = null;
            foreach (Person p in Root.index_Person.Cast<Person>().Where(p=>p.Id == id))
            {
                person = p;
            }

            Root.index_Person.Remove(person);
            MessageBox.Show("Запись удалена!", "Сообщение", MessageBoxButtons.OK);
            db.Close();
        }
    }
}
