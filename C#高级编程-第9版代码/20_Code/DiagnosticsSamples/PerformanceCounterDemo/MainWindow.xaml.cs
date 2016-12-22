using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.Generic;

namespace PerformanceCounterDemo
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    // Performance monitoring counter values
    private int clickCountPerSec = 0;
    private int mouseMoveCountPerSec = 0;

    private PerformanceCounter performanceCounterButtonClicks;
    private PerformanceCounter performanceCounterButtonClicksPerSec;
    private PerformanceCounter performanceCounterMouseMoveEvents;
    private PerformanceCounter performanceCounterMouseMoveEventsPerSec;



    private const string perfomanceCounterCategoryName = "Wrox Performance Counters";
    private string instanceName = "PerformanceCounterDemo";
    private SortedList<string, Tuple<string, string>> perfCountNames;

    private DispatcherTimer timer;


    public MainWindow()
    {
      InitializeComponent();
      InitializePerfomanceCountNames();
      InitializePerformanceCounters();
      if (PerformanceCounterCategory.Exists(perfomanceCounterCategoryName))
      {
        buttonCount.IsEnabled = true;
        timer = new DispatcherTimer(TimeSpan.FromSeconds(1),
            DispatcherPriority.Background,
            delegate
            {
              this.performanceCounterButtonClicksPerSec.RawValue = this.clickCountPerSec;
              this.clickCountPerSec = 0;
              this.performanceCounterMouseMoveEventsPerSec.RawValue = this.mouseMoveCountPerSec;
              this.mouseMoveCountPerSec = 0;
            },
            Dispatcher.CurrentDispatcher);
        timer.Start();
      }
    }

    private void InitializePerfomanceCountNames()
    {
      perfCountNames = new SortedList<string, Tuple<string, string>>();
      perfCountNames.Add("clickCount", Tuple.Create("# of button Clicks", "Total # of button clicks"));
      perfCountNames.Add("clickSec", Tuple.Create("# of button clicks/sec", "# of mouse button clicks in one second"));
      perfCountNames.Add("mouseCount", Tuple.Create("# of mouse move events", "Total # of mouse move events"));
      perfCountNames.Add("mouseSec", Tuple.Create("# of mouse move events/sec", "# of mouse move events in one second"));
    }

    private void InitializePerformanceCounters()
    {
      performanceCounterButtonClicks = new PerformanceCounter
      {
        CategoryName = perfomanceCounterCategoryName,
        CounterName = perfCountNames["clickCount"].Item1,
        ReadOnly = false,
        MachineName = ".",
        InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
        InstanceName = this.instanceName
      };
      performanceCounterButtonClicksPerSec = new PerformanceCounter
      {
        CategoryName = perfomanceCounterCategoryName,
        CounterName = perfCountNames["clickSec"].Item1,
        ReadOnly = false,
        MachineName = ".",
        InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
        InstanceName = this.instanceName
      };
      performanceCounterMouseMoveEvents = new PerformanceCounter
      {
        CategoryName = perfomanceCounterCategoryName,
        CounterName = perfCountNames["mouseCount"].Item1,
        ReadOnly = false,
        MachineName = ".",
        InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
        InstanceName = this.instanceName
      };
      performanceCounterMouseMoveEventsPerSec = new PerformanceCounter
      {
        CategoryName = perfomanceCounterCategoryName,
        CounterName = perfCountNames["mouseSec"].Item1,
        ReadOnly = false,
        MachineName = ".",
        InstanceLifetime = PerformanceCounterInstanceLifetime.Process,
        InstanceName = this.instanceName
      };
    }

    private void OnButtonClick(object sender, RoutedEventArgs e)
    {
      this.performanceCounterButtonClicks.Increment();
      this.clickCountPerSec++;
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {

      this.performanceCounterMouseMoveEvents.Increment();
      this.mouseMoveCountPerSec++;
    }

    private void OnRegisterCounts(object sender, RoutedEventArgs e)
    {
      if (!PerformanceCounterCategory.Exists(perfomanceCounterCategoryName))
      {

        var counterCreationData = new CounterCreationData[4];
        counterCreationData[0] = new CounterCreationData
        {
          CounterName = perfCountNames["clickCount"].Item1,
          CounterType = PerformanceCounterType.NumberOfItems32,
          CounterHelp = perfCountNames["clickCount"].Item2
        };
        counterCreationData[1] = new CounterCreationData
        {
          CounterName = perfCountNames["clickSec"].Item1,
          CounterType = PerformanceCounterType.RateOfCountsPerSecond32,
          CounterHelp = perfCountNames["clickSec"].Item2,
        };
        counterCreationData[2] = new CounterCreationData
        {
          CounterName = perfCountNames["mouseCount"].Item1,
          CounterType = PerformanceCounterType.NumberOfItems32,
          CounterHelp = perfCountNames["mouseCount"].Item2,
        };
        counterCreationData[3] = new CounterCreationData
        {
          CounterName = perfCountNames["mouseSec"].Item1,
          CounterType = PerformanceCounterType.RateOfCountsPerSecond32,
          CounterHelp = perfCountNames["mouseSec"].Item2,
        };
        var counters =
            new CounterCreationDataCollection(counterCreationData);

        var category = PerformanceCounterCategory.Create(perfomanceCounterCategoryName,
            "Sample Counters for Professional C#",
            PerformanceCounterCategoryType.MultiInstance,
            counters);

        MessageBox.Show(String.Format("category {0} successfully created", category.CategoryName));

      }

    }
  }
}
