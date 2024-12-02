using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillDetailBL
    {
        BillDetailDA billdetailDA = new BillDetailDA();
        public List<BillDetail> GetAll()
        {
            return billdetailDA.GetAll();
        }
        public List<BillDetail> GetFromBillID(int id)
        {
           return billdetailDA.GetFromBillID(id);
        }

        public int Insert(BillDetail billdetail)
        { return billdetailDA.Insert_Update_Delete(billdetail, 0); }

        public int Update(BillDetail billdetail)
        { return billdetailDA.Insert_Update_Delete(billdetail, 1); }

        public int Delete(BillDetail billdetail)
        { return billdetailDA.Insert_Update_Delete(billdetail, 2); }
    }
}
