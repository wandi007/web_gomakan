#pragma checksum "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83778e4d01464d3d21c3b21234339a34c6b88d79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DaftarPesanan), @"mvc.1.0.view", @"/Views/Home/DaftarPesanan.cshtml")]
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
#line 1 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\_ViewImports.cshtml"
using web_gomakan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\_ViewImports.cshtml"
using web_gomakan.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83778e4d01464d3d21c3b21234339a34c6b88d79", @"/Views/Home/DaftarPesanan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"683a4bd21549ac4c098cff7766d54e47c072324b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DaftarPesanan : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
  
    ViewData["Title"] = "Daftar Pesanan";

#line default
#line hidden
#nullable disable
            DefineSection("Css", async() => {
                WriteLiteral("\r\n    <link href=\"https://unpkg.com/tailwindcss@2.2.19/dist/tailwind.min.css\"rel=\"stylesheet\"/>\r\n");
            }
            );
            WriteLiteral(@"<div class=""container mx-auto mt-20"">
  <table class=""w-full md:w-2/3 mx-auto bg-white rounded-lg shadow-lg"">
    <thead class=""text-lg font-medium"">
    <tr class=""bg-indigo-500 text-white"">
      <th class=""p-4"">Produk</th>
      <th class=""p-4"">Harga</th>
      <th class=""p-4"">Quantity</th>
      <th class=""p-4"">Total</th>
    </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 18 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
     foreach (var item in ViewBag.pesanan)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <tr class=\"border-b border-gray-400\">\r\n        <td class=\"p-4\">");
#nullable restore
#line 21 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
                    Write(item?.Makanan?.Name ?? "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td class=\"p-4\">Rp. ");
#nullable restore
#line 22 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
                        Write(item?.Makanan?.Price ?? "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td class=\"p-4\">");
#nullable restore
#line 23 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
                    Write(item?.Qty ?? "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td class=\"p-4\">Rp. ");
#nullable restore
#line 24 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
                        Write(item?.Total ?? "");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      </tr>\r\n");
#nullable restore
#line 26 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n    <tr class=\"text-lg font-medium\">\r\n      <td class=\"p-4\" colspan=\"3\">Total</td>\r\n      <td class=\"p-4\">Rp. ");
#nullable restore
#line 31 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
                      Write(ViewBag.TotalPesanan);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    </tfoot>\r\n  </table>\r\n  <div class=\"w-full md:w-2/3 mx-auto\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 1131, "\"", 1175, 1);
#nullable restore
#line 36 "D:\Learn\gomakan\web_gomakan\web_gomakan\Views\Home\DaftarPesanan.cshtml"
WriteAttributeValue("", 1138, Url.Action("CheckoutPesanan","Home"), 1138, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"bg-indigo-500 text-white py-2 px-4 rounded hover:bg-indigo-600 mt-4\">Submit Pesanan</a>\r\n  </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
