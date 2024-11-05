// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;


var hello = "Hello, World!";
var bye = "Bye, World!";

//var helloHash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(hello));
var helloHash = MD5.HashData(Encoding.ASCII.GetBytes(hello));
var byeHash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(bye));

Console.WriteLine($"hello: {Encoding.Default.GetString(helloHash)}\nbye: {Encoding.Default.GetString(byeHash)}\n");


