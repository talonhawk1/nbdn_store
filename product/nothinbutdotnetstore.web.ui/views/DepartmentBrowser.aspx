<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="System.Web.UI.Page" MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.web.core" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
<%
    var handler = new RawHandler();
    handler.ProcessRequest(HttpContext.Current);
    
 %>
    <p class="ListHead">Select An Department</p>

            <table>            
		<!-- for each of the main departments in the store -->
        	<tr class="ListItem">
               		 <td>                     

                	</td>
           	 </tr>        
	    </table>            
</asp:Content>
