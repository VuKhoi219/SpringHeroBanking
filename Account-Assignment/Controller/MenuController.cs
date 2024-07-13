namespace Account_Assignment.Controller;

public class MenuController
{
    public static void LogOrRegister()
    {
        bool ll = true;
        bool mk = true;

        while (ll) 
        {
            Console.WriteLine("Vui lòng nập lựa chọn của bạn");
            Console.WriteLine("1.Đăng ký tài khoản");
            Console.WriteLine("2. Đăng nhập");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                // đăng ký tài khoản
                Console.WriteLine("Nhập tên tài khoản :");
                string accountName = Console.ReadLine();
                Console.WriteLine("nhập số điện thoại :");
                string phone = Console.ReadLine();
                Console.WriteLine("Nhập mật khẩu");
                string password = Console.ReadLine();
                while (mk)
                {
                    Console.WriteLine("Vui lòng nhập lại mật khẩu");
                    string password2 = Console.ReadLine();
                    if (password2.Equals(password))
                    {
                        mk = false;
                    }
                }
                Console.WriteLine("Bạn là người dùng(1) hay admin(2)?");
                int y = int.Parse(Console.ReadLine());
                if (y==1)
                {
                    
                }

                if (y==2)
                {
                    
                }
                else
                {
                    Console.WriteLine("lựa chọn không hợp lệ");
                }
            }

            if (choice == 2)
            {
                ll = false;
                Console.WriteLine("Nhập tên tài khoản :");
                string accountName = Console.ReadLine();
                Console.WriteLine("Nhập mật khẩu");
                string password = Console.ReadLine();
                // đăng nhập 
            }
            else
            {
                Console.WriteLine("vui lòng nhập lại lựa chọn");
            }
        }
    }
}