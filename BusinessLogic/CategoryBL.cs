using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoryBL
    {
        CategoryDA nhomMatHangDA = new CategoryDA();
        public List<Category> GetAll()
        { return nhomMatHangDA.GetAll(); }
        public List<int> GetSoLuong()
        { return nhomMatHangDA.NhomMatHangTheoSL(); }
        public int Insert(Category category)
        { return nhomMatHangDA.Insert_Update_Delete(category, 0); }
        public int Update(Category category)
        { return nhomMatHangDA.Insert_Update_Delete(category, 1); }
        public int Delete(Category category)
        { return nhomMatHangDA.Insert_Update_Delete(category, 2); }
    }
}
