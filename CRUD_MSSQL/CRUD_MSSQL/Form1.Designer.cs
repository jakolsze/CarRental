namespace CRUD_MSSQL
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
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Login = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoginOK = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Display = new System.Windows.Forms.TabPage();
            this.txtColorBox = new System.Windows.Forms.TextBox();
            this.lblCarYear = new System.Windows.Forms.Label();
            this.lblPlate = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.btnRentAdd = new System.Windows.Forms.Button();
            this.lblCarId = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewCar = new System.Windows.Forms.DataGridView();
            this.Functions = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.comboBrand = new System.Windows.Forms.ComboBox();
            this.dtpCarYear = new System.Windows.Forms.DateTimePicker();
            this.txtPlate = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.Rentals = new System.Windows.Forms.TabPage();
            this.btnSortRentalByCars = new System.Windows.Forms.Button();
            this.btnShowFinished = new System.Windows.Forms.Button();
            this.btnHideFinished = new System.Windows.Forms.Button();
            this.lblRentID = new System.Windows.Forms.Label();
            this.btnRentDelete = new System.Windows.Forms.Button();
            this.dataGridViewRent = new System.Windows.Forms.DataGridView();
            this.RentFun = new System.Windows.Forms.TabPage();
            this.dataGridViewRentByID = new System.Windows.Forms.DataGridView();
            this.btnRentCancel = new System.Windows.Forms.Button();
            this.btnRentSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFinish = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl.SuspendLayout();
            this.Login.SuspendLayout();
            this.Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCar)).BeginInit();
            this.Functions.SuspendLayout();
            this.Rentals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRent)).BeginInit();
            this.RentFun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentByID)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Login);
            this.tabControl.Controls.Add(this.Display);
            this.tabControl.Controls.Add(this.Functions);
            this.tabControl.Controls.Add(this.Rentals);
            this.tabControl.Controls.Add(this.RentFun);
            this.tabControl.Location = new System.Drawing.Point(16, 15);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1395, 524);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.Controls.Add(this.checkBox1);
            this.Login.Controls.Add(this.label1);
            this.Login.Controls.Add(this.btnLoginOK);
            this.Login.Controls.Add(this.txtPassword);
            this.Login.Location = new System.Drawing.Point(4, 25);
            this.Login.Margin = new System.Windows.Forms.Padding(4);
            this.Login.Name = "Login";
            this.Login.Padding = new System.Windows.Forms.Padding(4);
            this.Login.Size = new System.Drawing.Size(1387, 495);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(800, 203);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 20);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Show";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "  Enter password:";
            // 
            // btnLoginOK
            // 
            this.btnLoginOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoginOK.Location = new System.Drawing.Point(530, 231);
            this.btnLoginOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoginOK.Name = "btnLoginOK";
            this.btnLoginOK.Size = new System.Drawing.Size(100, 28);
            this.btnLoginOK.TabIndex = 2;
            this.btnLoginOK.Text = "OK";
            this.btnLoginOK.UseVisualStyleBackColor = true;
            this.btnLoginOK.Click += new System.EventHandler(this.btnLoginOK_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(379, 201);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(393, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Display.Controls.Add(this.txtColorBox);
            this.Display.Controls.Add(this.lblCarYear);
            this.Display.Controls.Add(this.lblPlate);
            this.Display.Controls.Add(this.lblModel);
            this.Display.Controls.Add(this.btnRentAdd);
            this.Display.Controls.Add(this.lblCarId);
            this.Display.Controls.Add(this.lblColor);
            this.Display.Controls.Add(this.btnDelete);
            this.Display.Controls.Add(this.btnEdit);
            this.Display.Controls.Add(this.btnAddNew);
            this.Display.Controls.Add(this.lblBrand);
            this.Display.Controls.Add(this.pictureBox1);
            this.Display.Controls.Add(this.dataGridViewCar);
            this.Display.Location = new System.Drawing.Point(4, 25);
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Name = "Display";
            this.Display.Padding = new System.Windows.Forms.Padding(4);
            this.Display.Size = new System.Drawing.Size(1387, 495);
            this.Display.TabIndex = 1;
            this.Display.Text = "Cars Database";
            // 
            // txtColorBox
            // 
            this.txtColorBox.Enabled = false;
            this.txtColorBox.Location = new System.Drawing.Point(847, 264);
            this.txtColorBox.Name = "txtColorBox";
            this.txtColorBox.Size = new System.Drawing.Size(384, 22);
            this.txtColorBox.TabIndex = 14;
            this.txtColorBox.Text = "Color";
            this.txtColorBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCarYear
            // 
            this.lblCarYear.AutoSize = true;
            this.lblCarYear.Location = new System.Drawing.Point(380, 2);
            this.lblCarYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarYear.Name = "lblCarYear";
            this.lblCarYear.Size = new System.Drawing.Size(44, 16);
            this.lblCarYear.TabIndex = 13;
            this.lblCarYear.Text = "label2";
            this.lblCarYear.Visible = false;
            // 
            // lblPlate
            // 
            this.lblPlate.AutoSize = true;
            this.lblPlate.Location = new System.Drawing.Point(328, 2);
            this.lblPlate.Name = "lblPlate";
            this.lblPlate.Size = new System.Drawing.Size(44, 16);
            this.lblPlate.TabIndex = 12;
            this.lblPlate.Text = "label2";
            this.lblPlate.Visible = false;
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(227, 2);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(44, 16);
            this.lblModel.TabIndex = 11;
            this.lblModel.Text = "label2";
            this.lblModel.Visible = false;
            // 
            // btnRentAdd
            // 
            this.btnRentAdd.Location = new System.Drawing.Point(847, 307);
            this.btnRentAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentAdd.Name = "btnRentAdd";
            this.btnRentAdd.Size = new System.Drawing.Size(384, 23);
            this.btnRentAdd.TabIndex = 10;
            this.btnRentAdd.Text = "Rent Car";
            this.btnRentAdd.UseVisualStyleBackColor = true;
            this.btnRentAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCarId
            // 
            this.lblCarId.AutoSize = true;
            this.lblCarId.Location = new System.Drawing.Point(156, 2);
            this.lblCarId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarId.Name = "lblCarId";
            this.lblCarId.Size = new System.Drawing.Size(53, 16);
            this.lblCarId.TabIndex = 9;
            this.lblCarId.Text = "lblCarId";
            this.lblCarId.Visible = false;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(463, 2);
            this.lblColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(90, 16);
            this.lblColor.TabIndex = 7;
            this.lblColor.Text = "               Color  ";
            this.lblColor.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(466, 347);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(344, 347);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 28);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(220, 347);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 28);
            this.btnAddNew.TabIndex = 4;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(8, 2);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(44, 16);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "label2";
            this.lblBrand.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(847, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 216);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridViewCar
            // 
            this.dataGridViewCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCar.Location = new System.Drawing.Point(8, 22);
            this.dataGridViewCar.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCar.Name = "dataGridViewCar";
            this.dataGridViewCar.Size = new System.Drawing.Size(807, 308);
            this.dataGridViewCar.TabIndex = 1;
            // 
            // Functions
            // 
            this.Functions.Controls.Add(this.label8);
            this.Functions.Controls.Add(this.label7);
            this.Functions.Controls.Add(this.label6);
            this.Functions.Controls.Add(this.label5);
            this.Functions.Controls.Add(this.label4);
            this.Functions.Controls.Add(this.comboColor);
            this.Functions.Controls.Add(this.comboBrand);
            this.Functions.Controls.Add(this.dtpCarYear);
            this.Functions.Controls.Add(this.txtPlate);
            this.Functions.Controls.Add(this.txtModel);
            this.Functions.Controls.Add(this.btnCancel);
            this.Functions.Controls.Add(this.btnSave);
            this.Functions.Location = new System.Drawing.Point(4, 25);
            this.Functions.Margin = new System.Windows.Forms.Padding(4);
            this.Functions.Name = "Functions";
            this.Functions.Size = new System.Drawing.Size(1387, 495);
            this.Functions.TabIndex = 2;
            this.Functions.Text = "Placeholder";
            this.Functions.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 206);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Year:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(469, 176);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Plate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Color:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Model:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Brand:";
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Grey",
            "Red",
            "Blue",
            "Green",
            "Yellow",
            "Silver",
            "Beige"});
            this.comboColor.Location = new System.Drawing.Point(554, 138);
            this.comboColor.Margin = new System.Windows.Forms.Padding(4);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(177, 24);
            this.comboColor.TabIndex = 7;
            // 
            // comboBrand
            // 
            this.comboBrand.FormattingEnabled = true;
            this.comboBrand.Items.AddRange(new object[] {
            "Toyota",
            "Opel",
            "Mercedes",
            "Lexus",
            "Audi"});
            this.comboBrand.Location = new System.Drawing.Point(554, 76);
            this.comboBrand.Margin = new System.Windows.Forms.Padding(4);
            this.comboBrand.Name = "comboBrand";
            this.comboBrand.Size = new System.Drawing.Size(177, 24);
            this.comboBrand.TabIndex = 6;
            // 
            // dtpCarYear
            // 
            this.dtpCarYear.Location = new System.Drawing.Point(554, 200);
            this.dtpCarYear.Margin = new System.Windows.Forms.Padding(4);
            this.dtpCarYear.Name = "dtpCarYear";
            this.dtpCarYear.Size = new System.Drawing.Size(177, 22);
            this.dtpCarYear.TabIndex = 5;
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(554, 170);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlate.MaxLength = 7;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Size = new System.Drawing.Size(177, 22);
            this.txtPlate.TabIndex = 3;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(554, 108);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.MaxLength = 20;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(177, 22);
            this.txtModel.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(631, 259);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 259);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Rentals
            // 
            this.Rentals.Controls.Add(this.btnSortRentalByCars);
            this.Rentals.Controls.Add(this.btnShowFinished);
            this.Rentals.Controls.Add(this.btnHideFinished);
            this.Rentals.Controls.Add(this.lblRentID);
            this.Rentals.Controls.Add(this.btnRentDelete);
            this.Rentals.Controls.Add(this.dataGridViewRent);
            this.Rentals.Location = new System.Drawing.Point(4, 25);
            this.Rentals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rentals.Name = "Rentals";
            this.Rentals.Size = new System.Drawing.Size(1387, 495);
            this.Rentals.TabIndex = 3;
            this.Rentals.Text = "Rentals";
            this.Rentals.UseVisualStyleBackColor = true;
            // 
            // btnSortRentalByCars
            // 
            this.btnSortRentalByCars.Location = new System.Drawing.Point(1099, 182);
            this.btnSortRentalByCars.Margin = new System.Windows.Forms.Padding(4);
            this.btnSortRentalByCars.Name = "btnSortRentalByCars";
            this.btnSortRentalByCars.Size = new System.Drawing.Size(140, 37);
            this.btnSortRentalByCars.TabIndex = 5;
            this.btnSortRentalByCars.Text = "Sort by car";
            this.btnSortRentalByCars.UseVisualStyleBackColor = true;
            this.btnSortRentalByCars.Click += new System.EventHandler(this.btnSortRentalByCars_Click);
            // 
            // btnShowFinished
            // 
            this.btnShowFinished.Location = new System.Drawing.Point(1099, 138);
            this.btnShowFinished.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowFinished.Name = "btnShowFinished";
            this.btnShowFinished.Size = new System.Drawing.Size(140, 37);
            this.btnShowFinished.TabIndex = 4;
            this.btnShowFinished.Text = "Show finished";
            this.btnShowFinished.UseVisualStyleBackColor = true;
            this.btnShowFinished.Click += new System.EventHandler(this.btnShowFinished_Click);
            // 
            // btnHideFinished
            // 
            this.btnHideFinished.Location = new System.Drawing.Point(1099, 94);
            this.btnHideFinished.Margin = new System.Windows.Forms.Padding(4);
            this.btnHideFinished.Name = "btnHideFinished";
            this.btnHideFinished.Size = new System.Drawing.Size(140, 37);
            this.btnHideFinished.TabIndex = 3;
            this.btnHideFinished.Text = "Hide finished";
            this.btnHideFinished.UseVisualStyleBackColor = true;
            this.btnHideFinished.Click += new System.EventHandler(this.btnHideFinished_Click);
            // 
            // lblRentID
            // 
            this.lblRentID.AutoSize = true;
            this.lblRentID.Location = new System.Drawing.Point(68, 12);
            this.lblRentID.Name = "lblRentID";
            this.lblRentID.Size = new System.Drawing.Size(62, 16);
            this.lblRentID.TabIndex = 2;
            this.lblRentID.Text = "lblRentID";
            this.lblRentID.Visible = false;
            // 
            // btnRentDelete
            // 
            this.btnRentDelete.Location = new System.Drawing.Point(1099, 50);
            this.btnRentDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentDelete.Name = "btnRentDelete";
            this.btnRentDelete.Size = new System.Drawing.Size(140, 37);
            this.btnRentDelete.TabIndex = 1;
            this.btnRentDelete.Text = "Delete entry";
            this.btnRentDelete.UseVisualStyleBackColor = true;
            this.btnRentDelete.Click += new System.EventHandler(this.btnRentDelete_Click);
            // 
            // dataGridViewRent
            // 
            this.dataGridViewRent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRent.Location = new System.Drawing.Point(37, 34);
            this.dataGridViewRent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewRent.Name = "dataGridViewRent";
            this.dataGridViewRent.RowTemplate.Height = 24;
            this.dataGridViewRent.Size = new System.Drawing.Size(1048, 334);
            this.dataGridViewRent.TabIndex = 0;
            // 
            // RentFun
            // 
            this.RentFun.Controls.Add(this.dataGridViewRentByID);
            this.RentFun.Controls.Add(this.btnRentCancel);
            this.RentFun.Controls.Add(this.btnRentSave);
            this.RentFun.Controls.Add(this.label10);
            this.RentFun.Controls.Add(this.label9);
            this.RentFun.Controls.Add(this.dtpFinish);
            this.RentFun.Controls.Add(this.dtpStart);
            this.RentFun.Location = new System.Drawing.Point(4, 25);
            this.RentFun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RentFun.Name = "RentFun";
            this.RentFun.Size = new System.Drawing.Size(1387, 495);
            this.RentFun.TabIndex = 4;
            this.RentFun.Text = "Functions";
            this.RentFun.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRentByID
            // 
            this.dataGridViewRentByID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRentByID.Location = new System.Drawing.Point(585, 27);
            this.dataGridViewRentByID.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRentByID.Name = "dataGridViewRentByID";
            this.dataGridViewRentByID.Size = new System.Drawing.Size(595, 283);
            this.dataGridViewRentByID.TabIndex = 6;
            // 
            // btnRentCancel
            // 
            this.btnRentCancel.Location = new System.Drawing.Point(269, 153);
            this.btnRentCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentCancel.Name = "btnRentCancel";
            this.btnRentCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRentCancel.TabIndex = 5;
            this.btnRentCancel.Text = "Cancel";
            this.btnRentCancel.UseVisualStyleBackColor = true;
            this.btnRentCancel.Click += new System.EventHandler(this.btnRentCancel_Click);
            // 
            // btnRentSave
            // 
            this.btnRentSave.Location = new System.Drawing.Point(109, 153);
            this.btnRentSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentSave.Name = "btnRentSave";
            this.btnRentSave.Size = new System.Drawing.Size(75, 23);
            this.btnRentSave.TabIndex = 4;
            this.btnRentSave.Text = "Rent";
            this.btnRentSave.UseVisualStyleBackColor = true;
            this.btnRentSave.Click += new System.EventHandler(this.btnRentSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "End of rental:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Start of rental:";
            // 
            // dtpFinish
            // 
            this.dtpFinish.Location = new System.Drawing.Point(156, 97);
            this.dtpFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFinish.Name = "dtpFinish";
            this.dtpFinish.Size = new System.Drawing.Size(200, 22);
            this.dtpFinish.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(156, 49);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 448);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1291, 487);
            this.MinimumSize = new System.Drawing.Size(1291, 487);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.Login.ResumeLayout(false);
            this.Login.PerformLayout();
            this.Display.ResumeLayout(false);
            this.Display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCar)).EndInit();
            this.Functions.ResumeLayout(false);
            this.Functions.PerformLayout();
            this.Rentals.ResumeLayout(false);
            this.Rentals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRent)).EndInit();
            this.RentFun.ResumeLayout(false);
            this.RentFun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentByID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Login;
        private System.Windows.Forms.TabPage Display;
        private System.Windows.Forms.TabPage Functions;
        private System.Windows.Forms.Button btnLoginOK;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridView dataGridViewCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPlate;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.DateTimePicker dtpCarYear;
        private System.Windows.Forms.ComboBox comboBrand;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboColor;
        private System.Windows.Forms.Label lblCarId;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage Rentals;
        private System.Windows.Forms.DataGridView dataGridViewRent;
        private System.Windows.Forms.TabPage RentFun;
        private System.Windows.Forms.Button btnRentAdd;
        private System.Windows.Forms.Button btnRentCancel;
        private System.Windows.Forms.Button btnRentSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFinish;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnRentDelete;
        private System.Windows.Forms.Label lblRentID;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblPlate;
        private System.Windows.Forms.DataGridView dataGridViewRentByID;
        private System.Windows.Forms.Label lblCarYear;
        private System.Windows.Forms.Button btnHideFinished;
        private System.Windows.Forms.Button btnShowFinished;
        private System.Windows.Forms.Button btnSortRentalByCars;
        private System.Windows.Forms.TextBox txtColorBox;
    }
}

