using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    //声明委托类型
    public delegate void AlarmClockEventHandler(object sender, EventArgs e);
  
    //声明参数类型
    public class EventArgs
    {
        public string ShowTime;
    }

    //定义事件源
    public class SetAlarmClock
    {  
        //声明事件
        public event AlarmClockEventHandler Setting;
        public void DoSetting()
        {
            Console.WriteLine("请输入闹钟唤醒时间(hh:mm)：");        //设置闹钟
            string str1 = Console.ReadLine();
            DateTime SettingTime;
            DateTime.TryParse(str1, out SettingTime);
            Console.WriteLine($"已设定闹钟为 {SettingTime}");

            DateTime NowTime = DateTime.Now;

            while (0 != DateTime.Compare(SettingTime, NowTime))
            {
                string str2 = DateTime.Now.ToShortTimeString().ToString(); //此时时间

                //每到一定的时间，发生一个事件，即通知外界
                if (Setting != null)
                {
                    EventArgs args = new EventArgs();
                    args.ShowTime = str2;
                    if (str1 != str2)
                    {
                        Console.WriteLine("时间未到！");
                    }
                    else
                    {
                        Console.WriteLine("时间已到！");
                    }
                    Setting(this, args);
                }
            }
        }
    }

    public class UseAlarmClock
    {
        static void Main()
        {
            var setter = new SetAlarmClock();
            //注册事件
            System.Threading.Thread.Sleep(1000);
            setter.Setting += ShowProgress;
            setter.DoSetting();
        }
        //事件处理方法
        static void ShowProgress(object sender, EventArgs e)
        {
            Console.WriteLine($"当前时间为：{e.ShowTime: ##:##}");
        }
    }

}