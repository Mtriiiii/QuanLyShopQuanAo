using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillBL
    {
        BillDA billDA = new BillDA();
        public List<Bill> GetAll()
        { return billDA.GetAll(); }
        public int Insert(Bill bill)
        { return billDA.Insert_Update_Delete(bill, 0); }

        public int Update(Bill bill)
        { return billDA.Insert_Update_Delete(bill, 1); }

        public int Delete(Bill bill)
        { return billDA.Insert_Update_Delete(bill, 2); }
        public List<Bill> GetBillCustomerID(int ID, bool sortDate)
        { return billDA.GetBillCustomerID(ID, sortDate); }
    }
}
