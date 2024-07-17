// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using Account_Assignment.Controller;
using Account_Assignment.Eniti;
using Account_Assignment.MySQLrepository;
using BCrypt.Net;

MenuController menuController = new MenuController();
menuController.LogOrRegister();
