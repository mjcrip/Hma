<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Hma.Admin.Articles.Create" MasterPageFile="/Admin/Admin.master" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">Create Article</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<form id="form1" runat="server">
	<asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
	<asp:FormView runat="server" ID="addArticleForm"
		ItemType="Hma.Core.Entities.Article"
		InsertMethod="CreateArticle" DefaultMode="Insert"
		RenderOuterTable="false">
		<InsertItemTemplate>
			<fieldset>
				<%--<ol>
					<asp:DynamicEntity runat="server" Mode="Insert" />
				</ol>--%>

				<asp:TextBox runat="server"></asp:TextBox>

				<asp:Button runat="server" Text="Insert" CommandName="Insert" />
			</fieldset>
		</InsertItemTemplate>
	</asp:FormView>
		</form>
</asp:Content>
