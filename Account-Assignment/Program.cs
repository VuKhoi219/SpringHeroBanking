// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using Account_Assignment.Controller;
using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;
using BCrypt.Net;

// MenuController menuController = new MenuController();
// menuController.LogOrRegister();

CommonFunctionRepository _commonFunctionRepository = new CommonFunctionRepository();

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