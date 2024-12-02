using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        public static string ColorSize_GetAll = "ColorSize_GetAll";
        public static string ColorSize_InsertUpdateDelete = "ColorSize_InsertUpdateDelete";

        public static string Clothes_GetAll = "Clothes_GetAll";
        public static string Clothes_InsertUpdateDelete = "Clothes_InsertUpdateDelete";

        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";
        public static string Category_GetTopSell = "Category_GetTopSell";

        public static string Employee_GetAll = "Employee_GetAll";
        public static string Employee_InsertUpdateDelete = "Employee_InsertUpdateDelete";
        
        public static string Bill_GetAll = "Bill_GetAll";
        public static string Bill_InsertUpdateDelete = "Bill_InsertUpdateDelete";

        public static string BillDetail_GetAll = "BillDetail_GetAll";
        public static string BillDetail_InsertUpdateDelete = "BillDetail_InsertUpdateDelete";

        public static string Customer_GetAll = "Customer_GetAll";
        public static string Customer_InsertUpdateDelete = "Customer_InsertUpdateDelete";
    }
}
