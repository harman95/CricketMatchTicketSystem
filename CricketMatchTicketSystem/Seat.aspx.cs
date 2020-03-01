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
    public partial class Seat : System.Web.UI.Page
    {
        ISeatService iSeatService = new SeatService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SeatViewModel seatViewModel = new SeatViewModel();
            seatViewModel.SeatNumber = Convert.ToInt32(SeatNumber.Text);
            seatViewModel.SeatSide = SeatSide.Text;

            if (HiddenField1.Value != "")
                seatViewModel.ID = Convert.ToInt32(HiddenField1.Value);
            seatViewModel = iSeatService.AddAndUpdate(seatViewModel);
            if (seatViewModel.ID > 0)
            {
                Response.Write("<script>alert('Record saved successfully')</script>");
                Response.Redirect("Ticket.aspx");
            }
            bindGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            string id = this.grd.DataKeys[rowIndex]["ID"].ToString();
            if (e.CommandName == "updates")
            {
                DataTableConversion lsttodt = new DataTableConversion();
                var lst = iSeatService.GetByID(Convert.ToInt32(id));
                DataTable dt = lsttodt.ToDataTable(lst);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HiddenField1.Value = dt.Rows[0]["ID"].ToString();
                    SeatNumber.Text = dt.Rows[0]["SeatNumber"].ToString();
                    SeatSide.Text = dt.Rows[0]["SeatSide"].ToString();
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
                bool result = iSeatService.Delete(Convert.ToInt32(id));
                if (result)
                {
                    bindGrid();

                }
            }
        }
        protected void bindGrid()
        {
            DataTableConversion lsttodt = new DataTableConversion();
            var lst = iSeatService.Lists();
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

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Seat.aspx");
        }
    }
}