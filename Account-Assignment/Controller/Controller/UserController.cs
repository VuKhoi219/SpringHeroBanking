using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

namespace Account_Assignment.Controller;

public class UserController : UserHelperInterface
{
    private UserAccountBankRepository _userAccountBankRepository = new UserAccountBankRepository();
    private TransactionRepository _transactionRepository = new TransactionRepository();
    private CommonFunctionRepository _commonFunctionRepository = new CommonFunctionRepository();
    public void DepositMoney(string accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        userAccountBank.AccountNumber = accountNumber;
        Console.WriteLine("Số tiền nhận :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản đã được gửi : " + tractionAmount;
        Console.WriteLine("Nhập nội dung  ");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt =  DateTime.Now;
        _userAccountBankRepository.depositMoney(userAccountBank, tractionAmount);
    }

    public void WithdrawMoney(string accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();

        userAccountBank.AccountNumber = accountNumber;
        Console.WriteLine("Số tiền rút :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản đã được rút : " + tractionAmount;
        Console.WriteLine("Nhập nội dung :");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt =  DateTime.Now;
        _userAccountBankRepository.withdrawMoney(userAccountBank, tractionAmount);        
    }

    public void TransferMoney(string accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();

        userAccountBank.senderAccount = accountNumber;
        Console.WriteLine("Số tài khoản nhận");
        userAccountBank.recipientAccount = Console.ReadLine();
        Console.WriteLine("Số tiền giao dịch :");
        double tractionAmount = double.Parse(Console.ReadLine());
        userAccountBank.TransactionHistory = "Số tài khoản  " +userAccountBank.senderAccount +" đã gửi "+ tractionAmount + " đến số tài khoản " + userAccountBank.recipientAccount;
        userAccountBank.TransactionHistory2 = "Số tài khoản" + userAccountBank.recipientAccount + " đã nhận " + tractionAmount + " từ số tài khoản " + userAccountBank.senderAccount;
        Console.WriteLine("Nhập nội dung :");
        userAccountBank.TransactionHistoryContent = Console.ReadLine();
        userAccountBank.CreatedAt =  DateTime.Now;
        _userAccountBankRepository.transferMoney(userAccountBank, tractionAmount);
    }

    public void CheckBalance(string accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        userAccountBank.AccountNumber = accountNumber;
        userAccountBank = _userAccountBankRepository.CheckBalance(userAccountBank);
        Console.WriteLine("Balace : "+userAccountBank.Balance);
    }

    public void EditPersonalInformation(string accountNumber)
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
        _commonFunctionRepository.editPersonalInformation(userAccountBank, accountNumber);
        
    }

    public void ChangePassword(string accountNumber)
    {
        UserAccountBank userAccountBank = new UserAccountBank();
        Console.WriteLine("Nhập mật khẩu : ");
        string password = Console.ReadLine();
        Console.WriteLine("Nhập mật khẩu mới:");
        userAccountBank.PassWord = Console.ReadLine();
        _commonFunctionRepository.changePassword(userAccountBank, accountNumber, password);    }

    public void ViewTransactionHistory(string accountNumber)
    {
        List<UserAccountBank> userAccountBanks = _transactionRepository.transactionHistoryByAccountBank(accountNumber);
        Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}","Account Number","Transaction history" ,"Transaction history content","Create at");
        foreach (var transaction in userAccountBanks)
        {
            Console.WriteLine("{0,-30} {1,-30} {2,-30} {3,-30}",transaction.AccountNumber,transaction.TransactionHistory,transaction.TransactionHistoryContent,transaction.CreatedAt);
        }
    }


}