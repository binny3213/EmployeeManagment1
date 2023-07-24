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
    public partial class Employees : Form
    {
        Functions Con;
       
        public Employees()
        {
            InitializeComponent();
            Con = new Functions();
            ShowEmp();
            GetDepartment();
        }

        private void ShowEmp()
        {
            string Query = " Select * from EmployeeTbl";
            EmployeeList.DataSource = Con.GetData(Query);
        }

        private void GetDepartment()
        {
            string Query = "Select * from DepartmentTbl";
            DepCb.DisplayMember = Con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text =="")
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue);
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "insert into EmployeeTbl values('{0}', '{1}' , {2} , '{3}', '{4}' , {5})";
                    Query = string.Format(Query, Name , Gender , Dep , DOB , JDate , Salary);
                    Con.SetDate(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Key == 0)
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    
                    string Query = "delete from EmployeeTbl where EmpId ={0}";
                    Query = string.Format(Query, Key);
                    Con.SetDate(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Deleted!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmpNameTb.Text == "" || GenCb.SelectedIndex == -1 || DepCb.SelectedIndex == -1 || DailySalTb.Text == "")
                {
                    MessageBox.Show("Missing Data!!");
                }
                else
                {
                    string Name = EmpNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    int Dep = Convert.ToInt32(DepCb.SelectedValue);
                    string DOB = DOBTb.Value.ToString();
                    string JDate = JDateTb.Value.ToString();
                    int Salary = Convert.ToInt32(DailySalTb.Text);
                    string Query = "Update EmployeeTbl set EmpName ='{0}', EmpGen = '{1}' , EmpDep = {2} , EmpDOB = '{3}', EmpJDate = '{4}' , EmpSal = {5} where EmpId ={6}";
                    Query = string.Format(Query, Name, Gender, Dep, DOB, JDate, Salary,Key);
                    Con.SetDate(Query);
                    ShowEmp();
                    MessageBox.Show("Employee Added!!!");
                    EmpNameTb.Text = "";
                    DailySalTb.Text = "";
                    GenCb.SelectedIndex = -1;
                    DepCb.SelectedIndex = -1;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int Key = 0;
        private void EmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpNameTb.Text = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            GenCb.Text = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            DepCb.SelectedValue = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            DOBTb.Text = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
            JDateTb.Text = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
            DailySalTb.Text = EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[6].Value.ToString();

            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeeList.Rows[EmployeeList.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Salaries Obj = new Salaries();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
