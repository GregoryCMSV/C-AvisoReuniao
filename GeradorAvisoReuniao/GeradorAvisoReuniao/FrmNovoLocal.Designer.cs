namespace GeradorAvisoReuniao
{
    partial class FrmNovoLocal
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
            this.lblLocal = new Label();
            txtLocal = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Font = new Font("Segoe UI", 14F);
            this.lblLocal.Location = new Point(12, 9);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new Size(254, 25);
            this.lblLocal.TabIndex = 0;
            this.lblLocal.Text = "Digite o nome do novo local:";
            // 
            // txtLocal
            // 
            txtLocal.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLocal.Location = new Point(12, 37);
            txtLocal.Name = "txtLocal";
            txtLocal.Size = new Size(350, 33);
            txtLocal.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Font = new Font("Segoe UI", 14.25F);
            btnOk.Location = new Point(12, 87);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(108, 43);
            btnOk.TabIndex = 2;
            btnOk.Text = "Salvar";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 14.25F);
            btnCancel.Location = new Point(254, 87);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(108, 43);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmNovoLocal
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(377, 140);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtLocal);
            Controls.Add(this.lblLocal);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmNovoLocal";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Novo Local";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLocal;
        private TextBox txtLocal;
        private Button btnOk;
        private Button btnCancel;
    }
}