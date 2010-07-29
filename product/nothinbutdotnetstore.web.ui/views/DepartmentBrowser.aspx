<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" MasterPageFile="Store.master" 
CodeFile="DepartmentBrowser.aspx.cs"%>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="nothinbutdotnetstore.model" %>
<%@ Import Namespace="nothinbutdotnetstore.web.application.catalogbrowsing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>

            <table>            
            <% foreach (var department in this.display_model) { %>
            <tr class="ListItem">
                <td>
<%
                        Link<Department>.for_a(department).when(some_criteria).render_with<ViewMainDepartments>();
                        Link<Department>.for_a(department).when(some_criteria).render_with<ViewMainDepartments>().otherwise.render_with<ViewSubDepartmentsInADepartment>();

                      
                       {%>
                    <a href="/dept.store/ViewSubDepartments?d=<%= department.name %>"><%=department.name%></a>
                    <%
                        }
                       else
{%>
                    <a href="/dept.store/ViewProducts?d=<%= department.name %>"><%=department.name%></a>
<%
}%>
                </td>
            </tr>        
            <% } %>
        </table>            
</asp:Content>
