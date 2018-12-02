namespace MainProject.Views.SubViews
{
    partial class ucResultPage
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChooseType = new System.Windows.Forms.Button();
            this.btnSaveSummaryType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1920, 1080);
            this.splitContainer1.SplitterDistance = 1280;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Controls.Add(this.btnChooseType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSummaryType, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85715F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.85715F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 1080);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnChooseType
            // 
            this.btnChooseType.BackColor = System.Drawing.Color.Aquamarine;
            this.btnChooseType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChooseType.Font = new System.Drawing.Font("AR JULIAN", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseType.Location = new System.Drawing.Point(67, 328);
            this.btnChooseType.Name = "btnChooseType";
            this.btnChooseType.Size = new System.Drawing.Size(502, 154);
            this.btnChooseType.TabIndex = 0;
            this.btnChooseType.Text = "Choose\r\nSummary\r\nType";
            this.btnChooseType.UseVisualStyleBackColor = false;
            this.btnChooseType.Click += new System.EventHandler(this.btnChooseType_Click);
            // 
            // btnSaveSummaryType
            // 
            this.btnSaveSummaryType.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSaveSummaryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveSummaryType.Font = new System.Drawing.Font("AR JULIAN", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveSummaryType.Location = new System.Drawing.Point(67, 596);
            this.btnSaveSummaryType.Name = "btnSaveSummaryType";
            this.btnSaveSummaryType.Size = new System.Drawing.Size(502, 154);
            this.btnSaveSummaryType.TabIndex = 0;
            this.btnSaveSummaryType.Text = "Save\r\nSummary";
            this.btnSaveSummaryType.UseVisualStyleBackColor = false;
            this.btnSaveSummaryType.Click += new System.EventHandler(this.btnSaveSummaryType_Click);
            // 
            // ucResultPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "ucResultPage";
            this.Size = new System.Drawing.Size(1920, 1080);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnChooseType;
        private System.Windows.Forms.Button btnSaveSummaryType;
    }
}
