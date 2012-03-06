namespace KalmanCS
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSourceSigma = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxMeasuredSigma = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonSquareWave = new System.Windows.Forms.RadioButton();
            this.radioButtonSineWave = new System.Windows.Forms.RadioButton();
            this.radioButtonRandomWalk = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(12, 12);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Received";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Lime;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Filtered";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Actual";
            this.chartMain.Series.Add(series1);
            this.chartMain.Series.Add(series2);
            this.chartMain.Series.Add(series3);
            this.chartMain.Size = new System.Drawing.Size(714, 463);
            this.chartMain.TabIndex = 0;
            this.chartMain.Text = "chart1";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(732, 224);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(112, 39);
            this.buttonRefresh.TabIndex = 1;
            this.buttonRefresh.Text = "Regenerate";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxSourceSigma);
            this.groupBox1.Location = new System.Drawing.Point(732, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Sigma";
            // 
            // textBoxSourceSigma
            // 
            this.textBoxSourceSigma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceSigma.Location = new System.Drawing.Point(7, 20);
            this.textBoxSourceSigma.Name = "textBoxSourceSigma";
            this.textBoxSourceSigma.Size = new System.Drawing.Size(99, 20);
            this.textBoxSourceSigma.TabIndex = 0;
            this.textBoxSourceSigma.Text = "0.01";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.textBoxMeasuredSigma);
            this.groupBox2.Location = new System.Drawing.Point(732, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 51);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measured Sigma";
            // 
            // textBoxMeasuredSigma
            // 
            this.textBoxMeasuredSigma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMeasuredSigma.Location = new System.Drawing.Point(7, 20);
            this.textBoxMeasuredSigma.Name = "textBoxMeasuredSigma";
            this.textBoxMeasuredSigma.Size = new System.Drawing.Size(99, 20);
            this.textBoxMeasuredSigma.TabIndex = 0;
            this.textBoxMeasuredSigma.Text = "0.4";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radioButtonSquareWave);
            this.groupBox3.Controls.Add(this.radioButtonSineWave);
            this.groupBox3.Controls.Add(this.radioButtonRandomWalk);
            this.groupBox3.Location = new System.Drawing.Point(732, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 92);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Signal Type";
            // 
            // radioButtonSquareWave
            // 
            this.radioButtonSquareWave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSquareWave.AutoSize = true;
            this.radioButtonSquareWave.Location = new System.Drawing.Point(6, 67);
            this.radioButtonSquareWave.Name = "radioButtonSquareWave";
            this.radioButtonSquareWave.Size = new System.Drawing.Size(91, 17);
            this.radioButtonSquareWave.TabIndex = 2;
            this.radioButtonSquareWave.Text = "Square Wave";
            this.radioButtonSquareWave.UseVisualStyleBackColor = true;
            this.radioButtonSquareWave.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // radioButtonSineWave
            // 
            this.radioButtonSineWave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonSineWave.AutoSize = true;
            this.radioButtonSineWave.Location = new System.Drawing.Point(7, 44);
            this.radioButtonSineWave.Name = "radioButtonSineWave";
            this.radioButtonSineWave.Size = new System.Drawing.Size(78, 17);
            this.radioButtonSineWave.TabIndex = 1;
            this.radioButtonSineWave.Text = "Sine Wave";
            this.radioButtonSineWave.UseVisualStyleBackColor = true;
            this.radioButtonSineWave.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // radioButtonRandomWalk
            // 
            this.radioButtonRandomWalk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonRandomWalk.AutoSize = true;
            this.radioButtonRandomWalk.Checked = true;
            this.radioButtonRandomWalk.Location = new System.Drawing.Point(7, 20);
            this.radioButtonRandomWalk.Name = "radioButtonRandomWalk";
            this.radioButtonRandomWalk.Size = new System.Drawing.Size(93, 17);
            this.radioButtonRandomWalk.TabIndex = 0;
            this.radioButtonRandomWalk.TabStop = true;
            this.radioButtonRandomWalk.Text = "Random Walk";
            this.radioButtonRandomWalk.UseVisualStyleBackColor = true;
            this.radioButtonRandomWalk.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 487);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.chartMain);
            this.Name = "FormMain";
            this.Text = "Kalman Filter";
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSourceSigma;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMeasuredSigma;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonSquareWave;
        private System.Windows.Forms.RadioButton radioButtonSineWave;
        private System.Windows.Forms.RadioButton radioButtonRandomWalk;
    }
}

