#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Bill\DeleteBillModel.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5991604b6974ccf5c5c5c84f10d159564c00549"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.Bill
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
    public partial class DeleteBillModel : DeleteBillBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal fade");
            __builder.AddAttribute(2, "id", "deletebillmodel");
            __builder.AddAttribute(3, "tabindex", "-1");
            __builder.AddAttribute(4, "role", "dialog");
            __builder.AddAttribute(5, "aria-labelledby", "exampleModalCenterTitle");
            __builder.AddAttribute(6, "aria-hidden", "true");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "modal-dialog modal-dialog-centered");
            __builder.AddAttribute(9, "role", "document");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "modal-content");
            __builder.AddMarkupContent(12, "<div class=\"modal-body deletemodelbody\">\r\n                Are you sure you want to remove this brand?\r\n            </div>\r\n            ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "modal-footer");
            __builder.AddMarkupContent(15, "<button type=\"button\" class=\"btn btn-primary\" data-dismiss=\"modal\">No</button>\r\n                ");
            __builder.OpenElement(16, "button");
            __builder.AddAttribute(17, "type", "button");
            __builder.AddAttribute(18, "class", "btn btn-danger");
            __builder.AddAttribute(19, "data-dismiss", "modal");
            __builder.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Bill\DeleteBillModel.razor"
                                                                                            deleteBill

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(21, "Yes");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
