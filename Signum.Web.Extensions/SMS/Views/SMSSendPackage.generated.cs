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
    using Signum.Entities;
    
    #line 1 "..\..\SMS\Views\SMSSendPackage.cshtml"
    using Signum.Entities.SMS;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/SMS/Views/SMSSendPackage.cshtml")]
    public partial class _SMS_Views_SMSSendPackage_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _SMS_Views_SMSSendPackage_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\SMS\Views\SMSSendPackage.cshtml"
 using (var sc = Html.TypeContext<SMSSendPackageEntity>())
{
    
            
            #line default
            #line hidden
            
            #line 4 "..\..\SMS\Views\SMSSendPackage.cshtml"
Write(Html.ValueLine(sc, s => s.Name));

            
            #line default
            #line hidden
            
            #line 4 "..\..\SMS\Views\SMSSendPackage.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\SMS\Views\SMSSendPackage.cshtml"
Write(Html.SearchControl(new FindOptions(typeof(SMSMessageEntity))
    {
        FilterOptions = { new FilterOption("Entity.SendPackage", sc.Value) { Frozen = true } },
        SearchOnLoad = true
    }, new Context(sc, "smpM")));

            
            #line default
            #line hidden
            
            #line 9 "..\..\SMS\Views\SMSSendPackage.cshtml"
                               ;
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
