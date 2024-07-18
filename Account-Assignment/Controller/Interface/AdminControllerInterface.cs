using Account_Assignment.Eniti;

namespace Account_Assignment.Controller;

public interface AdminControllerInterface
{
    void UserList();
    void TransactionHistoryList();
    void DisplayByPersonalInfo(UserAccountBank userAccountBank);
    void SearchUsersByName();
    void SearchUsersByAccountNumber();
    void SearchUsersByPhoneNumber();
    void AddNewUser(); 
    void LockAndUnlockUserAccount();
    void SearchTransactionHistoryByAccountNumber();
    void ChangeAccountInformation();
    void ChangePasswordInformation();
}