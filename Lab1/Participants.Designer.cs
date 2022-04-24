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
            this.addParticipant = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.participantsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // participantsGV
            // 
            this.participantsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.participantsGV.Location = new System.Drawing.Point(12, 12);
            this.participantsGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.participantsGV.Name = "participantsGV";
            this.participantsGV.RowTemplate.Height = 24;
            this.participantsGV.Size = new System.Drawing.Size(776, 150);
            this.participantsGV.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 415);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Член комиссии";
            // 
            // commissionMemberCombo
            // 
            this.commissionMemberCombo.FormattingEnabled = true;
            this.commissionMemberCombo.Location = new System.Drawing.Point(12, 191);
            this.commissionMemberCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commissionMemberCombo.Name = "commissionMemberCombo";
            this.commissionMemberCombo.Size = new System.Drawing.Size(261, 24);
            this.commissionMemberCombo.TabIndex = 3;
            this.commissionMemberCombo.DropDown += new System.EventHandler(this.commissionMemberCombo_DropDown);
            // 
            // addParticipant
            // 
            this.addParticipant.Location = new System.Drawing.Point(12, 223);
            this.addParticipant.Margin = new System.Windows.Forms.Padding(4);
            this.addParticipant.Name = "addParticipant";
            this.addParticipant.Size = new System.Drawing.Size(100, 28);
            this.addParticipant.TabIndex = 4;
            this.addParticipant.Text = "Добавить";
            this.addParticipant.UseVisualStyleBackColor = true;
            this.addParticipant.Click += new System.EventHandler(this.addParticipant_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 258);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Participants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.addParticipant);
            this.Controls.Add(this.commissionMemberCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.participantsGV);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Participants";
            this.Text = "Participants";
            this.Load += new System.EventHandler(this.Participants_Load);
            ((System.ComponentModel.ISupportInitialize)(this.participantsGV)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button addParticipant;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.ComboBox commissionMemberCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.DataGridView participantsGV;

        #endregion
    }
}