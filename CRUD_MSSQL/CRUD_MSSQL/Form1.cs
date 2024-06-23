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
using System.Reflection;

namespace CRUD_MSSQL
{
    public partial class Form1 : Form
    {
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
           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy"; // This format will display only the year
            dateTimePicker1.ShowUpDown = true;


        }

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False");

        void DataBind()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Car", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void DataBindRent()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False");
            SqlCommand cmd = new SqlCommand("SELECT R.ID, R.Start, R.Finish, C.Brand, C.Model, C.Color, C.Plate FROM Rent AS R INNER JOIN Car AS C ON R.Car_ID = C.Id", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridViewRent.DataSource = dt;

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
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
            string hashedPassword = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
            if (hashedStrign == hashedPassword)
            {
                DataBind();
                DataBindRent();
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

                lblColor.ForeColor=lblColor.BackColor = Color.FromName(lblColor.Text);
                labelColor.Visible=true;
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

        private void btnUnhidePassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lblCarId != null)
            {
                tabControl.TabPages.Remove(Display);
                tabControl.TabPages.Remove(Rentals);
                tabControl.TabPages.Add(Functions);
                tabControl.TabPages[0].Text = btnEdit.Text;
                txtModel.Text = lblModel.Text;
                txtPlate.Text = lblPlate.Text;

            }
            else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblCarId != null)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
                DataBind();
            }
            else MessageBox.Show("You need to choose a car", "Car Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(Functions);
            tabControl.TabPages.Add(Display);
            comboBrand.SelectedIndex = -1;
            comboColor.SelectedIndex = -1;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBrand.SelectedIndex != -1 && txtModel.Text != null && comboColor.SelectedIndex != -1 && txtPlate.Text != null)
            {

                if (tabControl.TabPages[0].Text == "Add New")
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
                            command.Parameters.Add("@year", SqlDbType.Int).Value = (int)dateTimePicker1.Value.Year;
                            command.ExecuteNonQuery();
                        }

                    }
                }
                else if (tabControl.TabPages[0].Text == "Edit")
                {
                    using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
                            command.Parameters.Add("@year", SqlDbType.Int).Value = (int)dateTimePicker1.Value.Year;
                            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(lblCarId.Text);
                            command.ExecuteNonQuery();
                        }

                    }
                }
                tabControl.TabPages.Remove(Functions);
                tabControl.TabPages.Add(Display);
                DataBind();
            }
            else MessageBox.Show("You need to complete every field", "Field Completion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCarId != null)
            {
                tabControl.TabPages.Remove(Display);
                tabControl.TabPages.Remove(Rentals);
                tabControl.TabPages.Add(RentFun);
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
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
                        DataBindRent();
                        
                    }
                }
            }
            else MessageBox.Show("Rent start date cannot be after rent finish date", "Rent time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnRentDelete_Click(object sender, EventArgs e)
        {
            if (lblRentID != null)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=CarsDB;Integrated Security=True;Encrypt=False"))
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
                DataBindRent();
            }
            else MessageBox.Show("You need to choose a rental", "Rent Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
