using System.Collections.Generic;
using Perst;

namespace Lab1
{
    public class HelperDb<T>: IRead<T>
    {
        public Storage db;

        public HelperDb(bool init)
        {
            if (init) db = StorageFactory.Instance.CreateStorage();
        }

        public static MyRoot CreateRoot(Storage db)
        {
            db.Open(Form1.dbName);
            MyRoot Root = (MyRoot)db.Root;
            if (Root == null)
            {
                Root = new MyRoot(db);
            }
            db.Close();
            return Root;
        }

        public List<T> Read(FieldIndex fieldIndex)
        {
            List<T> dataList = new List<T>();
            foreach (T obj in fieldIndex)
            {
                dataList.Add(obj);
            }

            return dataList;
        }
    }
}