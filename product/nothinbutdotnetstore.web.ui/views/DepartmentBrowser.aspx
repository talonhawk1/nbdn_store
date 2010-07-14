<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
		<% foreach (var department in ((IEnumerable<Department>)this.Context.Items["blah"]))
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
