﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Yuzu.ProductMonitor.UserControls;
using Yuzu.ProductMonitor.Models;

namespace Yuzu.ProductMonitor.ViewModels
{

    /// <summary>
    /// 主界面的视图模型（ViewModel）
    /// </summary>
    public class MainWindowVM : ObservableObject
    {
        #region 计时器
        private readonly DispatcherTimer timer = new DispatcherTimer();

        private string time = string.Empty;
        public string Time
        {
            get => time;
            set
            {
                if (time != value) { time = value; RaisePropertyChanged(); }
            }
        }

        private string date = string.Empty;
        public string Date
        {
            get => date;
            set
            {
                if (date != value) { date = value; RaisePropertyChanged(); }
            }
        }

        private string weekDay = string.Empty;
        public string WeekDay
        {
            get => weekDay;
            set
            {
                if (weekDay != value) { weekDay = value; RaisePropertyChanged(); }
            }
        }

        // 初始化计时器
        private void InitializeTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) =>
            {
                Time = DateTime.Now.ToString("HH:mm:ss");
                Date = DateTime.Now.ToString("yyyy:MM:dd");
                WeekDay = DateTime.Now.ToString("dddd");
            };
            timer.Start();
        }
        #endregion

        #region 用户控件
        // 监视用户控件：因为以后会定义别的控件，所以类型统一使用 UserControl
        private UserControl? monitorUserControl;
        public UserControl? MonitorUserControl
        {
            get
            {
                return monitorUserControl;
            }
            set
            {
                monitorUserControl = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region 计数
        // 机台总数
        private string machineCount;
        public string MachineCount
        {
            get => machineCount;
            set
            {
                if (machineCount != value)
                {
                    machineCount = value; RaisePropertyChanged();
                }
            }
        }

        // 生产计数
        private string productCount;
        public string ProductCount
        {
            get => productCount;
            set
            {
                if (productCount != value)
                {
                    productCount = value; RaisePropertyChanged();
                }
            }
        }

        // 不良计数
        private string badCount;
        public string BadCount
        {
            get => badCount;
            set
            {
                if (badCount != value)
                {
                    badCount = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 环境监控数据
        private List<EnvironmentModel> environmentModelList = new List<EnvironmentModel>();
        public List<EnvironmentModel> EnvironmentModelList
        {
            get => environmentModelList;
            set
            {
                if (environmentModelList != value)
                {
                    environmentModelList = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 报警属性
        private List<AlarmModel> alarmList;
        public List<AlarmModel> AlarmList
        {
            get => alarmList;
            set
            {
                if (alarmList != value)
                {
                    alarmList = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 构造器
        public MainWindowVM()
        {
            MonitorUserControl = new MonitorUserControl();

            // 真实场景数据是即时产生的
            machineCount = "0442";
            ProductCount = "11423";
            BadCount = "0122";

            #region 初始化环境监控数据
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "光照(Lux)", EnvironmentItemValue = 123 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "噪音(dB)", EnvironmentItemValue = 55 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "温度(℃)", EnvironmentItemValue = 30 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "湿度(%)", EnvironmentItemValue = 90 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "PM2.5(m³)", EnvironmentItemValue = 40 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "硫化氢(PPM)", EnvironmentItemValue = 15 });
            EnvironmentModelList.Add(new EnvironmentModel { EnvironmentItemName = "氮气(PPM)", EnvironmentItemValue = 20 });
            #endregion

            #region 初始化报警数据
            AlarmList = new List<AlarmModel>();
            AlarmList.Add(new AlarmModel() { Code = "01", Duration = 7, Message = "设备温度过高", Time = "2024-08-04" });
            AlarmList.Add(new AlarmModel() { Code = "02", Duration = 12, Message = "车间温度过高", Time = "2024-08-03" });
            AlarmList.Add(new AlarmModel() { Code = "03", Duration = 6, Message = "设备转速过快", Time = "2024-08-02" });
            AlarmList.Add(new AlarmModel() { Code = "04", Duration = 1, Message = "设备气压过低", Time = "2024-08-01" });
            AlarmList.Add(new AlarmModel() { Code = "05", Duration = 3, Message = "设备脱机", Time = "2024-08-01" });
            #endregion

            InitializeTimer();
        }
        #endregion
    }
}
