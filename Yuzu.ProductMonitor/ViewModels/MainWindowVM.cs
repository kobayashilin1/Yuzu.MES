﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Yuzu.ProductMonitor.UserControls;
using Yuzu.ProductMonitor.Models;
using System.Collections.ObjectModel;
using System.Windows.Navigation;

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

        #region 设备属性
        private List<DeviceModels> deviceList;
        public List<DeviceModels> DeviceList
        {
            get => deviceList;
            set
            {
                if (deviceList != value)
                {
                    deviceList = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 雷达图属性
        private List<RaderModel> raderList;
        public List<RaderModel> RaderList
        {
            get => raderList;
            set
            {
                if (raderList != value)
                {
                    raderList = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 人力资源属性
        private HumanResourceModel humanResource;
        public HumanResourceModel HumanResource
        {
            get => humanResource;
            set
            {
                if (humanResource != value)
                {
                    humanResource = value; RaisePropertyChanged();
                }
            }
        }
        #endregion

        #region 员工缺岗属性
        private List<StuffOutOfWorkModel> stuffOutOfWorkList = new List<StuffOutOfWorkModel>();
        public List<StuffOutOfWorkModel> StuffOutOfWorkList
        {
            get => stuffOutOfWorkList;
            set
            {
                if (stuffOutOfWorkList != value)
                {
                    stuffOutOfWorkList = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region 车间数据属性
        private List<WorkShopModel> workShopList;
        public List<WorkShopModel> WorkShopList
        {
            get => workShopList;
            set
            {
                if (value != null)
                {
                    workShopList = value;
                    RaisePropertyChanged();
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

            #region 初始化设备数据
            DeviceList = new List<DeviceModels>();
            DeviceList.Add(new DeviceModels { DeviceItemName = "电能(KWh)", DeviceItemValue = 60.8 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "电压(V)", DeviceItemValue = 420 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "电流(A)", DeviceItemValue = 12 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "压强(KPa)", DeviceItemValue = 13 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "湿度(%)", DeviceItemValue = 52 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "震动(mm/s)", DeviceItemValue = 3.2 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "转速(rpm)", DeviceItemValue = 7200 });
            DeviceList.Add(new DeviceModels { DeviceItemName = "气压(KPa)", DeviceItemValue = 10 });
            #endregion

            #region 初始化雷达图数据
            RaderList = new List<RaderModel>();
            raderList.Add(new RaderModel { ItemName = "排水烟风机", ItemValue = 90 });
            raderList.Add(new RaderModel { ItemName = "稳压设备", ItemValue = 67.2 });
            raderList.Add(new RaderModel { ItemName = "变电设备", ItemValue = 83 });
            raderList.Add(new RaderModel { ItemName = "喷淋水泵", ItemValue = 90 });
            raderList.Add(new RaderModel { ItemName = "客梯", ItemValue = 45 });
            raderList.Add(new RaderModel { ItemName = "供水机", ItemValue = 56 });
            #endregion

            #region 初始化人力资源数据
            humanResource = new HumanResourceModel("在岗总人数", 566);
            #endregion

            #region 初始化员工缺岗数据
            StuffOutOfWorkList.Add(new StuffOutOfWorkModel { StuffName = "张三", OutOfWorkCount = 12, PositionName = "技术员" });
            StuffOutOfWorkList.Add(new StuffOutOfWorkModel { StuffName = "李四", OutOfWorkCount = 30, PositionName = "技术员" });
            StuffOutOfWorkList.Add(new StuffOutOfWorkModel { StuffName = "王五", OutOfWorkCount = 61, PositionName = "操作员" });
            StuffOutOfWorkList.Add(new StuffOutOfWorkModel { StuffName = "赵六", OutOfWorkCount = 2, PositionName = "技术员" });
            StuffOutOfWorkList.Add(new StuffOutOfWorkModel { StuffName = "何七七", OutOfWorkCount = 18, PositionName = "技术员" });
            StuffOutOfWorkList.Sort(new StuffOutOfWorkComparer());
            #endregion

            #region 初始化车间数据
            WorkShopList = new List<WorkShopModel>();
            WorkShopList.Add(new WorkShopModel { WorkShopName = "车间1" , WorkingCount = 12, StopCount = 3, WaitingCount = 1, ErrorCount = 0});
            WorkShopList.Add(new WorkShopModel { WorkShopName = "车间2" , WorkingCount =11, StopCount = 0, WaitingCount = 4, ErrorCount = 1});
            WorkShopList.Add(new WorkShopModel { WorkShopName = "车间3" , WorkingCount = 1, StopCount = 8, WaitingCount = 5, ErrorCount = 4});
            WorkShopList.Add(new WorkShopModel { WorkShopName = "车间4" , WorkingCount = 15, StopCount = 6, WaitingCount = 1, ErrorCount = 7});
            WorkShopList.Add(new WorkShopModel { WorkShopName = "车间5" , WorkingCount = 16, StopCount = 0, WaitingCount = 9, ErrorCount = 3});
            #endregion

            InitializeTimer();
    }
    #endregion
}

#region 比较器
/// <summary>
/// StuffOutOfWork 比较器，需要传入 StuffOutOfWork 实例
/// </summary>
public class StuffOutOfWorkComparer : IComparer<StuffOutOfWorkModel>
{
    public int Compare(StuffOutOfWorkModel x, StuffOutOfWorkModel y)
    {
        if (x.OutOfWorkCount != y.OutOfWorkCount)
        {
            return x.OutOfWorkCount.CompareTo(y.OutOfWorkCount);
        }
        else
        {
            return x.StuffName.CompareTo(y.StuffName);
        }
    }
}
    #endregion
}