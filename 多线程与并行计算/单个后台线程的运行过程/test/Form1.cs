using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        struct WorkRange {
            public int nStart;
            public int nEnd;
        }
        private void btnStart_Click(object sender, EventArgs e) {
            WorkRange wr = new WorkRange { nStart = 100, nEnd = 1000000 };
            bgWork.RunWorkerAsync(wr); //开始执行后台操作
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            //先把BackgroundWorker的WorkerSupportsCancellation改为true
            //或者添加判断
            //if (!bgWork.WorkerSupportsCancellation)
            //    bgWork.WorkerSupportsCancellation = true;
            bgWork.CancelAsync();   //请求取消的挂起的后台操作
        }

        private void bgWork_DoWork(object sender, DoWorkEventArgs e) {
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
            e.Result = sum;
        }

        private void bgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled)
                txtResult.Text = "canceled";
            else
                txtResult.Text = e.Result.ToString();
        }
    }
}
