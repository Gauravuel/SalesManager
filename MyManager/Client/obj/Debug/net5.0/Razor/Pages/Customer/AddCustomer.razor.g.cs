#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12f2d0325aa54c89711c61e2b6302794e3e22c8d"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.Customer
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/addcustomer")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/addcustomer/{Id}")]
    public partial class AddCustomer : AddCustomerBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container-fluid mt-5");
            __builder.AddAttribute(2, "b-um0ebwhovp");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "col-8 offset-2 h-100");
            __builder.AddAttribute(5, "b-um0ebwhovp");
            __builder.OpenElement(6, "h3");
            __builder.AddAttribute(7, "class", "label");
            __builder.AddAttribute(8, "b-um0ebwhovp");
            __builder.AddContent(9, 
#nullable restore
#line 9 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                           DynamicLabel

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(10, " Customer");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(12);
            __builder.AddAttribute(13, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                          customerView

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                                       handleSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(15, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(16);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n            ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group");
                __builder2.AddAttribute(20, "b-um0ebwhovp");
                __builder2.AddMarkupContent(21, "<label for=\"name\" b-um0ebwhovp>Customer Name</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(22);
                __builder2.AddAttribute(23, "type", "text");
                __builder2.AddAttribute(24, "class", "form-control");
                __builder2.AddAttribute(25, "id", "name");
                __builder2.AddAttribute(26, "placeholder", "Enter customer name");
                __builder2.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                                                         customerView.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => customerView.Name = __value, customerView.Name))));
                __builder2.AddAttribute(29, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => customerView.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\r\n                ");
                __Blazor.MyManager.Client.Pages.Customer.AddCustomer.TypeInference.CreateValidationMessage_0(__builder2, 31, 32, 
#nullable restore
#line 15 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                          ()=>customerView.Name

#line default
#line hidden
#nullable disable
                , 33, "validationmessage");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n            ");
                __builder2.OpenElement(35, "div");
                __builder2.AddAttribute(36, "class", "form-group");
                __builder2.AddAttribute(37, "b-um0ebwhovp");
                __builder2.AddMarkupContent(38, "<label for=\"address\" b-um0ebwhovp>Address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(39);
                __builder2.AddAttribute(40, "type", "text");
                __builder2.AddAttribute(41, "class", "form-control");
                __builder2.AddAttribute(42, "id", "address");
                __builder2.AddAttribute(43, "placeholder", "Address");
                __builder2.AddAttribute(44, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                                                                      customerView.Address

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => customerView.Address = __value, customerView.Address))));
                __builder2.AddAttribute(46, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => customerView.Address));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(47, "\r\n                ");
                __Blazor.MyManager.Client.Pages.Customer.AddCustomer.TypeInference.CreateValidationMessage_1(__builder2, 48, 49, 
#nullable restore
#line 20 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                          ()=>customerView.Address

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n            ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "form-group");
                __builder2.AddAttribute(53, "b-um0ebwhovp");
                __builder2.AddMarkupContent(54, "<label for=\"phone\" b-um0ebwhovp>Contact</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(55);
                __builder2.AddAttribute(56, "type", "text");
                __builder2.AddAttribute(57, "class", "form-control");
                __builder2.AddAttribute(58, "id", "phone");
                __builder2.AddAttribute(59, "placeholder", "Phone number");
                __builder2.AddAttribute(60, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                                                                    customerView.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => customerView.Phone = __value, customerView.Phone))));
                __builder2.AddAttribute(62, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => customerView.Phone));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(63, "\r\n                ");
                __Blazor.MyManager.Client.Pages.Customer.AddCustomer.TypeInference.CreateValidationMessage_2(__builder2, 64, 65, 
#nullable restore
#line 25 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                          ()=>customerView.Phone

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(66, "\r\n\r\n\r\n            ");
                __builder2.OpenElement(67, "div");
                __builder2.AddAttribute(68, "class", "d-flex justify-content-center");
                __builder2.AddAttribute(69, "b-um0ebwhovp");
                __builder2.OpenElement(70, "button");
                __builder2.AddAttribute(71, "type", "submit");
                __builder2.AddAttribute(72, "class", "customerbtn");
                __builder2.AddAttribute(73, "b-um0ebwhovp");
                __builder2.AddContent(74, 
#nullable restore
#line 30 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Customer\AddCustomer.razor"
                                                           DynamicLabel

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyManager.Client.Pages.Customer.AddCustomer
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0, int __seq1, System.Object __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.AddAttribute(__seq1, "class", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591