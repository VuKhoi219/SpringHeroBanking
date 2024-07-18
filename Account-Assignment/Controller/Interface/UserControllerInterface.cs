namespace Account_Assignment.Controller;

public interface UserControllerInterface
{
    void DepositMoney(string accountNumber);
    void WithdrawMoney(string accountNumber);
    void TransferMoney(string accountNumber);
    void CheckBalance(string accountNumber);
    void EditPersonalInformation(string accountNumber);
    void ChangePassword(string accountNumber);
    void ViewTransactionHistory(string accountNumber);
}