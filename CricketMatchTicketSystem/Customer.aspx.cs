using CricketMatchSeatSystem.Biz.Service;
using CricketMatchTicketSystem.Biz.Interface;
using CricketMatchTicketSystem.Biz.Service;
using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CricketMatchTicketSystem
{
    public partial class Customer : System.Web.UI.Page
    {
        ICustomerService iCustomerService = new CustomerService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
                bindSeatList();
                bindTicketList();
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            CustomerViewModel vmModel = new CustomerViewModel();
            vmModel.TicketID = Convert.ToInt32(TicketID.Text);
            vmModel.SeatID = Convert.ToInt32(SeatID.Text);
            vmModel.Name = Name.Text;
            vmModel.MobileNumber = MobileNumber.Text;
            vmModel.EmailID = Email.Text;
            //vmModel.HireDate = Convert.ToDateTime(HireDate.Text);
            if (HiddenField1.Value != "")
                vmModel.ID = Convert.ToInt32(HiddenField1.Value);
            vmModel = iCustomerService.AddAndUpdate(vmModel);
            if (vmModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Customer.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //EmployeeModel vmModel = new EmployeeModel();
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            //vmModel.ID = Convert.ToInt32(id);
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iCustomerService.GetByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    TicketID.Text = dt.Rows[0]["TicketID"].ToString();
                    SeatID.Text = dt.Rows[0]["SeatID"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    MobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();
                    Email.Text = dt.Rows[0]["EmailID"].ToString();
                    //HireDate.Text = dt.Rows[0]["HireDate"].ToString();
                    //Salary.Text = dt.Rows[0]["Salary"].ToString();
                    Submit.Text = "Update";

                }
                else
                {
                    Submit.Text = "Save";
                }
            }
            else
            {
                DataTable dt = new DataTable();
                bool result = iCustomerService.Delete(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iCustomerService.Lists();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                grd.DataSource = dt;
                grd.DataBind();
            }
            else
            {
                grd.DataBind();
            }
        }
        protected void bindTicketList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            ITicketService service = new TicketService();
            var lst = service.Lists().Select(x => new { Name = x.Number + " " + x.Price , x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                TicketID.DataSource = dt;
                TicketID.DataTextField = "Name";
                TicketID.DataValueField = "ID";
                TicketID.DataBind();

            }
            else
            {
                TicketID.DataBind();
            }
        }
        protected void bindSeatList()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            ISeatService service = new SeatService();
            var lst = service.Lists().Select(x => new { Name = x.SeatNumber + " " + x.SeatSide, x.ID }).ToList();
            DataTable dt = lsttodt.ToDataTable(lst);
            if (dt != null && dt.Rows.Count > 0)
            {
                SeatID.DataSource = dt;
                SeatID.DataTextField = "Name";
                SeatID.DataValueField = "ID";
                SeatID.DataBind();

            }
            else
            {
                SeatID.DataBind();
            }
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Customer.aspx");
        }

    }
}