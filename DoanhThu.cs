using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WatchStore
{
    class DoanhThu: SanPham
    {
        DSHoaDon tk = new DSHoaDon();
        public void ThongkeNgay()
        {
            float dtN = 0;
            Console.Write("\n\t\tNhập ngày bạn muốn tính doanh thu (dd/mm/yyyy) :");
            DateTime ngay = DateTime.Parse(Console.ReadLine());
            StreamReader sr = new StreamReader("hoadon.txt");// Mở tệp đã tồn tại
            string s1;
            Console.WriteLine("\n\t\t==========================DANH SÁCH HÓA ĐƠN BÁN HÀNG================================");
            Console.WriteLine("\t\t|| MÃ ||          KHÁCH HÀNG           ||   NGÀY BÁN  ||  SỐ LƯỢNG  ||  TỔNG TIỀN ||");
            Console.WriteLine("\t\t------------------------------------------------------------------------------------");
            while ((s1 = sr.ReadLine()) != null)
            {
                string[] tmp = s1.Split('#');
                if (DateTime.Parse(tmp[2]) == ngay)
                {
                    dtN = dtN + float.Parse(tmp[4]);
                    DSHoaDon hd = new DSHoaDon();
                    hd.DocTepHD();
                    hd.HienHD(tmp[0]);
                }
            }
            Console.WriteLine("\t\t====================================================================================");
            sr.Close();// Đóng tệp
            Console.Write("\n\t\tSỐ TIỀN BÁN ĐƯỢC TRONG NGÀY {0} LÀ :                            {1}" ,ngay.ToString("dd/MM/yyyy"), dtN);
        }
        public void ThongkeThang()
        {
            float dtT = 0;
            Console.Write("\t\tNhập tháng bạn muốn tính doanh thu :");
            int thang = int.Parse(Console.ReadLine());
            Console.Write("\t\tNhập năm bạn muốn tính doanh thu :");
            int nam = int.Parse(Console.ReadLine());
            StreamReader l = new StreamReader("hoadon.txt");
            string s1;
            Console.WriteLine("\n\t\t==========================DANH SÁCH HÓA ĐƠN BÁN HÀNG================================");
            Console.WriteLine("\t\t|| MÃ ||          KHÁCH HÀNG           ||   NGÀY BÁN  ||  SỐ LƯỢNG  ||  TỔNG TIỀN ||");
            Console.WriteLine("\t\t------------------------------------------------------------------------------------");
            while ((s1 = l.ReadLine()) != null)
            {
                string[] tmp = s1.Split('#');
                if ((DateTime.Parse(tmp[2]).Month == thang) && (DateTime.Parse(tmp[2]).Year == nam))
                {
                    dtT = dtT + float.Parse(tmp[4]);
                    DSHoaDon hd = new DSHoaDon();
                    hd.DocTepHD();
                    hd.HienHD(tmp[0]);
                }
            }
            Console.WriteLine("\t\t====================================================================================");
            l.Close();
            Console.Write("\n\t\tTỔNG SỐ TIỀN BÁN ĐƯỢC TRONG THÁNG {0}/{1} : {2} ", thang, nam, dtT);
            //StreamReader sr = new StreamReader("phieunhap.txt");
            //string s;
            //float dt1 = 0;
            //float dt2 = 0;
            //while ((s = sr.ReadLine()) != null)
            //{
            //    string[] t = s.Split('#');
            //    if ((DateTime.Parse(t[4]).Month == thang) && (DateTime.Parse(t[4]).Year == nam))
            //    {
            //        dt1 = dt1 + float.Parse(t[6]);
            //    }
            //}
            //sr.Close();
            //dt2 += dtT - dt1;
            //if( dt2 >= 0)
            //Console.WriteLine("\t\tTIỀN LÃI THU ĐƯỢC TRONG THÁNG {0}/{1} :                            {3} ", thang, nam, dt2);
            //else Console.WriteLine("\n\t\tTRONG THÁNG {0}/{1} DOANH THU CỦA CỬA HÀNG BỊ LỖ ", thang, nam);
        }
        public void MenuDT()
        {
            while (true)
            {
                Console.Clear();// Xóa màn hình
                Console.SetCursorPosition(20, 5); Console.WriteLine("__________________________________________________");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                    THỐNG KÊ                    *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*------------------------------------------------*");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Thống Kê Danh Sách Sản Phẩm                *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thống Kê Doanh Thu Theo Ngày               *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Thống Kê Doanh Thu Theo Tháng              *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*  4. Quay Lại                                   *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*  5. Thoát                                      *");
                Console.SetCursorPosition(20, 13); Console.WriteLine("*________________________________________________*");
                Console.SetCursorPosition(20, 15); Console.Write("  Mời bạn chọn công việc (1-5): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        DSSanPham d = new DSSanPham();
                        d.DocTep();
                        d.ThongKe(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------THỐNG KÊ DOANH THU CHO CỬA HÀNG THEO NGÀY-----------------*");
                        ThongkeNgay();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------THỐNG KÊ DOANH THU CHO CỬA HÀNG THEO THÁNG-----------------*");
                        ThongkeThang(); 
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuQL a = new MenuQL();
                        a.MenuChinh();
                        break;
                    case 5: Environment.Exit(0); break;
                }
            }
        }
    }
}
