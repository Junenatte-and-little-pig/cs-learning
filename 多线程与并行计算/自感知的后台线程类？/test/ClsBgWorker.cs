using System;
using System.ComponentModel;
using System.Windows.Forms;

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
        private Form Frm { get; set; }

        public delegate void CompleteHandler(bool cancel, WorkResult result);   //提供一类相似方法的模板
        public delegate void MessageHandler(int id, string msg);
        public event CompleteHandler Complete;  //提供一定模板下的方法供具体实现
        public event MessageHandler SendMessage;
        public ClsBgWorker(WorkRange wr,Form frm) {
            Range = wr;
            Frm = frm;
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
                //在拥有控件的基础窗口句柄的线程上，用指定的自变量列表执行指定委托
                try {
                    Frm.Invoke(SendMessage, Range.id, sum.ToString() + '\t' + k.ToString());
                } catch (Exception) {
                    return;
                }
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