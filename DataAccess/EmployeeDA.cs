using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EmployeeDA
    {
        public List<Employee> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Employee_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> list = new List<Employee>();
            while (reader.Read())
            {
                Employee nv = new Employee();
                nv.Id = Convert.ToInt32(reader["ID"]);
                nv.HoTen = reader["HoTen"].ToString();
                nv.SoCCCD = reader["SoCCCD"].ToString();
                nv.DiaChi = reader["DiaChi"].ToString();
                nv.NgaySinh = Convert.ToDateTime(reader["NgaySinh"].ToString());
                nv.NgayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"].ToString());
                nv.ViTriLV = reader["ViTriLV"].ToString();
                nv.SoDienThoai = reader["SDT"].ToString();
                nv.Luong = int.Parse(reader["Luong"].ToString());
                nv.Enable = Convert.ToBoolean(reader["enable"].ToString());
                nv.TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                nv.Password = reader["Password"].ToString();
                list.Add(nv);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Employee employee, int action)
        {
            using (SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Employee_InsertUpdateDelete";

                SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
                IDPara.Direction = ParameterDirection.InputOutput; // Vừa đầu vào vừa đầu ra
                command.Parameters.Add(IDPara).Value = employee.Id;

                command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = employee.HoTen;
                command.Parameters.Add("@SoCCCD", SqlDbType.NChar, 20).Value = employee.SoCCCD;
                command.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).Value = employee.DiaChi;
                command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = employee.NgaySinh;
                command.Parameters.Add("@NgayVaoLam", SqlDbType.DateTime).Value = employee.NgayVaoLam;
                command.Parameters.Add("@ViTriLV", SqlDbType.NVarChar, 20).Value = employee.ViTriLV;
                command.Parameters.Add("@SDT", SqlDbType.NChar, 10).Value = employee.SoDienThoai;
                command.Parameters.Add("@Luong", SqlDbType.Int).Value = employee.Luong;
                command.Parameters.Add("@Enable", SqlDbType.Bit).Value = employee.Enable;
                command.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar, 30).Value = (object)employee.TenTaiKhoan ?? DBNull.Value;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = employee.Password;
                command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

                // Thực thi lệnh
                command.ExecuteNonQuery();

                // Trả về ID nếu thành công
                return (int)command.Parameters["@ID"].Value;
            }
        }
    }
}
