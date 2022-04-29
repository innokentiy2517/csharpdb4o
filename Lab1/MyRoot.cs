using Perst;

namespace Lab1
{
    public class MyRoot : Persistent
    {
        public FieldIndex index_Person;
        public FieldIndex index_commission;
        public FieldIndex index_commissionMember;
        public FieldIndex index_session;
        public MyRoot(Storage db) : base(db)
        {
            index_Person = db.CreateFieldIndex(typeof(Person), "Id", true);
            index_commission = db.CreateFieldIndex(typeof(Commission), "Id", true);
            index_commissionMember = db.CreateFieldIndex(typeof(CommissionMember), "Id", true);
            index_session = db.CreateFieldIndex(typeof(Session), "Id", true);
        }

    }
}