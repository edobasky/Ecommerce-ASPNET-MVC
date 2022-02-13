#pragma checksum "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fdf2a6e8fefbe4bb9b037f1e0e25770a559e4839"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
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
#line 1 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\_ViewImports.cshtml"
using eTickets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\_ViewImports.cshtml"
using eTickets.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fdf2a6e8fefbe4bb9b037f1e0e25770a559e4839", @"/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae36ea9afdbf4434090466b2ad951861827cd6f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
      
    ViewData["Title"] = "All orders";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-8 offset-2"">
        <p>
            <h4>List of all your orders</h4>
        </p>
        <table class=""table"">
            <thead>
                <tr>
                    <th>Order ID</th>
                    <th>Items</th>
                    <th>Total</th>
");
#nullable restore
#line 18 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                     if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <th>User</th>\r\n");
#nullable restore
#line 21 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                     foreach (var order in Model)
                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <tr>\n                           <td class=\"align-middle\">");
#nullable restore
#line 28 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                               Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                           <td class=\"align-middle\">\r\n                               <ul style=\"list-style-type:none\">\r\n");
#nullable restore
#line 31 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                     foreach (var item in order.OrderItems)
                                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>\n                                            <div class=\"alert alert-info\">\r\n                                                <span class=\"badge bg-success\">");
#nullable restore
#line 35 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                                                          Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> [");
#nullable restore
#line 35 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                                                                               Write(item.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("] - ");
#nullable restore
#line 35 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                                                                                                            Write(item.Movie.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </div>\r\n                                        </li>\n");
#nullable restore
#line 38 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                               </ul>\r\n                           </td>\r\n                           <td class=\"align-middle\">\r\n                               ");
#nullable restore
#line 42 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                          Write(order.OrderItems.Select(m => m.Movie.Price * m.Amount).Sum().ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                           </td>\r\n");
#nullable restore
#line 44 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                             if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"align-middle\"> ");
#nullable restore
#line 46 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                                                     Write(order.User.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n");
#nullable restore
#line 47 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       </tr>\n");
#nullable restore
#line 49 "C:\Users\hp\Desktop\ECommerce_MVC\eTickets\eTickets\Views\Orders\Index.cshtml"
                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
