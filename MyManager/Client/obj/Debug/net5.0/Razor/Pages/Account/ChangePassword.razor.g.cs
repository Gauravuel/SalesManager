#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55269617fd8793270422e2dd7aa5de81e7e48e98"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.Account
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/changepassword")]
    public partial class ChangePassword : ChangePasswordBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container-fluid");
            __builder.AddAttribute(2, "b-vjg6ytv7fx");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row newpassrow d-flex justify-content-center align-items-center");
            __builder.AddAttribute(5, "b-vjg6ytv7fx");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "col-md-4 bg-white newpasscolumn");
            __builder.AddAttribute(8, "b-vjg6ytv7fx");
            __builder.AddMarkupContent(9, "<h3 class=\"newpassbanner\" b-vjg6ytv7fx>Change Password</h3>\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(10);
            __builder.AddAttribute(11, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 9 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                              changePasswordModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                                                  handleSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(14);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(15, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(16);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(17, "\r\n                ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group");
                __builder2.AddAttribute(20, "b-vjg6ytv7fx");
                __builder2.AddMarkupContent(21, "<label for=\"prevpass\" b-vjg6ytv7fx>Previous Password</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(22);
                __builder2.AddAttribute(23, "type", "password");
                __builder2.AddAttribute(24, "class", "form-control");
                __builder2.AddAttribute(25, "id", "prevpass");
                __builder2.AddAttribute(26, "placeholder", "Previous Password");
                __builder2.AddAttribute(27, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                                                                               changePasswordModel.PrevPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(28, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => changePasswordModel.PrevPassword = __value, changePasswordModel.PrevPassword))));
                __builder2.AddAttribute(29, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => changePasswordModel.PrevPassword));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\r\n                    ");
                __Blazor.MyManager.Client.Pages.Account.ChangePassword.TypeInference.CreateValidationMessage_0(__builder2, 31, 32, 
#nullable restore
#line 15 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                              ()=>changePasswordModel.PrevPassword

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(33, "\r\n                ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "form-group");
                __builder2.AddAttribute(36, "b-vjg6ytv7fx");
                __builder2.AddMarkupContent(37, "<label for=\"cupass\" b-vjg6ytv7fx>Current Password</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(38);
                __builder2.AddAttribute(39, "type", "password");
                __builder2.AddAttribute(40, "class", "form-control");
                __builder2.AddAttribute(41, "id", "cupass");
                __builder2.AddAttribute(42, "placeholder", "Current Password");
                __builder2.AddAttribute(43, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                                                                             changePasswordModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(44, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => changePasswordModel.Password = __value, changePasswordModel.Password))));
                __builder2.AddAttribute(45, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => changePasswordModel.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(46, "\r\n                    ");
                __Blazor.MyManager.Client.Pages.Account.ChangePassword.TypeInference.CreateValidationMessage_1(__builder2, 47, 48, 
#nullable restore
#line 20 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                              ()=>changePasswordModel.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, "\r\n                ");
                __builder2.OpenElement(50, "div");
                __builder2.AddAttribute(51, "class", "form-group");
                __builder2.AddAttribute(52, "b-vjg6ytv7fx");
                __builder2.AddMarkupContent(53, "<label for=\"confPassword\" b-vjg6ytv7fx> Confirm-Password</label>\r\n                    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(54);
                __builder2.AddAttribute(55, "type", "password");
                __builder2.AddAttribute(56, "class", "form-control");
                __builder2.AddAttribute(57, "id", "confPassword");
                __builder2.AddAttribute(58, "placeholder", "Confirm-Password");
                __builder2.AddAttribute(59, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                                                                                   changePasswordModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(60, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => changePasswordModel.ConfirmPassword = __value, changePasswordModel.ConfirmPassword))));
                __builder2.AddAttribute(61, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => changePasswordModel.ConfirmPassword));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(62, "\r\n                    ");
                __Blazor.MyManager.Client.Pages.Account.ChangePassword.TypeInference.CreateValidationMessage_2(__builder2, 63, 64, 
#nullable restore
#line 25 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Account\ChangePassword.razor"
                                              ()=>changePasswordModel.ConfirmPassword

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n                ");
                __builder2.AddMarkupContent(66, "<div class=\"d-flex justify-content-center\" b-vjg6ytv7fx><button type=\"submit\" class=\"newpassbtn\" b-vjg6ytv7fx>Submit</button></div>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.MyManager.Client.Pages.Account.ChangePassword
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
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
