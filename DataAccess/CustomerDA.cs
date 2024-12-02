using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDA
    {
        public List<Customer> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Customer_GetAll; // Thay tên thủ tục phù hợp

            // Đọc dữ liệu, trả về danh sách các đối tượng Customer
            SqlDataReader reader = command.ExecuteReader();
            List<Customer> list = new List<Customer>();
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(reader["id"]);
                customer.HoTen = reader["HoTen"].ToString();
                customer.SDT = reader["SDT"].ToString();
                customer.DiaChi = reader["DiaChi"].ToString();
                customer.TongTienDaMua = Convert.ToInt32(reader["TongTienDaMua"]);
                list.Add(customer);
            }

            sqlConn.Close();
            return list;
        }

        public int Insert_Update_Delete(Customer customer, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Customer_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = customer.Id;

            command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = customer.HoTen;
            command.Parameters.Add("@SDT", SqlDbType.Char, 10).Value = customer.SDT;
            command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).Value = customer.DiaChi;
            command.Parameters.Add("@TongTienDaMua", SqlDbType.Int).Value = customer.TongTienDaMua;
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
