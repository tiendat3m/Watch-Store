using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchStore
{
    class TimKiem : SanPham
    {
        public void TKSanPham()
        {
            DSSanPham sp = new DSSanPham();
            sp.DocTep();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 3); Console.WriteLine(" _______________TÌM KIẾM SẢN PHẨM_____________ ");
                Console.SetCursorPosition(20, 4); Console.WriteLine("|     1. Tìm Kiếm Theo Mã Sản Phẩm            |");
                Console.SetCursorPosition(20, 5); Console.WriteLine("|     2. Tìm Kiếm Theo Tên Sản Phẩm           |");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|     3. Tìm Kiếm Theo Giá Sản Phẩm           |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 10); Console.Write("Nhập công việc bạn muốn thực hiện: ");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO MÃ-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("Nhập mã sản phẩm cần tìm kiếm: ");
                        string ma = Console.ReadLine();
                        sp.TKMa(ma); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO TÊN SP-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập tên sản phẩm cần tìm kiếm: ");
                        string b = Console.ReadLine();
                        sp.TKTen(b); Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO GiÁ SP-----------------*");
                        sp.TKGia(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuTK(); break;
                }
            }
        }
        public void TKPhieuNhap()
        {
            DSPhieuNhap pn = new DSPhieuNhap();
            pn.DocTepPN();
            pn.DocTepCT();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 3); Console.WriteLine(" _________TÌM KIẾM HÓA ĐƠN NHẬP HÀNG__________ ");
                Console.SetCursorPosition(20, 4); Console.WriteLine("|     1. Tìm kiếm theo mã                     |");
                Console.SetCursorPosition(20, 5); Console.WriteLine("|     2. Tìm kiếm theo tên nhà cung cấp       |");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|     3. Tìm kiếm theo ngày nhập sản phẩm     |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 10); Console.Write("     Chọn công việc: ");
                int b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO MÃ----------------*");
                        pn.TKMa(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO NGÀY----------------*");
                        pn.TKNgay();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*---------------TÌM KIẾM PHIẾU NHẬP THEO TÊN NCC----------------*");
                        pn.TKTen(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuTK(); break;
                }
            }
        }
        public void TKHoaDon()
        {
            DSHoaDon hd = new DSHoaDon();
            hd.DocTepHD();
            hd.DocTepCT();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 3); Console.WriteLine(" __________TÌM KIẾM HÓA ĐƠN BÁN HÀNG__________ ");
                Console.SetCursorPosition(20, 4); Console.WriteLine("|     1. Tìm kiếm theo mã hóa đơn             |");
                Console.SetCursorPosition(20, 5); Console.WriteLine("|     2. Tìm kiếm theo tên khách hàng         |");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|     3. Tìm kiếm theo ngày bán sản phẩm      |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|     4. Quay lại                             |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 10); Console.Write(" Chọn công việc bạn muốn thực hiện: ");
                int b = int.Parse(Console.ReadLine());
                switch (b)
                {
                    case 1:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO MÃ HD-----------------*");
                        hd.TKMa(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO TÊN KH-----------------*");
                        hd.TKTen(); Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO NGÀY-----------------*");
                        hd.TKNgay();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuTK(); break;
                }
            }
        }
        public void MenuTK()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*----------------TÌM KIẾM------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*     1. Tìm Kiếm Hóa Đơn Nhập             *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*     2. Tìm Kiếm Sản Phẩm                 *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*     3. Tìm Kiếm Hóa Đơn Bán Hàng         *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*     4. Quay Lại                          *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*     5. Thoát                             *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*------------------------------------------*");
                Console.SetCursorPosition(20, 12); Console.Write("  Mời Bạn Chọn Công Việc (1-5): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        TKPhieuNhap(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        DSSanPham sp = new DSSanPham();
                        sp.DocTep();
                        TKSanPham();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        TKHoaDon(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        MenuQL a = new MenuQL();
                        a.MenuChinh();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
    class MenuQL
    {

        public void MenuChinh()
        {

            Console.SetCursorPosition(20, 5); Console.WriteLine(" =============================================================================");
            Console.SetCursorPosition(20, 6); Console.WriteLine(" ||               =======>  QUẢN LÝ CỬA HÀNG ĐỒNG HỒ  <=======               ||");
            Console.SetCursorPosition(20, 7); Console.WriteLine(" ||                                                                          ||");
            Console.SetCursorPosition(20, 8); Console.WriteLine(" ||   1. Quản Lý Sản Phẩm            ||       4. Tìm Kiếm Thông Tin          ||");
            Console.SetCursorPosition(20, 9); Console.WriteLine(" ||                                  ||                                      ||");
            Console.SetCursorPosition(20, 10); Console.WriteLine(" ||   2. Quản Lý Hóa Đơn Nhập        ||       5. Thống Kê Doanh Thu          ||");
            Console.SetCursorPosition(20, 11); Console.WriteLine(" ||                                  ||                                      ||");
            Console.SetCursorPosition(20, 12); Console.WriteLine(" ||   3. Quản Lý Hóa Đơn Bán Hàng    ||       6. Thoát Khỏi Chương Trình     ||");
            Console.SetCursorPosition(20, 13); Console.WriteLine(" ||                                                                          ||");
            Console.SetCursorPosition(20, 14); Console.WriteLine(" =============================================================================");
            Console.SetCursorPosition(20, 16); Console.Write(" Mời Bạn Chọn Công Việc (1-6): ");
            int t = int.Parse(Console.ReadLine());
            do
            {
                switch (t)
                {
                    case 1:
                        Console.Clear();
                        DSSanPham dssp = new DSSanPham();
                        dssp.MenuSP(); Console.ReadKey();
                        Console.ReadKey();
                        break;
                    case 2:
                        DSPhieuNhap dspn = new DSPhieuNhap();
                        dspn.MenuPhieuNhap(); Console.ReadKey();
                        Console.ReadKey();
                        break;
                    case 3:
                        DSHoaDon dshd = new DSHoaDon();
                        dshd.MenuHD(); Console.ReadKey();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        TimKiem tk = new TimKiem();
                        tk.MenuTK();
                        Console.ReadKey();
                        break;
                    case 5:
                       DoanhThu dt = new DoanhThu();
                        dt.MenuDT(); Console.ReadKey();
                        Console.ReadKey();
                        break;
                    case 6: Environment.Exit(0); break;
                }
            } while (true);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.OutputEncoding = Encoding.UTF8;
            MenuQL ql = new MenuQL();
            ql.MenuChinh();
            Console.ReadKey();//lệnh này dùng với mục đích dừng màn hình để xem kết quả.
        }
    }
}
