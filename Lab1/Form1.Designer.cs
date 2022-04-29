namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addCommissionButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.commissionDeleteButton = new System.Windows.Forms.Button();
            this.editCommissionButton = new System.Windows.Forms.Button();
            this.commissionGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.deletePersonButton = new System.Windows.Forms.Button();
            this.editPersonButton = new System.Windows.Forms.Button();
            this.addPersonButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.middleNameTextBox = new System.Windows.Forms.TextBox();
            this.secondNameTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.houseNumberTextBox = new System.Windows.Forms.TextBox();
            this.appartNumberTextBox = new System.Windows.Forms.TextBox();
            this.phoneHomeTextBox = new System.Windows.Forms.TextBox();
            this.phoneWorkTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.personGridView = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.removeFromCommissionButton = new System.Windows.Forms.Button();
            this.deassignChairmanButton = new System.Windows.Forms.Button();
            this.assignChairmanButton = new System.Windows.Forms.Button();
            this.addCommissionMemberButton = new System.Windows.Forms.Button();
            this.commissionDropDown = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.personComboBox = new System.Windows.Forms.ComboBox();
            this.commissionMemberDGV = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.openParticipants = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.updateSessionButton = new System.Windows.Forms.Button();
            this.addSessionButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.sessionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.sessionPlaceTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.sessionCommissionCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.sessionGV = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.indexQueryButton = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.indexQueryDGV = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commissionGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commissionMemberDGV)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionGV)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexQueryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // addCommissionButton
            // 
            this.addCommissionButton.Location = new System.Drawing.Point(5, 348);
            this.addCommissionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addCommissionButton.Name = "addCommissionButton";
            this.addCommissionButton.Size = new System.Drawing.Size(100, 23);
            this.addCommissionButton.TabIndex = 0;
            this.addCommissionButton.Text = "Добавить";
            this.addCommissionButton.UseVisualStyleBackColor = true;
            this.addCommissionButton.Click += new System.EventHandler(this.addCommissionButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 277);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Название комиссии";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(13, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 528);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Click += new System.EventHandler(this.log);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.commissionDeleteButton);
            this.tabPage1.Controls.Add(this.editCommissionButton);
            this.tabPage1.Controls.Add(this.commissionGridView);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.addCommissionButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(749, 499);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Комиссии";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // commissionDeleteButton
            // 
            this.commissionDeleteButton.Location = new System.Drawing.Point(5, 407);
            this.commissionDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commissionDeleteButton.Name = "commissionDeleteButton";
            this.commissionDeleteButton.Size = new System.Drawing.Size(100, 23);
            this.commissionDeleteButton.TabIndex = 5;
            this.commissionDeleteButton.Text = "Удалить";
            this.commissionDeleteButton.UseVisualStyleBackColor = true;
            this.commissionDeleteButton.Click += new System.EventHandler(this.commissionDeleteButton_Click);
            // 
            // editCommissionButton
            // 
            this.editCommissionButton.Location = new System.Drawing.Point(5, 378);
            this.editCommissionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editCommissionButton.Name = "editCommissionButton";
            this.editCommissionButton.Size = new System.Drawing.Size(100, 23);
            this.editCommissionButton.TabIndex = 4;
            this.editCommissionButton.Text = "Изменить";
            this.editCommissionButton.UseVisualStyleBackColor = true;
            this.editCommissionButton.Click += new System.EventHandler(this.editCommissionButton_Click);
            // 
            // commissionGridView
            // 
            this.commissionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commissionGridView.Location = new System.Drawing.Point(5, 2);
            this.commissionGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commissionGridView.Name = "commissionGridView";
            this.commissionGridView.RowHeadersWidth = 51;
            this.commissionGridView.RowTemplate.Height = 24;
            this.commissionGridView.Size = new System.Drawing.Size(737, 251);
            this.commissionGridView.TabIndex = 3;
            this.commissionGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.commissionGridView_CellMouseClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.deletePersonButton);
            this.tabPage2.Controls.Add(this.editPersonButton);
            this.tabPage2.Controls.Add(this.addPersonButton);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.middleNameTextBox);
            this.tabPage2.Controls.Add(this.secondNameTextBox);
            this.tabPage2.Controls.Add(this.cityTextBox);
            this.tabPage2.Controls.Add(this.streetTextBox);
            this.tabPage2.Controls.Add(this.houseNumberTextBox);
            this.tabPage2.Controls.Add(this.appartNumberTextBox);
            this.tabPage2.Controls.Add(this.phoneHomeTextBox);
            this.tabPage2.Controls.Add(this.phoneWorkTextBox);
            this.tabPage2.Controls.Add(this.firstNameTextBox);
            this.tabPage2.Controls.Add(this.personGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(749, 499);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Члены ГорДумы";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // deletePersonButton
            // 
            this.deletePersonButton.Location = new System.Drawing.Point(337, 452);
            this.deletePersonButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deletePersonButton.Name = "deletePersonButton";
            this.deletePersonButton.Size = new System.Drawing.Size(96, 23);
            this.deletePersonButton.TabIndex = 21;
            this.deletePersonButton.Text = "Удалить";
            this.deletePersonButton.UseVisualStyleBackColor = true;
            this.deletePersonButton.Click += new System.EventHandler(this.deletePersonButton_Click);
            // 
            // editPersonButton
            // 
            this.editPersonButton.Location = new System.Drawing.Point(337, 422);
            this.editPersonButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editPersonButton.Name = "editPersonButton";
            this.editPersonButton.Size = new System.Drawing.Size(96, 23);
            this.editPersonButton.TabIndex = 20;
            this.editPersonButton.Text = "Изменить";
            this.editPersonButton.UseVisualStyleBackColor = true;
            this.editPersonButton.Click += new System.EventHandler(this.editPersonButton_Click);
            // 
            // addPersonButton
            // 
            this.addPersonButton.Location = new System.Drawing.Point(337, 393);
            this.addPersonButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(96, 23);
            this.addPersonButton.TabIndex = 19;
            this.addPersonButton.Text = "Добавить";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Рабочий номер телефона";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(337, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Домашний номер телефона";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 418);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "№ квартиры";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "№ дома";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Улица";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Город";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Имя";
            // 
            // middleNameTextBox
            // 
            this.middleNameTextBox.Location = new System.Drawing.Point(5, 350);
            this.middleNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.middleNameTextBox.Name = "middleNameTextBox";
            this.middleNameTextBox.Size = new System.Drawing.Size(149, 22);
            this.middleNameTextBox.TabIndex = 2;
            // 
            // secondNameTextBox
            // 
            this.secondNameTextBox.Location = new System.Drawing.Point(5, 394);
            this.secondNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.secondNameTextBox.Name = "secondNameTextBox";
            this.secondNameTextBox.Size = new System.Drawing.Size(149, 22);
            this.secondNameTextBox.TabIndex = 3;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(199, 304);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(100, 22);
            this.cityTextBox.TabIndex = 4;
            // 
            // streetTextBox
            // 
            this.streetTextBox.Location = new System.Drawing.Point(199, 350);
            this.streetTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(100, 22);
            this.streetTextBox.TabIndex = 5;
            // 
            // houseNumberTextBox
            // 
            this.houseNumberTextBox.Location = new System.Drawing.Point(199, 394);
            this.houseNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.houseNumberTextBox.Name = "houseNumberTextBox";
            this.houseNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.houseNumberTextBox.TabIndex = 6;
            // 
            // appartNumberTextBox
            // 
            this.appartNumberTextBox.Location = new System.Drawing.Point(199, 438);
            this.appartNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.appartNumberTextBox.Name = "appartNumberTextBox";
            this.appartNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.appartNumberTextBox.TabIndex = 7;
            // 
            // phoneHomeTextBox
            // 
            this.phoneHomeTextBox.Location = new System.Drawing.Point(337, 304);
            this.phoneHomeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneHomeTextBox.Name = "phoneHomeTextBox";
            this.phoneHomeTextBox.Size = new System.Drawing.Size(193, 22);
            this.phoneHomeTextBox.TabIndex = 8;
            // 
            // phoneWorkTextBox
            // 
            this.phoneWorkTextBox.Location = new System.Drawing.Point(337, 350);
            this.phoneWorkTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneWorkTextBox.Name = "phoneWorkTextBox";
            this.phoneWorkTextBox.Size = new System.Drawing.Size(193, 22);
            this.phoneWorkTextBox.TabIndex = 9;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(5, 304);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(149, 22);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // personGridView
            // 
            this.personGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personGridView.Location = new System.Drawing.Point(5, 6);
            this.personGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.personGridView.Name = "personGridView";
            this.personGridView.RowHeadersWidth = 51;
            this.personGridView.RowTemplate.Height = 24;
            this.personGridView.Size = new System.Drawing.Size(737, 274);
            this.personGridView.TabIndex = 0;
            this.personGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.personGridView_CellMouseClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.removeFromCommissionButton);
            this.tabPage3.Controls.Add(this.deassignChairmanButton);
            this.tabPage3.Controls.Add(this.assignChairmanButton);
            this.tabPage3.Controls.Add(this.addCommissionMemberButton);
            this.tabPage3.Controls.Add(this.commissionDropDown);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.personComboBox);
            this.tabPage3.Controls.Add(this.commissionMemberDGV);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(749, 499);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Члены комиссий";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // removeFromCommissionButton
            // 
            this.removeFromCommissionButton.Location = new System.Drawing.Point(5, 450);
            this.removeFromCommissionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeFromCommissionButton.Name = "removeFromCommissionButton";
            this.removeFromCommissionButton.Size = new System.Drawing.Size(197, 23);
            this.removeFromCommissionButton.TabIndex = 8;
            this.removeFromCommissionButton.Text = "Исключить из комиссии";
            this.removeFromCommissionButton.UseVisualStyleBackColor = true;
            this.removeFromCommissionButton.Click += new System.EventHandler(this.removeFromCommissionButton_Click);
            // 
            // deassignChairmanButton
            // 
            this.deassignChairmanButton.Location = new System.Drawing.Point(5, 421);
            this.deassignChairmanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deassignChairmanButton.Name = "deassignChairmanButton";
            this.deassignChairmanButton.Size = new System.Drawing.Size(197, 23);
            this.deassignChairmanButton.TabIndex = 7;
            this.deassignChairmanButton.Text = "Снять с поста";
            this.deassignChairmanButton.UseVisualStyleBackColor = true;
            this.deassignChairmanButton.Click += new System.EventHandler(this.deassignChairmanButton_Click);
            // 
            // assignChairmanButton
            // 
            this.assignChairmanButton.Location = new System.Drawing.Point(5, 391);
            this.assignChairmanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.assignChairmanButton.Name = "assignChairmanButton";
            this.assignChairmanButton.Size = new System.Drawing.Size(197, 23);
            this.assignChairmanButton.TabIndex = 6;
            this.assignChairmanButton.Text = "Назначить председателем";
            this.assignChairmanButton.UseVisualStyleBackColor = true;
            this.assignChairmanButton.Click += new System.EventHandler(this.assignChairmanButton_Click);
            // 
            // addCommissionMemberButton
            // 
            this.addCommissionMemberButton.Location = new System.Drawing.Point(5, 363);
            this.addCommissionMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addCommissionMemberButton.Name = "addCommissionMemberButton";
            this.addCommissionMemberButton.Size = new System.Drawing.Size(197, 23);
            this.addCommissionMemberButton.TabIndex = 5;
            this.addCommissionMemberButton.Text = "Добавить члена комиссии";
            this.addCommissionMemberButton.UseVisualStyleBackColor = true;
            this.addCommissionMemberButton.Click += new System.EventHandler(this.addCommissionMemberButton_Click);
            // 
            // commissionDropDown
            // 
            this.commissionDropDown.FormattingEnabled = true;
            this.commissionDropDown.Location = new System.Drawing.Point(5, 334);
            this.commissionDropDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commissionDropDown.Name = "commissionDropDown";
            this.commissionDropDown.Size = new System.Drawing.Size(281, 24);
            this.commissionDropDown.TabIndex = 4;
            this.commissionDropDown.DropDown += new System.EventHandler(this.commissionDropDown_DropDown);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(5, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.label12.TabIndex = 3;
            this.label12.Text = "Комиссия";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "Член ГорДумы";
            // 
            // personComboBox
            // 
            this.personComboBox.FormattingEnabled = true;
            this.personComboBox.Location = new System.Drawing.Point(5, 281);
            this.personComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.personComboBox.Name = "personComboBox";
            this.personComboBox.Size = new System.Drawing.Size(281, 24);
            this.personComboBox.TabIndex = 1;
            this.personComboBox.DropDown += new System.EventHandler(this.personComboBox_DropDown);
            // 
            // commissionMemberDGV
            // 
            this.commissionMemberDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commissionMemberDGV.Location = new System.Drawing.Point(5, 6);
            this.commissionMemberDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commissionMemberDGV.Name = "commissionMemberDGV";
            this.commissionMemberDGV.RowTemplate.Height = 24;
            this.commissionMemberDGV.Size = new System.Drawing.Size(737, 247);
            this.commissionMemberDGV.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.openParticipants);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.updateSessionButton);
            this.tabPage4.Controls.Add(this.addSessionButton);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.sessionDatePicker);
            this.tabPage4.Controls.Add(this.sessionPlaceTextBox);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.sessionCommissionCombo);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.sessionGV);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(749, 499);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Собрание";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // openParticipants
            // 
            this.openParticipants.Location = new System.Drawing.Point(403, 293);
            this.openParticipants.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openParticipants.Name = "openParticipants";
            this.openParticipants.Size = new System.Drawing.Size(265, 23);
            this.openParticipants.TabIndex = 10;
            this.openParticipants.Text = "Просмотреть участников собрания";
            this.openParticipants.UseVisualStyleBackColor = true;
            this.openParticipants.Click += new System.EventHandler(this.openParticipants_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(251, 322);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // updateSessionButton
            // 
            this.updateSessionButton.Location = new System.Drawing.Point(251, 293);
            this.updateSessionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateSessionButton.Name = "updateSessionButton";
            this.updateSessionButton.Size = new System.Drawing.Size(107, 23);
            this.updateSessionButton.TabIndex = 8;
            this.updateSessionButton.Text = "Изменить";
            this.updateSessionButton.UseVisualStyleBackColor = true;
            this.updateSessionButton.Click += new System.EventHandler(this.updateSessionButton_Click);
            // 
            // addSessionButton
            // 
            this.addSessionButton.Location = new System.Drawing.Point(251, 263);
            this.addSessionButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addSessionButton.Name = "addSessionButton";
            this.addSessionButton.Size = new System.Drawing.Size(107, 23);
            this.addSessionButton.TabIndex = 7;
            this.addSessionButton.Text = "Добавить";
            this.addSessionButton.UseVisualStyleBackColor = true;
            this.addSessionButton.Click += new System.EventHandler(this.addSessionButton_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(5, 363);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 23);
            this.label15.TabIndex = 6;
            this.label15.Text = "Дата собрания";
            // 
            // sessionDatePicker
            // 
            this.sessionDatePicker.Location = new System.Drawing.Point(5, 389);
            this.sessionDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sessionDatePicker.Name = "sessionDatePicker";
            this.sessionDatePicker.Size = new System.Drawing.Size(200, 22);
            this.sessionDatePicker.TabIndex = 5;
            // 
            // sessionPlaceTextBox
            // 
            this.sessionPlaceTextBox.Location = new System.Drawing.Point(5, 329);
            this.sessionPlaceTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sessionPlaceTextBox.Name = "sessionPlaceTextBox";
            this.sessionPlaceTextBox.Size = new System.Drawing.Size(121, 22);
            this.sessionPlaceTextBox.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(5, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 23);
            this.label14.TabIndex = 3;
            this.label14.Text = "Место собрания";
            // 
            // sessionCommissionCombo
            // 
            this.sessionCommissionCombo.FormattingEnabled = true;
            this.sessionCommissionCombo.Location = new System.Drawing.Point(5, 263);
            this.sessionCommissionCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sessionCommissionCombo.Name = "sessionCommissionCombo";
            this.sessionCommissionCombo.Size = new System.Drawing.Size(121, 24);
            this.sessionCommissionCombo.TabIndex = 2;
            this.sessionCommissionCombo.DropDown += new System.EventHandler(this.sessionCommissionCombo_DropDown);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(5, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 1;
            this.label13.Text = "Комиссия";
            // 
            // sessionGV
            // 
            this.sessionGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sessionGV.Location = new System.Drawing.Point(5, 6);
            this.sessionGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sessionGV.Name = "sessionGV";
            this.sessionGV.RowTemplate.Height = 24;
            this.sessionGV.Size = new System.Drawing.Size(737, 229);
            this.sessionGV.TabIndex = 0;
            this.sessionGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sessionGV_mouseClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.indexQueryButton);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.toDatePicker);
            this.tabPage5.Controls.Add(this.fromDatePicker);
            this.tabPage5.Controls.Add(this.indexQueryDGV);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(749, 499);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "INDEXED_QUERY";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // indexQueryButton
            // 
            this.indexQueryButton.Location = new System.Drawing.Point(6, 368);
            this.indexQueryButton.Name = "indexQueryButton";
            this.indexQueryButton.Size = new System.Drawing.Size(75, 23);
            this.indexQueryButton.TabIndex = 5;
            this.indexQueryButton.Text = "Найти";
            this.indexQueryButton.UseVisualStyleBackColor = true;
            this.indexQueryButton.Click += new System.EventHandler(this.indexQueryButton_Click);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 314);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.label17.TabIndex = 4;
            this.label17.Text = "По";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "С";
            // 
            // toDatePicker
            // 
            this.toDatePicker.Location = new System.Drawing.Point(6, 340);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(200, 22);
            this.toDatePicker.TabIndex = 2;
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Location = new System.Drawing.Point(6, 289);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(200, 22);
            this.fromDatePicker.TabIndex = 1;
            // 
            // indexQueryDGV
            // 
            this.indexQueryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indexQueryDGV.Location = new System.Drawing.Point(6, 6);
            this.indexQueryDGV.Name = "indexQueryDGV";
            this.indexQueryDGV.RowTemplate.Height = 24;
            this.indexQueryDGV.Size = new System.Drawing.Size(737, 254);
            this.indexQueryDGV.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 553);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commissionGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commissionMemberDGV)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sessionGV)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.indexQueryDGV)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button indexQueryButton;

        private System.Windows.Forms.DataGridView indexQueryDGV;

        private System.Windows.Forms.TabPage tabPage5;

        private System.Windows.Forms.Button openParticipants;

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox sessionCommissionCombo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox sessionPlaceTextBox;
        private System.Windows.Forms.DateTimePicker sessionDatePicker;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button updateSessionButton;
        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView sessionGV;

        private System.Windows.Forms.Button addCommissionMemberButton;

        private System.Windows.Forms.Button assignChairmanButton;
        private System.Windows.Forms.Button addSessionButton;
        private System.Windows.Forms.Button deassignChairmanButton;
        private System.Windows.Forms.Button removeFromCommissionButton;

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox commissionDropDown;

        private System.Windows.Forms.ComboBox personComboBox;
        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView commissionMemberDGV;

        #endregion

        private System.Windows.Forms.Button addCommissionButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView commissionGridView;
        private System.Windows.Forms.DataGridView personGridView;
        private System.Windows.Forms.Button deletePersonButton;
        private System.Windows.Forms.Button editPersonButton;
        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox middleNameTextBox;
        private System.Windows.Forms.TextBox secondNameTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.TextBox houseNumberTextBox;
        private System.Windows.Forms.TextBox appartNumberTextBox;
        private System.Windows.Forms.TextBox phoneHomeTextBox;
        private System.Windows.Forms.TextBox phoneWorkTextBox;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Button commissionDeleteButton;
        private System.Windows.Forms.Button editCommissionButton;
    }
}

