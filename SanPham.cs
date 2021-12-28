using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WatchStore
{
    class SanPham
    {
        string MaSP, TenSP, ThuongHieu, TrangThai;
        int SoLuong;
        float GiaBan;

        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public string TenSP1 { get => TenSP; set => TenSP = value; }
        public string ThuongHieu1 { get => ThuongHieu; set => ThuongHieu = value; }
        public string TrangThai1 { get => TrangThai; set => TrangThai = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public float GiaBan1 { get => GiaBan; set => GiaBan = value; }

        public SanPham() { }

        public SanPham(string maSP) { }

        public SanPham(string maSP, string tenSP, string thuongHieu, float giaBan, int soLuong, string trangThai)
        {
            MaSP = maSP;
            TenSP = tenSP;
            ThuongHieu = thuongHieu;
            GiaBan = giaBan;
            SoLuong = soLuong;
            TrangThai = trangThai;
        }

        public void Nhap()
        {
            Console.Write("\t\t Tên sản phẩm: ");
            TenSP = Console.ReadLine();
            Console.Write("\t\t Thương hiệu : ");
            ThuongHieu = Console.ReadLine();
            Console.Write("\t\t Giá bán     : ");
            GiaBan = float.Parse(Console.ReadLine());
            Console.Write("\t\t Số Lượng    : ");
            SoLuong = int.Parse(Console.ReadLine());
            if (SoLuong > 0)
            {
                TrangThai = "Còn";
            }
            else TrangThai = "Hết hàng ";
        }
        public void Hien()
        {
            Console.WriteLine("\t|| {0,-4} ||   {1,-50}  ||  {2,-13}  ||  {3,-8}  ||   {4,-5}  ||   {5,-10} || "
                , MaSP, TenSP, ThuongHieu, GiaBan, SoLuong, TrangThai);
        }
        public string toString()
        {
            return MaSP + "#" + TenSP + "#" + ThuongHieu + "#" + GiaBan + "#" + SoLuong + "#" + TrangThai;
        }
    } 
    class DSSanPham
    {
        List<SanPham> ds = new List<SanPham>();

        // DỌC GHI FILE
        public void DocTep()
        {
            try
            {
                StreamReader sr = File.OpenText("sanpham.txt");//Mở một tệp đang tồn tại
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 0)
                    {
                        string[] l = new string[6];
                        l = s.Split('#');
                        SanPham t = new SanPham(l[0], l[1], l[2], float.Parse(l[3]), int.Parse(l[4]), l[5]);
                        ds.Add(t);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void GhiTep()
        {
            StreamWriter sw = new StreamWriter("sanpham.txt");
            foreach (SanPham x in ds)
            {
                sw.WriteLine(x.toString());
            }
            sw.Close();
        }
        // THÊM SẢN PHẨM VÀO DANH SÁCH
        public void Them1SP()
        {
            SanPham sp = new SanPham();
            bool ok = false;
            Console.Write("\t\t Nhập mã sản phẩm: ");
            sp.MaSP1 = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(sp.MaSP1))//So sánh 2 chuỗi có giống nhau hay không
                {
                    ok = true;
                    Console.WriteLine("\n\t\tĐã tồn tại mã hóa đơn trong danh sách. Vui lòng nhập lại!");
                }
            }
            if (!ok)//Chưa tồn tại mã nếu biến Ok khác true thì sẽ thực hiện các lệnh 
            {
                sp.Nhap();
                ds.Add(sp);
                Console.WriteLine("\t\tSẢN PHẨM ÐÃ ÐƯỢC THÊM VÀO TRONG DANH SÁCH !");
            }
        }
        public void Them()
        {
            Console.Write("\t\tNhập số lượng sản phẩm cần thêm: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n\t\tNhập thông tin sản phẩm thứ {0} ", i + 1);
                Them1SP();
                GhiTep();
            }

        }
        // CHỨC NĂNG SỬA THÔNG TIN SẢN PHẨM
        public void SuaTen()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập tên mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].TenSP1 = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t Tên sản phẩm đã sửa thành công !\n");
                TKMa(a);
            }
        }
        public void SuaTH()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập tên thương hiệu mới : ");
            string b = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].ThuongHieu1 = b;
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\n\t\t   Thương hiệu sản phẩm đã sửa thành công !\n");
                TKMa(a);
            }
        }
        public void Suagia()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập đơn giá mới : ");
            float b = float.Parse(Console.ReadLine());
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].GiaBan1 = b;
                }
            }
         
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t   Giá sản phẩm đã sửa thành công !\n");
                TKMa(a);
            }
        }
        
        public void Suasoluong()
        {
            bool ok = false;
            Console.Write("\n\t\t\tNhập mã sản phẩm cần sửa: ");
            string a = Console.ReadLine();
            Console.Write("\t\t\tNhập số lượng sản phẩm mới: ");
            int b = int.Parse(Console.ReadLine());
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].SoLuong1 = b;
                    if (ds[i].SoLuong1 > 0)
                    {
                        ds[i].TrangThai1 = "Còn";
                    }
                    else ds[i].TrangThai1 = "Hết hàng ";
                }
            }
            if (!ok)
                Console.WriteLine("\n\t\tMã sản phẩm không tồn tại. Vui lòng quay lại sau!");
            else
            {
                Console.WriteLine("\t\t   Số lượng sản phẩm đã sửa thành công !\n");
                TKMa(a);
            }
        }
        public void Sua()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine(" _______________________________________________ ");
                Console.SetCursorPosition(20, 6); Console.WriteLine("|         CÁC HÌNH THỨC SỬA SẢN PHẨM            |");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|-----------------------------------------------|");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|            1. Sửa Giá Sản Phẩm                |");
                Console.SetCursorPosition(20, 9); Console.WriteLine("|            2. Sửa Số Lượng Sản Phẩm           |");
                Console.SetCursorPosition(20, 10); Console.WriteLine("|            3. Sửa Tên Sản Phẩm                |");
                Console.SetCursorPosition(20, 11); Console.WriteLine("|            4. Sửa Thương Hiệu Sản Phẩm        |");
                Console.SetCursorPosition(20, 12); Console.WriteLine("|            5. Quay Lại                        |");
                Console.SetCursorPosition(20, 13); Console.WriteLine("|_______________________________________________|");
                Console.SetCursorPosition(20, 15); Console.Write(" Nhập công việc bạn muốn thực hiện : ");
                int chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        Console.Clear();
                        char a;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA GIÁ BÁN SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            Suagia();
                            GhiTep();
                            Console.Write("\n\t\tBạn có muốn sửa giá sản phẩm khác không (C/K)? ");
                            a = char.Parse(Console.ReadLine());
                        } while (a== 'c'|| a=='C');
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        char b;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-------------SỬA SỐ LƯỢNG SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            Suasoluong();
                            GhiTep();
                            Console.Write("\n\t\tBạn có muốn sửa số lượng sản phẩm khác không (C/K)? ");
                            b = char.Parse(Console.ReadLine());
                        } while (b == 'c' || b == 'C');
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        char c;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------SỬA TÊN SẢN PHẨM----------------*");
                        do
                        {
                            Console.WriteLine();
                            SuaTen();
                            GhiTep();
                            Console.Write("\n\t\tBạn có muốn sửa tên sản phẩm khác không (C/K)? ");
                            c = char.Parse(Console.ReadLine());
                        } while (c == 'c' ||c == 'C');
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        char d;
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------SỬA THƯƠNG HIỆU SẢN PHẨM------------*");
                        do
                        {
                            Console.WriteLine();
                            SuaTH();
                            GhiTep();
                            Console.Write("\n\t\tBạn có muốn sửa số lượng sản phẩm khác không (C/K)? ");
                            d = char.Parse(Console.ReadLine());
                        } while (d == 'c' || d == 'C');
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        MenuSP(); break;
                }
            }
        }
        // CHỨC NĂNG XÓA SẢN PHẨM
        public void Xoa()
        {
            bool ok = false;
            Console.Write("\t\t\tNhập mã sản phẩm cần xóa: ");
            string ma = Console.ReadLine();
            SanPham sp = new SanPham();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(ma))
                {
                    ok = true;//tim thay
                    ds.RemoveAt(i);//RemoveAt Xoa tai vi tri i 
                    Console.WriteLine("\n\t\t    SẢN PHẨM {0} ĐÃ XÓA KHỎI DANH SÁCH ", ma);
                    break;//thoat
                }
            }
            if (!ok)
                Console.WriteLine("Không tồn tại mã " + ma);
        }
        // CHỨC NĂNG THÔNG KÊ SẢN PHẨM
        public void HienThi()
        {
            Console.WriteLine("\n\t========================================DANH SÁCH THÔNG TIN SẢN PHẨM CỦA CỬA HÀNG===============================================");
            Console.WriteLine("\t||  Mã  ||                       Tên Sản Phẩm                    ||   Thương Hiệu   ||     Giá    || Số Lượng ||  Tình Trạng  ||");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------------------------------------");
            foreach (SanPham x in ds)
            {
                x.Hien();
            }
            Console.WriteLine("\t================================================================================================================================");
        }
        public void SapHet()
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM SẮP HẾT CỦA CỬA HÀNG======================================================");
            Console.WriteLine("\t||  Mã  ||                       Tên Sản Phẩm                    ||   Thương Hiệu   ||     Giá    || Số Lượng ||  Tình Trạng  ||");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < ds.Count; i++)
            {
                if ((ds[i].SoLuong1) > 0 && (ds[i].SoLuong1) <= 50)
                {
                    ds[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================");
        }
        public void Het()
        {
            Console.WriteLine("\n\t===================================DANH SÁCH SẢN PHẨM ĐÃ BÁN HẾT CỦA CỬA HÀNG===================================================");
            Console.WriteLine("\t||  Mã  ||                       Tên Sản Phẩm                    ||   Thương Hiệu   ||     Giá    || Số Lượng ||  Tình Trạng  ||");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < ds.Count; i++)
            {
                if ((ds[i].TrangThai1) == "Hết hàng")
                {
                    ds[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================");

        }
        public void ThongKe()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 6); Console.WriteLine(" _____________________________________________ ");
                Console.SetCursorPosition(20, 7); Console.WriteLine("|              THỐNG KÊ SẢN PHẨM              |");
                Console.SetCursorPosition(20, 8); Console.WriteLine("|---------------------------------------------|");
                Console.SetCursorPosition(20, 9); Console.WriteLine("|     1. Thống Kê Tất Cả Sản Phẩm             |");
                Console.SetCursorPosition(20, 10); Console.WriteLine("|     2. Thống Kê Các Sản Phẩm Sắp Hết        |");
                Console.SetCursorPosition(20, 11); Console.WriteLine("|     3. Thống Kê Các Sản Phẩm Đã Hết         |");
                Console.SetCursorPosition(20, 12); Console.WriteLine("|     4. Quay Lại                             |");
                Console.SetCursorPosition(20, 13); Console.WriteLine("|_____________________________________________|");
                Console.SetCursorPosition(20, 15); Console.Write("  Chọn công việc bạn muốn thực hiện(1->4): ");
                int  c = int.Parse(Console.ReadLine());
                switch(c)
                {
                    case 1:
                        Console.Clear(); HienThi();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear(); SapHet();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear(); Het();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        DoanhThu dt = new DoanhThu();
                        dt.MenuDT(); break;
                }
            }
        }
        // CHỨC NĂNG TÌM KIẾM SẢN PHẨM
        public void TKMa(string ma)
        {
            bool ok = false;
            Console.WriteLine("\t===============================================THÔNG TIN SẢN PHẨM===============================================================");
            Console.WriteLine("\t||  Mã  ||                       Tên Sản Phẩm                    ||   Thương Hiệu   ||     Giá    || Số Lượng ||  Tình Trạng  ||");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(ma))
                {
                    ok = true;
                    ds[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================");
            if (!ok)
                Console.WriteLine("Mã Sản Phẩm Không Tồn Tại");
        }
        public void TKTen(String b)
        {
            int j = 0;//khai báo biến kiểu nguyên có tên là j và khởi tạo giá trị là 0.
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].TenSP1.StartsWith(b)) //Str1.StartsWith(Str2):Kiểm tra xem chuỗi Str1 có bắt đầu bằng chuỗi Str2 không?
                {
                    j = 1;
                    ds[i].Hien();
                }
            }
            if (j == 0)
                Console.WriteLine("\t\tKhông tìm thấy tên sản phẩm {0} ", b);
        }
        public void TKGia()
        {
            Console.WriteLine("\n\t\tMời Bạn Nhâp Khoảng Giá Cần Tìm Kiếm");
            Console.Write("\t\tGiá Min: ");
            float min = float.Parse(Console.ReadLine());
            Console.Write("\t\tGiá Max: ");
            float max = float.Parse(Console.ReadLine());
            Console.WriteLine("\n\t==============================================DANH SÁCH THÔNG TIN SẢN PHẨM======================================================");
            Console.WriteLine("\t||  Mã  ||                       Tên Sản Phẩm                    ||   Thương Hiệu   ||     Giá    || Số Lượng ||  Tình Trạng  ||");
            Console.WriteLine("\t--------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].GiaBan1 >= min && ds[i].GiaBan1 <= max)
                {
                    ds[i].Hien();
                }
            }
            Console.WriteLine("\t================================================================================================================================");
        }
        // MENU SẢN PHẨM
        public void MenuSP()
        {
            DocTep();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                        QUẢN LÝ DANH SÁCH SẢN PHẨM                      *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Hiện Thị Danh Sách Sản Phẩm   |  5. Tìm Kiếm Sản Phẩm Theo Mã      *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thêm Sản Phẩm                 |  6. Tìm Kiếm Sản Phẩm Theo Tên     *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Sửa Thông Tin Sản Phẩm        |  7. Quay Lại                       *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*  4. Xóa Thông Tin Sản Phẩm        |  8. Thoát Khỏi Chương Trình        *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*                                                                        *");
                Console.SetCursorPosition(20, 13); Console.WriteLine("*------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 15); Console.Write(" Mời Bạn Chọn Công Việc (1->8): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        HienThi();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*--------------THÊM THÔNG TIN SẢN PHẨM--------------*");
                        Them();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Sua(); Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*--------------XÓA THÔNG TIN SẢN PHẨM----------------*");
                        do
                        {
                            Console.WriteLine();
                            Xoa();
                            GhiTep();
                            Console.Write("\n\t\t  Bạn có muốn xóa sản phẩm khác không (C/K)? ");
                        } while( Console.ReadLine() == "c"|| Console.ReadLine()== "C");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO MÃ-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("Nhập mã sản phẩm cần tìm kiếm: ");
                        string ma = Console.ReadLine();
                        TKMa(ma); Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(10, 3); Console.WriteLine("*---------------TÌM KIẾM SẢN PHẢM THEO TÊN SP-----------------*");
                        Console.SetCursorPosition(10, 5); Console.Write("\n\t\tNhập tên sản phẩm cần tìm kiếm: ");
                        string b = Console.ReadLine();
                        TKTen(b); Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        MenuQL a = new MenuQL();
                        a.MenuChinh();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public string LayTenSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[1];
            }
            sr.Close();
            return "";
        }
        public string LayGiaSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[3];
            }
            sr.Close();
            return "";
        }
        public string LaySLSanPham(string MaSP)
        {
            StreamReader sr = new StreamReader("sanpham.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] a = s.Split('#');
                if (a[0] == MaSP) return a[4];
            }
            sr.Close();
            return "";
        }
        public void SuaPN(string a, int b)
        {
            bool ok = false;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].SoLuong1 += b;
                    if (ds[i].SoLuong1 > 0)
                    {
                        ds[i].TrangThai1 = "Còn";
                    }
                    else ds[i].TrangThai1 = "Hết hàng ";
                    Console.WriteLine("\t\tSố lượng sản phẩm đã sửa thành công.");
                }
            }
            if (!ok)
            {
                Console.WriteLine("\t\tMã sản phẩm không tồn tại!Vui lòng thêm vào DS sản phẩm");
                Them1SP();
            }
        }
        public void SuaHD(string a, int b)
        {
            bool ok = false;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP1.Equals(a))
                {
                    ok = true;
                    ds[i].SoLuong1 -= b;
                    if (ds[i].SoLuong1 > 0)
                    {
                        ds[i].TrangThai1 = "Còn";
                    }
                    else ds[i].TrangThai1 = "Hết hàng ";
                    Console.WriteLine("\t\tSố lượng sản phẩm đã sửa thành công");
                }
            }
            if (!ok)
                Console.WriteLine("\t\tMã sản phẩm không tồn tại!Vui lòng nhập lại");
        }
    }
}