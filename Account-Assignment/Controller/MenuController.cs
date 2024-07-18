using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

namespace Account_Assignment.Controller;

public class MenuController
{
    public void LogOrRegister()
    {
        AdminController adminController = new AdminController();
        UserMenu userMenu = new UserMenu();
        AdminMenu adminMenu = new AdminMenu();
        LoginRepository loginRepository = new LoginRepository();
        UserAccountBank userAccountBank = new UserAccountBank();


        bool ll = true;

        while (ll)
        {
            Console.WriteLine("Vui lòng nập lựa chọn của bạn");
            Console.WriteLine("1.Đăng ký tài khoản");
            Console.WriteLine("2. Đăng nhập");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                adminController.AddNewUser();
            }

            if (choice == 2)
            {
                ll = false;
                Console.WriteLine("Nhập tên tài khoản :");
                string userName = Console.ReadLine();
                Console.WriteLine("Nhập mật khẩu");
                string password = Console.ReadLine();
                userAccountBank = loginRepository.checkAccount(userName, password);
                if (userAccountBank != null)
                {
                    if (userAccountBank.Status == 1)
                    {
                        userMenu.UserAashboard(userAccountBank.AccountNumber, userAccountBank.Name);
                    }
                    else if (userAccountBank.Status == -1)
                    {
                        adminMenu.AdminDashboard(userAccountBank.Name);
                    }
                    else if (userAccountBank.Status == 0)
                    {
                        Console.WriteLine("Tài khoản đã bị khóa");
                    }
                    else
                    {
                        Console.WriteLine("tài khoản không họp lệ ");
                    }
                }
            }
            else
            {
                Console.WriteLine("vui lòng nhập lại lựa chọn");
            }
        }
    }
}