using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDA
    {
        public List<Bill> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Bill> list = new List<Bill>();
            while (reader.Read())
            {
                Bill bill = new Bill();
                bill.ID = Convert.ToInt32(reader["id"]);
                bill.KhachHangID = int.Parse(reader["KhachHangID"].ToString());
                bill.NhanVienID = int.Parse(reader["NhanVienID"].ToString());
                bill.NgayLapHoaDon = Convert.ToDateTime(reader["NgayLapHD"].ToString());
                bill.TongTien = int.Parse(reader["TongTien"].ToString());
                bill.TrangThai = reader["TrangThai"].ToString();
                bill.GiamGia = int.Parse(reader["GiamGia"].ToString());
                list.Add(bill);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(Bill bill, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = bill.ID;

            command.Parameters.Add("@KhachHangID", SqlDbType.Int).Value = bill.KhachHangID;
            command.Parameters.Add("@NhanVienID", SqlDbType.Int).Value = bill.NhanVienID;
            command.Parameters.Add("@NgayLapHD", SqlDbType.DateTime).Value = bill.NgayLapHoaDon;
            command.Parameters.Add("@TongTien", SqlDbType.Int).Value = bill.TongTien;
            command.Parameters.Add("@TrangThai", SqlDbType.NVarChar, 30).Value = bill.TrangThai;
            command.Parameters.Add("@LoaiHoaDon", SqlDbType.Bit).Value = bill.LoaiHoaDon;
            command.Parameters.Add("@GiamGia", SqlDbType.Int).Value = bill.GiamGia;
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
        public List<Bill> GetBillCustomerID(int ID, bool sortDate)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandText = "select * from Bill Where KhachHangID = " + ID + "Order By TongTien-GiamGia";
            if (sortDate)
                command.CommandText = "select * from Bill Where KhachHangID = " + ID +"Order By NgayLapHD";
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<Bill> list = new List<Bill>();
            while (reader.Read())
            {
                Bill bill = new Bill();
                bill.ID = Convert.ToInt32(reader["id"]);
                bill.KhachHangID = int.Parse(reader["KhachHangID"].ToString());
                bill.NhanVienID = int.Parse(reader["NhanVienID"].ToString());
                bill.NgayLapHoaDon = Convert.ToDateTime(reader["NgayLapHD"].ToString());
                bill.TongTien = int.Parse(reader["TongTien"].ToString());
                bill.TrangThai = reader["TrangThai"].ToString();
                bill.GiamGia = int.Parse(reader["GiamGia"].ToString());
                list.Add(bill);
            }
            sqlConn.Close();
            return list;
        }
    }
}
