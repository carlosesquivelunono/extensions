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
    
    #line 1 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 2 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
    using Signum.Entities.Scheduler;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Scheduler/Views/ScheduledTaskLog.cshtml")]
    public partial class _Scheduler_Views_ScheduledTaskLog_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Scheduler_Views_ScheduledTaskLog_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
 using (var e = Html.TypeContext<ScheduledTaskLogEntity>()) 
{
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.EntityLine(e, f => f.Task));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.EntityLine(e, f => f.ScheduledTask));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                             
	
            
            #line default
            #line hidden
            
            #line 8 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.ValueLine(e, f => f.StartTime));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                        
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.ValueLine(e, f => f.EndTime));

            
            #line default
            #line hidden
            
            #line 9 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.EntityLine(e, f => f.User));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.EntityLine(e, f => f.ProductEntity));

            
            #line default
            #line hidden
            
            #line 11 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                             
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.ValueLine(e, f => f.MachineName));

            
            #line default
            #line hidden
            
            #line 12 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.ValueLine(e, f => f.ApplicationName));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                              
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
Write(Html.EntityLine(e, f => f.Exception));

            
            #line default
            #line hidden
            
            #line 14 "..\..\Scheduler\Views\ScheduledTaskLog.cshtml"
                                         
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
