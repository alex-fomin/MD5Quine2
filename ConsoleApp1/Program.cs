// See https://aka.ms/new-console-template for more information

using System.Text;
using ConsoleApp1;

var bytes = Enumerable.Range(0,16).Select(x=>(byte)x).ToArray();


Console.WriteLine(MD5.Calculate(bytes));

//var x= new Variable("x");
//var y= new Variable("y");

//var z = x&y&x&x&y;
//Console.WriteLine(z);