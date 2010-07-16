<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master"
CodeFile="DepartmentBrowser.aspx.cs" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core.helpers" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">

    <p class="ListHead">Select An Department</p>

        <table>            
		<% foreach (var department in model)
     {
        %>	
        	<tr class="ListItem">
                <td>                     
                    <a href="<%=Url.for_command<ViewSubDepartments>()
                       .with_input_model(department)
                       .with_parameter(x => x.id) %>"><%=department.name%></a>
                </td>
            </tr>
	    <%
     }
	    %>
	    </table>            
</asp:Content>
