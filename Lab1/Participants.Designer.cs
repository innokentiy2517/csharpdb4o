using System.ComponentModel;

namespace Lab1
{
    partial class Participants
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.participantsGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.commissionMemberCombo = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.participantsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // participantsGV
            // 
            this.participantsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.participantsGV.Location = new System.Drawing.Point(9, 10);
            this.participantsGV.Margin = new System.Windows.Forms.Padding(2);
            this.participantsGV.Name = "participantsGV";
            this.participantsGV.RowTemplate.Height = 24;
            this.participantsGV.Size = new System.Drawing.Size(582, 122);
            this.participantsGV.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 337);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Член комиссии";
            // 
            // commissionMemberCombo
            // 
            this.commissionMemberCombo.FormattingEnabled = true;
            this.commissionMemberCombo.Location = new System.Drawing.Point(9, 155);
            this.commissionMemberCombo.Margin = new System.Windows.Forms.Padding(2);
            this.commissionMemberCombo.Name = "commissionMemberCombo";
            this.commissionMemberCombo.Size = new System.Drawing.Size(197, 21);
            this.commissionMemberCombo.TabIndex = 3;
            this.commissionMemberCombo.DropDown += new System.EventHandler(this.commissionMemberCombo_DropDown);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Добавить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 210);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Participants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.commissionMemberCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.participantsGV);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Participants";
            this.Text = "Participants";
            this.Load += new System.EventHandler(this.Participants_Load);
            ((System.ComponentModel.ISupportInitialize)(this.participantsGV)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.ComboBox commissionMemberCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView participantsGV;

        #endregion
    }
}