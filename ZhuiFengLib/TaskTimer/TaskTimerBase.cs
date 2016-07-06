using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace ZhuiFengLib.TaskTimer
{
    /// <summary>
    /// 倒计时执行任务
    /// </summary>
    public class TaskTimerBase
    {
        private const int INT_Constant = 1000;
        private Thread Td;                                            //实例化一个线程，执行实现的任务
        private System.Timers.Timer tim = new System.Timers.Timer();  //实例化Timer类，设置间隔时间为10000毫秒；

        /// <summary>
        /// 初始化同步
        /// </summary>
        public TaskTimerBase()
        {
            tim.Interval = INT_Constant;                              //设置
            tim.Elapsed += new ElapsedEventHandler(Theout);   //到达时间的时候执行事件；
        }

        /// <summary>
        /// 同步间隔时间 单位为分钟 默认五分钟
        /// </summary>
        public double Interval
        {
            get { return tim.Interval; }
            set { tim.Interval = value * INT_Constant; }
        }

        /// <summary>
        /// 开始同步
        /// </summary>
        public void Start()
        {
            tim.Start();
        }

        /// <summary>
        /// 停止同步
        /// </summary>
        public void Stop()
        {
            tim.Stop();
        }

        /// <summary>
        /// 开始计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Theout(object sender, ElapsedEventArgs e)
        {
            Td = new Thread(new ThreadStart(SynchronousMethod));
            Td.IsBackground = true;
            Td.Start();
        }

        /// <summary>
        /// 到了指定时间要执行的方法
        /// </summary>
        public Action SynchronousMethod;
    }
}