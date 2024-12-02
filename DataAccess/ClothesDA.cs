using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClothesDA
    {
        public List<Clothes> GetAll()
        {
            SqlConnection sqlConn = new
               SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Clothes_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Clothes> list = new List<Clothes>();
            while (reader.Read())
            {
                Clothes QuanAo = new Clothes();
                QuanAo.ID = Convert.ToInt32(reader["ID"]);
                QuanAo.TenQuanAo = reader["TenQuanAo"].ToString();
                QuanAo.NhomMatHangID = Convert.ToInt32(reader["NhomMatHangID"]);
                QuanAo.GiaBan = Convert.ToInt32(reader["GiaBan"]);
                QuanAo.GhiChu = reader["GhiChu"].ToString();
                QuanAo.Enable = Convert.ToBoolean(reader["enable"]);
                list.Add(QuanAo);
            }
            // Đóng kết nối và trả về danh sách
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Clothes clothes, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Clothes_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = clothes.ID;

            command.Parameters.Add("@TenQuanAo", SqlDbType.NVarChar, 50).Value = clothes.TenQuanAo;
            command.Parameters.Add("@NhomMatHangID", SqlDbType.Int).Value = clothes.NhomMatHangID;
            command.Parameters.Add("@GiaBan", SqlDbType.Int).Value = clothes.GiaBan;
            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar,50).Value = clothes.GhiChu;
            command.Parameters.Add("@Enable", SqlDbType.Bit).Value = clothes.Enable;
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
