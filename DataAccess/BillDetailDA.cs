using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{

    public class BillDetailDA
    {
        public List<BillDetail> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.BillDetail_GetAll;
            // Đọc dữ liệu, trả về danh sách các đối tượng Food
            SqlDataReader reader = command.ExecuteReader();
            List<BillDetail> list = new List<BillDetail>();
            while (reader.Read())
            {
                BillDetail cthd = new BillDetail();
                cthd.ID = Convert.ToInt32(reader["ID"]);
                cthd.HoaDonID = Convert.ToInt32(reader["HoaDonID"]);
                cthd.MauSizeID = Convert.ToInt32(reader["MauSizeID"]);
                cthd.GiaBan = Convert.ToInt32(reader["Gia"]);
                cthd.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                list.Add(cthd);
            }
            sqlConn.Close();
            return list;
        }
        public int Insert_Update_Delete(BillDetail billdetail, int action)
        {
            // Khai báo đối tượng SqlConnection và mở kết nối
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            // Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.BillDetail_InsertUpdateDelete; // Thay tên thủ tục phù hợp

            // Thêm các tham số cho thủ tục
            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = billdetail.ID;

            command.Parameters.Add("@HoaDonID", SqlDbType.Int).Value = billdetail.HoaDonID;
            command.Parameters.Add("@MauSizeID", SqlDbType.Int).Value = billdetail.MauSizeID;
            command.Parameters.Add("@Gia", SqlDbType.Int).Value = billdetail.GiaBan;
            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = billdetail.SoLuong;
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
        public List<BillDetail> GetFromBillID(int id)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            //Khai báo đối tượng SqlCommand có kiểu xử lý là StoredProcedure
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandText = "Select * from Bill_Detail where HoaDonID = "+id;
            SqlDataReader reader = command.ExecuteReader();
            List<BillDetail> list = new List<BillDetail>();
            while (reader.Read())
            {
                BillDetail cthd = new BillDetail();
                cthd.ID = Convert.ToInt32(reader["ID"]);
                cthd.HoaDonID = Convert.ToInt32(reader["HoaDonID"]);
                cthd.MauSizeID = Convert.ToInt32(reader["MauSizeID"]);
                cthd.GiaBan = Convert.ToInt32(reader["Gia"]);
                cthd.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                list.Add(cthd);
            }
            sqlConn.Close();
            return list;
        }
    }
}
