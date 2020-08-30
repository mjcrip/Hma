<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Hma.Admin.Articles.List" MasterPageFile="/Admin/Admin.master" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">List of Articles</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Label runat="server" ID="Label1"> Articles </asp:Label>
	<asp:HyperLink NavigateUrl="/Admin/Articles/Create.aspx" runat="server"> Add </asp:HyperLink>

	<form id="form1" runat="server">
		<asp:GridView runat="server" ID="studentsGrid"
			ItemType="Hma.Core.Entities.Article" DataKeyNames="Id"
			SelectMethod="GetArticles"
			AutoGenerateColumns="false">
			<Columns>
				<asp:DynamicField DataField="Id" />
				<asp:DynamicField DataField="Title" />
				<asp:DynamicField DataField="Author" />
				<asp:DynamicField DataField="CreatedDate" />
			</Columns>
		</asp:GridView>
	</form>
</asp:Content>
