using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDA
    {
        public List<Category> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Category_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                Category nhom = new Category();
                nhom.ID = Convert.ToInt32(reader["ID"]);
                nhom.TenNhom = reader["TenNhom"].ToString();
                nhom.GhiChu = reader["GhiChu"].ToString();
                nhom.Enable = Convert.ToBoolean(reader["enable"].ToString());
                list.Add(nhom);
            }
            sqlConn.Close();
            return list;
        }
        public List<int> NhomMatHangTheoSL()
        {
            List<int> result = new List<int>();
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Category_GetTopSell;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                result.Add(Convert.ToInt32(reader["ID"]));
            }
            sqlConn.Close();
            return result;
        }
        public int Insert_Update_Delete(Category category, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Category_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = category.ID;

            command.Parameters.Add("@TenNhom", SqlDbType.NVarChar,50).Value = category.TenNhom;
            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar,50).Value = category.GhiChu;
            command.Parameters.Add("@Enable", SqlDbType.Bit).Value = category.Enable;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            // Thực thi lệnh
            int result = command.ExecuteNonQuery();

            // Đóng kết nối
            sqlConn.Close();

            // Trả về ID nếu thành công, ngược lại trả về 0
            if (result > 0)
                return (int)command.Parameters["@ID"].Value;

            return 0;
        }
    }
}
