namespace Account_Assignment.Controller;

public class UserMenu
{
    private UserController _userController = new UserController();
    public void UserAashboard(string accountNumber,string name)
    {
        bool ll = true;
        while (ll) 
        {
            Console.WriteLine("------Ngân hàng Spring Hero Bank------");
            Console.WriteLine("Chào mừng {0} quay trở lại . Vui lòng chọn thao tác ",name);
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
                    _userController.DepositMoney(accountNumber);
                    break;
                case 2:
                    // rút tiền
                    _userController.WithdrawMoney(accountNumber);
                    break;
                case 3:
                    // chuyển khoản
                    _userController.TransferMoney(accountNumber);
                    break;
                case 4:
                    _userController.CheckBalance(accountNumber);
                    // truy vấn số dư
                    break; 
                case 5:
                    _userController.EditPersonalInformation(accountNumber);
                    // thay đổi thông tin cá nhaan
                    break;
                case 6:
                    _userController.ChangePassword(accountNumber);
                    // thay đổi mật khẩu
                    break;
                case 7:
                    // ls gd
                    _userController.ViewTransactionHistory(accountNumber);
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