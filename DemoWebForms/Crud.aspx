<%@ Page Language="C#" Title="CRUD" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="DemoWebForms.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <div class="container-fluid">
            <div class="row">
                <div class="col-4">
                    <table>
                        <thead>
                            <tr>
                                <td>
                                    <label class="form-label">Enter Table Name</label></td>
                                <td>
                                    <asp:TextBox ID="tableName" class="form-control" runat="server" Width="137px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="form-label">Enter Column Name</label></td>
                                <td>
                                    <asp:TextBox ID="columnName" class="form-control" runat="server" Width="138px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="form-label">Enter Type</label></td>
                                <td>
                                    <asp:TextBox ID="dataType" class="form-control" runat="server" Width="133px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Create" OnClick="Button1_Click" Width="73px" />
                                </td>
                            </tr>
                        </thead>

                    </table>
                </div>
                <div class="col-4">
                    <div class="col">
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Department"></asp:Label>
                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                            <table>
                                <thead>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button2" runat="server" Text="Create" OnClick="Add_Record" CssClass="btn btn-outline-success" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button4" runat="server" Text="Update" OnClick="Update_Record" CssClass="btn btn-outline-info" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button5" runat="server" Text="Delete" OnClick="Delete_Record" CssClass="btn btn-outline-danger" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button3" runat="server" Text="Get" OnClick="Get_Record" CssClass="btn btn-outline-warning" />
                                        </td>
                                    </tr>
                                </thead>
                            </table>
                            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" CssClass="table table-striped table-bordered">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

