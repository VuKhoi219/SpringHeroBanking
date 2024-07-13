using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

namespace Account_Assignment.Controller;

public class AdminController
{
    

    public void AdminDashboard()
    {
        AdminHelper adminHelper = new AdminHelper();
        bool ll = true;

        while (ll) 
        {
            Console.WriteLine("Vui lòng nập lựa chọn của bạn");
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
                    adminHelper.UserList();
                    break;
                case 2:
                    // danh sách lịch sử gd
                    
                    break;
                case 3:
                    // tìm theo tên
                    break;
                case 4:
                    // tìm theo số tài khoản
                    break; 
                case 5:
                    // tìm theo số điện thoại
                    break;
                case 6:
                    // thêm mới
                    break;
                case 7:
                    // khóa or mở tài khoản người dùng
                    break;
                case 8:
                    // tìm kiếm lịch suwr giao dịch theo số tk
                    break;
                case 9:
                    // thay đổi thông tin tài khoản
                    break;
                case 10:
                    // thay đổi mk
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