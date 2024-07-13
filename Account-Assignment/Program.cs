// See https://aka.ms/new-console-template for more information

using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;

AdminRepository adminRepository = new AdminRepository();
AdminAccountBank adminAccountBank = new AdminAccountBank();
adminRepository.finByName("khoidk");
adminAccountBank.show();
