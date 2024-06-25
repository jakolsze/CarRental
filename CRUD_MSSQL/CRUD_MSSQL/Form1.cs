using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Xml.Linq;

namespace CRUD_MSSQL
{
    public partial class Form1 : Form
    {
        //Database connection string, can be also done by ConfigurationManager.ConnectionString["ConnectDB"].ConnectionString
        string ConnectDB = "Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False";

        public Form1()
        {
            InitializeComponent();
            //Initial view, showing only login page
            tabControl.TabPages.Remove(Display);
            tabControl.TabPages.Remove(Functions);
            tabControl.TabPages.Remove(Rentals);
            tabControl.TabPages.Remove(RentFun);
            //Login confirmation button activating by pressing "Enter" key 
            this.AcceptButton = btnLoginOK;
            //Eventhandlers for invoking a method when a cell is selected
            this.dataGridViewCar.CellClick += new DataGridViewCellEventHandler(this.dataGridViewCar_CellClick);
            this.dataGridViewRent.CellClick += new DataGridViewCellEventHandler(this.dataGridViewRent_CellClick);
            //Eventhadnler for deselecting cell in dataGridView for rentals and cars when a cell was previously selected
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            //Disabling row creation, cells modifications and first row with arrow indicating selection from dataGridViews
            dataGridViewCar.RowHeadersVisible = false;
            dataGridViewCar.AllowUserToAddRows = false;
            dataGridViewCar.ReadOnly = true;
            dataGridViewRent.AllowUserToAddRows = false;
            dataGridViewRent.ReadOnly = true;
            dataGridViewRent.RowHeadersVisible = false;
            dataGridViewRentByID.AllowUserToAddRows = false;
            dataGridViewRentByID.ReadOnly = true;
            dataGridViewRentByID.RowHeadersVisible = false;
            //enabeling whole row selection for dataGridViews by clickng any cell
            dataGridViewCar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRent.MultiSelect = false;
            dataGridViewRent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRent.MultiSelect = false;
            dataGridViewRentByID.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRentByID.MultiSelect = false;
            //DateTimePicker in car creation/edition showing only year
            dtpCarYear.Format = DateTimePickerFormat.Custom;
            dtpCarYear.CustomFormat = "yyyy"; // This format will display only the year
            dtpCarYear.ShowUpDown = true;
        }
        //Methods to bind data to dataGridViews via DateTable dt
        void DataBind()
        {
            SqlConnection conn = new SqlConnection(ConnectDB);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Car", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewCar.DataSource = dt;
            dataGridViewCar.ClearSelection();
        }
        void DataBindRent(int selector)
        {
            string query;
            switch (selector) //allowes to change query for data retrival
            {
                case 1:
                    query = "SELECT R.ID, R.Start, R.Finish, C.Brand, C.Model, C.Color, C.Plate FROM Rent AS R INNER JOIN Car AS C ON R.Car_ID = C.Id";
                    break;
                case 2:
                    query = "SELECT R.ID, R.Start, R.Finish, C.Brand, C.Model, C.Color, C.Plate FROM Rent AS R INNER JOIN Car AS C ON R.Car_ID = C.Id WHERE finish > CAST(GETDATE()-1 AS DATE)";
                    break;
                case 3:
                    query = "SELECT R.ID, R.Start, R.Finish, C.Brand, C.Model, C.Color, C.Plate FROM Rent AS R INNER JOIN Car AS C ON R.Car_ID = C.Id ORDER BY Car_ID";
                    break;
                default:
                    query = "SELECT DATABASE ERROR!";
                    break;
            }
            SqlConnection conn = new SqlConnection(ConnectDB);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewRent.DataSource = dt;
            dataGridViewRent.ClearSelection();
        }
        void DataBindRentByID(int ID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectDB))
            {
                using (var command = new SqlCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "SELECT ID, Start, Finish FROM Rent WHERE Car_ID = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    command.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewRentByID.DataSource = dt;
                    dataGridViewRentByID.ClearSelection();
                }
            }
        }
        //Binding picture to picturebox corresponding to car brand taken from datagrid view
        void ShowPicture()
        {
            using (SqlConnection conn = new SqlConnection(ConnectDB))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT LogoData FROM Logo WHERE LogoName=@Value", conn))
                {
                    cmd.Parameters.AddWithValue("@Value", lblBrand.Text);
                    byte[] imageData = (byte[])cmd.ExecuteScalar();
                    if (imageData != null && imageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
            }
        }
        //Method for hashing a string with SHA256 algorithem
        public static string HashString(string inputString)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        //Method for login
        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            string hashedStrign = HashString(txtPassword.Text);
            string hashedPassword = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"; //admin
            if (hashedStrign == hashedPassword)
            {
                //Creating view after successful login
                tabControl.TabPages.Remove(Login);
                tabControl.TabPages.Add(Display);
                tabControl.TabPages.Add(Rentals);
                AcceptButton = null;
                //Invoking databinding for datagridviews
                DataBind();
                DataBindRent(1);
                ShowPicture();
            }
            else
                MessageBox.Show("Wrong password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Method for toggeling hide/show characters in inputed string
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
        //Methods for assigning values from datagridviews to label values (can be done with variables of course)
        private void dataGridViewCar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               if (dataGridViewCar.SelectedCells.Count > 0)
               {
                int rowindex = dataGridViewCar.CurrentCell.RowIndex;

                lblCarId.Text = dataGridViewCar.Rows[rowindex].Cells[0].Value.ToString();
                lblBrand.Text = dataGridViewCar.Rows[rowindex].Cells[1].Value.ToString();
                lblModel.Text = dataGridViewCar.Rows[rowindex].Cells[2].Value.ToString();
                lblColor.Text = dataGridViewCar.Rows[rowindex].Cells[3].Value.ToString();
                lblPlate.Text = dataGridViewCar.Rows[rowindex].Cells[4].Value.ToString();
                lblCarYear.Text = dataGridViewCar.Rows[rowindex].Cells[5].Value.ToString();

                txtColorBox.BackColor = Color.FromName(lblColor.Text);
               
                ShowPicture(); 
               }
        }
        private void dataGridViewRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRent.SelectedCells.Count > 0)
            {
                int rowindex = dataGridViewRent.CurrentCell.RowIndex;
                lblRentID.Text = dataGridViewRent.Rows[rowindex].Cells[0].Value.ToString();
            }
        }
        //Methods for showing funcions tab used to add / edit with default/taken values

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(Display);
            tabControl.TabPages.Remove(Rentals);
            tabControl.TabPages.Add(Functions);
            tabControl.TabPages[0].Text = btnAddNew.Text; //changes tab name, used later for determining function
            txtModel.Text = "";
            txtPlate.Text = "";
            comboBrand.SelectedIndex = -1;
            comboColor.SelectedIndex = -1;
            dtpCarYear.Value = new DateTime(2024, 1, 1); 
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblCarId.Text != "lblCarId")
            {
                tabControl.TabPages.Remove(Display);
                tabControl.TabPages.Remove(Rentals);
                tabControl.TabPages.Add(Functions);
                tabControl.TabPages[0].Text = btnEdit.Text; //changes tab name, used later for determining function
                txtModel.Text = lblModel.Text;
                txtPlate.Text = lblPlate.Text;
                comboBrand.SelectedIndex = comboBrandSelector(lblBrand.Text);
                comboColor.SelectedIndex = comboColorSelector(lblColor.Text);
                int yearFromLabel = int.Parse(lblCarYear.Text);
                dtpCarYear.Value = new DateTime(yearFromLabel, 1, 1);
            }
            else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Methods for Cancel/Save button functions in car Add/Edit. Cancel works the same for both, save changes depending on chosen function
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(Functions);
            tabControl.TabPages.Add(Display);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBrand.SelectedIndex != -1 && txtModel.Text != "" && comboColor.SelectedIndex != -1 && txtPlate.Text != "")
            {

                if (tabControl.TabPages[0].Text == "Add New")
                {
                    using (SqlConnection conn = new SqlConnection(ConnectDB))
                    {
                        using (var command = new SqlCommand())
                        {
                            conn.Open();
                            command.Connection = conn;
                            command.CommandText = "INSERT INTO Car VALUES (@brand, @model, @color, @plate, @year)";
                            command.Parameters.Add("@brand", SqlDbType.NVarChar).Value = (string)comboBrand.SelectedItem;
                            command.Parameters.Add("@model", SqlDbType.NVarChar).Value = (string)txtModel.Text;
                            command.Parameters.Add("@color", SqlDbType.NVarChar).Value = (string)comboColor.SelectedItem;
                            command.Parameters.Add("@plate", SqlDbType.NVarChar).Value = (string)txtPlate.Text;
                            command.Parameters.Add("@year", SqlDbType.Int).Value = (int)dtpCarYear.Value.Year;
                            command.ExecuteNonQuery();
                        }

                    }
                }
                else if (tabControl.TabPages[0].Text == "Edit")
                {
                    using (SqlConnection conn = new SqlConnection(ConnectDB))
                    {
                        using (var command = new SqlCommand())
                        {
                            conn.Open();
                            command.Connection = conn;
                            command.CommandText = @"UPDATE Car 
                                    set Brand=@brand,Model=@model,Color=@color, Plate=@plate, Year=@year  
                                    where Id=@id";
                            command.Parameters.Add("@brand", SqlDbType.NVarChar).Value = (string)comboBrand.SelectedItem;
                            command.Parameters.Add("@model", SqlDbType.NVarChar).Value = (string)txtModel.Text;
                            command.Parameters.Add("@color", SqlDbType.NVarChar).Value = (string)comboColor.SelectedItem;
                            command.Parameters.Add("@plate", SqlDbType.NVarChar).Value = (string)txtPlate.Text;
                            command.Parameters.Add("@year", SqlDbType.Int).Value = (int)dtpCarYear.Value.Year;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(lblCarId.Text);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                tabControl.TabPages.Remove(Functions);
                tabControl.TabPages.Add(Display);
                tabControl.TabPages.Add(Rentals);
                tabControl.SelectedTab = Display;
                SelectionClearCars();
            }
            else MessageBox.Show("You need to complete every field", "Field Completion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Method for deleting an entry in table Car
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCarId.Text != "lblCarId")
                {
                    using (SqlConnection conn = new SqlConnection(ConnectDB))
                    {
                        using (var command = new SqlCommand())
                        {
                            conn.Open();
                            command.Connection = conn;
                            command.CommandText = "DELETE FROM Car WHERE id = @id";
                            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(lblCarId.Text);
                            command.ExecuteNonQuery();
                        }

                    }
                    SelectionClearCars();
                }
                else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("You cannot delete rented car", "Car Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Method creating a view for adding new rent entity
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCarId.Text != "lblCarId")
            {
                tabControl.TabPages.Remove(Display);
                tabControl.TabPages.Remove(Rentals);
                tabControl.TabPages.Add(RentFun);
                DataBindRentByID(int.Parse(lblCarId.Text));
            }
        }
        //Methods for cancel and save buttons for creating rent entities
        private void btnRentCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Add(Display);
            tabControl.TabPages.Add(Rentals);
            tabControl.TabPages.Remove(RentFun);
        }

        private void btnRentSave_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value < dtpFinish.Value)
            {
                bool check = CreateArrayPickedDate().Any(element => CreateArrayExsistingRents().Contains(element)); //checks if any of the dates in chosen range of dates occures in the table already, preventing overbooking
                if (!check)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectDB))
                    {
                        using (var command = new SqlCommand())
                        {
                            conn.Open();
                            command.Connection = conn;
                            command.CommandText = "INSERT INTO Rent VALUES (@car_id, @start, @finish)";
                            command.Parameters.Add("@car_id", SqlDbType.Int).Value = int.Parse(lblCarId.Text);
                            command.Parameters.Add("@start", SqlDbType.Date).Value = dtpStart.Value;
                            command.Parameters.Add("@finish", SqlDbType.Date).Value = dtpFinish.Value;
                            command.ExecuteNonQuery();
                            tabControl.TabPages.Add(Display);
                            tabControl.TabPages.Add(Rentals);
                            tabControl.TabPages.Remove(RentFun);
                            tabControl.SelectedTab = Rentals;
                            DataBindRent(1);
                            SelectionClearCars();
                        }
                    }
                }
            else MessageBox.Show("The car is not aviable in chosen date", "Rent date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         else MessageBox.Show("Rent start date cannot be after rent finish date", "Rent time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRentDelete_Click(object sender, EventArgs e)
        {
            if (lblRentID.Text != "lblRentID")
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB))
                {
                    using (var command = new SqlCommand())
                    {
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = "DELETE FROM Rent WHERE id = @id";
                        command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(lblRentID.Text);
                        command.ExecuteNonQuery();
                    }
                }
                SelectionClearRents();
            }
            else MessageBox.Show("You need to choose a rental", "Rent Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // Method for creating an array of dates betweewn dates in column start and finish in the table for each row, then combining those arrays into one
        private List<DateTime> CreateArrayExsistingRents()
        {
            List<DateTime> dateArray = new List<DateTime>();
            List<DateTime> dateArrayCombined = new List<DateTime>();
            //Collecting data from the gridview for each row
            for (int i = 0; i < dataGridViewRentByID.Rows.Count; i++)
            {
                DateTime startDate = DateTime.Parse(dataGridViewRentByID.Rows[i].Cells[1].Value.ToString());
                DateTime endDate = DateTime.Parse(dataGridViewRentByID.Rows[i].Cells[2].Value.ToString());
                // Creating an array with dates between taken dates  
                DateTime currentDate = startDate;
                while (currentDate <= endDate)
                {
                    dateArray.Add(currentDate);
                    currentDate = currentDate.AddDays(1);
                }
                dateArrayCombined.AddRange(dateArray); //combining arrays
            }
            return dateArrayCombined;
        }
        // Method for creating an array of dates betweewn chosen dates via datetimepicker
        private List<DateTime> CreateArrayPickedDate()
        {
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpFinish.Value.Date;

            List<DateTime> dateArray = new List<DateTime>();
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                dateArray.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }
            return dateArray;
        }
        //Methods for setting defalut values when editing a car entry
        private int comboBrandSelector(string Selector)
        {
            switch(Selector)
            {
                case "Toyota":
                    return 0;
                case "Opel":
                    return 1;
                case "Mercedes":
                    return 2;
                case "Lexus":
                    return 3;
                case "Audi":
                    return 4;
                default:
                    return -1;
            }
        }
        private int comboColorSelector(string Selector)
        {
            switch (Selector)
            {
                case "Black":
                    return 0;
                case "White":
                    return 1;
                case "Silver":
                    return 2;
                case "Red":
                    return 3;
                case "Blue":
                    return 4;
                case "Green":
                    return 4;
                case "Yellow":
                    return 4;
                case "Beige":
                    return 4;
                default:
                    return -1;
            }
        }
        //Methods for invoikng data bind with filters: hiding/showing rents with finish date equal to yesterdays date and sorting 
        private void btnHideFinished_Click(object sender, EventArgs e)
        {
            DataBindRent(2);
        }
        private void btnShowFinished_Click(object sender, EventArgs e)
        {
            DataBindRent(1);
        }
        private void btnSortRentalByCars_Click(object sender, EventArgs e)
        {
            DataBindRent(3);
        }
        //Methods for clearing labels after completeng a function
        private void SelectionClearCars()
        {
            lblCarId.Text = "lblCarId";
            lblBrand.Text = "";
            DataBind();
            txtColorBox.BackColor = Color.WhiteSmoke;
            pictureBox1.Image = null;
        }
        private void SelectionClearRents()
        {
            lblRentID.Text = "lblRentID";
            DataBindRent(1);
        }
        //Method for clearing cell selection and image shown after changing a tab in view
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewRent.ClearSelection();
            dataGridViewCar.ClearSelection();
            txtColorBox.BackColor = Color.WhiteSmoke;
            pictureBox1.Image = null;
        }
    }
}
