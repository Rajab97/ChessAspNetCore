#pragma checksum "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00cc7930bd257dea3e71efe8385b0d2a13fd1b8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DirectionDescriptions_Index), @"mvc.1.0.view", @"/Views/DirectionDescriptions/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DirectionDescriptions/Index.cshtml", typeof(AspNetCore.Views_DirectionDescriptions_Index))]
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
#line 1 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\_ViewImports.cshtml"
using ChessWebAspNetCore;

#line default
#line hidden
#line 2 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\_ViewImports.cshtml"
using ChessWebAspNetCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00cc7930bd257dea3e71efe8385b0d2a13fd1b8e", @"/Views/DirectionDescriptions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7389356c7c988c6220b37623a83abe298fb3897", @"/Views/_ViewImports.cshtml")]
    public class Views_DirectionDescriptions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ChessWebAspNetCore.Models.DirectionDescription>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right;margin-bottom:15px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            DefineSection("Style", async() => {
                BeginContext(173, 89, true);
                WriteLiteral("\r\n    <style>\r\n        tr td{\r\n            padding:10px 0px;\r\n        }\r\n    </style>\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(265, 313, true);
            WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <h2 style=""width:75%; margin:0 auto; margin-top:20px; margin-bottom:10px;"">Direction Descriptions</h2>
            <div class=""buttonsRow col-12"">
                <div style=""width:75%; margin:0 auto;"" class=""clearfix"">
                    ");
            EndContext();
            BeginContext(578, 125, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cca71b43d3b4edcb67d342d2ffa558c", async() => {
                BeginContext(665, 34, true);
                WriteLiteral("<i class=\"far fa-plus-square\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(703, 336, true);
            WriteLiteral(@"
                </div>
            </div>
            <div class=""col-md-12""></div>
            <div class=""col-12"">
                <table style=""width:75%;margin:0 auto; "" class=""table table-bordered"">
                    <thead>
                        <tr>
                            <th>
                                ");
            EndContext();
            BeginContext(1040, 43, false);
#line 30 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.RowStep));

#line default
#line hidden
            EndContext();
            BeginContext(1083, 103, true);
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
            EndContext();
            BeginContext(1187, 46, false);
#line 33 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.ColumnStep));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 103, true);
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
            EndContext();
            BeginContext(1337, 52, false);
#line 36 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.DiagonalMovement));

#line default
#line hidden
            EndContext();
            BeginContext(1389, 103, true);
            WriteLiteral("\r\n                            </th>\r\n                            <th>\r\n                                ");
            EndContext();
            BeginContext(1493, 57, false);
#line 39 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.PerpendicularMovement));

#line default
#line hidden
            EndContext();
            BeginContext(1550, 239, true);
            WriteLiteral("\r\n                            </th>\r\n\r\n                            <th>\r\n                                Actions\r\n                            </th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 48 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(1870, 183, true);
            WriteLiteral("                            <tr>\r\n                                <td style=\"width:25%;\" class=\"centeredContainer\">\r\n                                    <span class=\"centeredElement\">");
            EndContext();
            BeginContext(2055, 51, false);
#line 52 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                              Write(item.RowStep < 0 ? item.RowStep * -1 : item.RowStep);

#line default
#line hidden
            EndContext();
            BeginContext(2107, 6, true);
            WriteLiteral(" step ");
            EndContext();
            BeginContext(2115, 57, false);
#line 52 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                                                                                          Write(item.RowStep == 0 ? "" : item.RowStep > 0 ? "Up" : "Down");

#line default
#line hidden
            EndContext();
            BeginContext(2173, 197, true);
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td style=\"width:25%;\" class=\"centeredContainer\">\r\n                                    <span class=\"centeredElement\">");
            EndContext();
            BeginContext(2372, 60, false);
#line 55 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                              Write(item.ColumnStep < 0 ? item.ColumnStep * -1 : item.ColumnStep);

#line default
#line hidden
            EndContext();
            BeginContext(2433, 6, true);
            WriteLiteral(" step ");
            EndContext();
            BeginContext(2441, 66, false);
#line 55 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                                                                                                   Write(item.ColumnStep == 0 ? "" : item.ColumnStep > 0 ? "Right" : "Left");

#line default
#line hidden
            EndContext();
            BeginContext(2508, 178, true);
            WriteLiteral("</span>\r\n                                </td>\r\n                                <td style=\"width:10%; text-align:center; font-size:large\">\r\n                                    <i");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2686, "\"", 2753, 3);
            WriteAttributeValue("", 2694, "color:", 2694, 6, true);
#line 58 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
WriteAttributeValue(" ", 2700, item.DiagonalMovement == true ? @"green" : "red", 2701, 51, false);

#line default
#line hidden
            WriteAttributeValue("", 2752, ";", 2752, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2754, "\"", 2846, 1);
#line 58 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
WriteAttributeValue("", 2762, item.DiagonalMovement == true ? "far fa-calendar-check" : "fas fa-calendar-times", 2762, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2847, 176, true);
            WriteLiteral("></i>\r\n                                </td>\r\n                                <td style=\"width:10%; text-align:center; font-size:large\">\r\n                                    <i");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 3023, "\"", 3095, 3);
            WriteAttributeValue("", 3031, "color:", 3031, 6, true);
#line 61 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
WriteAttributeValue(" ", 3037, item.PerpendicularMovement == true ? @"green" : "red", 3038, 56, false);

#line default
#line hidden
            WriteAttributeValue("", 3094, ";", 3094, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 3096, "\"", 3193, 1);
#line 61 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
WriteAttributeValue("", 3104, item.PerpendicularMovement == true ? "far fa-calendar-check" : "fas fa-calendar-times", 3104, 89, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3194, 236, true);
            WriteLiteral("></i>\r\n                                </td>\r\n                                <td class=\"centeredContainer\" style=\"width:30%;\">\r\n                                    <div class=\"centeredElement\">\r\n                                        ");
            EndContext();
            BeginContext(3430, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b128dacec8a34bb085fd9015130b357b", async() => {
                BeginContext(3499, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                                                       WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3507, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(3549, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78e07b8074bf42a8848c9ee51cc5ec36", async() => {
                BeginContext(3619, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 66 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3629, 120, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 70 "C:\Users\Rajab\source\repos\ChessWebAspNetCore\ChessWebAspNetCore\Views\DirectionDescriptions\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(3776, 112, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ChessWebAspNetCore.Models.DirectionDescription>> Html { get; private set; }
    }
}
#pragma warning restore 1591
