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
        CheckAccountRepository checkAccountRepository = new CheckAccountRepository();
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
                string userOrAccount = null;

                Console.WriteLine("Chọn phương thức đăng nhập: ");
                Console.WriteLine("1.Đăng nhập bằng tên tài khoản");
                Console.WriteLine("2.Đăng nhập bằng số tài khoản");
                int choice2 = int.Parse(Console.ReadLine());
                if (choice2 == 1)
                {
                    Console.WriteLine("Vui lòng nhập tên tài khoản: ");
                    userOrAccount = Console.ReadLine();
                }
                else if (choice2 == 2)
                {
                    Console.WriteLine("Vui lòng nhập tên tài khoản: ");
                    userOrAccount = Console.ReadLine();
                }

                Console.WriteLine("Nhập mật khẩu");
                string password = Console.ReadLine();
                if (choice2 == 1)
                {
                    userAccountBank = checkAccountRepository.checkAccountBankByUserName(userOrAccount, password);
                }
                else if (choice2 == 2)
                {
                    userAccountBank = checkAccountRepository.checkAccountBankByAccountBank(userOrAccount, password);
                }

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