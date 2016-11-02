<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="Week6.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Student Details</h1>


    <div class="form-group">
        <label for="txtLastName" class="col-sm-3 control-label">Last Name :</label>
        <asp:TextBox ID="txtLastName" runat="server" CssClass="col-sm-3 form-control" required />
    </div>

    <div class="form-group">
        <label for="txtFirstName" class="col-sm-3 control-label">First Name :</label>
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="col-sm-3 form-control" required />
    </div>

    <div class="form-group">
        <label for="txtEnrollDate" class="col-sm-3 control-label">Enrollment Date :</label>
        <asp:TextBox ID="txtEnrollDate" runat="server" CssClass="col-sm-3 form-control" type="date" required />
    </div>

    <asp:Button ID="btnSave" runat="server" CssClass="col-sm-offset-3 btn btn-primary"  Text="Save" OnClick="btnSave_Click" />
    <asp:label ID="lblError" runat="server" text="Someting Went wrong Please try again later!" CssClass="label-danger" Visible="false"></asp:label>

</asp:Content>
