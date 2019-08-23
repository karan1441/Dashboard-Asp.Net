using System;  
using System.Collections.Generic;  
using System.Configuration;  
using System.Data;  
using System.Linq;  
using System.Web;  
using System.Web.UI;  
using System.Web.UI.WebControls;  
using MySql.Data.MySqlClient;  
  
  
namespace MYSQLCRUDApplication  
{  
    public partial class Student : System.Web.UI.Page  
    {  
        #region MySqlConnection Connection and Page Lode  
        MySqlConnection conn = new  
MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);          
        protected void Page_Load(object sender, EventArgs e)  
        {  
            Try  
            {  
                if (!Page.IsPostBack)  
                {  
                    BindGridView();  
                      
                }  
            }  
            catch (Exception ex)  
            {  
                ShowMessage(ex.Message);  
            }  
        }  
        #endregion  
        #region show message  
        /// <summary>  
        /// This function is used for show message.  
        /// </summary>  
        /// <param name="msg"></param>  
        void ShowMessage(string msg)  
        {  
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  
language='javascript'>alert('" + msg + "');</script>");  
        }  
        /// <summary>  
        /// This Function is used TextBox Empty.  
        /// </summary>  
        void clear()  
        {  
            txtName.Text = string.Empty; txtAddress.Text = string.Empty; txtMobile.Text = string.Empty;  
txtEmail.Text = string.Empty;  
            txtName.Focus();  
        }  
        #endregion  
        #region bind data to GridViewStudent  
        private void BindGridView()  
        {   
            Try  
            {  
                if (conn.State == ConnectionState.Closed)  
                {  
                    conn.Open();  
                }  
                MySqlCommand cmd = new MySqlCommand("Select * from Student ORDER BY SID DESC;",  
conn);  
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);  
                DataSet ds = new DataSet();  
                adp.Fill(ds);  
                GridViewStudent.DataSource = ds;  
                GridViewStudent.DataBind();  
                lbltotalcount.Text = GridViewStudent.Rows.Count.ToString();  
            }  
            catch (MySqlException ex)  
            {  
                ShowMessage(ex.Message);  
            }  
            Finally  
            {  
                if (conn.State == ConnectionState.Open)  
                {  
                   conn.Close();  
                }  
            }  
        }  
        #endregion  
        #region Insert Data  
        /// <summary>  
        /// this code used to Student Data insert in MYSQL Database  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        protected void btnSubmit_Click(object sender, EventArgs e)  
        {  
            Try  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("Insert into student (Name,Address,Mobile,Email )  
values (@Name,@Address,@Mobile,@Email)", conn);  
                cmd.Parameters.AddWithValue("@Name",txtName.Text);  
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);  
                cmd.Parameters.AddWithValue("@Mobile",txtMobile.Text);  
                cmd.Parameters.AddWithValue("@Email",txtEmail.Text);  
                cmd.ExecuteNonQuery();                 
                cmd.Dispose();   
                ShowMessage("Registered successfully......!");               
                clear();  
                BindGridView();  
            }  
            catch (MySqlException ex)  
            {  
                ShowMessage(ex.Message);  
            }  
            Finally  
            {  
                conn.Close();  
            }  
        }  
          
        #endregion   
        #region SelectedIndexChanged  
        /// <summary>  
        /// this code used to GridViewRow SelectedIndexChanged value show textbox  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        protected void GridViewStudent_SelectedIndexChanged(object sender, EventArgs e)  
        {  
            GridViewRow row = GridViewStudent.SelectedRow;  
            lblSID.Text = row.Cells[2].Text;  
            txtName.Text = row.Cells[3].Text;  
            txtAddress.Text = row.Cells[4].Text;  
            txtEmail.Text = row.Cells[5].Text;  
            txtMobile.Text = row.Cells[6].Text;  
            btnSubmit.Visible = false;  
            btnUpdate.Visible = true;  
        }  
        #endregion  
        #region Delete Student Data  
        /// <summary>  
        /// This code used to GridViewStudent_RowDeleting Student Data Delete  
        /// </summary>  
        /// <param name="sender"></param>  
        /// <param name="e"></param>  
        protected void GridViewStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)  
        {  
            Try  
            {  
                conn.Open();  
                int SID = Convert.ToInt32(GridViewStudent.DataKeys[e.RowIndex].Value);  
                MySqlCommand cmd = new MySqlCommand("Delete From student where SID='" + SID + "'",  
conn);  
                cmd.ExecuteNonQuery();  
                cmd.Dispose();  
                ShowMessage("Student Data Delete Successfully......!");  
                GridViewStudent.EditIndex = -1;  
                BindGridView();  
            }  
            catch (MySqlException ex)  
            {  
                ShowMessage(ex.Message);  
            }  
            Finally  
            {  
                conn.Close();  
            }  
        }  
        #endregion  
        #region student data update  
        /// <summary>  
        /// This code used to student data update  
        /// </summary>  
        /// <param name="sender"></param>  
       /// <param name="e"></param>  
        protected void btnUpdate_Click(object sender, EventArgs e)  
        {  
            Try  
            {  
                conn.Open();  
                string SID = lblSID.Text;                
                MySqlCommand cmd = new MySqlCommand("update student Set  
Name=@Name,Address=@Address,Mobile=@Mobile,Email=@Email where SID=@SID", conn);  
                cmd.Parameters.AddWithValue("@Name", txtName.Text);  
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);  
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);  
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);  
                cmd.Parameters.AddWithValue("SID",SID);  
                cmd.ExecuteNonQuery();  
                cmd.Dispose();  
                ShowMessage("Student Data update Successfully......!");  
                GridViewStudent.EditIndex = -1;  
                BindGridView(); btnUpdate.Visible = false;  
            }  
            catch (MySqlException ex)  
            {  
                ShowMessage(ex.Message);  
            }  
            Finally  
            {  
                conn.Close();  
            }  
        }  
        #endregion  
        #region textbox clear  
        protected void btnCancel_Click(object sender, EventArgs e)  
        {  
            clear();  
        }  
        #endregion  
    }  
}   
Now run the page,
