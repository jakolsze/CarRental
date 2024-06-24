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

namespace CRUD_MSSQL
{
    public partial class Form1 : Form
    {
        string ConnectDB = "Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"; //can be also done by ConfigurationManager.ConnectionString["ConnectDB"].ConnectionString

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnLoginOK;
            tabControl.TabPages.Remove(Display);
            tabControl.TabPages.Remove(Functions);
            tabControl.TabPages.Remove(Rentals);
            tabControl.TabPages.Remove(RentFun);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridViewRent.CellClick += new DataGridViewCellEventHandler(this.dataGridViewRent_CellClick);

            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = dataGridView1.DefaultCellStyle.ForeColor;
            dataGridViewRent.DefaultCellStyle.SelectionBackColor = dataGridViewRent.DefaultCellStyle.BackColor;
            dataGridViewRent.DefaultCellStyle.SelectionForeColor = dataGridViewRent.DefaultCellStyle.ForeColor;
            dataGridView1.AllowUserToAddRows = false;
            dataGridViewRent.AllowUserToAddRows = false;
            dataGridViewRentByID.AllowUserToAddRows = false;

            dtpCarYear.Format = DateTimePickerFormat.Custom;
            dtpCarYear.CustomFormat = "yyyy"; // This format will display only the year
            dtpCarYear.ShowUpDown = true;
        }
              
        void DataBind()
        {
            SqlConnection conn = new SqlConnection(ConnectDB);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Car", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void DataBindRent(int selector)
        {
            string query;
            switch (selector)
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

        }
        void DataBindRentByID(int ID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectDB))
            {
                using (var command = new SqlCommand())
                {
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = "SELECT * FROM Rent WHERE Car_ID = @id";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    command.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewRentByID.DataSource = dt;
                }
            }
        }

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
        void ShowPicture()
        {
            // Assuming 'connectionString' is your SQL Server connection string
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
        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            string hashedStrign = HashString(txtPassword.Text);
            string hashedPassword = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"; //admin
            if (hashedStrign == hashedPassword)
            {
                DataBind();
                DataBindRent(1);
                ShowPicture();
                tabControl.TabPages.Remove(Login);
                tabControl.TabPages.Add(Display);
                tabControl.TabPages.Add(Rentals);
                this.AcceptButton = null;

            }
            else
                MessageBox.Show("Wrong password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
               if (dataGridView1.SelectedCells.Count > 0)
               {
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Blue;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                int rowindex = dataGridView1.CurrentCell.RowIndex;

                lblCarId.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                lblBrand.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                lblModel.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
                lblColor.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
                lblPlate.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
                lblCarYear.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();

                txtColorBox.BackColor = Color.FromName(lblColor.Text);
               
                ShowPicture(); 
               }
            
        }
        private void dataGridViewRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewRent.SelectedCells.Count > 0)
            {
                dataGridViewRent.DefaultCellStyle.SelectionBackColor = Color.Blue;
                dataGridViewRent.DefaultCellStyle.SelectionForeColor = Color.White;
                int rowindex = dataGridViewRent.CurrentCell.RowIndex;
                lblRentID.Text = dataGridViewRent.Rows[rowindex].Cells[0].Value.ToString();
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(Display);
            tabControl.TabPages.Remove(Rentals);
            tabControl.TabPages.Add(Functions);
            tabControl.TabPages[0].Text = btnAddNew.Text;
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
                tabControl.TabPages[0].Text = btnEdit.Text;
                txtModel.Text = lblModel.Text;
                txtPlate.Text = lblPlate.Text;
                comboBrand.SelectedIndex = comboBrandSelector(lblBrand.Text);
                comboColor.SelectedIndex = comboColorSelector(lblColor.Text);
                int yearFromLabel = int.Parse(lblCarYear.Text);
                dtpCarYear.Value = new DateTime(yearFromLabel, 1, 1);

            }
            else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try {
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
                    SelectionClear();
                }
                else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            catch
            {
            MessageBox.Show("You cannot delete rented car", "Car Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(Functions);
            tabControl.TabPages.Add(Display);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBrand.SelectedIndex != -1 && txtModel.Text != null && comboColor.SelectedIndex != -1 && txtPlate.Text != null)
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
                SelectionClear();
            }
            else MessageBox.Show("You need to complete every field", "Field Completion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCarId.Text != "lblCarId")
            {
                tabControl.TabPages.Remove(Display);
                tabControl.TabPages.Remove(Rentals);
                tabControl.TabPages.Add(RentFun);
                //DataBindRentByID();
                DataBindRentByID(int.Parse(lblCarId.Text));
            }
        }

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
                int check = AviableCheck();
                if (check == 0)
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
                            AviableCheck();
                            DataBindRent(1);

                        }
                    }
                }
            else MessageBox.Show("The car is not aviable in the date: "+lblCheck.Text, "Rent date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblRentID.Text = "lblRentID";
                DataBindRent(1);
                dataGridViewRent.ClearSelection();
            }
            else MessageBox.Show("You need to choose a rental", "Rent Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int AviableCheck()
        {
            int flag = 0;
            int flag2 = 0;
            // Przykładowe daty pobrane z DateTimePicker
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpFinish.Value.Date;

            // Tworzenie tablicy z datami między startDate a endDate
            List<DateTime> dateArray = new List<DateTime>();
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                dateArray.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }
            foreach (DateTime date in dateArray)
            {
               flag = CheckDataGrid(date);
                if (flag == 1)
                    flag2 = 1;
                lblCheck.Text = date.ToShortDateString();
            }
            return flag2;
        }
        private bool IsValueInDataGridView(DataGridView dataGridView, DateTime valueToCheck)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.Equals(valueToCheck))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private int CheckDataGrid(DateTime a)
        {
            // Przykładowe wartości

            DateTime valueToFind = a;
            int flag = 0;

            bool found = IsValueInDataGridView(dataGridViewRentByID, valueToFind);
            if (found)
            {
                Console.WriteLine($"Value :{valueToFind} found.");
                flag = 1;
            }
            else
            {
                Console.WriteLine($"Value: {valueToFind} not found");
            }
            Console.WriteLine($"Flag:{flag}");
            return flag;
        }

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

        private void btnHideFinished_Click(object sender, EventArgs e)
        {
            DataBindRent(2);
        }

        private void btnShowFinished_Click(object sender, EventArgs e)
        {
            DataBindRent(1);
        }
        private void SelectionClear()
        {
            lblCarId.Text = "lblCarId";
            DataBind();
            dataGridView1.ClearSelection();
        }

        private void btnSortRentalByCars_Click(object sender, EventArgs e)
        {
            DataBindRent(3);
        }
    }
}
