namespace Presentacion
{
    partial class frmMenuConsultor
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnModificarContrasena = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnConsultarCitas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Menu de Consultor";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(188, 279);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(365, 38);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnModificarContrasena
            // 
            this.btnModificarContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarContrasena.Location = new System.Drawing.Point(188, 233);
            this.btnModificarContrasena.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificarContrasena.Name = "btnModificarContrasena";
            this.btnModificarContrasena.Size = new System.Drawing.Size(365, 38);
            this.btnModificarContrasena.TabIndex = 24;
            this.btnModificarContrasena.Text = "Modificar contrasena";
            this.btnModificarContrasena.UseVisualStyleBackColor = true;
            this.btnModificarContrasena.Click += new System.EventHandler(this.btnModificarContrasena_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(188, 188);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(365, 38);
            this.btnReportes.TabIndex = 21;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnConsultarCitas
            // 
            this.btnConsultarCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarCitas.Location = new System.Drawing.Point(188, 142);
            this.btnConsultarCitas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConsultarCitas.Name = "btnConsultarCitas";
            this.btnConsultarCitas.Size = new System.Drawing.Size(365, 39);
            this.btnConsultarCitas.TabIndex = 20;
            this.btnConsultarCitas.Text = "Consultar Citas";
            this.btnConsultarCitas.UseVisualStyleBackColor = true;
            this.btnConsultarCitas.Click += new System.EventHandler(this.btnConsultarCitas_Click);
            // 
            // frmMenuConsultor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificarContrasena);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnConsultarCitas);
            this.Name = "frmMenuConsultor";
            this.Text = "frmMenuConsultor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnModificarContrasena;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnConsultarCitas;
    }
}