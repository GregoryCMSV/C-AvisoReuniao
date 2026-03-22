using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorAvisoReuniao
{
    public static class Utils
    {
        private static readonly string localsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "Locais.txt");

        public static TextBox CreateSubjectTextBox(int id)
        {
            TextBox txtSubject = new TextBox();
            txtSubject.Name = $"txtSubject_{id}";
            txtSubject.Multiline = true ;
            txtSubject.Font = new Font(txtSubject.Font.FontFamily, 14);
            txtSubject.Size = new Size(txtSubject.Width, 150);

            return txtSubject;
        }

        public static List<string> GetLocalsFromFile()
        {
            List<string> locals = new List<string>();
            if (File.Exists(localsPath))
            {
                locals = File.ReadAllLines(localsPath).ToList();
            }
            return locals.OrderBy(x => x).ToList();
        }

        public static void AddNewLocal(string novoLocal)
        {
            var currentLocals = GetLocalsFromFile();
            if (!currentLocals.Contains(novoLocal))
            {
                currentLocals.Add(novoLocal);
                currentLocals = currentLocals.OrderBy(x => x).ToList();
                File.WriteAllLines(localsPath, currentLocals);
            }
        }

    }
}
