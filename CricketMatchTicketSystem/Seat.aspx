<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seat.aspx.cs" Inherits="CricketMatchTicketSystem.Seat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class=" col-md-12">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <div class="form-group">
                <label for="exampleInputName">Seat Number <span style="color: red;">*</span></label>
                <asp:TextBox ID="SeatNumber" class="form-control" runat="server" placeholder=" Seat Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumber" ValidationGroup="Save" runat="server" ControlToValidate="SeatNumber" ErrorMessage="Please enter seat number" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class=" col-md-12">
            <div class="form-group">
                <label for="exampleInputPrice">Seat Side <span style="color: red;">*</span></label>
                <asp:TextBox ID="SeatSide" class="form-control" runat="server" placeholder="Seat Side"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Save" runat="server" ControlToValidate="SeatSide" ErrorMessage="Please enter seat side" ForeColor="#993333"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class=" col-md-6">
            <asp:Button ID="Submit" class="btn btn-primary" ValidationGroup="Save" runat="server" Text="Submit" OnClick="Submit_Click" />
            <asp:Button ID="Reset" class="btn btn-danger" runat="server" Text="Reset" OnClick="Reset_Click" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">

            <asp:GridView ID="grd" runat="server" CssClass="table table-striped table-bordered table-hover"
                AutoGenerateColumns="false" EmptyDataText="No Record Found" DataKeyNames="ID"
                AllowPaging="false" PageSize="10" OnRowCommand="grd_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                           Seat Number
                           
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="butType" runat="server" CommandName="updates" Text='<%# Eval("SeatNumber") %>' CommandArgument="<%#((GridViewRow)Container).RowIndex%>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SeatSide" HeaderText="Seat Side" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="butEnable" runat="server" class="btn btn-warning btn-xs" CommandName="enable" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" Text="Delete"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
