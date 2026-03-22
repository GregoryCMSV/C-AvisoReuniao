using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace GeradorAvisoReuniao
{
    public partial class GeradorAviso : Form
    {

        private List<string> locais;
        private ContextMenuStrip menuRemoverAssunto;

        public GeradorAviso()
        {
            InitializeComponent();
            locais = new List<string>();

            menuRemoverAssunto = new ContextMenuStrip();
            var itemRemover = menuRemoverAssunto.Items.Add("Remover Assunto");
            itemRemover.Click += RemoverAssunto_Click;
        }

        private void GeradorAviso_Load(object sender, EventArgs e)
        {
            SetLocals();
        }

        private void SetLocals()
        {
            try
            {
                cmbLocais.DataSource = null;
                locais = Utils.GetLocalsFromFile();
                locais.Add("Adicionar novo...");
                cmbLocais.DataSource = locais;
            }
            catch
            {
                cmbLocais.DataSource = new List<string>() { "Erro ao carregar os locais" };
            }
        }
        private void CmbLocais_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbLocais.SelectedItem == null) return;
            if (cmbLocais.SelectedItem.ToString() != "Adicionar novo...") return;

            using (FrmNovoLocal frm = new())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string novoLocal = frm.LocalDigitado;
                    if (!string.IsNullOrWhiteSpace(novoLocal))
                    {
                        Utils.AddNewLocal(novoLocal);
                        SetLocals();
                        cmbLocais.SelectedItem = novoLocal;
                    }
                    else
                    {
                        cmbLocais.SelectedIndex = 0;
                    }
                }
            }
        }

        private void RemoverAssunto_Click(object? sender, EventArgs e)
        {
            if (menuRemoverAssunto.SourceControl is TextBox txtParaRemover)
            {
                flpAssuntos.Controls.Remove(txtParaRemover);
                txtParaRemover.Dispose();
            }
        }


        #region Controlando flp
        private void BtnNovoAssunto_Click(object sender, EventArgs e)
        {
            var newTxtBox = Utils.CreateSubjectTextBox(flpAssuntos.Controls.Count);
            UpdateSubjectSize(newTxtBox);
            newTxtBox.MouseWheel += ScrollToPainel;
            newTxtBox.ContextMenuStrip = menuRemoverAssunto;
            flpAssuntos.Controls.Add(newTxtBox);
            newTxtBox.Focus();
        }

        private void ScrollToPainel(object sender, MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs handledArgs)
            {
                handledArgs.Handled = true;
            }
            int posicaoAtualY = Math.Abs(flpAssuntos.AutoScrollPosition.Y);
            int novaPosicaoY = posicaoAtualY - e.Delta;
            flpAssuntos.AutoScrollPosition = new Point(0, novaPosicaoY);
        }

        private void FlpAssuntos_SizeChanged(object sender, EventArgs e)
        {
            UpdateSubjectSize();
        }

        private void UpdateSubjectSize()
        {
            foreach (var t in flpAssuntos.Controls)
            {
                if (t is TextBox)
                {
                    UpdateSubjectSize((TextBox)t);
                }
            }
        }

        private void UpdateSubjectSize(TextBox txtSubject)
        {
            txtSubject.Size = new Size(flpAssuntos.ClientSize.Width - 25, txtSubject.Size.Height);
        }
        #endregion

        private void DtpPriChamada_ValueChanged(object sender, EventArgs e)
        {
            var primeiraChamada = dtpPriChamada.Value;
            dtpSegChamada.Value = primeiraChamada.AddMinutes(30);
        }

        private void BtnGerarAviso_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "ModeloAviso.docx");
            string pastaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pastaAvisos = Path.Combine(pastaDocumentos, "Avisos");

            if (!Directory.Exists(pastaAvisos))
            {
                Directory.CreateDirectory(pastaAvisos);
            }
            string dataSelecionada = dtpData.Value.ToString("dd-MM-yyyy");
            string caminhoFinal = Path.Combine(pastaAvisos, $"AvisoReuniao-{dataSelecionada}.docx");

            try
            {
                File.Copy(templatePath, caminhoFinal, true);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(caminhoFinal, true))
                {
                    var body = wordDoc.MainDocumentPart.Document.Body;
                    var paragrafoAssuntos = body.Descendants<Paragraph>().FirstOrDefault(p => p.InnerText.Contains("{{Assuntos}}"));

                    if (paragrafoAssuntos != null)
                    {
                        foreach (System.Windows.Forms.Control controle in flpAssuntos.Controls)
                        {
                            if (controle is TextBox txtAssunto && !string.IsNullOrWhiteSpace(txtAssunto.Text))
                            {
                                Paragraph novoParagrafo = (Paragraph)paragrafoAssuntos.CloneNode(true);
                                novoParagrafo.RemoveAllChildren<Run>();

                                Run novaRun = new Run();

                                var formatacaoOriginal = paragrafoAssuntos.Elements<Run>().FirstOrDefault()?.RunProperties;
                                if (formatacaoOriginal != null)
                                {
                                    novaRun.Append((RunProperties)formatacaoOriginal.CloneNode(true));
                                }

                                string[] linhas = txtAssunto.Text.Trim().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                                for (int i = 0; i < linhas.Length; i++)
                                {
                                    if (i > 0) novaRun.Append(new Break());

                                    novaRun.Append(new Text(linhas[i]) { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });
                                }

                                novoParagrafo.Append(novaRun);

                                paragrafoAssuntos.Parent.InsertBefore(novoParagrafo, paragrafoAssuntos);
                            }
                        }
                        paragrafoAssuntos.Remove();
                    }

                    foreach (var p in body.Descendants<Paragraph>().ToList())
                    {
                        if (p.InnerText.Contains("{{"))
                        {
                            string textoCompleto = p.InnerText;
                            textoCompleto = textoCompleto.Replace("{{Data}}", dtpData.Value.ToString("dd/MM/yyyy"));

                            if (cmbLocais.SelectedItem != null)
                                textoCompleto = textoCompleto.Replace("{{Local}}", cmbLocais.SelectedItem.ToString());

                            textoCompleto = textoCompleto.Replace("{{PriChamada}}", dtpPriChamada.Value.ToString("HH:mm"));
                            textoCompleto = textoCompleto.Replace("{{SegChamada}}", dtpSegChamada.Value.ToString("HH:mm"));

                            var formatacao = p.Elements<Run>().FirstOrDefault()?.RunProperties?.CloneNode(true);

                            p.RemoveAllChildren<Run>();

                            Run novaRun = new Run(new Text(textoCompleto) { Space = DocumentFormat.OpenXml.SpaceProcessingModeValues.Preserve });

                            if (formatacao != null)
                            {
                                novaRun.PrependChild(formatacao);
                            }

                            p.Append(novaRun);
                        }
                    }

                    wordDoc.MainDocumentPart.Document.Save();
                }

                DialogResult resposta = MessageBox.Show(
                    "Aviso de reunião gerado com sucesso!\n\nDeseja abrir o arquivo agora?",
                    "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resposta == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = caminhoFinal,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao gerar o arquivo:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
