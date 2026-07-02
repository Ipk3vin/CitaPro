namespace Presentacion
{
    partial class frmMenuAdministrador
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
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnHabilitarEditarEliminar = new System.Windows.Forms.Button();
            this.btnRegistrarConsultor = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Menu de Administracion";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(152, 453);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(333, 43);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.Location = new System.Drawing.Point(152, 258);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(333, 43);
            this.btnReportes.TabIndex = 7;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnHabilitarEditarEliminar
            // 
            this.btnHabilitarEditarEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitarEditarEliminar.Location = new System.Drawing.Point(152, 182);
            this.btnHabilitarEditarEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHabilitarEditarEliminar.Name = "btnHabilitarEditarEliminar";
            this.btnHabilitarEditarEliminar.Size = new System.Drawing.Size(333, 69);
            this.btnHabilitarEditarEliminar.TabIndex = 6;
            this.btnHabilitarEditarEliminar.Text = "Habilitar, editar y eliminar consultor";
            this.btnHabilitarEditarEliminar.Click += new System.EventHandler(this.btn_HabilitarEditarEliminar_Click);
            // 
            // btnRegistrarConsultor
            // 
            this.btnRegistrarConsultor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarConsultor.Location = new System.Drawing.Point(152, 132);
            this.btnRegistrarConsultor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegistrarConsultor.Name = "btnRegistrarConsultor";
            this.btnRegistrarConsultor.Size = new System.Drawing.Size(333, 43);
            this.btnRegistrarConsultor.TabIndex = 5;
            this.btnRegistrarConsultor.Text = "Registrar Consultor";
            this.btnRegistrarConsultor.Click += new System.EventHandler(this.btn_RegistrarConsultor_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(152, 309);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "Auditoria";
            this.button1.Click += new System.EventHandler(this.btn_Auditoria_Click);
            // 
            // frmMenuAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 511);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnHabilitarEditarEliminar);
            this.Controls.Add(this.btnRegistrarConsultor);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMenuAdministrador";
            this.Text = "frmMenuAdministrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnHabilitarEditarEliminar;
        private System.Windows.Forms.Button btnRegistrarConsultor;
        private System.Windows.Forms.Button button1;
    }
}