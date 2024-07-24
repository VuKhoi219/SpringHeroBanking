namespace Account_Assignment.Enity;

public class UserAccountBank
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string UseName { get; set; }
    public string Name { get; set; }
    public string PassWord { get; set; }
    public string Phone { get; set; }
    public double Balance { get; set; }
    public string senderAccount { get; set; }
    public string recipientAccount { get; set; }
    public string TransactionHistory { get; set; } // lịch sử giao dịch hoặc lịch sử giao dịch cho tài khoản 1
    public string TransactionHistory2 { get; set; } // lịch sử giao dịch cho tài khoản 2
    public string TransactionHistoryContent { get; set; } // nội dung giao dịch
    public DateTime CreatedAt { get; set; } // ngày giao dịch 
    public int Status { get; set; } // trạng thái số tài khoản -1 : admin ; 0: log acc ; 1:user
}