using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WatchStore
{
    class HoaDon
    {
        string MaHD, TenKH;
        DateTime NgayBan;
        int Tongsl;
        float Tong;

        public HoaDon() { }

        public HoaDon(string maHD, string tenKH, DateTime ngayBan, int tongsl, float tong)
        {
            MaHD = maHD;
            TenKH = tenKH;
            NgayBan = ngayBan;
            Tongsl = tongsl;
            Tong = tong;
        }

        public string MaHD1 { get => MaHD; set => MaHD = value; }
        public string TenKH1 { get => TenKH; set => TenKH = value; }
        public DateTime NgayBan1 { get => NgayBan; set => NgayBan = value; }
        public int Tongsl1 { get => Tongsl; set => Tongsl = value; }
        public float Tong1 { get => Tong; set => Tong = value; }

        public void Nhap()
        {
            Console.WriteLine("\t\tNgày Bán :{0} ", DateTime.Now.ToString("dd/MM/yyyy"));
            NgayBan = DateTime.Now;
            Console.Write("\t\tTên Khách Hàng: ");
            TenKH = Console.ReadLine();
        }
        public void Hien()
        {
            Console.WriteLine("\t\t||{0,-4}||   {1,-25}   || {2,-10}  || {3,-10} || {4,-10} ||", MaHD, TenKH, NgayBan.ToString("dd/MM/yyyy"), Tongsl, Tong);
        }
        public string toStringDS()
        {
            return MaHD1 + "#" + TenKH1 + "#" + NgayBan1.ToString("dd/MM/yyyy") + "#" + Tongsl1 + "#" + Tong1;
        }

    }
    class CTHoaDon
    {
        HoaDon a = new HoaDon();
        string MaHD, MaSP;
        int SoLuong;
        float TGia;
        public CTHoaDon() { }
        public CTHoaDon(int SoLuong) { }
        public CTHoaDon(string maHD, string maSP, int soLuong, float gia)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            TGia = gia;
        }

        public string MaHD1 { get => MaHD; set => MaHD = value; }
        public string MaSP1 { get => MaSP; set => MaSP = value; }
        public int SoLuong1 { get => SoLuong; set => SoLuong = value; }
        public float TGia1 { get => TGia; set => TGia = value; }

        public void NhapCT()
        {
            DSSanPham a = new DSSanPham();
            Console.Write("\t\tMã Sản Phẩm: ");
            MaSP = Console.ReadLine();
            Console.Write("\t\tSố Lượng: ");
            SoLuong = int.Parse(Console.ReadLine());
        }
        public void HienCT()
        {
            Console.WriteLine("\t\t||{0,-4}||   {1,-4}   || {2,-10}  || {3,-10}  ||", MaHD, MaSP, SoLuong, TGia);
        }
        public string toStringCT()
        {
            return MaHD + "#" + MaSP + "#" + SoLuong + "#" + TGia;
        }

    }
    class DSHoaDon
    {
        List<HoaDon> ds = new List<HoaDon>();
        List<CTHoaDon> dss = new List<CTHoaDon>();
        HoaDon hd = new HoaDon();
        CTHoaDon ct = new CTHoaDon();
        public void DocTepHD()
        {
            StreamReader sr = File.OpenText("hoadon.txt");
            string s;
            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length > 0)
                    {
                        string[] l = new string[5];
                        l = s.Split('#');
                        HoaDon hd = new HoaDon(l[0], l[1], DateTime.Parse(l[2]), int.Parse(l[3]), float.Parse(l[4]));
                        ds.Add(hd);
                    }
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DocTepCT()
        {
            StreamReader sr = File.OpenText("chitiethoadon.txt");
            string[] l;
            string s;
            try
            {
                while ((s = sr.ReadLine()) != null)
                {
                    CTHoaDon ct = new CTHoaDon();
                    l = s.Split('#');
                    ct.MaHD1 = l[0];
                    ct.MaSP1 = l[1];
                    ct.SoLuong1 = int.Parse(l[2]);
                    ct.TGia1 = float.Parse(l[3]);
                    dss.Add(ct);
                }
                sr.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GhiTepHD()
        {
            StreamWriter sw1 = new StreamWriter("hoadon.txt");
            foreach (HoaDon x in ds)
            {
                sw1.WriteLine(x.toStringDS());
            }
            sw1.Close();
        }
        public void GhiTepCT()
        {
            StreamWriter sw2 = new StreamWriter("chitiethoadon.txt");
            foreach (CTHoaDon x in dss)
            {
                sw2.WriteLine(x.toStringCT());
            }
            sw2.Close();
        }
        // THÊM HÓA ĐƠN BÁN HÀNG
        public int setMa()
        {
            int max = 0;
            foreach (HoaDon a in ds)
            {
                if (max < int.Parse(a.MaHD1))
                    max = int.Parse(a.MaHD1);
            }
            return max + 1;
        }
        public void SuaSL()
        {
            ct.MaHD1 = hd.MaHD1;
            ct.NhapCT();
            dss.Add(ct);
            DSSanPham dssp = new DSSanPham();
            dssp.DocTep();
            dssp.SuaHD(ct.MaSP1, ct.SoLuong1);
            dssp.GhiTep();
        }
        public void Them()
        {
            Console.WriteLine("\n\t\tNHẬP THÔNG TIN HÓA ĐƠN MUA HÀNG");
            hd.MaHD1 = setMa().ToString();
            Console.WriteLine("\t\tMã hóa đơn: " + hd.MaHD1);
            hd.Nhap();
            Console.Write("\t\tSố lượng sản phẩm đã mua : ");
            int n = int.Parse(Console.ReadLine());
            float[] g = new float[n];
            int[] h = new int[n];
            StreamWriter sw = File.AppendText("chitiethoadon.txt");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\t\tThông tin sản phẩm thứ {0} đã mua", i + 1);
                SuaSL();
                DSSanPham dssp = new DSSanPham();
                ct.TGia1 = ct.SoLuong1 * float.Parse(dssp.LayGiaSanPham(ct.MaSP1));
                sw.WriteLine(ct.MaHD1 + "#" + ct.MaSP1 + "#" + ct.SoLuong1 + "#" + ct.TGia1);
                h[i] = ct.SoLuong1;
                g[i] = ct.TGia1;
                Console.WriteLine("\t\tThành tiền: " + g[i]);
            }
            sw.Close();
            for (int i = 0; i < n; i++)
            {
                hd.Tongsl1 += h[i];

                hd.Tong1 += g[i];

            }
            Console.WriteLine("\t\tTổng số   : " + hd.Tongsl1);
            Console.WriteLine("\t\tTổng tiền : " + hd.Tong1);
            ds.Add(hd);
            GhiTepHD();
        }
        //CHỨC NĂNG HIỆN THỊ HÓA ĐƠN
        public void HienHD(string a)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaHD1 == a) ds[i].Hien();
            }
        }
        public void Hien()
        {
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine("\n\t\t*****************************THÔNG TIN HÓA ĐƠN BÁN HÀNG THỨ {0}**************************************", i + 1);
                Console.WriteLine("\t\t Mã Hóa Đơn Nhập : {0,-5}                                              Ngày Bán: {1,10}", ds[i].MaHD1, ds[i].NgayBan1.ToString("dd/MM/yyyy"));
                Console.WriteLine("\t\t Tên Khách Hàng  : {0,-20}", ds[i].TenKH1);
                Console.WriteLine("\t\t ________________________________________________________________________________________________ ");
                Console.WriteLine("\t\t |                      TÊN SẢN PHẨM                     |  GIÁ BÁN   | SỐ LƯỢNG |  THÀNH TIỀN   |");
                Console.WriteLine("\t\t -------------------------------------------------------------------------------------------------");
                StreamReader sr = new StreamReader("chitiethoadon.txt");
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] a = s.Split('#');
                    DSSanPham dssp = new DSSanPham();
                    if (a[0] == ds[i].MaHD1)
                        Console.WriteLine("\t\t |{0,-55}|  {1,-10}|   {2,-5}  |  {3,-12} |"
                  , dssp.LayTenSanPham(a[1]), dssp.LayGiaSanPham(a[1]), int.Parse(a[2]), float.Parse(a[3]));
                }
                sr.Close();
                Console.WriteLine("\t\t |_______________________________________________________________________________________________|");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t Tổng Số  :                                                                  {0,-7}", ds[i].Tongsl1);
                Console.WriteLine("\t\t Tổng Tiền:                                                                         {0,-11}", ds[i].Tong1);
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
        public void HienChiTiet(string Ma)
        {
            StreamReader l = new StreamReader("hoadon.txt");
            string s1;
            while ((s1 = l.ReadLine()) != null)
            {
                string[] x = s1.Split('#');
                if (x[0] == Ma)
                {
                    Console.WriteLine("\t\tMã Hóa Đơn     : {0}                                        Ngay Ban : {1}", x[0], DateTime.Parse(x[2]).ToString("dd/MM/yyyy"));
                    Console.WriteLine("\t\tTên Khách Hàng : {0}", x[1]);
                    Console.WriteLine("\t\t ________________________________________________________________________________________________ ");
                    Console.WriteLine("\t\t |                      TÊN SẢN PHẨM                     |  GIÁ BÁN   | SỐ LƯỢNG |  THÀNH TIỀN   |");
                    Console.WriteLine("\t\t -------------------------------------------------------------------------------------------------");
                    StreamReader sr = new StreamReader("chitiethoadon.txt");
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {

                        DSSanPham dssp = new DSSanPham();
                        string[] a = s.Split('#');
                        if (a[0] == Ma)
                            Console.WriteLine("\t\t |{0,-55}|  {1,-10}|   {2,-5}  |  {3,-12} |"
                        , dssp.LayTenSanPham(a[1]), dssp.LayGiaSanPham(a[1]), int.Parse(a[2]), float.Parse(a[3]));
                    }
                    sr.Close();
                    Console.WriteLine("\t\t |_______________________________________________________________________________________________|");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\t Tổng Số   :                                                             {0}", int.Parse(x[3]));
                    Console.WriteLine("\t\t Tổng Tiền :                                                                         {0}", float.Parse(x[4]));
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }
            l.Close();
        }
        //CHỨC NĂNG XÓA HÓA ĐƠN
        public void Xoa()
        {
            bool ok = false;
            Console.Write("\t\tNhập mã hóa đơn cần xóa: ");
            string ma = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaHD1.Equals(ma))
                {
                    ok = true;//tim thay
                    ds.RemoveAt(i);//RemoveAt Xoa tai vi tri
                    GhiTepHD();
                    break;//thoat
                }
            }
            if (!ok)
                Console.WriteLine("\t\tKhông tồn tại " + ma);
            StreamWriter sw = new StreamWriter("chitiethoadon.txt");
            for (int j = 0; j < dss.Count; j++)
            {
                if (ma != dss[j].MaHD1)
                    sw.WriteLine(dss[j].MaHD1 + "#" + dss[j].MaSP1 + "#" + dss[j].SoLuong1 + "#" + dss[j].TGia1);
            }
            sw.Close();
            Console.WriteLine("\t\tĐã xóa hóa đơn có mã " + ma);
        }
        //CHỨC NĂNG TÌM KIẾM HÓA ĐƠN
        public void TKMa()
        {
            bool ok = false;
            Console.Write("\n\t\tNhập mã hóa đơn cần tìm kiếm: ");
            string a = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaHD1.Equals(a))
                {
                    ok = true;
                    Console.WriteLine("\n\t\t______________________________HÓA ĐƠN BÁN HÀNG THỨ {0} TRONG DANH SÁCH________________________________\n", i + 1);
                    HienChiTiet(a);
                }
            }
            if (!ok)
                Console.WriteLine("\t\tMã hàng không tồn tại");
        }
        public void TKTen()
        {
            int j = 0;
            Console.Write("\n\t\tNhập tên khách hàng cần tìm kiếm: ");
            string b = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].TenKH1.StartsWith(b))
                {
                    j = 1;
                    Console.WriteLine("\n\t\t______________________________HÓA ĐƠN BÁN HÀNG THỨ {0} TRONG DANH SÁCH________________________________\n", i + 1);
                    HienChiTiet(ds[i].MaHD1);
                }
            }
            if (j == 0)
                Console.WriteLine("\t\tKhông tìm thấy tên khách hàng " + b);
        }
        public void TKNgay()
        {
            int j = 0;
            Console.Write("\n\t\tNhập ngày cần tìm kiếm: ");
            DateTime ngay = DateTime.Parse(Console.ReadLine());
            for (int i = 0; i < ds.Count; i++)
            {
                j = 1;
                if (ds[i].NgayBan1 == ngay)
                {
                    Console.WriteLine("\n\t\t______________________________HÓA ĐƠN BÁN HÀNG THỨ {0} TRONG DANH SÁCH________________________________\n", i + 1);
                    HienChiTiet(ds[i].MaHD1);
                }
            }
            if (j == 0)
                Console.WriteLine("\t\tKhông tìm thấy ngày bán " + ngay);
        }
        //MENU HÓA ĐƠN
        public void MenuHD()
        {
            DocTepHD();
            DocTepCT();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5); Console.WriteLine("*----------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 6); Console.WriteLine("*                     QUẢN LÝ DANH SÁCH HÓA ĐƠN BÁN HÀNG                     *");
                Console.SetCursorPosition(20, 7); Console.WriteLine("*                                                                            *");
                Console.SetCursorPosition(20, 8); Console.WriteLine("*  1. Hiện Thị Hóa Đơn Bán Hàng      |    5. Tìm Kiếm Hóa Đơn Theo Mã        *");
                Console.SetCursorPosition(20, 9); Console.WriteLine("*  2. Thêm Hóa Đơn Bán Hàng          |    6. Tìm Kiếm Hóa Đơn Theo Tên KH    *");
                Console.SetCursorPosition(20, 10); Console.WriteLine("*  3. Xóa Hóa Đơn Bán Hàng           |    7. Quay Lại                        *");
                Console.SetCursorPosition(20, 11); Console.WriteLine("*  4. Tìm Kiếm Hóa Đơn Theo Ngày     |    8. Thoát Khỏi Chương Trình         *");
                Console.SetCursorPosition(20, 12); Console.WriteLine("*                                                                            *");
                Console.SetCursorPosition(20, 13); Console.WriteLine("*----------------------------------------------------------------------------*");
                Console.SetCursorPosition(20, 15); Console.Write(" Mời bạn chọ công việc(1->8): ");
                int c = int.Parse(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.Clear();
                        Hien(); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.SetCursorPosition(15, 3); Console.WriteLine("*-----------------------NHẬP THÊM HÓA ĐƠN BÁN HÀNG-------------------------*");
                        do
                        {
                            Console.WriteLine();
                            Them();
                            Console.Write("\n\t\tBạn có muốn thêm hóa đơn khác không (C/K)? ");
                        } while (Console.ReadLine() == "C" || Console.ReadLine() == "c");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.SetCursorPosition(15, 3); Console.WriteLine("*-----------------------XÓA THÔNG TIN HÓA ĐƠN BÁN HÀNG----------------------*");
                        do
                        {
                            Console.WriteLine();
                            Xoa();
                            Console.Write("\n\t\tBạn có muốn xóa hóa đơn khác không (C/K)? ");
                        } while (Console.ReadLine() == "C" || Console.ReadLine() == "c");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO NGÀY-----------------*");
                        TKNgay();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO MÃ HD-----------------*");
                        TKMa();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.SetCursorPosition(20, 3); Console.WriteLine("*-----------------TÌM KIẾM HÓA ĐƠN BÁN HÀNG THEO TÊN KH-----------------*");
                        TKTen();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        MenuQL a = new MenuQL();
                        a.MenuChinh();
                        break;
                    case 8: Environment.Exit(0); break;
                }
            }
        }
    }
}
