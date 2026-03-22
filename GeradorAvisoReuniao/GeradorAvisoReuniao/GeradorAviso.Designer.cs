namespace GeradorAvisoReuniao
{
    partial class GeradorAviso
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblData = new Label();
            lblSegChamada = new Label();
            lblPriChamada = new Label();
            dtpData = new DateTimePicker();
            dtpPriChamada = new DateTimePicker();
            dtpSegChamada = new DateTimePicker();
            flpAssuntos = new FlowLayoutPanel();
            btnNovoAssunto = new Button();
            lblLocal = new Label();
            cmbLocais = new ComboBox();
            btnGerarAviso = new Button();
            SuspendLayout();
            // 
            // lblData
            // 
            lblData.Font = new Font("Segoe UI", 14F);
            lblData.Location = new Point(30, 15);
            lblData.Name = "lblData";
            lblData.Size = new Size(120, 33);
            lblData.TabIndex = 0;
            lblData.Text = "Data:";
            lblData.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSegChamada
            // 
            lblSegChamada.Font = new Font("Segoe UI", 14F);
            lblSegChamada.Location = new Point(30, 165);
            lblSegChamada.Name = "lblSegChamada";
            lblSegChamada.Size = new Size(118, 33);
            lblSegChamada.TabIndex = 1;
            lblSegChamada.Text = "2ª Chamada:";
            lblSegChamada.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPriChamada
            // 
            lblPriChamada.Font = new Font("Segoe UI", 14F);
            lblPriChamada.Location = new Point(30, 115);
            lblPriChamada.Name = "lblPriChamada";
            lblPriChamada.Size = new Size(118, 33);
            lblPriChamada.TabIndex = 2;
            lblPriChamada.Text = "1ª Chamada:";
            lblPriChamada.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpData
            // 
            dtpData.Font = new Font("Segoe UI", 14.25F);
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(154, 15);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(267, 33);
            dtpData.TabIndex = 1;
            // 
            // dtpPriChamada
            // 
            dtpPriChamada.CustomFormat = "HH:mm";
            dtpPriChamada.Font = new Font("Segoe UI", 14.25F);
            dtpPriChamada.Format = DateTimePickerFormat.Custom;
            dtpPriChamada.Location = new Point(154, 115);
            dtpPriChamada.Name = "dtpPriChamada";
            dtpPriChamada.ShowUpDown = true;
            dtpPriChamada.Size = new Size(267, 33);
            dtpPriChamada.TabIndex = 3;
            dtpPriChamada.ValueChanged += DtpPriChamada_ValueChanged;
            // 
            // dtpSegChamada
            // 
            dtpSegChamada.CustomFormat = "HH:mm";
            dtpSegChamada.Font = new Font("Segoe UI", 14.25F);
            dtpSegChamada.Format = DateTimePickerFormat.Custom;
            dtpSegChamada.Location = new Point(154, 165);
            dtpSegChamada.Name = "dtpSegChamada";
            dtpSegChamada.ShowUpDown = true;
            dtpSegChamada.Size = new Size(267, 33);
            dtpSegChamada.TabIndex = 4;
            // 
            // flpAssuntos
            // 
            flpAssuntos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpAssuntos.AutoScroll = true;
            flpAssuntos.Location = new Point(0, 261);
            flpAssuntos.Name = "flpAssuntos";
            flpAssuntos.Padding = new Padding(10, 0, 10, 0);
            flpAssuntos.Size = new Size(784, 300);
            flpAssuntos.TabIndex = 5;
            flpAssuntos.SizeChanged += FlpAssuntos_SizeChanged;
            // 
            // btnNovoAssunto
            // 
            btnNovoAssunto.AutoSize = true;
            btnNovoAssunto.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNovoAssunto.Location = new Point(12, 220);
            btnNovoAssunto.Name = "btnNovoAssunto";
            btnNovoAssunto.Size = new Size(203, 35);
            btnNovoAssunto.TabIndex = 5;
            btnNovoAssunto.Text = "Adicionar assunto (+)";
            btnNovoAssunto.UseVisualStyleBackColor = true;
            btnNovoAssunto.Click += BtnNovoAssunto_Click;
            // 
            // lblLocal
            // 
            lblLocal.Font = new Font("Segoe UI", 14F);
            lblLocal.Location = new Point(30, 65);
            lblLocal.Name = "lblLocal";
            lblLocal.Size = new Size(118, 33);
            lblLocal.TabIndex = 8;
            lblLocal.Text = "Local:";
            lblLocal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbLocais
            // 
            cmbLocais.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbLocais.FormattingEnabled = true;
            cmbLocais.Location = new Point(154, 65);
            cmbLocais.Name = "cmbLocais";
            cmbLocais.Size = new Size(267, 33);
            cmbLocais.TabIndex = 2;
            cmbLocais.SelectedValueChanged += CmbLocais_SelectedValueChanged;
            // 
            // btnGerarAviso
            // 
            btnGerarAviso.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGerarAviso.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGerarAviso.Location = new Point(654, 15);
            btnGerarAviso.Name = "btnGerarAviso";
            btnGerarAviso.Size = new Size(118, 39);
            btnGerarAviso.TabIndex = 0;
            btnGerarAviso.Text = "Gerar Aviso";
            btnGerarAviso.UseVisualStyleBackColor = true;
            btnGerarAviso.Click += BtnGerarAviso_Click;
            // 
            // GeradorAviso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnGerarAviso);
            Controls.Add(btnNovoAssunto);
            Controls.Add(cmbLocais);
            Controls.Add(lblLocal);
            Controls.Add(flpAssuntos);
            Controls.Add(dtpSegChamada);
            Controls.Add(dtpPriChamada);
            Controls.Add(dtpData);
            Controls.Add(lblPriChamada);
            Controls.Add(lblSegChamada);
            Controls.Add(lblData);
            MinimumSize = new Size(800, 600);
            Name = "GeradorAviso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador: Avisos de reuniões";
            Load += GeradorAviso_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblData;
        private Label lblSegChamada;
        private Label lblPriChamada;
        private DateTimePicker dtpData;
        private DateTimePicker dtpPriChamada;
        private DateTimePicker dtpSegChamada;
        private FlowLayoutPanel flpAssuntos;
        private Label lblLocal;
        private ComboBox cmbLocais;
        private Button btnNovoAssunto;
        private Button btnGerarAviso;
    }
}
