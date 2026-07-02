namespace Presentacion
{
    partial class frmReportes
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
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.cboConsultor = new System.Windows.Forms.ComboBox();
            this.cboSeleccionarReporte = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(473, 77);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(100, 24);
            this.cboEstado.TabIndex = 11;
            // 
            // dgvReportes
            // 
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportes.Location = new System.Drawing.Point(54, 236);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.RowHeadersWidth = 51;
            this.dgvReportes.RowTemplate.Height = 24;
            this.dgvReportes.Size = new System.Drawing.Size(927, 248);
            this.dgvReportes.TabIndex = 10;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(54, 133);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(151, 23);
            this.btnGenerarReporte.TabIndex = 9;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // cboRubro
            // 
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(335, 77);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(89, 24);
            this.cboRubro.TabIndex = 8;
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(313, 28);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 22);
            this.dtpFin.TabIndex = 7;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(54, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(200, 22);
            this.dtpInicio.TabIndex = 6;
            // 
            // cboConsultor
            // 
            this.cboConsultor.FormattingEnabled = true;
            this.cboConsultor.Location = new System.Drawing.Point(621, 77);
            this.cboConsultor.Name = "cboConsultor";
            this.cboConsultor.Size = new System.Drawing.Size(100, 24);
            this.cboConsultor.TabIndex = 12;
            // 
            // cboSeleccionarReporte
            // 
            this.cboSeleccionarReporte.FormattingEnabled = true;
            this.cboSeleccionarReporte.Location = new System.Drawing.Point(54, 77);
            this.cboSeleccionarReporte.Name = "cboSeleccionarReporte";
            this.cboSeleccionarReporte.Size = new System.Drawing.Size(275, 24);
            this.cboSeleccionarReporte.TabIndex = 13;
            this.cboSeleccionarReporte.SelectedIndexChanged += new System.EventHandler(this.cboSeleccionarReporte_SelectedIndexChanged_1);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 517);
            this.Controls.Add(this.cboSeleccionarReporte);
            this.Controls.Add(this.cboConsultor);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.dtpInicio);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.ComboBox cboConsultor;
        private System.Windows.Forms.ComboBox cboSeleccionarReporte;
    }
}