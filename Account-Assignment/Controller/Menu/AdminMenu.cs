using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

namespace Account_Assignment.Controller;

public class AdminMenu
{
    public void AdminDashboard(string name)
    {
        AdminController adminController = new AdminController();
        bool ll = true;
        Console.WriteLine("------ Ngân hàng Spring Hero Bank--------");
        Console.WriteLine("chào mừng Admin {0} quay trở lại ",name);
        while (ll) 
        {
            Console.WriteLine("Vui lòng chọn thao tác");
            Console.WriteLine("1. Danh sách người dùng");
            Console.WriteLine("2. Danh sách lịch sử giao dịch");
            Console.WriteLine("3. Tìm kiếm người dùng theo tên.");
            Console.WriteLine("4. Tìm kiếm người dùng theo số tài khoản");
            Console.WriteLine("5. Tìm kiếm người dùng theo số điện thoại.");
            Console.WriteLine("6. Thêm người dùng mới.");
            Console.WriteLine("7. Khoá và mở tài khoản người dùng");
            Console.WriteLine("8. Tìm kiếm lịch sử giao dịch theo số tài khoản");
            Console.WriteLine("9. Thay đổi thông tin tài khoản");
            Console.WriteLine("10. Thay đổi thông tin mật khẩu");
            Console.WriteLine("11.Thoát");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    // danh sách người dùng
                    adminController.UserList();
                    break;
                case 2:
                    // danh sách lịch sử gd
                    adminController.TransactionHistoryList();
                    break;
                case 3:
                    // tìm theo tên
                    adminController.SearchUsersByName();
                    break;
                case 4:
                    // tìm theo số tài khoản
                    adminController.SearchUsersByAccountNumber();
                    break; 
                case 5:
                    // tìm theo số điện thoại
                    adminController.SearchUsersByPhoneNumber();
                    break;
                case 6:
                    // thêm mới
                    adminController.AddNewUser();
                    break;
                case 7:
                    // khóa or mở tài khoản người dùng
                    adminController.LockAndUnlockUserAccount();
                    break;
                case 8:
                    // tìm kiếm lịch suwr giao dịch theo số tk
                    adminController.SearchTransactionHistoryByAccountNumber();
                    break;
                case 9:
                    // thay đổi thông tin tài khoản
                    adminController.ChangeAccountInformation();
                    break;
                case 10:
                    // thay đổi mk
                    adminController.ChangePasswordInformation();
                    break;
                case 11:
                    ll = false;
                    Console.WriteLine("Chào tạm biệt");
                    break;
                default:
                    Console.WriteLine("lựa chọn không hợp lệ");
                    break;
            }
        }
    }
}