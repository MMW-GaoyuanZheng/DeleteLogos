using System;
using System.IO;

namespace OpenWriteFile
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
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnNameChange = new System.Windows.Forms.Button();
            this.AlleZeichnungenInEinenOrdnerVerschieben = new System.Windows.Forms.Button();
            this.ZeichnungenAusDemOrdnerZiehen = new System.Windows.Forms.Button();
            this.Mergen = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(88, 92);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(89, 13);
            this.lblOutput.TabIndex = 16;
            this.lblOutput.Text = "Output Dictionary";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(88, 9);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(81, 13);
            this.lblInput.TabIndex = 15;
            this.lblInput.Text = "Input Dictionary";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(126, 113);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(497, 20);
            this.txtOutput.TabIndex = 14;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(126, 25);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(497, 20);
            this.txtInput.TabIndex = 13;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(629, 25);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(46, 20);
            this.btnInput.TabIndex = 17;
            this.btnInput.Text = "...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(629, 113);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(46, 21);
            this.btnOutput.TabIndex = 18;
            this.btnOutput.Text = "...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnNameChange
            // 
            this.btnNameChange.Location = new System.Drawing.Point(249, 242);
            this.btnNameChange.Name = "btnNameChange";
            this.btnNameChange.Size = new System.Drawing.Size(300, 20);
            this.btnNameChange.TabIndex = 22;
            this.btnNameChange.Text = "split and NameChange";
            this.btnNameChange.UseVisualStyleBackColor = true;
            this.btnNameChange.Click += new System.EventHandler(this.btnNameChange_Click);
            // 
            // AlleZeichnungenInEinenOrdnerVerschieben
            // 
            this.AlleZeichnungenInEinenOrdnerVerschieben.Location = new System.Drawing.Point(250, 51);
            this.AlleZeichnungenInEinenOrdnerVerschieben.Name = "AlleZeichnungenInEinenOrdnerVerschieben";
            this.AlleZeichnungenInEinenOrdnerVerschieben.Size = new System.Drawing.Size(300, 20);
            this.AlleZeichnungenInEinenOrdnerVerschieben.TabIndex = 24;
            this.AlleZeichnungenInEinenOrdnerVerschieben.Text = "AlleZeichnungenInEinenOrdnerVerschieben";
            this.AlleZeichnungenInEinenOrdnerVerschieben.UseVisualStyleBackColor = true;
            this.AlleZeichnungenInEinenOrdnerVerschieben.Click += new System.EventHandler(this.MoveAllPdfsToOneDict_Click);
            // 
            // ZeichnungenAusDemOrdnerZiehen
            // 
            this.ZeichnungenAusDemOrdnerZiehen.Location = new System.Drawing.Point(249, 343);
            this.ZeichnungenAusDemOrdnerZiehen.Name = "ZeichnungenAusDemOrdnerZiehen";
            this.ZeichnungenAusDemOrdnerZiehen.Size = new System.Drawing.Size(300, 20);
            this.ZeichnungenAusDemOrdnerZiehen.TabIndex = 24;
            this.ZeichnungenAusDemOrdnerZiehen.Text = "ZeichnungenAusDemOrdnerZiehen";
            this.ZeichnungenAusDemOrdnerZiehen.UseVisualStyleBackColor = true;
            this.ZeichnungenAusDemOrdnerZiehen.Click += new System.EventHandler(this.ZeichnungenAusDemOrdnerZiehen_Click);
            // 
            // Mergen
            // 
            this.Mergen.Location = new System.Drawing.Point(250, 139);
            this.Mergen.Name = "Mergen";
            this.Mergen.Size = new System.Drawing.Size(300, 20);
            this.Mergen.TabIndex = 25;
            this.Mergen.Text = "Zeichnungen zusammenfügen";
            this.Mergen.UseVisualStyleBackColor = true;
            this.Mergen.Click += new System.EventHandler(this.Mergen_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(629, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(46, 21);
            this.button3.TabIndex = 32;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "3";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(126, 198);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(497, 20);
            this.textBox2.TabIndex = 30;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(629, 307);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(46, 21);
            this.button4.TabIndex = 36;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "4";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(126, 307);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(497, 20);
            this.textBox3.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 426);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.Mergen);
            this.Controls.Add(this.ZeichnungenAusDemOrdnerZiehen);
            this.Controls.Add(this.AlleZeichnungenInEinenOrdnerVerschieben);
            this.Controls.Add(this.btnNameChange);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
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
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnNameChange;
        private System.Windows.Forms.Button AlleZeichnungenInEinenOrdnerVerschieben;
        private System.Windows.Forms.Button ZeichnungenAusDemOrdnerZiehen;
        private System.Windows.Forms.Button Mergen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

