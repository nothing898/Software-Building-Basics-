using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace clock
{
    // 定义闹钟类
    class AlarmClock
    {
        private Timer timer;
        private DateTime alarmTime;

        // 定义 Tick 事件
        public event EventHandler Tick;
        // 定义 Alarm 事件
        public event EventHandler Alarm;

        public AlarmClock()
        {
            timer = new Timer(1000); // 1秒触发一次
            timer.Elapsed += OnTick;
            Alarm += (s, e) => {
                Console.WriteLine("闹钟响了！时间到：" + DateTime.Now.ToString("HH:mm:ss"));
                timer.Stop(); 
            }; // 触发闹钟响铃
            Tick += (s, e) => { Console.WriteLine("嘀嗒... " + DateTime.Now.ToString("HH:mm:ss")); };
        }

        public void SetAlarm(DateTime time)
        {
            alarmTime = time;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            Tick?.Invoke(this, EventArgs.Empty);
            

            if (DateTime.Now == alarmTime)
            {
                Alarm?.Invoke(this, EventArgs.Empty);
                
            }
        }
    }

}
