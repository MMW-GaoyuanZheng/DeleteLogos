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

namespace DeleteLogosInPDFs
{
    public partial class Form1 : Form
    {
        private string pathOfFolderOnDesktop;
        private string pathOfFolderWithAllNumberedPDFs;
        private string pathOfFolderWithMergedPDF;
        private string pathOfFolderWithSplittedPDFs;

        public Form1()
        {
            InitializeComponent();
            EnableOnlyOneButton(btnMoveAllPDFsIntoOneFolder);
        }

        //0
        private void btnFolderWithOriginalPDFs_Click(object sender, EventArgs e)
        {
            chooseFolder(txtFolderWithOriginalDrawings);
            //function
            void chooseFolder(TextBox textBox)
            {
                if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        //1
        private void MoveAllPDFsIntoOneFolder_Click(object sender, EventArgs e)
        {
            var allFilesInOriginalFolder = Directory.GetFiles(txtFolderWithOriginalDrawings.Text, "*.*", SearchOption.AllDirectories)
                                           .Where(s => s.EndsWith(".pdf"));
            string fileName;
            int prefixNumber = 0;
            int pages;
            pathOfFolderOnDesktop = CreateTempDictionaryOnDesktop();
            pathOfFolderWithAllNumberedPDFs = pathOfFolderOnDesktop + "\\1";
            System.IO.Directory.CreateDirectory(pathOfFolderWithAllNumberedPDFs);

            foreach (string file in allFilesInOriginalFolder)
            {
                pages = GetPages(file);
                fileName = Path.GetFileName(file);

                if (pages > 1)
                {
                    prefixNumber++;
                    int firstPrefixNumber = prefixNumber;
                    int lastPrefixNumber = prefixNumber + pages - 1;
                    fileName = firstPrefixNumber.ToString("D" + 5) + "-" + lastPrefixNumber.ToString("D" + 5) + "_" + fileName;
                }
                else
                {
                    prefixNumber++;
                    fileName = prefixNumber.ToString("D" + 5) + "_" + fileName;
                }

                File.Copy(file, pathOfFolderWithAllNumberedPDFs + "\\" + fileName, true);
            }
            MessageBox.Show("Alle Zeichnungen werden in " + pathOfFolderWithAllNumberedPDFs + " verschoben", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Question);
            EnableOnlyOneButton(btnMergenAllPDFsIntoOnePDF);
        }
        //2
        private void MergenAllPDFsIntoOnePDF_Click(object sender, EventArgs e)
        {
            PdfSharp.Pdf.PdfDocument onePdf;
            PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument();
            pathOfFolderWithMergedPDF = pathOfFolderOnDesktop + "\\2";
            System.IO.Directory.CreateDirectory(pathOfFolderWithMergedPDF);

            DirectoryInfo toChange = new DirectoryInfo(pathOfFolderWithAllNumberedPDFs);
            foreach (var fi in toChange.GetFiles().OrderBy(fi => fi.Name))
            {
                onePdf = PdfSharp.Pdf.IO.PdfReader.Open(fi.FullName, PdfDocumentOpenMode.Import);
                CopyPages(onePdf, outPdf);
                onePdf.Close();
                //fi.Delete();
            }
            outPdf.Save(pathOfFolderWithMergedPDF + "\\" + "Merge.pdf");
            outPdf.Close();
            MessageBox.Show("Alle Zeichnungen werden in" + pathOfFolderWithMergedPDF + " Merge.pdf zusammengefügt", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Question);
            EnableOnlyOneButton(btnNameChange);
        }
        //3
        void changeTheNummerToOriginalName()
        {
            DirectoryInfo pdfWithOriginalName = new DirectoryInfo(pathOfFolderWithAllNumberedPDFs);
            DirectoryInfo numberedPDFs = new DirectoryInfo(pathOfFolderWithSplittedPDFs);

            string[] allFilesIn;
            int[] prefix;

            int anzahl = 0;
            int i = 0;
            allFilesIn = new string[pdfWithOriginalName.GetFiles().Count()];

            prefix = new int[pdfWithOriginalName.GetFiles().Count()];
            foreach (var fi in pdfWithOriginalName.GetFiles())
            {
                allFilesIn[i] = fi.Name;
                prefix[i] = Convert.ToInt32(allFilesIn[i].Substring(0, 5));
                i++;
            }
            string oldfilename = "";
            string toChangeFileNumber;
            string newfilename = "";
            PdfSharp.Pdf.PdfDocument one;
            PdfSharp.Pdf.PdfDocument two;
            foreach (var fi in numberedPDFs.GetFiles())
            {
                toChangeFileNumber = fi.Name.Substring(0, fi.Name.IndexOf("-"));
                if (SuchenNachDemDateiMitGleicherNummer(allFilesIn.Length, prefix, Convert.ToInt32(toChangeFileNumber)) == -1)
                {
                    oldfilename = numberedPDFs.ToString() + "\\" + fi.Name;
                    newfilename = numberedPDFs.ToString() + "\\" + fi.Name.Substring(0, fi.Name.IndexOf(" ") + 1) +
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
            foreach (var fi in numberedPDFs.GetFiles())
            {
                toChangeFileNumber = fi.Name.Substring(0, fi.Name.IndexOf("-"));
                oldfilename = numberedPDFs.ToString() + "\\" + fi.Name;
                newfilename = numberedPDFs.ToString() + "\\" + allFilesIn[SuchenNachDemDateiMitGleicherNummer(allFilesIn.Length, prefix, Convert.ToInt32(toChangeFileNumber))];
                System.IO.File.Move(oldfilename, newfilename);
            }

            foreach (var fi in numberedPDFs.GetFiles())
            {
                toChangeFileNumber = fi.Name.Substring( fi.Name.IndexOf("_") +1 , fi.Name.Length - fi.Name.IndexOf("_")-1);
                oldfilename = numberedPDFs.ToString() + "\\" + fi.Name;
                newfilename = numberedPDFs.ToString() + "\\" + toChangeFileNumber;
                System.IO.File.Move(oldfilename, newfilename);
            }

            MessageBox.Show("Die Namen sind schon geändert", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Question);
            EnableOnlyOneButton(btnMovePDFsToOriginalFolder);
        }

        private void btnNameChange_Click(object sender, EventArgs e)
        {
            splitPDF();
            changeTheNummerToOriginalName();
        }
        //4
        private void btnMovePDFsToOriginalFolder_Click(object sender, EventArgs e)
        {
            var allfilesInFromFolder = System.IO.Directory.GetFiles(pathOfFolderWithSplittedPDFs + "\\", "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf"));
            var allfilesInToFolder = System.IO.Directory.GetFiles(txtFolderWithOriginalDrawings.Text, "*.*", System.IO.SearchOption.AllDirectories).Where(s => s.EndsWith(".pdf"));
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
                    fileName = Path.GetFileName(fileInFromFolder);
                    if (Path.GetFileName(fileInToFolder).Equals(fileName))
                    {
                        //System.IO.File.Move(fileInFromFolder, Path.GetDirectoryName(fileInFromFolder) + "\\" + fileName);
                        System.IO.File.Copy(fileInFromFolder , fileInToFolder, true);
                        gefunden = true;
                    }
                }
                if (gefunden == false)
                {
                    MessageBox.Show(fileInToFolder + "nicht gefunden, das Programm wird abgebrochen", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    break;
                }
            }
            MessageBox.Show("Alle Zeichnungen werden in diesen Ordner verschoben", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        #region supplementary function
        private void EnableOnlyOneButton(Button button)
        {
            
            btnMoveAllPDFsIntoOneFolder.Enabled = false;
            btnMergenAllPDFsIntoOnePDF.Enabled = false;
            btnNameChange.Enabled = false;
            btnMovePDFsToOriginalFolder.Enabled = false;

            button.Enabled = true;
        }
        private void splitPDF()
        {
            pathOfFolderWithSplittedPDFs = pathOfFolderOnDesktop + "\\3";
            System.IO.Directory.CreateDirectory(pathOfFolderWithSplittedPDFs);
            ////// Get a fresh copy of the sample PDF file
            //const string filename = "Portable Document Format.pdf";
            //File.Copy(Path.Combine("../../../../../PDFs/", filename),
            //Path.Combine(Directory.GetCurrentDirectory(), filename), true);
            string filename = pathOfFolderWithMergedPDF + "\\Merge.pdf";
            // Open the file
            PdfSharp.Pdf.PdfDocument inputDocument = PdfSharp.Pdf.IO.PdfReader.Open(filename, PdfDocumentOpenMode.Import);
            string name = Path.GetFileNameWithoutExtension(filename);
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfSharp.Pdf.PdfDocument outputDocument = new PdfSharp.Pdf.PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                  String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                //outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(pathOfFolderWithSplittedPDFs + "\\"+String.Format("{0} - Page {1}_tempfile.pdf", idx + 1, name));
            }
        }
        private void CopyPages(PdfSharp.Pdf.PdfDocument from, PdfSharp.Pdf.PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
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
        private string CreateTempDictionaryOnDesktop()
        {
            string pathOfDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string localTempDirectoryOnDesktop = string.Concat(pathOfDesktop, @"\TempDeleteLogos\", Guid.NewGuid());
            System.IO.Directory.CreateDirectory(localTempDirectoryOnDesktop);
            return localTempDirectoryOnDesktop;
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
        #endregion  
    }
}
