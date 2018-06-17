using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateXingyun28
{
    public partial class MainForm : Form
    {
        private BackgroundWorker backgroundWorker1;
       private string rb_type="BJKL8";
        public MainForm()
        {
            InitializeComponent();
            backgroundWorker1 = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
            backgroundWorker1.DoWork += Dowork;
            backgroundWorker1.ProgressChanged += ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += RunWorkerCompleted;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.label1.Text = "";
                //todo 取消执行的操作
            }
            else if (e.Error != null)
            {
                this.label1.Text = "";
                //todo 发生错误时执行的操作
            }
            else
            {
                this.label1.Text = "";
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.Text = e.ProgressPercentage.ToString();
            this.label1.Text = e.UserState.ToString(); // 更新进度显示出来
        }

        // 执行任务
        private void Dowork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.WorkerReportsProgress = true;

            if (rb_type == "BJKL8")
            {
                UpdataDb updataDb = new UpdataDb();
                updataDb.SaveWithBJKL8("pceggs.db", new DateTime(2011, 1, 1), worker);
            }
            if (rb_type == "PK10")
            {
                UpdataDb updataDb = new UpdataDb();
                updataDb.SaveWithPK10("pceggs.db", new DateTime(2011, 1, 1), worker);
            }

        }
        // 查询按钮
        private void bt_search_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UpdateXingyun28 updateXingyun28 = new UpdateXingyun28();
            // 获得数据
            List<string> l=updateXingyun28.search(rb_type);
            // 添加进去
            listBox1.Items.AddRange(l.ToArray());
        }

        private void rb_bjkl8_CheckedChanged(object sender, EventArgs e)
        {
            rb_type = "BJKL8";
        }

        private void rb_pk10_CheckedChanged(object sender, EventArgs e)
        {
            rb_type = "PK10";
        }

        private void rb_jnd28_CheckedChanged(object sender, EventArgs e)
        {
            rb_type = "JNDKL8";
        }
        // 更新按钮
        private void bt_update_Click(object sender, EventArgs e)
        {
            //GetInitialData getInitialData = new GetInitialData();
            //getInitialData.getPK10(new DateTime(2018, 5, 1));
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            //if (rb_type == "BJKL8")
            //{
            //    UpdataDb updataDb = new UpdataDb();
            //    updataDb.SaveWithBJKL8("pceggs.db", new DateTime(2011, 1, 1));
            //}

        }
        // 测试
        private void button1_Click(object sender, EventArgs e)
        {
            GetInitialData getInitialData = new GetInitialData();
            getInitialData.getBJKL8_by168kai(new DateTime(2018, 5, 1));
        }
    }
}
