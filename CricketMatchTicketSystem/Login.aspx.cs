using CricketMatchTicketSystem.Biz.Interface;
using CricketMatchTicketSystem.Biz.Service;
using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketMatchTicketSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            UserViewModel vmModel = new UserViewModel();
            IUserService iUserService = new UserService();
            Response.Cookies["UserName"].Value = Username.Text.Trim();
            Response.Cookies["Password"].Value = password.Text.Trim();
            vmModel.Name = Username.Text.Trim();
            vmModel.Password = password.Text.Trim();
            bool msg = iUserService.LoginUser(vmModel);
            if (msg)
            {

                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}