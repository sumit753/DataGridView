<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DatagridViewDemo.EditUpdating_SqlDataSource_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />

                <%--if we want to store empty string instead of null then
                    set ConvertEmptyStringToNull to false in boundfield as well as in Update Parameter tag
                    --%>

                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" ConvertEmptyStringToNull="false" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            </Columns>
        </asp:GridView>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LinqDemoConnectionString %>" DeleteCommand="DELETE FROM [Students] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Students] ([FirstName], [LastName], [Gender]) VALUES (@FirstName, @LastName, @Gender)" SelectCommand="SELECT * FROM [Students]" UpdateCommand="UPDATE [Students] SET [FirstName] = @FirstName, [LastName] = @LastName, [Gender] = @Gender WHERE [ID] = @ID">
           
            <UpdateParameters>
                <asp:Parameter Name="FirstName" Type="String" ConvertEmptyStringToNull="false" />
                <asp:Parameter Name="LastName" Type="String" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
