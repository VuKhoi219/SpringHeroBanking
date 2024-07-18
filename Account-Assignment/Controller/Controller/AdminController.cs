using System.Runtime.InteropServices.JavaScript;
using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;
using Transaction = System.Transactions.Transaction;

namespace Account_Assignment.Controller;

public class AdminController : AdminHelperInterface
{
    private AdminAccountBankRepository _adminAccountBankRepository = new AdminAccountBankRepository();
    private TransactionRepository _transactionRepository = new TransactionRepository();
    private CommonFunctionRepository _commonFunctionRepository = new CommonFunctionRepository();

    public void DisplayByPersonalInfo(UserAccountBank userAccountBank)
    {
        Console.WriteLine("{0, -15} ||  {1, -15} || {2, -15} || {3, -15} || {4, -15} || {5, -15} || {6, -15}  ", 
            "Id", "Account Number","User name", "Name", "Phone", "Balance", "Status");
        Console.WriteLine("{0, -15} || {1, -15} || {2, -15} || {3, -15} || {4, -15} || {5, -15} || {6, -15}  ",
            userAccountBank.Id,userAccountBank.AccountNumber,userAccountBank.UseName,
            userAccountBank.Name, userAccountBank.Phone, userAccountBank.Balance,userAccountBank.Status);
    }
    public void UserList()
    {
        List<UserAccountBank> userRepositories = _adminAccountBankRepository.finAllUser();
        Console.WriteLine("{0, -15} | {1, -30} | {2, -30} | {3, -30} | {4, -30} | {5, -30} | {6, -30}  ", 
            "Id", "Account Number","User name", "Name", "Phone", "Balance", "Status");
        foreach (var user in userRepositories)
        {
            Console.WriteLine("{0, -15} | {1, -30} | {2, -30} | {3, -30} | {4, -30} | {5, -30} | {6, -30}  ",
                user.Id,user.AccountNumber,user.UseName, user.Name, user.Phone, user.Balance,user.Status);
        }
    } // thành công 

    public void TransactionHistoryList()
    {
        List<UserAccountBank> userAccountBanks = _transactionRepository.transactionHistory();
        Console.WriteLine("{0,-30} || {1,-30} || {2,-30} || {3,-30}","Account Number","Transaction history" ,"Transaction history content","Create at");
        foreach (var transaction in userAccountBanks)
        {
            Console.WriteLine("{0,-30} || {1,-30} || {2,-30} || {3,-30}",transaction.AccountNumber,transaction.TransactionHistory,transaction.TransactionHistoryContent,transaction.CreatedAt);
        }
    } // thành công

    public void SearchUsersByName()
    {
        Console.WriteLine("Vui lòng nhập tên tài khoản");
        string userName = Console.ReadLine();
        UserAccountBank userAccountBank = _adminAccountBankRepository.finByUserName(userName);
        DisplayByPersonalInfo(userAccountBank);
    } // thành công 

    public void SearchUsersByAccountNumber()
    {
        Console.WriteLine("Vui lòng nhập số tài khoản:");
        string accountNumber = Console.ReadLine() ;
        UserAccountBank userAccountBank = _adminAccountBankRepository.finByAccountNumber(accountNumber);
        DisplayByPersonalInfo(userAccountBank);
        
    } // thành công

    public void SearchUsersByPhoneNumber()  
    {
        Console.WriteLine("Vui lòng nhập phone:");
        string phone = Console.ReadLine();
        UserAccountBank userAccountBank = _adminAccountBankRepository.finByPhone(phone);
        DisplayByPersonalInfo(userAccountBank);
        
    } // thành công

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
        Console.WriteLine("Nhập lại mật khẩu ");
        string password2 = Console.ReadLine();
        while (password != password2)
        {
            Console.WriteLine("Nhập mật khẩu sai vui lòng nhập lại :");
            password2 = Console.ReadLine();
        }
        // Mã Hóa
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        userAccountBank.PassWord = BCrypt.Net.BCrypt.HashPassword(password, salt);
        Console.WriteLine("Nhập Số điện thoại:");
        userAccountBank.Phone = Console.ReadLine();
        while (userAccountBank.Phone.Length != 10)
        {
            Console.WriteLine("Số không hợp lệ vui lòng nhập lại");
            userAccountBank.Phone = Console.ReadLine();
        }
        Console.WriteLine("Bạn là người dùng(1) hay admin(2)?");
        int y = int.Parse(Console.ReadLine());
        if (y==1)
        {
            userAccountBank.Status = 1;
            Console.WriteLine("tài khoản người dùng");
        }
        else if (y==2)
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
        // Console.WriteLine("Số tài khoản của bạn là : " + userAccountBank.AccountNumber);

        _commonFunctionRepository.save(userAccountBank);
    } // thành công

    public void LockAndUnlockUserAccount()
    {   
        Console.WriteLine("Chọn vui lòng nhập số tài khoản");
        string accountNumber = Console.ReadLine();
        Console.WriteLine("Chọn bạn muốn khóa tài khoản (1) hay mở tài khoản(2)");
        int y = int.Parse(Console.ReadLine());
        if (y!=1 && y!=2)
        {
            Console.WriteLine("vui lòng chọn lại , bạn muốn khóa tài khoản (1) hay mở tài khoản(2) ");
            y = int.Parse(Console.ReadLine());
        }
        _adminAccountBankRepository.lockOrUnlock(accountNumber,y);
    } // thành công

    public void SearchTransactionHistoryByAccountNumber()
    {
        Console.WriteLine("Vui lòng nhập số tài khoản");
        string accountBank = Console.ReadLine();
        List<UserAccountBank> userAccountBanks = _transactionRepository.transactionHistoryByAccountBank(accountBank);
        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}","Account Number","Transaction history" ,"Transaction history content","Create at");
        foreach (var transaction in userAccountBanks)
        {
            Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}",transaction.AccountNumber,transaction.TransactionHistory,transaction.TransactionHistoryContent,transaction.CreatedAt);
        }
    }  // thành công

    public void ChangeAccountInformation()
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Vui lòng nhập số tài khoản bạn muốn thay đổi");
        string accountNumber = Console.ReadLine();
        Console.WriteLine("Nhập tên : ");
        userAccountBank.Name = Console.ReadLine();
        Console.WriteLine("Nhập số điện thoại:");
        userAccountBank.Phone = Console.ReadLine();
        while (userAccountBank.Phone.Length != 10)
        {
            Console.WriteLine("Số điện thoại khoong đúng vui lòng nhập lại :");
            userAccountBank.Phone = Console.ReadLine();
        }
        _commonFunctionRepository.editPersonalInformation(userAccountBank, accountNumber);
    } // thành công

    public void ChangePasswordInformation()
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Vui lòng nhập số tài khoản bạn muốn thay đổi");
        string accountNumber = Console.ReadLine();
        Console.WriteLine("Nhập mật khẩu cũ : ");
        string password = Console.ReadLine();
        Console.WriteLine("Nhập mật khẩu mới:");
        string password2 = Console.ReadLine();
        Console.WriteLine("Nhập lại mật khẩu");
        string password3 = Console.ReadLine();
        while (password2 != password3)
        {
            Console.WriteLine(" Nhập sai vui lòng nhập lại mật khẩu");
            password3 = Console.ReadLine();
        }
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        userAccountBank.PassWord = BCrypt.Net.BCrypt.HashPassword(password2, salt);
        _commonFunctionRepository.changePassword(userAccountBank, accountNumber, password);
    } // thành công 
}