/* Made by TheDarkJoker94. 
*  Check http://thedarkjoker094.blogspot.com/ for more C# Tutorials 
*  and also SUBSCRIBE to my Youtube Channel http://www.youtube.com/user/TheDarkJoker094 
*  Thanks! */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using PdfSharp.Charting;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace OpenWriteFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void chooseFolder(TextBox textBox)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void btnOutput_Click(object sender, EventArgs e)
        {
            chooseFolder(txtOutput);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            chooseFolder(txtInput);
        }

        private void btnNameChange_Click(object sender, EventArgs e)
        {
            DirectoryInfo nameComeFrom = new DirectoryInfo(this.txtInput.Text);
            DirectoryInfo toChange = new DirectoryInfo(this.txtOutput.Text);

            string[] allFilesComeFromFolder;
            int[] prefix;

            int anzahl = 0;
            int i = 0;
            allFilesComeFromFolder = new string[nameComeFrom.GetFiles().Count()];

            prefix = new int[nameComeFrom.GetFiles().Count()];
            foreach (var fi in nameComeFrom.GetFiles())
            {
                allFilesComeFromFolder[i] = fi.Name;
                prefix[i] = Convert.ToInt32(allFilesComeFromFolder[i].Substring(0, 5));
                i++;
            }
            string oldfilename = "";
            string toChangeFileNumber;
            string newfilename = "";
            PdfSharp.Pdf.PdfDocument one;
            PdfSharp.Pdf.PdfDocument two;
            foreach (var fi in toChange.GetFiles())
            {
                toChangeFileNumber = fi.Name.Substring(fi.Name.IndexOf(" "), fi.Name.IndexOf(".") - fi.Name.IndexOf(" "));
                if (SuchenNachDemDateiMitGleicherNummer(allFilesComeFromFolder.Length, prefix, Convert.ToInt32(toChangeFileNumber)) == -1)
                {
                    oldfilename = toChange.ToString() + "\\" + fi.Name;
                    newfilename = toChange.ToString() + "\\" + fi.Name.Substring(0, fi.Name.IndexOf(" ") + 1) +
                                    Convert.ToString(Convert.ToInt32(toChangeFileNumber) - 1) +
                                    fi.Name.Substring(fi.Name.IndexOf("."), fi.Name.Length - fi.Name.IndexOf("."));

                    one = PdfSharp.Pdf.IO.PdfReader.Open(newfilename, PdfDocumentOpenMode.Import);
                    two = PdfSharp.Pdf.IO.PdfReader.Open(oldfilename, PdfDocumentOpenMode.Import);
                    CopyPages(two, one);
                    one.Save(newfilename);
                    one.Close();
                    two.Close();
                    fi.Delete();
                }
            }
            foreach (var fi in toChange.GetFiles())
            {
                toChangeFileNumber = fi.Name.Substring(fi.Name.IndexOf(" "), fi.Name.IndexOf(".") - fi.Name.IndexOf(" "));
                oldfilename = toChange.ToString() + "\\" + fi.Name;
                newfilename = toChange.ToString() + "\\" + allFilesComeFromFolder[SuchenNachDemDateiMitGleicherNummer(allFilesComeFromFolder.Length, prefix, Convert.ToInt32(toChangeFileNumber))];
                System.IO.File.Move(oldfilename, newfilename);
            }
            if (MessageBox.Show("Die Namen sind schon geändert", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private int SuchenNachDemDateiMitGleicherNummer(int GesamtDateienAnzahl, int[] prefix, int toChangeFileNumber)
        {
            for (int j = 0; j < GesamtDateienAnzahl; j++)
            {
                if (prefix[j] == toChangeFileNumber)
                {
                    return j;
                }
            }
            return -1;
        }

        private void CopyPages(PdfSharp.Pdf.PdfDocument from, PdfSharp.Pdf.PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }

        private void MoveAllPdfsToOneDict_Click(object sender, EventArgs e)
        {
            var allFilesInDict = Directory.GetFiles(txtInput.Text, "*.*", SearchOption.AllDirectories)
                                           .Where(s => s.EndsWith(".pdf"));
            string fileName;
            int prefixNumber = 0;
            int pages;
            foreach (string file in allFilesInDict)
            {
                pages = GetPages(file);
                fileName = Path.GetFileName(file);

                if (pages > 1)
                {
                    prefixNumber ++;
                    int firstPrefixNumber= prefixNumber;
                    int lastPrefixNumber = prefixNumber + pages - 1;
                    fileName = firstPrefixNumber.ToString("D" + 5) + "-" + lastPrefixNumber.ToString("D" + 5) + "_" + fileName;
                }
                else
                {
                    prefixNumber++;
                    fileName = prefixNumber.ToString("D" + 5) + "_" + fileName;
                }
                File.Copy(file, txtOutput.Text + "\\" + fileName, true);
            }
            if (MessageBox.Show("Alle Zeichnungen werden in diesen Ordner verschoben", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private int GetPages(string ppath)
        {
            iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(ppath);
            int numberOfPages = pdfReader.NumberOfPages;
            Console.WriteLine(numberOfPages);
            //Console.ReadLine();
            return numberOfPages;
        }

        private void ZeichnungenAusDemOrdnerZiehen_Click(object sender, EventArgs e)
        {
            var allfilesInFromFolder = System.IO.Directory.GetFiles(txtInput.Text + "\\", "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf"));
            var allfilesInToFolder = System.IO.Directory.GetFiles(txtOutput.Text, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf"));
            Boolean gefunden = false;
            string fileName;
            int i = 0;
            string j;
            int seitenAnzahl;
            foreach (string fileInToFolder in allfilesInToFolder)
            {
                gefunden = false;
                //seitenAnzahl = GetPages(file.ToString());
                //Console.WriteLine(file.ToString());
                foreach (string fileInFromFolder in allfilesInFromFolder)
                {
                    fileName = Path.GetFileName(fileInFromFolder).Substring(Path.GetFileName(fileInFromFolder).IndexOf("_") + 1, fileInFromFolder.Length - fileInFromFolder.IndexOf("_") - 1);
                    if (Path.GetFileName(fileInToFolder).Equals(fileName))
                    {
                        System.IO.File.Move(fileInFromFolder, Path.GetDirectoryName(fileInFromFolder) + "\\" + fileName);
                        System.IO.File.Copy(txtInput.Text + "\\" + fileName, fileInToFolder, true);
                        gefunden = true;
                    }
                }
                if (gefunden == false)
                {
                    MessageBox.Show(fileInToFolder + "nicht gefunden, das Programm wird abgebrochen", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
                }
            }
            if (MessageBox.Show("Alle Zeichnungen werden in diesen Ordner verschoben", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Mergen_Click(object sender, EventArgs e)
        {
            PdfSharp.Pdf.PdfDocument onePdf;
            PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument();
            DirectoryInfo toChange = new DirectoryInfo(this.txtOutput.Text);
            foreach (var fi in toChange.GetFiles().OrderBy(fi => fi.Name))
            {
                onePdf = PdfSharp.Pdf.IO.PdfReader.Open(fi.FullName, PdfDocumentOpenMode.Import);
                CopyPages(onePdf, outPdf);
                onePdf.Close();
                //fi.Delete();
            }
            outPdf.Save(this.txtOutput.Text+"\\"+"TomTomMerge.pdf");
            outPdf.Close();
            if (MessageBox.Show("Alle Zeichnungen werden in TomTomMerge.pdf zusammengefügt", "My Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
