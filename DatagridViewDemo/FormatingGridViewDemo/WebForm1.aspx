<%@ Page Culture="en-IN" Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DatagridViewDemo.FormatingGridViewDemo.WebForm1" %>
<%--we can add culture attribute in page directives to get Rupees Symbol in Salary--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LinqDemoConnectionString %>" SelectCommand="SELECT * FROM [tblEmployeeDataGrid]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId" DataSourceID="SqlDataSource1">
            <Columns>
                 <%--hiding Id field by making Visible ="false"--%>
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" InsertVisible="False" Visible="false" ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="Last Name" />


                <%--we can format date pattern by using DataFormatString Attribute--%>
                <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" DataFormatString="{0:d}" />
                
                <%--it will show the currency symbol according to culture set in our PC.We can overwrite it by Specifying Culture attribute--%> 
                <asp:BoundField DataField="AnnualSalary" HeaderText="AnnualSalary" SortExpression="Annual Salary" DataFormatString="{0:c}" />
                 <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                 <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="Department Name" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
