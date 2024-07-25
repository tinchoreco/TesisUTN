
namespace ClienteFacturaRecibo.View
{
    partial class FormEliminarRecibo
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
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.rbidCliente = new System.Windows.Forms.RadioButton();
            this.rbID = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.Cerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGVEliminarRecibo = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEliminarRecibo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(163, 116);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 30);
            this.btn_Buscar.TabIndex = 3;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // rbidCliente
            // 
            this.rbidCliente.AutoSize = true;
            this.rbidCliente.Location = new System.Drawing.Point(202, 35);
            this.rbidCliente.Name = "rbidCliente";
            this.rbidCliente.Size = new System.Drawing.Size(169, 24);
            this.rbidCliente.TabIndex = 2;
            this.rbidCliente.TabStop = true;
            this.rbidCliente.Text = "Buscar por idCliente";
            this.rbidCliente.UseVisualStyleBackColor = true;
            // 
            // rbID
            // 
            this.rbID.AutoSize = true;
            this.rbID.Location = new System.Drawing.Point(27, 35);
            this.rbID.Name = "rbID";
            this.rbID.Size = new System.Drawing.Size(125, 24);
            this.rbID.TabIndex = 1;
            this.rbID.TabStop = true;
            this.rbID.Text = "Buscar por ID";
            this.rbID.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(27, 75);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(339, 26);
            this.txtBuscar.TabIndex = 0;
            // 
            // Cerrar
            // 
            this.Cerrar.Image = global::ClienteFacturaRecibo.Properties.Resources.volver;
            this.Cerrar.Location = new System.Drawing.Point(633, 16);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(135, 83);
            this.Cerrar.TabIndex = 10;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Buscar);
            this.groupBox1.Controls.Add(this.rbidCliente);
            this.groupBox1.Controls.Add(this.rbID);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Recibo";
            // 
            // dGVEliminarRecibo
            // 
            this.dGVEliminarRecibo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEliminarRecibo.Location = new System.Drawing.Point(32, 188);
            this.dGVEliminarRecibo.Name = "dGVEliminarRecibo";
            this.dGVEliminarRecibo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEliminarRecibo.Size = new System.Drawing.Size(736, 246);
            this.dGVEliminarRecibo.TabIndex = 8;
            this.dGVEliminarRecibo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVEliminarRecibo_CellContentClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(693, 152);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormEliminarRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGVEliminarRecibo);
            this.Name = "FormEliminarRecibo";
            this.Text = "FormEliminarRecibo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEliminarRecibo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.RadioButton rbidCliente;
        private System.Windows.Forms.RadioButton rbID;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVEliminarRecibo;
        private System.Windows.Forms.Button btnEliminar;
    }
}