#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e54abd27628fe1bc9a13fb3440539ad9a529491"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.CustomerCart
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using MyManager.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using MyManager.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using MyManager.Client.Shared.CustomLayout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(CustMainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/receipt")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/receipt/{purchaseid}")]
    public partial class CustomerReceipt : CustomerReceiptBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "voucher_main");
            __builder.AddAttribute(2, "b-e5o4shpvd9");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "innerdiv_1");
            __builder.AddAttribute(5, "b-e5o4shpvd9");
            __builder.AddMarkupContent(6, "<div class=\"banner_main\" b-e5o4shpvd9>My Manager</div>\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "address_main");
            __builder.AddAttribute(9, "b-e5o4shpvd9");
            __builder.AddMarkupContent(10, "<div class=\"address_sub1\" b-e5o4shpvd9><div b-e5o4shpvd9>Name : My Manager</div>\r\n                <div b-e5o4shpvd9>Address : Urlabari -7</div>\r\n                <div b-e5o4shpvd9>Contact : 980407658</div></div>\r\n\r\n            ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "address_sub2");
            __builder.AddAttribute(13, "b-e5o4shpvd9");
#nullable restore
#line 17 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                 if (getPurchase.PurchaseProduct.purchaseproduct.Any())
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "b-e5o4shpvd9");
            __builder.AddContent(16, "Date : ");
            __builder.AddContent(17, 
#nullable restore
#line 19 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                 getPurchase.PurchaseProduct.Purchase_Date

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "b-e5o4shpvd9");
            __builder.AddContent(21, "Bill No : ");
            __builder.AddContent(22, 
#nullable restore
#line 20 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                    getPurchase.PurchaseProduct.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 21 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(23, "<div b-e5o4shpvd9>Date : N/A</div>\r\n                    ");
            __builder.AddMarkupContent(24, "<div b-e5o4shpvd9>Bill No : N/A</div>");
#nullable restore
#line 26 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n        ");
            __builder.OpenElement(26, "table");
            __builder.AddAttribute(27, "class", "table");
            __builder.AddAttribute(28, "border", "1");
            __builder.AddAttribute(29, "b-e5o4shpvd9");
            __builder.AddMarkupContent(30, @"<thead b-e5o4shpvd9><tr b-e5o4shpvd9><th scope=""col"" b-e5o4shpvd9>Product Name</th>
                    <th scope=""col"" b-e5o4shpvd9>Quantity</th>
                    <th scope=""col"" b-e5o4shpvd9>Unit Price</th>
                    <th scope=""col"" b-e5o4shpvd9>Price</th></tr></thead>
            ");
            __builder.OpenElement(31, "tbody");
            __builder.AddAttribute(32, "b-e5o4shpvd9");
#nullable restore
#line 40 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                 if (getPurchase.PurchaseProduct.purchaseproduct.Any())
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                     foreach (var product in getPurchase.PurchaseProduct.purchaseproduct)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(33, "tr");
            __builder.AddAttribute(34, "b-e5o4shpvd9");
            __builder.OpenElement(35, "td");
            __builder.AddAttribute(36, "b-e5o4shpvd9");
            __builder.AddContent(37, 
#nullable restore
#line 45 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                 product.Product_name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n                            ");
            __builder.OpenElement(39, "td");
            __builder.AddAttribute(40, "b-e5o4shpvd9");
            __builder.AddContent(41, 
#nullable restore
#line 46 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                 product.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n                            ");
            __builder.OpenElement(43, "td");
            __builder.AddAttribute(44, "b-e5o4shpvd9");
            __builder.AddContent(45, 
#nullable restore
#line 47 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                 product.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n                            ");
            __builder.OpenElement(47, "td");
            __builder.AddAttribute(48, "b-e5o4shpvd9");
            __builder.AddContent(49, 
#nullable restore
#line 48 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                 product.TotalPrice

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 50 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                     



                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(50, "<tr b-e5o4shpvd9><td b-e5o4shpvd9>N/A</td>\r\n                        <td b-e5o4shpvd9>N/A</td>\r\n                        <td b-e5o4shpvd9>N/A</td>\r\n                        <td b-e5o4shpvd9>N/A</td></tr>");
#nullable restore
#line 63 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                 if (getPurchase.PurchaseProduct.purchaseproduct.Any())
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(51, "tr");
            __builder.AddAttribute(52, "b-e5o4shpvd9");
            __builder.AddMarkupContent(53, "<td colspan=\"3\" b-e5o4shpvd9><strong b-e5o4shpvd9>Grand Total</strong></td>\r\n\r\n                        ");
            __builder.OpenElement(54, "td");
            __builder.AddAttribute(55, "b-e5o4shpvd9");
            __builder.OpenElement(56, "strong");
            __builder.AddAttribute(57, "b-e5o4shpvd9");
            __builder.AddContent(58, 
#nullable restore
#line 70 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                     getPurchase.PurchaseProduct.Sum_Total

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n                    ");
            __builder.OpenElement(60, "tr");
            __builder.AddAttribute(61, "b-e5o4shpvd9");
            __builder.AddMarkupContent(62, "<td colspan=\"3\" b-e5o4shpvd9><strong b-e5o4shpvd9>Paid Amount</strong></td>\r\n                    \r\n                        ");
            __builder.OpenElement(63, "td");
            __builder.AddAttribute(64, "b-e5o4shpvd9");
            __builder.OpenElement(65, "strong");
            __builder.AddAttribute(66, "b-e5o4shpvd9");
            __builder.AddContent(67, 
#nullable restore
#line 76 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                     getPurchase.PurchaseProduct.Paid_Amount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                    ");
            __builder.OpenElement(69, "tr");
            __builder.AddAttribute(70, "b-e5o4shpvd9");
            __builder.AddMarkupContent(71, "<td colspan=\"3\" b-e5o4shpvd9><strong b-e5o4shpvd9>Credit</strong></td>\r\n                   \r\n                            ");
            __builder.OpenElement(72, "td");
            __builder.AddAttribute(73, "b-e5o4shpvd9");
            __builder.OpenElement(74, "strong");
            __builder.AddAttribute(75, "b-e5o4shpvd9");
            __builder.AddContent(76, 
#nullable restore
#line 82 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                          getPurchase.PurchaseProduct.Sum_Total - getPurchase.PurchaseProduct.Paid_Amount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 85 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                 }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n        ");
            __builder.AddMarkupContent(78, "<div class=\"footer\" b-e5o4shpvd9>********** Thank You For Choosing Us. Visit Again **********</div>\r\n        ");
            __builder.OpenElement(79, "div");
            __builder.AddAttribute(80, "b-e5o4shpvd9");
            __builder.OpenElement(81, "button");
            __builder.AddAttribute(82, "class", "btn btn-success voucher_print printhide");
            __builder.AddAttribute(83, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 90 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\CustomerCart\CustomerReceipt.razor"
                                                                               PrintBill

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(84, "b-e5o4shpvd9");
            __builder.AddContent(85, "Print");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
