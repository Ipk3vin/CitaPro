namespace Presentacion.frmConsultor
{
    partial class frmReportesConsultor
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
            this.btnReporteCitas = new System.Windows.Forms.Button();
            this.btnClienteFrecuentes = new System.Windows.Forms.Button();
            this.btnGraficosIngresos = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReporteCitas
            // 
            this.btnReporteCitas.Location = new System.Drawing.Point(193, 72);
            this.btnReporteCitas.Name = "btnReporteCitas";
            this.btnReporteCitas.Size = new System.Drawing.Size(280, 63);
            this.btnReporteCitas.TabIndex = 0;
            this.btnReporteCitas.Text = "Reporte Citas";
            this.btnReporteCitas.UseVisualStyleBackColor = true;
            this.btnReporteCitas.Click += new System.EventHandler(this.btnReporteCitas_Click);
            // 
            // btnClienteFrecuentes
            // 
            this.btnClienteFrecuentes.Location = new System.Drawing.Point(193, 141);
            this.btnClienteFrecuentes.Name = "btnClienteFrecuentes";
            this.btnClienteFrecuentes.Size = new System.Drawing.Size(280, 63);
            this.btnClienteFrecuentes.TabIndex = 1;
            this.btnClienteFrecuentes.Text = "Clientes Frecuentes";
            this.btnClienteFrecuentes.UseVisualStyleBackColor = true;
            this.btnClienteFrecuentes.Click += new System.EventHandler(this.btnClienteFrecuentes_Click);
            // 
            // btnGraficosIngresos
            // 
            this.btnGraficosIngresos.Location = new System.Drawing.Point(193, 211);
            this.btnGraficosIngresos.Name = "btnGraficosIngresos";
            this.btnGraficosIngresos.Size = new System.Drawing.Size(280, 63);
            this.btnGraficosIngresos.TabIndex = 2;
            this.btnGraficosIngresos.Text = "Graficos de Ingresos";
            this.btnGraficosIngresos.UseVisualStyleBackColor = true;
            this.btnGraficosIngresos.Click += new System.EventHandler(this.btnGraficosIngresos_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(193, 280);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(280, 63);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // frmReportesConsultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGraficosIngresos);
            this.Controls.Add(this.btnClienteFrecuentes);
            this.Controls.Add(this.btnReporteCitas);
            this.Name = "frmReportesConsultor";
            this.Text = "frmReportesConsultor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReporteCitas;
        private System.Windows.Forms.Button btnClienteFrecuentes;
        private System.Windows.Forms.Button btnGraficosIngresos;
        private System.Windows.Forms.Button btnVolver;
    }
}