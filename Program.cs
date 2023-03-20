using static System.Console;
using System;
using System.IO;

namespace DelegateExample
{
    /// <summary>
    /// 用于问候方法的委托类型
    /// </summary>
    /// <param name="name"></param>
    public delegate void GreetMethods(string name);
    public class GreetProject{

        public static GreetMethods gm;  //将委托变量变成字段封装，调用方法前，需绑定
        /// <summary>
        /// 动态执行委托对应的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greetdelegate"></param>
        public static void GreetPeople2(string name)
        {
            if (gm != null) {
                gm(name);  //判断有没绑定先
            }
        }
    }
     class Program
    {
        /// <summary>
        /// 中文格式调用的方法
        /// </summary>
        /// <param name="name"></param>
        public static void ChineseGreet(string name)
        {
            WriteLine($"早晨，{name}！");
        }
        /// <summary>
        /// 英文格式调用的方法
        /// </summary>
        /// <param name="name"></param>
        public static void EnglishGreet(string name)
        {
            WriteLine($"Good morning,{name}!");
        }
        static void Main(string[] args)
        {
            //方法直接绑定到委托变量中
            GreetProject.gm = ChineseGreet;
            //委托的多播
            GreetProject.gm += EnglishGreet;
            GreetProject.gm -= EnglishGreet;
            GreetProject.GreetPeople2("吃佐早餐未");
            ReadKey();
        }
    }
}
