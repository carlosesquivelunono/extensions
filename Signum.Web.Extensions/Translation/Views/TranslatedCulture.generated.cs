﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Translation.Views
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
    
    #line 1 "..\..\Translation\Views\TranslatedCulture.cshtml"
    using Signum.Entities.Translation;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Translation/Views/TranslatedCulture.cshtml")]
    public partial class TranslatedCulture : System.Web.Mvc.WebViewPage<dynamic>
    {
        public TranslatedCulture()
        {
        }
        public override void Execute()
        {


            
            #line 2 "..\..\Translation\Views\TranslatedCulture.cshtml"
 using (var tcc = Html.TypeContext<TranslatedCultureDN>())
{
    
            
            #line default
            #line hidden
            
            #line 4 "..\..\Translation\Views\TranslatedCulture.cshtml"
Write(Html.EntityCombo(tcc, d => d.Culture));

            
            #line default
            #line hidden
            
            #line 4 "..\..\Translation\Views\TranslatedCulture.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Translation\Views\TranslatedCulture.cshtml"
Write(Html.ValueLine(tcc, d => d.Action));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Translation\Views\TranslatedCulture.cshtml"
                                       
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591