namespace Account_Assignment.Controller;

public interface AdminHelperInterface
{
    void UserList();
    void TransactionHistoryList();
    void SearchUsersByName();
    void SearchUsersByAccountNumber();
    void SearchUsersByPhoneNumber();
    void AddNewUser(); // thành công
    void LockAndUnlockUserAccount();
    void SearchTransactionHistoryByAccountNumber();
    void ChangeAccountInformation();
    void ChangePasswordInformation();
}