using static System.Console;
using System;
using System.IO;

namespace DelegateExample
{
    public  delegate void NumberResult(int count);
    /// <summary>
    /// 事件发布者
    /// </summary>
    public class Publisher
    {
        private int count;
        public  NumberResult nr;//事件
        public void NumberChanged()
        {
            if (nr != null)
            {
                count++;
                nr(count);
            }
        }
    }
    /// <summary>
    /// 事件订阅者
    /// </summary>
    public class Sublisher
    {
        /// <summary>
        /// 事件触发的行为
        /// </summary>
        /// <param name="count"></param>
        public void ShowNumber(int count)
        {
            WriteLine($"当前数字计数为{count}！");
        }
    }
     class Program
    {
        
        static void Main(string[] args)
        {
            Publisher pb = new Publisher();
            Sublisher sb = new Sublisher();
            pb.nr += sb.ShowNumber;  //注册事件
            //pb.NumberChanged();//触发事件
            pb.nr(100);   //若有event封装则不适宜
            ReadKey();
        }
    }
}
