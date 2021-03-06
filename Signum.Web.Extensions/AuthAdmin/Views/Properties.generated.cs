﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..\AuthAdmin\Views\Properties.cshtml"
    using Signum.Engine.Authorization;
    
    #line default
    #line hidden
    using Signum.Entities;
    using Signum.Entities.Authorization;
    using Signum.Utilities;
    using Signum.Web;
    using Signum.Web.Auth;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/AuthAdmin/Views/Properties.cshtml")]
    public partial class _AuthAdmin_Views_Properties_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _AuthAdmin_Views_Properties_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\AuthAdmin\Views\Properties.cshtml"
Write(Html.ScriptCss("~/authAdmin/Content/AuthAdmin.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 3 "..\..\AuthAdmin\Views\Properties.cshtml"
 using (var tc = Html.TypeContext<PropertyRulePack>())
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-compact\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 6 "..\..\AuthAdmin\Views\Properties.cshtml"
   Write(Html.EntityLine(tc, f => f.Role));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 7 "..\..\AuthAdmin\Views\Properties.cshtml"
   Write(Html.ValueLine(tc, f => f.Strategy));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 8 "..\..\AuthAdmin\Views\Properties.cshtml"
   Write(Html.EntityLine(tc, f => f.Type));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    <table");

WriteLiteral(" class=\"sf-auth-rules\"");

WriteLiteral(" id=\"properties\"");

WriteLiteral(">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 14 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(typeof(Signum.Entities.Basics.PropertyRouteEntity).NiceName());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 17 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(PropertyAllowed.Modify.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(PropertyAllowed.Read.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 23 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(PropertyAllowed.None.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 26 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(AuthAdminMessage.Overriden.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n");

            
            #line 30 "..\..\AuthAdmin\Views\Properties.cshtml"
        
            
            #line default
            #line hidden
            
            #line 30 "..\..\AuthAdmin\Views\Properties.cshtml"
         foreach (var item in tc.TypeElementContext(p => p.Rules))
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <td>\r\n");

WriteLiteral("                    ");

            
            #line 34 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(Html.Span(null, item.Value.Resource.Path));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(Html.Hidden(item.Compose("Resource_Path"), item.Value.Resource.Path));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 36 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(Html.Hidden(item.Compose("AllowedBase"), item.Value.AllowedBase));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n                <td>\r\n");

            
            #line 39 "..\..\AuthAdmin\Views\Properties.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 39 "..\..\AuthAdmin\Views\Properties.cshtml"
                     if (!item.Value.CoercedValues.Contains(PropertyAllowed.Modify))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"sf-auth-chooser sf-auth-modify\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 42 "..\..\AuthAdmin\Views\Properties.cshtml"
                       Write(Html.RadioButton(item.Compose("Allowed"), "Modify", item.Value.Allowed == PropertyAllowed.Modify));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");

            
            #line 44 "..\..\AuthAdmin\Views\Properties.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");

            
            #line 47 "..\..\AuthAdmin\Views\Properties.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 47 "..\..\AuthAdmin\Views\Properties.cshtml"
                     if (!item.Value.CoercedValues.Contains(PropertyAllowed.Read))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"sf-auth-chooser sf-auth-read\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 50 "..\..\AuthAdmin\Views\Properties.cshtml"
                       Write(Html.RadioButton(item.Compose("Allowed"), "Read", item.Value.Allowed == PropertyAllowed.Read));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");

            
            #line 52 "..\..\AuthAdmin\Views\Properties.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");

            
            #line 55 "..\..\AuthAdmin\Views\Properties.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 55 "..\..\AuthAdmin\Views\Properties.cshtml"
                     if (!item.Value.CoercedValues.Contains(PropertyAllowed.None))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"sf-auth-chooser sf-auth-none\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 58 "..\..\AuthAdmin\Views\Properties.cshtml"
                       Write(Html.RadioButton(item.Compose("Allowed"), "None", item.Value.Allowed == PropertyAllowed.None));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");

            
            #line 60 "..\..\AuthAdmin\Views\Properties.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");

WriteLiteral("                    ");

            
            #line 63 "..\..\AuthAdmin\Views\Properties.cshtml"
               Write(Html.CheckBox(item.Compose("Overriden"), item.Value.Overriden, new { disabled = "disabled", @class = "sf-auth-overriden" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");

            
            #line 66 "..\..\AuthAdmin\Views\Properties.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </table>\r\n");

            
            #line 68 "..\..\AuthAdmin\Views\Properties.cshtml"
}
            
            #line default
            #line hidden
WriteLiteral(" ");

        }
    }
}
#pragma warning restore 1591
