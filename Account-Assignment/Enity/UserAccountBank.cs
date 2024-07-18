using System.Runtime.InteropServices.JavaScript;

namespace Account_Assignment.Eniti;

public class UserAccountBank
{
    public int Id { get; set; }

    public String AccountNumber { get; set; }
    public String UseName { get; set; }

    public String Name { get; set; }
    public String PassWord { get; set; }
    public String Phone { get; set; }
    public double Balance { get; set; }

    public String senderAccount { get; set; }
    public String recipientAccount { get; set; }
    public string TransactionHistory { get; set; } // lịch sử giao dịch hoặc lịch sử giao dịch cho tài khoản 1
    public string TransactionHistory2 { get; set; } // lịch sử giao dịch cho tài khoản 2

    public String TransactionHistoryContent { get; set; } // nội dung giao dịch
    public DateTime CreatedAt { get; set; } // ngày giao dịch 
    public int Status { get; set; } // trạng thái số tài khoản -1 : admin ; 0: log acc ; 1:user
}