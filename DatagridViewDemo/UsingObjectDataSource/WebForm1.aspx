<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DatagridViewDemo.UsingObjectDataSource.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getAllDeparment" TypeName="DatagridViewDemo.UsingObjectDataSource.DataAccessLayer.DepartmentDataAccessLayer"></asp:ObjectDataSource>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="DepartmentName" DataValueField="ID">
        </asp:DropDownList>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" ItemStyle-CssClass="DisplayClass" HeaderStyle-CssClass="DisplayClass" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                
                <asp:BoundField DataField="DepartmentName" HeaderText="DepartmentName" SortExpression="DepartmentName" />
                <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            </Columns>
        </asp:GridView>

         <%-- To enable conflict detection
             we need to specify prefix string used before fields names in "oldValuesParameterFormatString" 
           & and also ConflictDetection method.--%>


        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAllEmployeeByDeparmentId" TypeName="DatagridViewDemo.UsingObjectDataSource.DataAccessLayer.EmployeeDataAccessLayer" 
            DeleteMethod="deleteEmployeeRecord" OldValuesParameterFormatString="orignal_{0}" ConflictDetection="CompareAllValues" >
            <DeleteParameters>
                <asp:Parameter Name="orignal_ID" Type="Int32" />
                <asp:Parameter Name="orignal_FirstName" Type="String" />
                <asp:Parameter Name="orignal_LastName" Type="String" />
                <asp:Parameter Name="orignal_Salary" Type="String" />
                <asp:Parameter Name="orignal_DepartmentName" Type="String" />
                <asp:Parameter Name="orignal_Gender" Type="String" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="DeptId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
