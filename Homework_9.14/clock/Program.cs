using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace clock
{
    delegate void AlarmHandler(object sender, Time args);
    delegate void TickHandler(object sender);

    class Time
    {
        public Time(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public bool Equals(Time newTime)
        {
            // 判断两个时间是否相当
            if (newTime.hour == this.hour && newTime.minute == this.minute && newTime.second == this.second) return true;
            else return false;
        }

        public int hour;
        public int minute;
        public int second;
    }

    class Screen
    {
        public event TickHandler OnTick;
        public Time nowTime = new Time(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        public void FreshTime()
        {
            // 更新时间
            nowTime.hour = DateTime.Now.Hour;
            nowTime.minute = DateTime.Now.Minute;
            nowTime.second = DateTime.Now.Second;
        }

        public void ShowNowTime()
        {
            // 屏幕打印现在的时间
            Console.Write(nowTime.hour.ToString().PadLeft(2, '0') + ":");
            Console.Write(nowTime.minute.ToString().PadLeft(2, '0') + ":");
            Console.Write(nowTime.second.ToString().PadLeft(2, '0') + "\n");
        }

        public void Tick()
        {
            // 触发OnTick事件
            OnTick(this);
        }
    }

    class AlarmController
    {
        public event AlarmHandler OnAlarm;
        public Time alarmTime;

        // 设定闹钟的时间
        public void SetAlarmTime(int hour, int minute, int second)
        {
            alarmTime = new Time(hour, minute, second);
        }

        public void Alarm()
        {
            // 触发OnAlarm事件
            OnAlarm(this, alarmTime);
        }
    }

    class Clock
    {
        public Screen screen = new Screen();
        public AlarmController alarm = new AlarmController();

        public Clock()
        {
            screen.OnTick += ClockTick;
            alarm.OnAlarm += Alarm;
        }

        public void Start()
        {
            while (!screen.nowTime.Equals(alarm.alarmTime))
            {
                screen.FreshTime();
                // Tick事件触发
                screen.Tick();
                Thread.Sleep(999);
            }

            alarm.Alarm();
        }

        void ClockTick(object sender)
        {
            Console.Write("Tick......");
            Console.Write("Now time is ");
            screen.ShowNowTime();
        }

        void Alarm(object sender, Time alarmTime)
        {
            Console.WriteLine("Alarm!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Clock clock = new Clock();
                int hour, minute, second;
                Console.WriteLine("请输入您指定的闹钟时间。（时、分、秒，并用回车相隔）");
                hour = int.Parse(Console.ReadLine());
                minute = int.Parse(Console.ReadLine());
                second = int.Parse(Console.ReadLine());
                Console.WriteLine("-----------------------------------------------------");

                clock.alarm.SetAlarmTime(hour, minute, second);
                clock.Start();
            }
            catch
            {
                Console.WriteLine("您的输入有误！");
            }
        }
    }
}
