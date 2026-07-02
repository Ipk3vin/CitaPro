namespace Presentacion.frmConsultor
{
    partial class frmReporteCitas
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.lblCitasMes = new System.Windows.Forms.Label();
            this.lblCitasHoy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(152, 237);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(180, 40);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click_1);
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.AutoSize = true;
            this.lblTotalCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCitas.Location = new System.Drawing.Point(372, 167);
            this.lblTotalCitas.Name = "lblTotalCitas";
            this.lblTotalCitas.Size = new System.Drawing.Size(24, 25);
            this.lblTotalCitas.TabIndex = 12;
            this.lblTotalCitas.Text = "0";
            this.lblTotalCitas.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCitasMes
            // 
            this.lblCitasMes.AutoSize = true;
            this.lblCitasMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasMes.Location = new System.Drawing.Point(372, 107);
            this.lblCitasMes.Name = "lblCitasMes";
            this.lblCitasMes.Size = new System.Drawing.Size(24, 25);
            this.lblCitasMes.TabIndex = 11;
            this.lblCitasMes.Text = "0";
            this.lblCitasMes.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCitasHoy
            // 
            this.lblCitasHoy.AutoSize = true;
            this.lblCitasHoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCitasHoy.Location = new System.Drawing.Point(372, 47);
            this.lblCitasHoy.Name = "lblCitasHoy";
            this.lblCitasHoy.Size = new System.Drawing.Size(24, 25);
            this.lblCitasHoy.TabIndex = 10;
            this.lblCitasHoy.Text = "0";
            this.lblCitasHoy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total de citas atendidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Citas atendidas durante este mes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Citas atendidas hoy";
            // 
            // frmReporteCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 327);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTotalCitas);
            this.Controls.Add(this.lblCitasMes);
            this.Controls.Add(this.lblCitasHoy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmReporteCitas";
            this.Text = "frmReporteCitas";
            this.Load += new System.EventHandler(this.frmReporteCitas_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblCitasMes;
        private System.Windows.Forms.Label lblCitasHoy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}