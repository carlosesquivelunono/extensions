﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Signum.Web" %>
<%@ Import Namespace="Signum.Web.Authorization" %>
<%@ Import Namespace="Signum.Web.Extensions.Properties" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> $(function() { $("#<%=UserMapping.NewPasswordKey %>").focus(); }); </script>

    <div id="reset-password-container">    
        <h2><%= Resources.NewPassword %></h2>
        <p><%= Resources.PleaseEnterYourChosenNewPassword %></p>
        
        <%= Html.ValidationSummary() %>
        <% using (Html.BeginForm()) { %>
            <%= Html.Hidden("rpr", ViewData["rpr"].ToString())%>
        <div id="changePassword">
            <table>
                <tr>
                    <td class="label"><label for="<%=UserMapping.NewPasswordKey %>"><%= Resources.NewPassword %></label>:</td>
                    <td>
                        <%= Html.Password(UserMapping.NewPasswordKey)%>
                        <%= Html.ValidationMessage(UserMapping.NewPasswordKey)%>
                    </td>
                </tr>
                <tr>
                    <td class="label"><label for="<%=UserMapping.NewPasswordBisKey %>"><%= Resources.ConfirmNewPassword %></label>:</td>
                    <td>
                        <%= Html.Password(UserMapping.NewPasswordBisKey)%>
                        <%= Html.ValidationMessage(UserMapping.NewPasswordBisKey) %>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="<%= Resources.ChangePassword %>" /></td>
                </tr>
            </table>
        </div>
        <% } %>
    </div>
</asp:Content>