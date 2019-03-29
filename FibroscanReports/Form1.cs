using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using Microsoft.Win32;

namespace FibroscanReports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileAssociations.EnsureAssociationsSet();
        }

        public Form1(string file)
        {
            InitializeComponent();
            FileAssociations.EnsureAssociationsSet();
            using (ZipArchive archive = ZipFile.OpenRead(file))
            {
                var info = archive.GetEntry("ExamReport.xml");
                if (info != null)
                {
                    using (var zipEntryStream = info.Open())
                    {
                        XDocument xDocument = XDocument.Load(zipEntryStream);
                        string name = string.Empty;
                        if (xDocument.Root.Element("Patient").Element("Lastname") != null) name = name + xDocument.Root.Element("Patient").Element("Lastname").Value;
                        if (xDocument.Root.Element("Patient").Element("Firstname") != null) name = name + " " + xDocument.Root.Element("Patient").Element("Firstname").Value;
                        if (name == string.Empty) name = $"Unknown";
                        var pdf = archive.GetEntry("Report.pdf");
                        if (pdf != null)
                        {
                            using (var pdfstream = pdf.Open())
                            {
                                saveFileDialog1.FileName = saveFileDialog1.InitialDirectory + name + ".pdf";
                                DialogResult save = saveFileDialog1.ShowDialog();
                                if (save == DialogResult.OK)
                                {
                                    using (FileStream output = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                                    {
                                        try { pdfstream.CopyTo(output); outputLog.AppendText($"\nСоздан файл {saveFileDialog1.FileName}"); }
                                        catch (Exception ex) { outputLog.AppendText($"\nОшибка обработки файла {file}: {ex.Message}"); }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ChoiseDirButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folderName = folderBrowserDialog1.SelectedPath;
                {
                    int files = 0;
                    foreach (var file in Directory.EnumerateFiles(folderName, "*.fibx"))
                    {
                        using (ZipArchive archive = ZipFile.OpenRead(file))
                        {
                            var info = archive.GetEntry("ExamReport.xml");
                            if (info != null)
                            {
                                using (var zipEntryStream = info.Open())
                                {
                                    XDocument xDocument = XDocument.Load(zipEntryStream);
                                    string name = string.Empty;
                                    if (xDocument.Root.Element("Patient").Element("Lastname") != null) name = name + xDocument.Root.Element("Patient").Element("Lastname").Value;
                                    if (xDocument.Root.Element("Patient").Element("Firstname") != null) name = name + " " + xDocument.Root.Element("Patient").Element("Firstname").Value;
                                    if (name == string.Empty) name = $"Unknown {files}";
                                    var pdf = archive.GetEntry("Report.pdf");
                                    if (pdf != null)
                                    {
                                        using (var pdfstream = pdf.Open())
                                        {
                                            string f = folderName + @"/" + name + ".pdf";
                                            using (FileStream output = new FileStream(f, FileMode.Create))
                                            {
                                                try { pdfstream.CopyTo(output); files++; outputLog.AppendText($"\nСоздан файл {f}"); }
                                                catch (Exception ex) { outputLog.AppendText($"\nОшибка обработки файла {file}: {ex.Message}"); }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show($"Обработано {files} файлов.");
                    System.Diagnostics.Process.Start("explorer.exe", folderName);
                }
            }
            else return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                using (ZipArchive archive = ZipFile.OpenRead(file))
                {
                    var info = archive.GetEntry("ExamReport.xml");
                    if (info != null)
                    {
                        using (var zipEntryStream = info.Open())
                        {
                            XDocument xDocument = XDocument.Load(zipEntryStream);
                            string name = string.Empty;
                            if (xDocument.Root.Element("Patient").Element("Lastname") != null) name = name + xDocument.Root.Element("Patient").Element("Lastname").Value;
                            if (xDocument.Root.Element("Patient").Element("Firstname") != null) name = name + " " + xDocument.Root.Element("Patient").Element("Firstname").Value;
                            if (name == string.Empty) name = $"Unknown";
                            var pdf = archive.GetEntry("Report.pdf");
                            if (pdf != null)
                            {
                                using (var pdfstream = pdf.Open())
                                {
                                    saveFileDialog1.FileName = saveFileDialog1.InitialDirectory + name + ".pdf";
                                    DialogResult save = saveFileDialog1.ShowDialog();
                                    if (save == DialogResult.OK)
                                    {
                                        using (FileStream output = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                                        {
                                            try { pdfstream.CopyTo(output); outputLog.AppendText($"\nСоздан файл {saveFileDialog1.FileName}"); }
                                            catch (Exception ex) { outputLog.AppendText($"\nОшибка обработки файла {file}: {ex.Message}"); }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public class FileAssociation
        {
            public string Extension { get; set; }
            public string ProgId { get; set; }
            public string FileTypeDescription { get; set; }
            public string ExecutableFilePath { get; set; }
        }

        public class FileAssociations
        {
            // needed so that Explorer windows get refreshed after the registry is updated
            [System.Runtime.InteropServices.DllImport("Shell32.dll")]
            private static extern int SHChangeNotify(int eventId, int flags, IntPtr item1, IntPtr item2);

            private const int SHCNE_ASSOCCHANGED = 0x8000000;
            private const int SHCNF_FLUSH = 0x1000;

            public static void EnsureAssociationsSet()
            {
                var filePath = Process.GetCurrentProcess().MainModule.FileName;
                EnsureAssociationsSet(
                    new FileAssociation
                    {
                        Extension = ".fibx",
                        ProgId = "FibroscanReport",
                        FileTypeDescription = "Fibroscan report File",
                        ExecutableFilePath = filePath
                    });
            }

            public static void EnsureAssociationsSet(params FileAssociation[] associations)
            {
                bool madeChanges = false;
                foreach (var association in associations)
                {
                    madeChanges |= SetAssociation(
                        association.Extension,
                        association.ProgId,
                        association.FileTypeDescription,
                        association.ExecutableFilePath);
                }

                if (madeChanges)
                {
                    SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_FLUSH, IntPtr.Zero, IntPtr.Zero);
                }
            }

            public static bool SetAssociation(string extension, string progId, string fileTypeDescription, string applicationFilePath)
            {
                bool madeChanges = false;
                madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + extension, progId);
                madeChanges |= SetKeyDefaultValue(@"Software\Classes\" + progId, fileTypeDescription);
                madeChanges |= SetKeyDefaultValue($@"Software\Classes\{progId}\shell\open\command", "\"" + applicationFilePath + "\" \"%1\"");
                return madeChanges;
            }

            private static bool SetKeyDefaultValue(string keyPath, string value)
            {
                using (var key = Registry.CurrentUser.CreateSubKey(keyPath))
                {
                    if (key.GetValue(null) as string != value)
                    {
                        key.SetValue(null, value);
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
