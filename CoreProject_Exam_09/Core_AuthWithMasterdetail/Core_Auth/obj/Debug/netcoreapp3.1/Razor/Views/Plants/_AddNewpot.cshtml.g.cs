#pragma checksum "F:\New folder (5)\asp.net core final project\CoreProject_Exam_09\Core_Project_AM\Core_AuthWithMasterdetail\Core_Auth\Views\Plants\_AddNewpot.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "789f36d1035338e0c72deb055f03e1017a4d2360"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Plants__AddNewpot), @"mvc.1.0.view", @"/Views/Plants/_AddNewpot.cshtml")]
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
#nullable restore
#line 1 "F:\New folder (5)\asp.net core final project\CoreProject_Exam_09\Core_Project_AM\Core_AuthWithMasterdetail\Core_Auth\Views\_ViewImports.cshtml"
using Core_Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\New folder (5)\asp.net core final project\CoreProject_Exam_09\Core_Project_AM\Core_AuthWithMasterdetail\Core_Auth\Views\_ViewImports.cshtml"
using Core_Auth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"789f36d1035338e0c72deb055f03e1017a4d2360", @"/Views/Plants/_AddNewpot.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b8ffcfb95120c0f709eff734cae4f4aa5149242", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Plants__AddNewpot : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Core_Auth.Models.pot>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div> Select Pot Item</div>\r\n\r\n<div class=\"row form-group mt-2\">\r\n    <div class=\"col-md-10\">\r\n        ");
#nullable restore
#line 7 "F:\New folder (5)\asp.net core final project\CoreProject_Exam_09\Core_Project_AM\Core_AuthWithMasterdetail\Core_Auth\Views\Plants\_AddNewpot.cshtml"
   Write(Html.DropDownListFor(x => x.potId, ViewBag.pots as SelectList, "--Select--", htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-2\">\r\n        <a class=\"btn btn-danger text-white\" id=\"btnDelete\">Delete</a>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Core_Auth.Models.pot> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
