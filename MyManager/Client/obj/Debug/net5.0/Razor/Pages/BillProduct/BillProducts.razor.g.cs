#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4acfc14e9deeec085f974d42cb609f2c290fb4e4"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.BillProduct
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/billproducts/{billid}")]
    public partial class BillProducts : BillProductBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "voucher_main");
            __builder.AddAttribute(2, "b-j5me7m6svi");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "innerdiv_1");
            __builder.AddAttribute(5, "b-j5me7m6svi");
            __builder.AddMarkupContent(6, "<div class=\"banner_main\" b-j5me7m6svi>My Manager</div>\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "address_main");
            __builder.AddAttribute(9, "b-j5me7m6svi");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "address_sub1");
            __builder.AddAttribute(12, "b-j5me7m6svi");
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBill.Singlebill != null)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "b-j5me7m6svi");
            __builder.AddContent(15, "Dealer Name : ");
            __builder.AddContent(16, 
#nullable restore
#line 12 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                        getBill.Singlebill.dealerView.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                    ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "b-j5me7m6svi");
            __builder.AddContent(20, "Address : ");
            __builder.AddContent(21, 
#nullable restore
#line 13 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                    getBill.Singlebill.dealerView.Adress

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                    ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "b-j5me7m6svi");
            __builder.AddContent(25, "Contact : ");
            __builder.AddContent(26, 
#nullable restore
#line 14 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                    getBill.Singlebill.dealerView.Phone

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 15 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(27, "<div b-j5me7m6svi>Dealer Name : N/A</div>\r\n                    ");
            __builder.AddMarkupContent(28, "<div b-j5me7m6svi>Address : N/A</div>\r\n                    ");
            __builder.AddMarkupContent(29, "<div b-j5me7m6svi>Contact : N/A</div>");
#nullable restore
#line 21 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "address_sub2");
            __builder.AddAttribute(33, "b-j5me7m6svi");
#nullable restore
#line 25 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBill.Singlebill != null)
                {


#line default
#line hidden
#nullable disable
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "b-j5me7m6svi");
            __builder.AddContent(36, "Date : ");
            __builder.AddContent(37, 
#nullable restore
#line 28 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 getBill.Singlebill.Checkout_Date.ToShortDateString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n                    ");
            __builder.OpenElement(39, "div");
            __builder.AddAttribute(40, "b-j5me7m6svi");
            __builder.AddContent(41, "Bill No : ");
            __builder.AddContent(42, 
#nullable restore
#line 29 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                    getBill.Singlebill.BillNo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 30 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"

                }
                else
                {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(43, "<div b-j5me7m6svi>Date : N/A</div>\r\n                    ");
            __builder.AddMarkupContent(44, "<div b-j5me7m6svi>Bill No : N/A</div>");
#nullable restore
#line 36 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n        ");
            __builder.OpenElement(46, "table");
            __builder.AddAttribute(47, "class", "table");
            __builder.AddAttribute(48, "border", "1");
            __builder.AddAttribute(49, "b-j5me7m6svi");
            __builder.AddMarkupContent(50, @"<thead b-j5me7m6svi><tr b-j5me7m6svi><th scope=""col"" b-j5me7m6svi>Product Name</th>
                    <th scope=""col"" b-j5me7m6svi>Quantity</th>
                    <th scope=""col"" b-j5me7m6svi>Unit Price</th>
                    <th scope=""col"" b-j5me7m6svi>Price</th></tr></thead>
            ");
            __builder.OpenElement(51, "tbody");
            __builder.AddAttribute(52, "b-j5me7m6svi");
#nullable restore
#line 54 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBillProduct.Headphones.Any())
                    foreach (var headphone in getBillProduct.Headphones)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(53, "tr");
            __builder.AddAttribute(54, "b-j5me7m6svi");
            __builder.OpenElement(55, "td");
            __builder.AddAttribute(56, "b-j5me7m6svi");
            __builder.AddContent(57, 
#nullable restore
#line 58 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 headphone.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                            ");
            __builder.OpenElement(59, "td");
            __builder.AddAttribute(60, "b-j5me7m6svi");
            __builder.AddContent(61, 
#nullable restore
#line 59 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 headphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n                            ");
            __builder.OpenElement(63, "td");
            __builder.AddAttribute(64, "b-j5me7m6svi");
            __builder.AddContent(65, 
#nullable restore
#line 60 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 headphone.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n                            ");
            __builder.OpenElement(67, "td");
            __builder.AddAttribute(68, "b-j5me7m6svi");
            __builder.AddContent(69, 
#nullable restore
#line 61 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                  headphone.Price * headphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 63 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBillProduct.Smartphones.Any())
                    foreach (var smartphone in getBillProduct.Smartphones)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(70, "tr");
            __builder.AddAttribute(71, "b-j5me7m6svi");
            __builder.OpenElement(72, "td");
            __builder.AddAttribute(73, "b-j5me7m6svi");
            __builder.AddContent(74, 
#nullable restore
#line 68 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 smartphone.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                            ");
            __builder.OpenElement(76, "td");
            __builder.AddAttribute(77, "b-j5me7m6svi");
            __builder.AddContent(78, 
#nullable restore
#line 69 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 smartphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n                            ");
            __builder.OpenElement(80, "td");
            __builder.AddAttribute(81, "b-j5me7m6svi");
            __builder.AddContent(82, 
#nullable restore
#line 70 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 smartphone.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n                            ");
            __builder.OpenElement(84, "td");
            __builder.AddAttribute(85, "b-j5me7m6svi");
            __builder.AddContent(86, 
#nullable restore
#line 71 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                  smartphone.Price * smartphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 73 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBillProduct.Chargers.Any())
                    foreach (var charger in getBillProduct.Chargers)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(87, "tr");
            __builder.AddAttribute(88, "b-j5me7m6svi");
            __builder.AddMarkupContent(89, "<td b-j5me7m6svi>Charger</td>\r\n                            ");
            __builder.OpenElement(90, "td");
            __builder.AddAttribute(91, "b-j5me7m6svi");
            __builder.AddContent(92, 
#nullable restore
#line 79 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 charger.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                            ");
            __builder.OpenElement(94, "td");
            __builder.AddAttribute(95, "b-j5me7m6svi");
            __builder.AddContent(96, 
#nullable restore
#line 80 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 charger.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n                            ");
            __builder.OpenElement(98, "td");
            __builder.AddAttribute(99, "b-j5me7m6svi");
            __builder.AddContent(100, 
#nullable restore
#line 81 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                  charger.Price * charger.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 83 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                 if (getBillProduct.PhoneCases.Any())
                    foreach (var phonecase in getBillProduct.PhoneCases)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(101, "tr");
            __builder.AddAttribute(102, "b-j5me7m6svi");
            __builder.OpenElement(103, "td");
            __builder.AddAttribute(104, "b-j5me7m6svi");
            __builder.AddContent(105, 
#nullable restore
#line 88 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 phonecase.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n                            ");
            __builder.OpenElement(107, "td");
            __builder.AddAttribute(108, "b-j5me7m6svi");
            __builder.AddContent(109, 
#nullable restore
#line 89 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 phonecase.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n                            ");
            __builder.OpenElement(111, "td");
            __builder.AddAttribute(112, "b-j5me7m6svi");
            __builder.AddContent(113, 
#nullable restore
#line 90 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 phonecase.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n                            ");
            __builder.OpenElement(115, "td");
            __builder.AddAttribute(116, "b-j5me7m6svi");
            __builder.AddContent(117, 
#nullable restore
#line 91 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                  phonecase.Price * phonecase.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 93 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(118, "tr");
            __builder.AddAttribute(119, "b-j5me7m6svi");
            __builder.AddMarkupContent(120, "<td colspan=\"3\" b-j5me7m6svi><strong b-j5me7m6svi>Grand Total</strong></td>\r\n                    ");
            __builder.OpenElement(121, "td");
            __builder.AddAttribute(122, "b-j5me7m6svi");
            __builder.OpenElement(123, "strong");
            __builder.AddAttribute(124, "b-j5me7m6svi");
            __builder.AddContent(125, 
#nullable restore
#line 97 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\BillProduct\BillProducts.razor"
                                 Total.ToString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(126, "\r\n        ");
            __builder.AddMarkupContent(127, "<div class=\"footer\" b-j5me7m6svi>********** Thank You For Choosing Us. Visit Again **********</div>");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
