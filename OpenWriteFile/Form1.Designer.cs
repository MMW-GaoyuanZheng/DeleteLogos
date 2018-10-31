using System;
using System.IO;

namespace DeleteLogosInPDFs
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.txtFolderWithOriginalDrawings = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnNameChange = new System.Windows.Forms.Button();
            this.btnMoveAllPDFsIntoOneFolder = new System.Windows.Forms.Button();
            this.btnMovePDFsToOriginalFolder = new System.Windows.Forms.Button();
            this.btnMergenAllPDFsIntoOnePDF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFolderWithOriginalDrawings
            // 
            this.txtFolderWithOriginalDrawings.Location = new System.Drawing.Point(56, 12);
            this.txtFolderWithOriginalDrawings.Name = "txtFolderWithOriginalDrawings";
            this.txtFolderWithOriginalDrawings.Size = new System.Drawing.Size(497, 20);
            this.txtFolderWithOriginalDrawings.TabIndex = 13;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(559, 12);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(190, 20);
            this.btnInput.TabIndex = 17;
            this.btnInput.Text = "Folder with original drawings";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnFolderWithOriginalPDFs_Click);
            // 
            // btnNameChange
            // 
            this.btnNameChange.Location = new System.Drawing.Point(180, 90);
            this.btnNameChange.Name = "btnNameChange";
            this.btnNameChange.Size = new System.Drawing.Size(300, 20);
            this.btnNameChange.TabIndex = 22;
            this.btnNameChange.Text = "split and NameChange";
            this.btnNameChange.UseVisualStyleBackColor = true;
            this.btnNameChange.Click += new System.EventHandler(this.btnNameChange_Click);
            // 
            // AlleZeichnungenInEinenOrdnerVerschieben
            // 
            this.btnMoveAllPDFsIntoOneFolder.Location = new System.Drawing.Point(180, 38);
            this.btnMoveAllPDFsIntoOneFolder.Name = "AlleZeichnungenInEinenOrdnerVerschieben";
            this.btnMoveAllPDFsIntoOneFolder.Size = new System.Drawing.Size(300, 20);
            this.btnMoveAllPDFsIntoOneFolder.TabIndex = 24;
            this.btnMoveAllPDFsIntoOneFolder.Text = "Number all drawings and pull them in one folder";
            this.btnMoveAllPDFsIntoOneFolder.UseVisualStyleBackColor = true;
            this.btnMoveAllPDFsIntoOneFolder.Click += new System.EventHandler(this.MoveAllPDFsIntoOneFolder_Click);
            // 
            // ZeichnungenAusDemOrdnerZiehen
            // 
            this.btnMovePDFsToOriginalFolder.Location = new System.Drawing.Point(180, 116);
            this.btnMovePDFsToOriginalFolder.Name = "ZeichnungenAusDemOrdnerZiehen";
            this.btnMovePDFsToOriginalFolder.Size = new System.Drawing.Size(300, 20);
            this.btnMovePDFsToOriginalFolder.TabIndex = 24;
            this.btnMovePDFsToOriginalFolder.Text = "ZeichnungenAusDemOrdnerZiehen";
            this.btnMovePDFsToOriginalFolder.UseVisualStyleBackColor = true;
            this.btnMovePDFsToOriginalFolder.Click += new System.EventHandler(this.btnMovePDFsToOriginalFolder_Click);
            // 
            // Mergen
            // 
            this.btnMergenAllPDFsIntoOnePDF.Location = new System.Drawing.Point(180, 64);
            this.btnMergenAllPDFsIntoOnePDF.Name = "Mergen";
            this.btnMergenAllPDFsIntoOnePDF.Size = new System.Drawing.Size(300, 20);
            this.btnMergenAllPDFsIntoOnePDF.TabIndex = 25;
            this.btnMergenAllPDFsIntoOnePDF.Text = "Merge all drawings into one pdf";
            this.btnMergenAllPDFsIntoOnePDF.UseVisualStyleBackColor = true;
            this.btnMergenAllPDFsIntoOnePDF.Click += new System.EventHandler(this.MergenAllPDFsIntoOnePDF_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 155);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMergenAllPDFsIntoOnePDF);
            this.Controls.Add(this.btnMovePDFsToOriginalFolder);
            this.Controls.Add(this.btnMoveAllPDFsIntoOneFolder);
            this.Controls.Add(this.btnNameChange);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtFolderWithOriginalDrawings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "ReadWrite File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtFolderWithOriginalDrawings;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnNameChange;
        private System.Windows.Forms.Button btnMoveAllPDFsIntoOneFolder;
        private System.Windows.Forms.Button btnMovePDFsToOriginalFolder;
        private System.Windows.Forms.Button btnMergenAllPDFsIntoOnePDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

