#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1188b75f17fdca3c9ad9bbb885bb9ced3f3de287"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.Smartphones
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/managesmartphone")]
    public partial class ManageSmartphone : ManageSmartphoneBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "b-tse3gjl7bi");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "container");
            __builder.AddAttribute(4, "b-tse3gjl7bi");
            __builder.AddMarkupContent(5, "<h1 b-tse3gjl7bi>Available Smartphones</h1>\r\n            \r\n            ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "d-flex justify-content-between align-items-center");
            __builder.AddAttribute(8, "b-tse3gjl7bi");
            __builder.OpenElement(9, "input");
            __builder.AddAttribute(10, "placeholder", "Search");
            __builder.AddAttribute(11, "onkeyup", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.KeyboardEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                                           onChange

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                   value

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => value = __value, value));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddAttribute(14, "b-tse3gjl7bi");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(16);
            __builder.AddAttribute(17, "class", "nav-link");
            __builder.AddAttribute(18, "href", "addsmartphone");
            __builder.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(20, "<button type=\"button\" class=\"smartphonebtn\" b-tse3gjl7bi><i class=\"fa fa-plus\" b-tse3gjl7bi></i>Add Phone</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\r\n            ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "table-responsive");
            __builder.AddAttribute(24, "b-tse3gjl7bi");
            __builder.OpenElement(25, "table");
            __builder.AddAttribute(26, "class", "table table-striped");
            __builder.AddAttribute(27, "b-tse3gjl7bi");
            __builder.OpenElement(28, "thead");
            __builder.AddAttribute(29, "b-tse3gjl7bi");
            __builder.OpenElement(30, "tr");
            __builder.AddAttribute(31, "b-tse3gjl7bi");
            __builder.AddMarkupContent(32, "<th scope=\"col\" b-tse3gjl7bi>Id</th>\r\n                            ");
            __builder.AddMarkupContent(33, "<th scope=\"col\" b-tse3gjl7bi>Name</th>\r\n                            ");
            __builder.AddMarkupContent(34, "<th scope=\"col\" b-tse3gjl7bi>Color</th>\r\n                            ");
            __builder.AddMarkupContent(35, "<th scope=\"col\" b-tse3gjl7bi>Ram</th>\r\n                            ");
            __builder.AddMarkupContent(36, "<th scope=\"col\" b-tse3gjl7bi>Storage</th>\r\n                            ");
            __builder.AddMarkupContent(37, "<th scope=\"col\" b-tse3gjl7bi>Cpu</th>\r\n                            ");
            __builder.AddMarkupContent(38, "<th scope=\"col\" b-tse3gjl7bi>Display</th>\r\n                            ");
            __builder.AddMarkupContent(39, "<th scope=\"col\" b-tse3gjl7bi>Quantity</th>\r\n                            ");
            __builder.OpenElement(40, "th");
            __builder.AddAttribute(41, "class", "order_btns");
            __builder.AddAttribute(42, "scope", "col");
            __builder.AddAttribute(43, "b-tse3gjl7bi");
            __builder.AddMarkupContent(44, "<div b-tse3gjl7bi>Price</div>");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "b-tse3gjl7bi");
            __builder.OpenElement(47, "i");
            __builder.AddAttribute(48, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                                                 priceascending

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(49, "class", "fas fa-sort-up");
            __builder.AddAttribute(50, "b-tse3gjl7bi");
            __builder.CloseElement();
            __builder.OpenElement(51, "i");
            __builder.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 29 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                                                                                                         pricedescending

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(53, "class", "fas fa-sort-down");
            __builder.AddAttribute(54, "b-tse3gjl7bi");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n                            ");
            __builder.AddMarkupContent(56, "<th scope=\"col\" b-tse3gjl7bi>Actions</th>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n                    ");
            __builder.OpenElement(58, "tbody");
            __builder.AddAttribute(59, "b-tse3gjl7bi");
#nullable restore
#line 34 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                         if (getSmartphones.Smartphones.Any() && !searchedphones.Any())
                        {
                            foreach (var smartphone in getSmartphones.Smartphones)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(60, "tr");
            __builder.AddAttribute(61, "b-tse3gjl7bi");
            __builder.OpenElement(62, "td");
            __builder.AddAttribute(63, "b-tse3gjl7bi");
            __builder.AddContent(64, 
#nullable restore
#line 39 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n                                    ");
            __builder.OpenElement(66, "td");
            __builder.AddAttribute(67, "b-tse3gjl7bi");
            __builder.AddContent(68, 
#nullable restore
#line 40 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n                                    ");
            __builder.OpenElement(70, "td");
            __builder.AddAttribute(71, "b-tse3gjl7bi");
            __builder.AddContent(72, 
#nullable restore
#line 41 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Color

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n                                    ");
            __builder.OpenElement(74, "td");
            __builder.AddAttribute(75, "b-tse3gjl7bi");
            __builder.AddContent(76, 
#nullable restore
#line 42 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Ram

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(77, "\r\n                                    ");
            __builder.OpenElement(78, "td");
            __builder.AddAttribute(79, "b-tse3gjl7bi");
            __builder.AddContent(80, 
#nullable restore
#line 43 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Storage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n                                    ");
            __builder.OpenElement(82, "td");
            __builder.AddAttribute(83, "b-tse3gjl7bi");
            __builder.AddContent(84, 
#nullable restore
#line 44 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Cpu

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n                                    ");
            __builder.OpenElement(86, "td");
            __builder.AddAttribute(87, "b-tse3gjl7bi");
            __builder.AddContent(88, 
#nullable restore
#line 45 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Display

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\r\n                                    ");
            __builder.OpenElement(90, "td");
            __builder.AddAttribute(91, "b-tse3gjl7bi");
            __builder.AddContent(92, 
#nullable restore
#line 46 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                                    ");
            __builder.OpenElement(94, "td");
            __builder.AddAttribute(95, "b-tse3gjl7bi");
            __builder.AddContent(96, 
#nullable restore
#line 47 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n\r\n\r\n                                    ");
            __builder.OpenElement(98, "td");
            __builder.AddAttribute(99, "class", "d-flex");
            __builder.AddAttribute(100, "b-tse3gjl7bi");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(101);
            __builder.AddAttribute(102, "class", "nav-link");
            __builder.AddAttribute(103, "href", 
#nullable restore
#line 51 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                          $"addsmartphone/{smartphone.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(104, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(105, "<i class=\"fas fa-edit\" b-tse3gjl7bi></i>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(106, "\r\n                                        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(107);
            __builder.AddAttribute(108, "class", "nav-link");
            __builder.AddAttribute(109, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(110, "i");
                __builder2.AddAttribute(111, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 55 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                           e =>{setSmartphoneId(smartphone.Id);}

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(112, "class", "fas fa-trash-alt");
                __builder2.AddAttribute(113, "data-toggle", "modal");
                __builder2.AddAttribute(114, "data-target", "#deletesmartphonemodel");
                __builder2.AddAttribute(115, "b-tse3gjl7bi");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 59 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                            }
                        }
                        else if (searchedphones.Any())
                        {
                            foreach (var smartphone in searchedphones)
                            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(116, "tr");
            __builder.AddAttribute(117, "b-tse3gjl7bi");
            __builder.OpenElement(118, "td");
            __builder.AddAttribute(119, "b-tse3gjl7bi");
            __builder.AddContent(120, 
#nullable restore
#line 66 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\r\n                                    ");
            __builder.OpenElement(122, "td");
            __builder.AddAttribute(123, "b-tse3gjl7bi");
            __builder.AddContent(124, 
#nullable restore
#line 67 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(125, "\r\n                                    ");
            __builder.OpenElement(126, "td");
            __builder.AddAttribute(127, "b-tse3gjl7bi");
            __builder.AddContent(128, 
#nullable restore
#line 68 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Color

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n                                    ");
            __builder.OpenElement(130, "td");
            __builder.AddAttribute(131, "b-tse3gjl7bi");
            __builder.AddContent(132, 
#nullable restore
#line 69 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Ram

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n                                    ");
            __builder.OpenElement(134, "td");
            __builder.AddAttribute(135, "b-tse3gjl7bi");
            __builder.AddContent(136, 
#nullable restore
#line 70 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Storage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(137, "\r\n                                    ");
            __builder.OpenElement(138, "td");
            __builder.AddAttribute(139, "b-tse3gjl7bi");
            __builder.AddContent(140, 
#nullable restore
#line 71 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Cpu

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n                                    ");
            __builder.OpenElement(142, "td");
            __builder.AddAttribute(143, "b-tse3gjl7bi");
            __builder.AddContent(144, 
#nullable restore
#line 72 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Display

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(145, "\r\n                                    ");
            __builder.OpenElement(146, "td");
            __builder.AddAttribute(147, "b-tse3gjl7bi");
            __builder.AddContent(148, 
#nullable restore
#line 73 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Quantity

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(149, "\r\n                                    ");
            __builder.OpenElement(150, "td");
            __builder.AddAttribute(151, "b-tse3gjl7bi");
            __builder.AddContent(152, 
#nullable restore
#line 74 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                         smartphone.Price

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(153, "\r\n\r\n\r\n                                    ");
            __builder.OpenElement(154, "td");
            __builder.AddAttribute(155, "class", "d-flex");
            __builder.AddAttribute(156, "b-tse3gjl7bi");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(157);
            __builder.AddAttribute(158, "class", "nav-link");
            __builder.AddAttribute(159, "href", 
#nullable restore
#line 78 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                          $"addsmartphone/{smartphone.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(160, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(161, "<i class=\"fas fa-edit\" b-tse3gjl7bi></i>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(162, "\r\n                                        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(163);
            __builder.AddAttribute(164, "class", "nav-link");
            __builder.AddAttribute(165, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(166, "i");
                __builder2.AddAttribute(167, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 82 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                           e =>{setSmartphoneId(smartphone.Id);}

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(168, "class", "fas fa-trash-alt");
                __builder2.AddAttribute(169, "data-toggle", "modal");
                __builder2.AddAttribute(170, "data-target", "#deletesmartphonemodel");
                __builder2.AddAttribute(171, "b-tse3gjl7bi");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 86 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                            }
                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 92 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
             if (getSmartphones.Message.Any())
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(172, "h1");
            __builder.AddAttribute(173, "b-tse3gjl7bi");
            __builder.AddContent(174, 
#nullable restore
#line 94 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                     getSmartphones.Message.FirstOrDefault()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 95 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
            }
            else if (!getSmartphones.Message.Any() && !getSmartphones.Smartphones.Any())
            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(175, "<div class=\"d-flex justify-content-center\" b-tse3gjl7bi><span class=\"spinner-border\" b-tse3gjl7bi></span>\r\n                    <span class=\"ml-3\" b-tse3gjl7bi>Loading...</span></div>");
#nullable restore
#line 102 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(176, "\r\n    ");
            __builder.OpenComponent<MyManager.Client.Pages.Smartphones.DeleteSmartphoneModel>(177);
            __builder.AddAttribute(178, "onDelete", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<MyManager.Shared.ResponseModels.SmartPhoneResponse>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<MyManager.Shared.ResponseModels.SmartPhoneResponse>(this, 
#nullable restore
#line 106 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                     smartphoneDeleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(179, "smartphoneid", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 106 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Smartphones\ManageSmartphone.razor"
                                                                       smartphoneid

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591