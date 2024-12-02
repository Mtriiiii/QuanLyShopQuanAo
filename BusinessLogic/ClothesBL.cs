using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ClothesBL
    {
        ClothesDA quanAoDA = new ClothesDA();
        public List<Clothes> GetAll()
        { return quanAoDA.GetAll();}
        public int Insert(Clothes clothes)
        { return quanAoDA.Insert_Update_Delete(clothes, 0); }
        public int Update(Clothes clothes)
        { return quanAoDA.Insert_Update_Delete(clothes, 1); }
        public int Delete(Clothes clothes)
        { return quanAoDA.Insert_Update_Delete( clothes, 2); }
    }
}
