// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System.Text;


var hello = "Hello, World!";
var helloHash = MD5.HashData(Encoding.ASCII.GetBytes(hello));

//var helloHash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(hello));
var bye = "Bye, World!";
var byeHash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(bye));

var text = "Hola Mundo!";
var textHashed = SHA256.HashData(Encoding.UTF8.GetBytes(text));
Console.WriteLine(textHashed);
 
Console.WriteLine($"hello: {Encoding.Default.GetString(helloHash)}\nbye: {Encoding.Default.GetString(byeHash)}\n");


