#pragma checksum "C:\Github\repo\ISTA_Project\myProject\Treker\WebApplication1\Pages\Tickets\TicketForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f6fda33ed43511e046710cb805d1faa417624c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Tickets_TicketForm), @"mvc.1.0.view", @"/Pages/Tickets/TicketForm.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f6fda33ed43511e046710cb805d1faa417624c6", @"/Pages/Tickets/TicketForm.cshtml")]
    public class Pages_Tickets_TicketForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication1.Models.Tickets>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Github\repo\ISTA_Project\myProject\Treker\WebApplication1\Pages\Tickets\TicketForm.cshtml"
  
    ViewBag.Title = "TicketForm";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 8 "C:\Github\repo\ISTA_Project\myProject\Treker\WebApplication1\Pages\Tickets\TicketForm.cshtml"
Write(Model.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication1.Models.Tickets> Html { get; private set; }
    }
}
#pragma warning restore 1591
