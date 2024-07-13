namespace Account_Assignment.Controller;

public class UserMenu
{
    
    public void UserAashboard()
    {
        bool ll = true;

        while (ll) 
        {
            Console.WriteLine("Vui lòng nập lựa chọn của bạn");
            Console.WriteLine("1.Gửi tiền");
            Console.WriteLine("2.Rút Tiền");
            Console.WriteLine("3.Chuyển khoản");
            Console.WriteLine("4.Truy vấn số dư");
            Console.WriteLine("5.Thay đổi thông tin cá nhân");
            Console.WriteLine("6.Thay đổi thông tin mật khẩu");
            Console.WriteLine("7.Truy vấn lịch sử giao dịch");
            Console.WriteLine("8.Thoát");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    // gửi tiền
                    break;
                case 2:
                    // rút tiền
                    break;
                case 3:
                    // chuyển khoản
                    break;
                case 4:
                    // truy vấn số dư
                    break; 
                case 5:
                    // thay đổi thông tin cá nhaan
                    break;
                case 6:
                    // thay đổi mật khẩu
                    break;
                case 7:
                    // ls gd
                    break;
                case 8:
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