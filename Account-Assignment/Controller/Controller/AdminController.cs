using Account_Assignment.Controller.Interface;
using Account_Assignment.Enity;
using Account_Assignment.MySQLrepository.MySqlRepository;

namespace Account_Assignment.Controller.Controller;

public class AdminController : IAdminControllerInterface
{
    private AdminAccountBankRepository _adminAccountBankRepository = new AdminAccountBankRepository();
    private PasswordSecurity.PasswordSecurity _passwordSecurity = new PasswordSecurity.PasswordSecurity();
    private CheckAccountRepository _checkAccountRepository = new CheckAccountRepository();

    //hiển thị danh sách ngươ dùng
    public void UserList()
    {
        List<UserAccountBank> userRepositories = _adminAccountBankRepository.FindAllUser();
        Console.WriteLine("{0, -15} | {1, -30} | {2, -30} | {3, -30} | {4, -30} | {5, -30} | {6, -30}  ",
            "Id", "Số tài khoản", "Tên tài khoản", "tên người dùng", "Số tài khoản", "Số dư", "Trạng thái");
        foreach (var user in userRepositories)
        {
            Console.WriteLine("{0, -15} | {1, -30} | {2, -30} | {3, -30} | {4, -30} | {5, -30} | {6, -30}  ",
                user.Id, user.AccountNumber, user.UseName, user.Name, user.Phone, user.Balance, user.Status);
        }
    }

    // hiển thị tất cả danh sách lịch suwr giao dịch
    public void TransactionHistoryList()
    {
        List<UserAccountBank> userAccountBanks = _adminAccountBankRepository.TransactionHistory();
        Console.WriteLine("{0,-30} || {1,-30} || {2,-30} || {3,-30}", "Số tài khoản", "Lịch sử giao dịch",
            "Nội dung giao dịch", "Ngày giao dịch");
        foreach (var users in userAccountBanks)
        {
            Console.WriteLine("{0,-30} || {1,-30} || {2,-30} || {3,-30}", users.AccountNumber,
                users.TransactionHistory, users.TransactionHistoryContent, users.CreatedAt);
        }
    }

    // hiển thị theo thông tin cá nhân 
    public void DisplayByPersonalInfo(UserAccountBank? userAccountBank)
    {
        Console.WriteLine("{0, -15} ||  {1, -15} || {2, -15} || {3, -15} || {4, -15} || {5, -15} || {6, -15}  ",
            "Id", "Số tài khoản", "Tên tài khoản", "tên người dùng", "sô điện thoại", "Số dư", "Trạng thái");
        Console.WriteLine("{0, -15} || {1, -15} || {2, -15} || {3, -15} || {4, -15} || {5, -15} || {6, -15}  ",
            userAccountBank.Id, userAccountBank.AccountNumber, userAccountBank.UseName,
            userAccountBank.Name, userAccountBank.Phone, userAccountBank.Balance, userAccountBank.Status);
    }

    public void SearchUsersByName()
    {
        Console.WriteLine("Vui lòng nhập tên tài khoản");
        string userName = Console.ReadLine();
        UserAccountBank? userAccountBank = _adminAccountBankRepository.FindByUserName(userName);
        DisplayByPersonalInfo(userAccountBank);
    }

    public void SearchUsersByAccountNumber()
    {
        Console.WriteLine("Vui lòng nhập số tài khoản:");
        string accountNumber = Console.ReadLine();
        UserAccountBank? userAccountBank = _adminAccountBankRepository.FindByAccountNumber(accountNumber);
        DisplayByPersonalInfo(userAccountBank);
    }

    public void SearchUsersByPhoneNumber()
    {
        Console.WriteLine("Vui lòng nhập phone:");
        string phone = Console.ReadLine();
        UserAccountBank? userAccountBank = _adminAccountBankRepository.FindByPhone(phone);
        DisplayByPersonalInfo(userAccountBank);
    }

    //thêm tài khoản
    public void AddNewUser()
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Vui lòng nhập thông tin");
        Console.WriteLine("Nhập tên tài khoản:");
        userAccountBank.UseName = Console.ReadLine();
        Console.WriteLine("Nhập tên người dùng");
        userAccountBank.Name = Console.ReadLine();
        Console.WriteLine("Nhập mật khẩu:");
        string password = Console.ReadLine();
        string encryptPassword = _passwordSecurity.EncryptPassword(password);
        Console.WriteLine("Nhập lại mật khẩu ");
        string checkPassword = Console.ReadLine();
        bool check = _passwordSecurity.DecryptPassword(checkPassword, encryptPassword);
        while (check != true)
        {
            Console.WriteLine("Nhập mật khẩu sai vui lòng nhập lại :");
            checkPassword = Console.ReadLine();
            check = _passwordSecurity.DecryptPassword(checkPassword, encryptPassword);
        }

        userAccountBank.PassWord = encryptPassword;
        Console.WriteLine("Nhập Số điện thoại:");
        userAccountBank.Phone = Console.ReadLine();
        while (userAccountBank.Phone.Length != 10)
        {
            Console.WriteLine("Số không hợp lệ vui lòng nhập lại");
            userAccountBank.Phone = Console.ReadLine();
        }

        Console.WriteLine("Bạn là người dùng(1) hay admin(2)?");
        int y = int.Parse(Console.ReadLine());
        if (y == 1)
        {
            userAccountBank.Status = 1;
            Console.WriteLine("tài khoản người dùng");
        }
        else if (y == 2)
        {
            userAccountBank.Status = -1;
            Console.WriteLine("tài khoản Admin");
        }
        else
        {
            Console.WriteLine("lựa chọn không hợp lệ");
        }

        Random random = new Random();
        string randomDigits = "";
        for (int i = 0; i < 10; i++)
        {
            randomDigits += random.Next(0, 10).ToString();
        }

        userAccountBank.AccountNumber = randomDigits;
        Console.WriteLine("Số tài khoản của bạn là : " + userAccountBank.AccountNumber);

        _adminAccountBankRepository.Save(userAccountBank);
    }

    // khóa hoặc mở khóa tài khoản
    public void LockAndUnlockUserAccount()
    {
        Console.WriteLine("Chọn vui lòng nhập số tài khoản");
        string accountNumber = Console.ReadLine();
        Console.WriteLine("Chọn bạn muốn khóa tài khoản (1) hay mở tài khoản(2)");
        int y = int.Parse(Console.ReadLine());
        if (y != 1 && y != 2)
        {
            Console.WriteLine("vui lòng chọn lại , bạn muốn khóa tài khoản (1) hay mở tài khoản(2) ");
            y = int.Parse(Console.ReadLine());
        }

        _adminAccountBankRepository.LockOrUnlock(accountNumber, y);
    }

    //tim kiếm lịch sử giao dịch theo số tài khoản
    public void SearchTransactionHistoryByAccountNumber()
    {
        Console.WriteLine("Vui lòng nhập số tài khoản");
        string accountBank = Console.ReadLine();
        List<UserAccountBank> userAccountBanks =
            _adminAccountBankRepository.TransactionHistoryByAccountBank(accountBank);
        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}", "Account Number", "Transaction history",
            "Transaction history content", "Create at");
        foreach (var transaction in userAccountBanks)
        {
            Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}", transaction.AccountNumber,
                transaction.TransactionHistory, transaction.TransactionHistoryContent, transaction.CreatedAt);
        }
    }

    // chỉnh suawr thông tin cá nhân và mật khẩu
    public void ChangeAccountInformation()
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Vui lòng nhập số tài khoản bạn muốn thay đổi");
        string? accountNumber = Console.ReadLine();
        Console.WriteLine("Nhập tên : ");
        userAccountBank.Name = Console.ReadLine();
        Console.WriteLine("Nhập số điện thoại:");
        userAccountBank.Phone = Console.ReadLine();
        while (userAccountBank.Phone.Length != 10)
        {
            Console.WriteLine("Số điện thoại khoong đúng vui lòng nhập lại :");
            userAccountBank.Phone = Console.ReadLine();
        }

        _adminAccountBankRepository.EditPersonalInformation(userAccountBank, accountNumber);
    }

    public void ChangePasswordInformation()
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Vui lòng nhập số tài khoản bạn muốn thay đổi");
        string? accountNumber = Console.ReadLine();
        Console.WriteLine("Nhập mật khẩu cũ : ");
        string password = Console.ReadLine();
        _checkAccountRepository.CheckAccountBankByAccountBank(accountNumber, password);
        Console.WriteLine("Nhập mật khẩu mới:");
        string newPassword = Console.ReadLine();
        string encryptPassword = _passwordSecurity.EncryptPassword(newPassword);
        Console.WriteLine("Nhập lại mật khẩu ");
        string checkPassword = Console.ReadLine();
        bool check = _passwordSecurity.DecryptPassword(checkPassword, encryptPassword);
        while (check != true)
        {
            Console.WriteLine("Nhập mật khẩu sai vui lòng nhập lại :");
            checkPassword = Console.ReadLine();
            check = _passwordSecurity.DecryptPassword(checkPassword, encryptPassword);
        }

        userAccountBank.PassWord = encryptPassword;

        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        userAccountBank.PassWord = BCrypt.Net.BCrypt.HashPassword(newPassword, salt);
        _adminAccountBankRepository.ChangePassword(userAccountBank, accountNumber, password);
    }
}