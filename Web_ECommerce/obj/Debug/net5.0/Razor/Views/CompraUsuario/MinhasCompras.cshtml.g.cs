#pragma checksum "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02f4f10f25b3e74c8dc0815d1398071c7bad938f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CompraUsuario_MinhasCompras), @"mvc.1.0.view", @"/Views/CompraUsuario/MinhasCompras.cshtml")]
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
#line 1 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\_ViewImports.cshtml"
using Web_ECommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\_ViewImports.cshtml"
using Web_ECommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02f4f10f25b3e74c8dc0815d1398071c7bad938f", @"/Views/CompraUsuario/MinhasCompras.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fcd1e58e32927a3e5ad400fd31f12f33d8d7e01", @"/Views/_ViewImports.cshtml")]
    public class Views_CompraUsuario_MinhasCompras : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Entities.CompraUsuario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompraUsuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Imprimir", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
  
    ViewData["Title"] = "MinhasCompras";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h1>Minhas compras</h1>\r\n");
#nullable restore
#line 9 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
     foreach (var item in Model)
    {
        if (item.ListaProdutos.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02f4f10f25b3e74c8dc0815d1398071c7bad938f5082", async() => {
                WriteLiteral("Imprimir Boleto");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 14 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                                                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <hr />\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayNameFor(model => model.EnderecoCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 21 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayFor(model => item.EnderecoCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    CEP\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 27 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayFor(model => item.ApplicationUser.CEP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayNameFor(model => model.QuantidadeProdutos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 33 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayFor(model => item.QuantidadeProdutos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayNameFor(model => model.ValorTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 39 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
               Write(Html.DisplayFor(model => item.ValorTotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n");
            WriteLiteral("            <h4>Produtos comprados</h4>\r\n");
            WriteLiteral(@"            <table class=""table"">
                <thead>
                    <tr>
                        <th>Nome</th>
                        <th>Imagem</th>
                        <th>Descricão</th>
                        <th>Observação</th>
                        <th>Valor</th>
                        <th>Quantidade</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 57 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                     foreach (var produto in item.ListaProdutos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 61 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                           Write(Html.DisplayFor(modelItem => produto.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
#nullable restore
#line 64 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                                  
                                    if (!string.IsNullOrWhiteSpace(produto.Url))
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <img width=\"80\" height=\"80\"");
            BeginWriteAttribute("src", " src=", 2485, "", 2502, 1);
#nullable restore
#line 67 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
WriteAttributeValue("", 2490, produto.Url, 2490, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 68 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 72 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                           Write(Html.DisplayFor(modelItem => produto.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 75 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                           Write(Html.DisplayFor(modelItem => produto.Observacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 78 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                           Write(Html.DisplayFor(modelItem => produto.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 81 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                           Write(Html.DisplayFor(modelItem => produto.QtdCompra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 84 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 87 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Não existem compras</h3>\r\n");
#nullable restore
#line 91 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\CompraUsuario\MinhasCompras.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Entities.CompraUsuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591