using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public class Color_SizeBL
    {
        Color_SizeDA mauSizeDA = new Color_SizeDA();
        public List<Color_Size> GetAll()
        {
            return mauSizeDA.GetAll();
        }
        public List<Color_Size> GetBySize(List<string> size)
        { return mauSizeDA.GetBySize(size); }
        public int Insert(Color_Size color_Size)
        { return mauSizeDA.Insert_Update_Delete(color_Size, 0); }
        public int Update(Color_Size color_Size)
        { return mauSizeDA.Insert_Update_Delete(color_Size, 1); }
        public int Delete(Color_Size color_Size)
        { return mauSizeDA.Insert_Update_Delete(color_Size, 2); }
    }
}
