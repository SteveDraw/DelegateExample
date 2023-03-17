using static System.Console;
using System;
using System.IO;

namespace DelegateExample
{
     class Program
    {
        //打印信息出来的委托
        public delegate void PrinfMsg(string msg);
        /// <summary>
        /// 根据传入的委托变量进行调用对应绑定的方法
        /// </summary>
        /// <param name="delegateMsg">委托变量参数</param>
        /// <param name="msg">信息参数</param>
        public static void Printf(PrinfMsg delegateMsg,string msg)
        {
            delegateMsg(msg);
        }
        /// <summary>
        /// 打印信息到屏幕中去
        /// </summary>
        /// <param name="msg">信息参数</param>
        public static void PrintfScreen(string msg)
        {
            WriteLine($"{msg}");
        }
        /// <summary>
        /// 打印信息到文件中去
        /// </summary>
        /// <param name="msg">信息参数</param>
        public static void PrintfFile(string msg)
        {
            FileStream fs = new FileStream(".\\example.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{DateTime.Now:yyyy年MM月dd日hh:mm:ss}->{msg}");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            //实例化委托，引用对应函数方法
            PrinfMsg pm1 = new PrinfMsg(PrintfScreen);
            PrinfMsg pm2 = new PrinfMsg(PrintfFile);
            //以委托变量的形式传参进入printf函数中执行
            Printf(pm1, "你好啊！");
            Printf(pm2, "Life is a fucking  movie!");
            ReadKey();
        }
    }
}
