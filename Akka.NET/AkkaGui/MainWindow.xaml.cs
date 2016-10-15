using Akka.Common;
using DataProcessor.Akka;
using DataProcessor.Akka.Actors;
using DataProcessor.Serial;
using PixelLab.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AkkaGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DataProcessorBase> _runningProcesses = new List<DataProcessorBase>();
        Queue<int> _runningTasks = new Queue<int>();
        private readonly TileCollection _tiles = new TileCollection();
        public static readonly DependencyProperty PanelProperty =
        DependencyProperty.Register("Panel", typeof(AnimatingTilePanel), typeof(MainWindow));

        public AnimatingTilePanel Panel
        {
            get
            {
                return (AnimatingTilePanel)GetValue(PanelProperty);
            }
            set
            {
                SetValue(PanelProperty, value);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            this.LayoutUpdated += delegate (object sender, EventArgs e)
            {
                if (Panel == null)
                {
                    Panel = m_itemsControl.FirstVisualDescendentOfType<AnimatingTilePanel>();
                }
            };

            m_itemsControl.ItemsSource = _tiles;


            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    int count = ProcessDataActor.InstanceCount;
                    Dispatcher.Invoke(() =>
                    {
                        actorCountLbl.Content = count;
                    });
                    Thread.Sleep(500);
                }
            });

        }


        

        private void AddTiles(int count)
        {
            _tiles.Clear();
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(1);
                this.Dispatcher.Invoke(() =>
                {
                    _tiles.Add(ProcessingColors.IdleBrush);
                });
            }
        }

        private void ResetTiles()
        {
            actorCountLbl.Content = 0;
            foreach (var item in _tiles)
            {
                item.Color = ProcessingColors.IDLE;
            }
        }



        private void StartTask1_Click(object sender, RoutedEventArgs e)
        {
            StartProcess(new DataProcessorSerial(failCbx.IsChecked.Value));
        }

        private void StartTask2_Click(object sender, RoutedEventArgs e)
        {
            StartProcess(new DataProcessorParallelForeach(failCbx.IsChecked.Value));
        }

        private void StartTask4_Click(object sender, RoutedEventArgs e)
        {
            StartProcess(new AkkaProcessorSingleActor(failCbx.IsChecked.Value));
        }

        private DataProcessorBase _poolProcessor;
        private void StartTask5_Click(object sender, RoutedEventArgs e)
        {

            int poolSize = int.Parse(poolSizeTb.Text);
            StartProcess(new AkkaProcessorPoolRouter(poolSize, failCbx.IsChecked.Value));
            
        }

        private void StartTask6_Click(object sender, RoutedEventArgs e)
        {
            //_poolProcessor.StartMessages();
        }

        private void StartProcess(DataProcessorBase processor)
        {
            processor.StatusChanged += StatusChanged;
            processor.Completed += Completed;
            processor.Start(_tiles.Count);
            _runningProcesses.Add(processor);
            //return processor;
        }


       

        public void UpdateTaskStatus(int index, ProcessStatus status)
        {
            Color col = status.ToColor();

            try
            {
                Dispatcher.Invoke(() =>
                   {
                       _tiles[index].Color = col;
                   });
            }
            catch (Exception)
            {
            }
        }

        private void ShowProgress(string txt, bool isFailed = false)
        {
            string msg;
            if(isFailed)
            {
                msg = "ABORTED!!! (Duration: " + txt + ")";
            }
            else
            {
                msg = "Completed in: " + txt;
            }

            Dispatcher.Invoke(() =>
            {
                MessageBox.Show(msg);
            });
        }

       

        private void StatusChanged(object o, DataProcessorEventArgs arg2)
        {
            UpdateTaskStatus(arg2.TaskId, arg2.Status);
        }

        private void Completed(object arg1, CompletedEventArgs arg2)
        {
            ShowProgress(arg2.Duration.ToString(), arg2.Failed);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddTiles(int.Parse(itemCountTb.Text));
        }

        private void StartNext_Click(object sender, RoutedEventArgs e)
        {
            var tile = _tiles.FirstOrDefault(t => t.Color != ProcessingColors.COMPLETED &&
                t.Color != ProcessingColors.RUNNING);
            if (tile != null)
            {
                var index = _tiles.IndexOf(tile);
                UpdateTaskStatus(index, ProcessStatus.Running);
                _runningTasks.Enqueue(index);
            }
        }

        private void StopCurrent_Click(object sender, RoutedEventArgs e)
        {
            if (_runningTasks.Count > 0)
            {
                var index = _runningTasks.Dequeue();
                UpdateTaskStatus(index, ProcessStatus.Completed);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddTiles(int.Parse(itemCountTb.Text));
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _runningProcesses)
            {
                item.Stop();
            }
            ResetTiles();
        }

        private void StopProcessing_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _runningProcesses)
            {
                item.Stop();
            }
        }

        
    }
}
