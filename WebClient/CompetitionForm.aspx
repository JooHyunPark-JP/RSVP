<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompetitionForm.aspx.cs" Inherits="WebClient.CompetitionForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Welcome to WebClient! You can get a data from Webservice!"></asp:Label>
            <br />
            <asp:Button ID="btn_AllStudents" runat="server" OnClick="btn_AllStudents_Click" Text="Extract All Students" />
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="StudentId" HeaderText="StudentId" SortExpression="StudentId" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="TechnicalInterest" HeaderText="TechnicalInterest" SortExpression="TechnicalInterest" />
                <asp:BoundField DataField="SocialNetworkInterest" HeaderText="SocialNetworkInterest" SortExpression="SocialNetworkInterest" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentCompetitionConnectionString %>" SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btn_SomeParts" runat="server" OnClick="btn_SomeParts_Click" Text="Extract some parts of Data" />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="btn_Detail" runat="server" OnClick="btn_Detail_Click" Text="Extract Detail information" />
        <asp:GridView ID="GridView3" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
