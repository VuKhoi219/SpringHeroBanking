namespace Account_Assignment.Controller;

public interface UserHelperInterface
{
    void DepositMoney();
    void WithdrawMoney();
    void TransferMoney();
    void CheckBalance();
    void EditPersonalInformation();
    void ChangePassword();
    void ViewTransactionHistory();
    void Logout();
}