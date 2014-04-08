namespace BloombergCalculateVWAPMoneyFlow
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbVolume = new System.Windows.Forms.TextBox();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tbVWAP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chtPrices = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAppStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chtPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(19, 34);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(100, 20);
            this.tbSymbol.TabIndex = 0;
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(135, 34);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(87, 20);
            this.tbPrice.TabIndex = 0;
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(245, 34);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(87, 20);
            this.tbVolume.TabIndex = 0;
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(16, 18);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(41, 13);
            this.lblSymbol.TabIndex = 1;
            this.lblSymbol.Text = "Symbol";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(132, 18);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Price";
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(253, 18);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(42, 13);
            this.lblVolume.TabIndex = 1;
            this.lblVolume.Text = "Volume";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(19, 72);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(125, 72);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbVWAP
            // 
            this.tbVWAP.Location = new System.Drawing.Point(347, 34);
            this.tbVWAP.Name = "tbVWAP";
            this.tbVWAP.Size = new System.Drawing.Size(100, 20);
            this.tbVWAP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VWAP";
            // 
            // chtPrices
            // 
            chartArea1.AxisX.Minimum = 1D;
            chartArea1.Name = "ChartArea1";
            this.chtPrices.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chtPrices.Legends.Add(legend1);
            this.chtPrices.Location = new System.Drawing.Point(19, 101);
            this.chtPrices.Name = "chtPrices";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Prices";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "VWAP";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "PriceUpColor=RED";
            series3.Legend = "Legend1";
            series3.Name = "SumMF";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chtPrices.Series.Add(series1);
            this.chtPrices.Series.Add(series2);
            this.chtPrices.Series.Add(series3);
            this.chtPrices.Size = new System.Drawing.Size(428, 236);
            this.chtPrices.TabIndex = 3;
            this.chtPrices.Text = "3";
            // 
            // lblAppStatus
            // 
            this.lblAppStatus.AutoSize = true;
            this.lblAppStatus.Location = new System.Drawing.Point(225, 77);
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(0, 13);
            this.lblAppStatus.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 349);
            this.Controls.Add(this.lblAppStatus);
            this.Controls.Add(this.chtPrices);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblSymbol);
            this.Controls.Add(this.tbVWAP);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbSymbol);
            this.Name = "Form1";
            this.Text = "VWAP and Money Flow";
            ((System.ComponentModel.ISupportInitialize)(this.chtPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbVolume;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox tbVWAP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtPrices;
        private System.Windows.Forms.Label lblAppStatus;
    }
}

