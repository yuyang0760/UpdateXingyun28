namespace UpdateXingyun28
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bt_update = new System.Windows.Forms.Button();
            this.rb_bjkl8 = new System.Windows.Forms.RadioButton();
            this.rb_pk10 = new System.Windows.Forms.RadioButton();
            this.rb_jnd28 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_search = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_update
            // 
            this.bt_update.Location = new System.Drawing.Point(21, 125);
            this.bt_update.Name = "bt_update";
            this.bt_update.Size = new System.Drawing.Size(100, 35);
            this.bt_update.TabIndex = 0;
            this.bt_update.Text = "更新";
            this.bt_update.UseVisualStyleBackColor = true;
            this.bt_update.Click += new System.EventHandler(this.bt_update_Click);
            // 
            // rb_bjkl8
            // 
            this.rb_bjkl8.AutoSize = true;
            this.rb_bjkl8.Checked = true;
            this.rb_bjkl8.Location = new System.Drawing.Point(21, 36);
            this.rb_bjkl8.Name = "rb_bjkl8";
            this.rb_bjkl8.Size = new System.Drawing.Size(77, 16);
            this.rb_bjkl8.TabIndex = 1;
            this.rb_bjkl8.TabStop = true;
            this.rb_bjkl8.Tag = "BJKL8";
            this.rb_bjkl8.Text = "北京快乐8";
            this.rb_bjkl8.UseVisualStyleBackColor = true;
            this.rb_bjkl8.CheckedChanged += new System.EventHandler(this.rb_bjkl8_CheckedChanged);
            // 
            // rb_pk10
            // 
            this.rb_pk10.AutoSize = true;
            this.rb_pk10.Location = new System.Drawing.Point(21, 58);
            this.rb_pk10.Name = "rb_pk10";
            this.rb_pk10.Size = new System.Drawing.Size(47, 16);
            this.rb_pk10.TabIndex = 2;
            this.rb_pk10.TabStop = true;
            this.rb_pk10.Tag = "PK10";
            this.rb_pk10.Text = "pk10";
            this.rb_pk10.UseVisualStyleBackColor = true;
            this.rb_pk10.CheckedChanged += new System.EventHandler(this.rb_pk10_CheckedChanged);
            // 
            // rb_jnd28
            // 
            this.rb_jnd28.AutoSize = true;
            this.rb_jnd28.Enabled = false;
            this.rb_jnd28.Location = new System.Drawing.Point(21, 80);
            this.rb_jnd28.Name = "rb_jnd28";
            this.rb_jnd28.Size = new System.Drawing.Size(119, 16);
            this.rb_jnd28.TabIndex = 3;
            this.rb_jnd28.TabStop = true;
            this.rb_jnd28.Tag = "JNDKL8";
            this.rb_jnd28.Text = "加拿大28(未更新)";
            this.rb_jnd28.UseVisualStyleBackColor = true;
            this.rb_jnd28.CheckedChanged += new System.EventHandler(this.rb_jnd28_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bt_search);
            this.groupBox1.Controls.Add(this.rb_bjkl8);
            this.groupBox1.Controls.Add(this.bt_update);
            this.groupBox1.Controls.Add(this.rb_jnd28);
            this.groupBox1.Controls.Add(this.rb_pk10);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 220);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "更新";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 5;
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(21, 166);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(100, 35);
            this.bt_search.TabIndex = 4;
            this.bt_search.Text = "查询";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(180, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(190, 220);
            this.listBox1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 248);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新幸运28";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_update;
        private System.Windows.Forms.RadioButton rb_bjkl8;
        private System.Windows.Forms.RadioButton rb_pk10;
        private System.Windows.Forms.RadioButton rb_jnd28;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

