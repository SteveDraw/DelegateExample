using static System.Console;
using System;
using System.IO;

namespace DelegateExample
{
     class Program
    {
        /// <summary>
        /// 用于问候方法的委托类型
        /// </summary>
        /// <param name="name"></param>
        public delegate void GreetMethods(string name);
        /// <summary>
        /// 用于选择中英文方法的枚举
        /// </summary>
        public enum Language {
            Chinese,English
        }
        /// <summary>
        /// 使用枚举标志进行选择执行对应的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        public static void GreetPeople1(string name,Language language)
        {
            switch (language) {
                case Language.Chinese:
                    ChineseGreet(name);
                    break;
                case Language.English:
                    EnglishGreet(name);
                    break;
            }       
        }
        /// <summary>
        /// 动态执行委托对应的方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="greetdelegate"></param>
        public static void GreetPeople2(string name,GreetMethods greetdelegate)
        {
            greetdelegate(name);
        }
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
            //传统根据选择枚举标志来执行对应的方法流程
            GreetPeople1("靓仔", Language.Chinese);
            GreetPeople1("handsome boy", Language.English);
            //方法绑定到委托实例化变量
            GreetMethods gm1 = new GreetMethods(ChineseGreet);
            GreetMethods gm2 = new GreetMethods(EnglishGreet);
            GreetPeople2("得闲饮茶",ChineseGreet);
            GreetPeople2("Bye", gm2);
            //方法直接绑定到委托变量中
            GreetMethods gm3 = ChineseGreet;
            //委托的多播
            gm3 += EnglishGreet;
            gm3 -= EnglishGreet;
            gm3("吃佐早餐未");
            ReadKey();
        }
    }
}
