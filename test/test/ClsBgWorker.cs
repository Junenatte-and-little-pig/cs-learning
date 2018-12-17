using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test {
    struct WorkRange {
        public int id;
        public int nStart;
        public int nEnd;
    }
    struct WorkResult {
        public int id;
        public int result;
    }
    class ClsBgWorker {
        public BackgroundWorker BgWorker { get; set; }
        private WorkRange Range { get; set; }

        public delegate void CompleteHandler(bool cancel, WorkResult result);   //提供一类相似方法的模板
        public event CompleteHandler Complete;  //提供一定模板下的方法供具体实现

        public ClsBgWorker(WorkRange wr) {
            Range = wr;
            BgWorker = new BackgroundWorker();
            BgWorker.WorkerSupportsCancellation = true;
            BgWorker.DoWork += new DoWorkEventHandler(DoWork);
            BgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
        }
        public void Run() {
            BgWorker.RunWorkerAsync(Range);
        }
        public void Cancel() {
            BgWorker.CancelAsync();
        }
        private void DoWork(object sender, DoWorkEventArgs e) {
            int sum = 0;
            for (int k = 0; k < 1000; k++) {
                if (BgWorker.CancellationPending) {    //指示应用程序是否已请求取消后台操作
                    e.Cancel = true;
                    return;
                }
                for (int i = Range.nStart; i < Range.nEnd; i++)
                    sum += i;
            }
            WorkResult result = new WorkResult {
                id = Range.id,
                result = sum
            };
            e.Result = result;
        }
        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            WorkResult result = (WorkResult)e.Result;
            Complete(e.Cancelled, result);
        }
    }
}