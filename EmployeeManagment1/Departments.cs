using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagment1
{
    public partial class Departments : Form
    {
        Functions Con;
        public Departments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowDepartments();
        }

     
        private void ShowDepartments()
        {
            string Query = " Select * from DepartmentTbl";
            DepList.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(DepNameTb.Text=="")
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "insert into DepartmentTbl values('{0}')";
                    Query = string.Format(Query,DepNameTb.Text);
                    Con.SetDate(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added!!!");
                    DepNameTb.Text = "";
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        int Key = 0;
        private void DepList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DepNameTb.Text = DepList.Rows[DepList.SelectedCells[0].RowIndex].Cells[1].Value.ToString();

            if (DepNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                //error cause(took me a while to figure): they used a different object with different format so the
                // way i approached to elements wasnt currect. i had to use a different way with the object i am using
                // so i googled it and found out the way to approach the elements. Also i understood better what was happening
                // beacuse it wasnt so clear since its a video without a guide explaining it. 
                Key = Convert.ToInt32(DepList.Rows[DepList.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Update DepartmentTbl set DepName = '{0}' where DepId = {1}";
                    Query = string.Format(Query, DepNameTb.Text, Key);
                    Con.SetDate(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated!!!");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DepNameTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    string Dep = DepNameTb.Text;
                    string Query = "Delete from DepartmentTbl where DepId = {0}";
                    Query = string.Format(Query, Key);
                    Con.SetDate(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted!!!");
                    DepNameTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void EmpLbl_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void SalaryLbl_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }
    }
}
