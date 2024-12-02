using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Color_SizeDA
    {
        public List<Color_Size> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.ColorSize_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Color_Size> list = new List<Color_Size>();
            while (reader.Read())
            {
                Color_Size mauSize = new Color_Size();
                mauSize.ID = Convert.ToInt32(reader["ID"]);
                mauSize.QuanAoID = Convert.ToInt32(reader["QuanAoID"]);
                mauSize.MauSac = reader["MauSac"].ToString();
                mauSize.Size = reader["Size"].ToString();
                mauSize.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                list.Add(mauSize);
            }
            sqlConn.Close();
            return list;
        }
        public List<Color_Size> GetBySize(List<string> listSize)
        {
            string condition="";
            for (int i = 0; i < listSize.Count; i++) 
            {
                if (i == listSize.Count - 1)
                {
                    condition += "Size='" + listSize[i]+"'";
                    break;
                }
                condition += "Size='" + listSize[i] + "' or ";
            }
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            if (condition == "")
                command.CommandText = "Select * from Color_Size ";
            else
                command.CommandText = "Select * from Color_Size where " + condition;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Color_Size> list = new List<Color_Size>();
            while (reader.Read())
            {
                Color_Size mauSize = new Color_Size();
                mauSize.ID = Convert.ToInt32(reader["ID"]);
                mauSize.QuanAoID = Convert.ToInt32(reader["QuanAoID"]);
                mauSize.MauSac = reader["MauSac"].ToString();
                mauSize.Size = reader["Size"].ToString();
                mauSize.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                list.Add(mauSize);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Color_Size color_Size, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.ColorSize_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = color_Size.ID;

            command.Parameters.Add("@QuanAoID", SqlDbType.Int).Value = color_Size.QuanAoID;
            command.Parameters.Add("@MauSac", SqlDbType.NVarChar,20).Value = color_Size.MauSac;
            command.Parameters.Add("@Size", SqlDbType.NVarChar,10).Value = color_Size.Size;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = color_Size.SoLuong;
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
