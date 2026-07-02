namespace Presentacion.frmConsultor
{
    partial class frmReporteIngresos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartIngresos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnVolver = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // chartIngresos
            // 
            chartArea4.Name = "ChartArea1";
            this.chartIngresos.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartIngresos.Legends.Add(legend4);
            this.chartIngresos.Location = new System.Drawing.Point(80, 25);
            this.chartIngresos.Name = "chartIngresos";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartIngresos.Series.Add(series4);
            this.chartIngresos.Size = new System.Drawing.Size(594, 300);
            this.chartIngresos.TabIndex = 0;
            this.chartIngresos.Text = "chart1";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(578, 383);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // frmReporteIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.chartIngresos);
            this.Name = "frmReporteIngresos";
            this.Text = "frmReporteIngresos";
            this.Load += new System.EventHandler(this.frmReporteIngresos_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresos;
        private System.Windows.Forms.Button btnVolver;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}