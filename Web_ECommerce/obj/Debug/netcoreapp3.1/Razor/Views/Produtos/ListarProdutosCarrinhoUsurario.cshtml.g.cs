#pragma checksum "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e0f12cd89e4cc111eae99d25c3ceed2309adb07"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produtos_ListarProdutosCarrinhoUsurario), @"mvc.1.0.view", @"/Views/Produtos/ListarProdutosCarrinhoUsurario.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e0f12cd89e4cc111eae99d25c3ceed2309adb07", @"/Views/Produtos/ListarProdutosCarrinhoUsurario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fcd1e58e32927a3e5ad400fd31f12f33d8d7e01", @"/Views/_ViewImports.cshtml")]
    public class Views_Produtos_ListarProdutosCarrinhoUsurario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Entities.Entities.Produto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CompraUsuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "FinalizarCompra", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
  
    ViewData["Title"] = "ListarProdutosCarrinhoUsurario";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Lista de Produtos do Carrinho</h1>\r\n\r\n<br />\r\n");
#nullable restore
#line 10 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
 if (Model.Count() != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2e0f12cd89e4cc111eae99d25c3ceed2309adb075109", async() => {
                WriteLiteral("Comprar do carrinho");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 13 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Imagem\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
           Write(Html.DisplayNameFor(model => model.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
           Write(Html.DisplayNameFor(model => model.Observacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
           Write(Html.DisplayNameFor(model => model.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
           Write(Html.DisplayNameFor(model => model.QtdCompra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 41 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 48 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
                      
                        if (!string.IsNullOrWhiteSpace(item.Url))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img width=\"80\" height=\"80\"");
            BeginWriteAttribute("src", " src=", 1392, "", 1406, 1);
#nullable restore
#line 51 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
WriteAttributeValue("", 1397, item.Url, 1397, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 52 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 56 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.DisplayFor(modelItem => item.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 59 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.DisplayFor(modelItem => item.Observacao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.DisplayFor(modelItem => item.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.DisplayFor(modelItem => item.QtdCompra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
               Write(Html.ActionLink("Remover", "RemoverCarrinho", new { id = item.IdProdutoCarrinho }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 71 "C:\Users\Eshi\source\repos\EcommerceDDD\Web_ECommerce\Views\Produtos\ListarProdutosCarrinhoUsurario.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Entities.Entities.Produto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
