<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DatagridViewDemo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en-us">
<head runat="server">
    <title>DataGridViewDemo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ObjectDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllStudents" TypeName="DatagridViewDemo.DataAccessLayer"></asp:ObjectDataSource>
    
        <br />
        <br />
        Xml DataSourceDemo<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Data/Countries1.xml"></asp:XmlDataSource>
        <br />
        Binding the Countries1.xml file to gridview control
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
            </Columns>
        </asp:GridView>
        <br />
        Binding the Countries.xml file to gridview control through xslt mapping<br />
        <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/Data/Countries.xml" TransformFile="~/Data/CountriesXSLT.xslt"></asp:XmlDataSource>
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="XmlDataSource2">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Continent" HeaderText="Continent" SortExpression="Continent" />
            </Columns>
        </asp:GridView>
        <br />
    
    </div>
        <p>
            loading xml file through dataset<asp:GridView ID="GridView4" runat="server">
            </asp:GridView>
        </p>
    </form>
</body>
</html>
