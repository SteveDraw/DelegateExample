using static System.Console;
using System;

namespace DelegateExample
{
     class Program
    {
        public delegate void Calculate(string msg);
        public static void SendMsg(string msg)
        {
            WriteLine($"->Send message({DateTime.Now:yyyy年MM月dd日hh:mm:ss}):{msg}");
        }
        public static void ReceiveMsg(string msg)
        {
            WriteLine($"->Receive message({DateTime.Now:yyyy年MM月dd日hh:mm:ss}):{msg}");
        }
        static void Main(string[] args)
        { 
            //原函数直接调用
            SendMsg("你好啊！");
            ReceiveMsg("你都好啊！");

            //委托类型调用方法
            Calculate msg1 = new Calculate(SendMsg);
            Calculate msg2 = new Calculate(ReceiveMsg);
            msg1("你食佐饭未啊？");
            msg2("食佐啦！");

            //委托的多播（组播）
            Calculate msg3;
            msg3 = msg1;
            msg3 += msg2;           
            msg3("多谢嗮！");
            
            ReadKey();
        }
    }
}
