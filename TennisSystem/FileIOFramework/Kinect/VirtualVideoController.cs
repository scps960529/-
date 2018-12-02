using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SystemFramework.Kinect;

namespace FileIOFramework.Kinect
{
    public class VirtualVideoController
    {
        //Auto-Implemented Properties  C#自動實作特性
        public string FolderPath { get; private set; }

        public string FileName { get; private set; }
        //C# 裡 List用法:  http://mermerism.blogspot.tw/2014/04/c-list.html
        private List<string> _fileNameList = new List<string>();
        //List 就是不用宣告長度的陣列(Array)

        public int FileCount { get { return _fileNameList.Count; } }

        private int _frameRate;
        public int FrameRate
        {
            get { return _frameRate; }
            set
            {
                _frameRate = value;
                Interval = 1000 / _frameRate; //取33毫秒
            }
        }

        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
            }
        }

        public FrameInfo Frame { get; private set; }

        public event EventHandler RefreshEventHandler;
        //首先在VirtualVideoController這個class宣告一個 EventHandler
        //給ReadForm 這個class做使用
        private AutoResetEvent _stopEvent = new AutoResetEvent(false);
        private ManualResetEvent _pauseEvent = new ManualResetEvent(false);

        private Task _grabbingTask;

        //建構式中指定framerate可調整撥放速度
        public VirtualVideoController()
        {
            FrameRate = 30;//物件被建立時就賦予FrameRate  30的值
        }

        public void Live()
        {
            _pauseEvent.Set();
            OnGrabbing();
        }

        public void Live(string path)
        {
            _fileNameList.Clear();
            //[Missing code] find all RAWD file
            // [Sample] _fileNameList.Add(A)
            // [Sample] _fileNameList.Add(B)
            FolderPath = path;//將外部獲得的目錄字串傳給FolderPath做處理
            DirectoryInfo di = new DirectoryInfo(FolderPath);//DirectoryInfo取得目錄資訊
            FileInfo[] files = di.GetFiles("*.RawD");//過濾副檔名為.RawD的檔案
            DateTime[] creationTimes = new DateTime[files.Length];
            //創建一個DateTime陣列,Array的大小跟file的總數一樣
            for (int i = 0; i < files.Length; i++)
                creationTimes[i] = files[i].CreationTime;//將每個檔案的產生時間點存放到DateTime陣列中

            Array.Sort(creationTimes, files);//根據時間做檔案排序
            //根據第一個Array中的索引，排序一對 一維陣列中的檔案
            foreach (var file in files)
            {
                _fileNameList.Add(file.Name.Split('.')[0]);//將選到的目錄下所有檔案加到List中
            }

            Live();
        }

        public void Stop()
        {
            _pauseEvent.Set();
            _stopEvent.Set();
        }

        public void Pause()
        {
            _pauseEvent.Reset();
        }

        private void OnGrabbing()
        {
            if (_grabbingTask != null) return;//一次只有一個資料進來
            
            _grabbingTask = Task.Factory.StartNew(() =>
            {
                int index = 0;
                try
                {
                    do
                    {
                        _pauseEvent.WaitOne();
                        if (index < FileCount)
                        {
                            FileName = _fileNameList[index];
                            Frame = ReadFromFileHelper.Read(FolderPath, FileName);
                            if (RefreshEventHandler != null)
                                RefreshEventHandler(this, EventArgs.Empty);

                            Thread.Sleep(Interval);
                            index++; // 下一frame 的添加
                        }
                        else
                        {
                            _stopEvent.Set();
                        }
                    } while (_stopEvent.WaitOne(0) == false);
                }
                finally
                {
                    _grabbingTask = null;
                }
            });
        }
    }
}
