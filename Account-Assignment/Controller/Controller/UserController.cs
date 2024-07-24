using Account_Assignment.Controller.Interface;
using Account_Assignment.Enity;
using Account_Assignment.MySQLrepository.MySqlRepository;

namespace Account_Assignment.Controller.Controller;

public class UserController : IUserControllerInterface
{
    private UserAccountBankRepository _userAccountBankRepository = new UserAccountBankRepository();
    private PasswordSecurity.PasswordSecurity _passwordSecurity = new PasswordSecurity.PasswordSecurity();
    private CheckAccountRepository _checkAccountRepository = new CheckAccountRepository();


    public void DepositMoney(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        userAccountBank.AccountNumber = accountNumber;
        Console.WriteLine("Số tiền nhận :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản đã được gửi : " + tractionAmount;
        Console.WriteLine("Nhập nội dung  ");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt = DateTime.Now;
        _userAccountBankRepository.DepositMoney(userAccountBank, tractionAmount);
    }

    public void WithdrawMoney(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();

        userAccountBank.AccountNumber = accountNumber;
        Console.WriteLine("Số tiền rút :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản đã được rút : " + tractionAmount;
        Console.WriteLine("Nhập nội dung :");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt = DateTime.Now;
        _userAccountBankRepository.WithdrawMoney(userAccountBank, tractionAmount);
    }

    public void TransferMoney(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();

        userAccountBank.senderAccount = accountNumber;
        Console.WriteLine("Số tài khoản nhận");
        userAccountBank.recipientAccount = Console.ReadLine();
        Console.WriteLine("Số tiền giao dịch :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản  " + userAccountBank.senderAccount + " đã gửi " +
                                             tractionAmount + " đến số tài khoản " + userAccountBank.recipientAccount;
        userAccountBank.TransactionHistory2 = "Số tài khoản" + userAccountBank.recipientAccount + " đã nhận " +
                                              tractionAmount + " từ số tài khoản " + userAccountBank.senderAccount;
        Console.WriteLine("Nhập nội dung :");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt = DateTime.Now;
        _userAccountBankRepository.TransferMoney(userAccountBank, tractionAmount);
    }

    public void CheckBalance(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        userAccountBank.AccountNumber = accountNumber;
        userAccountBank = _userAccountBankRepository.CheckBalance(userAccountBank);
        Console.WriteLine("Balace : " + userAccountBank.Balance);
    }

    public void EditPersonalInformation(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Nhập tên : ");
        userAccountBank.Name = Console.ReadLine();
        Console.WriteLine("Nhập số điện thoại:");
        userAccountBank.Phone = Console.ReadLine();
        while (userAccountBank.Phone.Length != 10)
        {
            Console.WriteLine("Số điện thoại khoong đúng vui lòng nhập lại :");
            userAccountBank.Phone = Console.ReadLine();
        }

        _userAccountBankRepository.EditPersonalInformation(userAccountBank, accountNumber);
    }

    public void ChangePassword(string? accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
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
        _userAccountBankRepository.ChangePassword(userAccountBank, accountNumber, password);
    }

    public void ViewTransactionHistory(string? accountNumber)
    {
        List<UserAccountBank> userAccountBanks =
            _userAccountBankRepository.TransactionHistoryByAccountBank(accountNumber);
        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}", "Account Number", "Transaction history",
            "Transaction history content", "Create at");
        foreach (var transaction in userAccountBanks)
        {
            Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}", transaction.AccountNumber,
                transaction.TransactionHistory, transaction.TransactionHistoryContent, transaction.CreatedAt);
        }
    }
}