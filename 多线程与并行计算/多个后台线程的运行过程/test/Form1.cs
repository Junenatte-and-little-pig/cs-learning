using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        struct WorkRange {
            public int id;
            public int nStart;
            public int nEnd;
        }
        struct WorkResult {
            public int id;
            public int result;
        }
        private BackgroundWorker bgWork;
        private void btnStart_Click(object sender, EventArgs e) {
            bgWork = new BackgroundWorker();
            bgWork.DoWork += new DoWorkEventHandler(DoWork);
            bgWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            WorkRange wr = new WorkRange();
            if ((Button)sender == btnStart1) {
                wr.id = 1;
                wr.nStart = 100;
                wr.nEnd = 100000;
            }else if ((Button)sender == btnStart2) {
                wr.id = 2;
                wr.nStart = 500;
                wr.nEnd = 200000;
            }
            bgWork.RunWorkerAsync(wr); //开始执行后台操作
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            //先把BackgroundWorker的WorkerSupportsCancellation改为true
            //或者添加判断
            if (!bgWork.WorkerSupportsCancellation)
                bgWork.WorkerSupportsCancellation = true;
            bgWork.CancelAsync();   //请求取消的挂起的后台操作
        }

        private void DoWork(object sender, DoWorkEventArgs e) {
            WorkRange wr = (WorkRange)e.Argument;
            int sum = 0;
            for(int k = 0; k < 1000; k++) {
                if(bgWork.CancellationPending) {    //指示应用程序是否已请求取消后台操作
                    e.Cancel = true;
                    return;
                }
                for (int i = wr.nStart; i < wr.nEnd; i++)
                    sum += i;
            }
            WorkResult result = new WorkResult();
            result.id = wr.id;
            result.result = sum;
            e.Result = result;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled)
                txtResult1.Text = "canceled";
            else {
                WorkResult result = (WorkResult)e.Result;
                if (result.id == 1)
                    txtResult1.Text = result.result.ToString();
                else if (result.id == 2)
                    txtResult2.Text = result.result.ToString();
            }
        }
    }
}
