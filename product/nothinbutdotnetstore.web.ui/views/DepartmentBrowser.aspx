<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master"
CodeFile="DepartmentBrowser.aspx.cs" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
<%
    var handler = new RawHandler();
    handler.ProcessRequest(HttpContext.Current);
    
 %>
    <p class="ListHead">Select An Department</p>

            <table>            
		<% foreach (var department in this.model)
     {

%>
	
        	<tr class="ListItem">
               		 <td>                     
        <%=department.name%>
                	</td>
           	 </tr>        
	<%
     }%>
	    </table>            
</asp:Content>
