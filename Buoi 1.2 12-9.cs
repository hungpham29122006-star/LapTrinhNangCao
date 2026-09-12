using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    interface IHinh
    {
        double GetDienTich();
        double GetChuVi();
        void Nhap();
        void HienThi();
    }

    class HinhChuNhat : IHinh
    {
        private double _width;
        private double _height;

        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0) throw new ArgumentException("Width must be > 0");
                _width = value;
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0) throw new ArgumentException("Height must be > 0");
                _height = value;
            }
        }

        public HinhChuNhat() { }

        public HinhChuNhat(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetDienTich() => Width * Height;

        public double GetChuVi() => 2 * (Width + Height);

        public void Nhap()
        {
            Width = ReadPositiveDouble("Nhap chieu rong: ");
            Height = ReadPositiveDouble("Nhap chieu dai: ");
        }

        public void HienThi()
        {
            Console.WriteLine($"Hinh Chu Nhat - W={Width}, H={Height}, Dien tich={GetDienTich():F2}, Chu vi={GetChuVi():F2}");
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (double.TryParse(s, out var v) && v > 0) return v;
                Console.WriteLine("Gia tri khong hop le. Vui long nhap so > 0.");
            }
        }
    }

    class HinhTron : IHinh
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Radius must be > 0");
                _radius = value;
            }
        }

        public HinhTron() { }

        public HinhTron(double r)
        {
            Radius = r;
        }

        public double GetDienTich() => Math.PI * Radius * Radius;

        public double GetChuVi() => 2 * Math.PI * Radius;

        public void Nhap()
        {
            Radius = ReadPositiveDouble("Nhap ban kinh: ");
        }

        public void HienThi()
        {
            Console.WriteLine($"Hinh Tron - R={Radius}, Dien tich={GetDienTich():F2}, Chu vi={GetChuVi():F2}");
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (double.TryParse(s, out var v) && v > 0) return v;
                Console.WriteLine("Gia tri khong hop le. Vui long nhap so > 0.");
            }
        }
    }

    class HinhTamGiac : IHinh
    {
        private double _a, _b, _c;

        public double A
        {
            get => _a;
            set
            {
                if (value <= 0) throw new ArgumentException("Canh phai > 0");
                _a = value;
            }
        }

        public double B
        {
            get => _b;
            set
            {
                if (value <= 0) throw new ArgumentException("Canh phai > 0");
                _b = value;
            }
        }

        public double C
        {
            get => _c;
            set
            {
                if (value <= 0) throw new ArgumentException("Canh phai > 0");
                _c = value;
            }
        }

        public HinhTamGiac() { }

        public HinhTamGiac(double a, double b, double c)
        {
            A = a; B = b; C = c;
            if (!IsTamGiac()) throw new ArgumentException("Ba canh khong tao thanh tam giac");
        }

        public bool IsTamGiac() => A + B > C && A + C > B && B + C > A;

        public double GetChuVi() => A + B + C;

        public double GetDienTich()
        {
            var p = GetChuVi() / 2.0;
            var s = p * (p - A) * (p - B) * (p - C);
            return s <= 0 ? 0 : Math.Sqrt(s);
        }

        public void Nhap()
        {
            while (true)
            {
                A = ReadPositiveDouble("Nhap canh a: ");
                B = ReadPositiveDouble("Nhap canh b: ");
                C = ReadPositiveDouble("Nhap canh c: ");
                if (IsTamGiac()) break;
                Console.WriteLine("Ba canh khong thoa man de tao thanh tam giac. Vui long nhap lai.");
            }
        }

        public void HienThi()
        {
            Console.WriteLine($"Hinh Tam Giac - a={A}, b={B}, c={C}, Dien tich={GetDienTich():F2}, Chu vi={GetChuVi():F2}");
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (double.TryParse(s, out var v) && v > 0) return v;
                Console.WriteLine("Gia tri khong hop le. Vui long nhap so > 0.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var shapes = new List<IHinh>();
            while (true)
            {
                Console.WriteLine("\n1. Them Hinh Chu Nhat\n2. Them Hinh Tron\n3. Them Hinh Tam Giac\n4. Hien thi tat ca\n5. Thoat");
                Console.Write("Chon: ");
                var choice = Console.ReadLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            var cn = new HinhChuNhat(); cn.Nhap(); shapes.Add(cn); break;
                        case "2":
                            var tr = new HinhTron(); tr.Nhap(); shapes.Add(tr); break;
                        case "3":
                            var tg = new HinhTamGiac(); tg.Nhap(); shapes.Add(tg); break;
                        case "4":
                            Console.WriteLine("\n--- Danh sach hinh ---");
                            for (int i = 0; i < shapes.Count; i++)
                            {
                                Console.Write($"[{i+1}] ");
                                shapes[i].HienThi();
                            }
                            if (shapes.Count == 0) Console.WriteLine("(Chua co hinh nào)");
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Lua chon khong hop le."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
        }
    }
}
