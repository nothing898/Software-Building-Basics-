using System;
using System.Timers;

namespace clock
{
    class Program
    {
        static void Main(string[] args)
        {

            AlarmClock clock = new AlarmClock();

            

            Console.Write("请输入闹钟时间 (格式 HH:mm:ss)：");
            DateTime alarmTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", null);
            clock.SetAlarm(alarmTime);

            Console.WriteLine("闹钟已启动...");
            clock.Start();

            Console.ReadLine(); // 防止程序退出
        }
    }

}

