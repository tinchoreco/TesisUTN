
namespace ClienteFacturaRecibo.View
{
    partial class FormEliminarFactura
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.rbidCliente = new System.Windows.Forms.RadioButton();
            this.rbID = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dGVEliminarFactura = new System.Windows.Forms.DataGridView();
            this.Cerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEliminarFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Buscar);
            this.groupBox1.Controls.Add(this.rbidCliente);
            this.groupBox1.Controls.Add(this.rbID);
            this.groupBox1.Controls.Add(this.txtBuscar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 166);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Facturas";
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(163, 116);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 30);
            this.Buscar.TabIndex = 3;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
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
            // dGVEliminarFactura
            // 
            this.dGVEliminarFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEliminarFactura.Location = new System.Drawing.Point(32, 188);
            this.dGVEliminarFactura.Name = "dGVEliminarFactura";
            this.dGVEliminarFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVEliminarFactura.Size = new System.Drawing.Size(736, 246);
            this.dGVEliminarFactura.TabIndex = 5;
            this.dGVEliminarFactura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVEliminarFactura_CellContentClick);
            // 
            // Cerrar
            // 
            this.Cerrar.Image = global::ClienteFacturaRecibo.Properties.Resources.volver;
            this.Cerrar.Location = new System.Drawing.Point(633, 16);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(135, 83);
            this.Cerrar.TabIndex = 7;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // FormEliminarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGVEliminarFactura);
            this.Name = "FormEliminarFactura";
            this.Text = "Eliminar Factura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEliminarFactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.RadioButton rbidCliente;
        private System.Windows.Forms.RadioButton rbID;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dGVEliminarFactura;
    }
}