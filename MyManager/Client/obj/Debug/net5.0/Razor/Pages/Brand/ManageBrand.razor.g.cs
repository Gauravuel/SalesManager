#pragma checksum "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d036767c7be9ea64b0dba576ee97e930f52a083e"
// <auto-generated/>
#pragma warning disable 1591
namespace MyManager.Client.Pages.Brand
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/managebrand")]
    public partial class ManageBrand : ManageBrandBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddAttribute(2, "b-bdzd7do7tr");
            __builder.AddMarkupContent(3, "<h1 b-bdzd7do7tr>Available Brand</h1>\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "d-flex justify-content-end");
            __builder.AddAttribute(6, "b-bdzd7do7tr");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(7);
            __builder.AddAttribute(8, "class", "nav-link");
            __builder.AddAttribute(9, "href", "addbrand");
            __builder.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(11, "<button type=\"button\" class=\"brandbtn\" b-bdzd7do7tr><i class=\"fa fa-plus\" b-bdzd7do7tr></i>Add Brand</button>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n\r\n    ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "table-responsive");
            __builder.AddAttribute(15, "b-bdzd7do7tr");
            __builder.OpenElement(16, "table");
            __builder.AddAttribute(17, "class", "table table-striped");
            __builder.AddAttribute(18, "b-bdzd7do7tr");
            __builder.AddMarkupContent(19, @"<thead b-bdzd7do7tr><tr b-bdzd7do7tr><th scope=""col"" b-bdzd7do7tr>Id</th>
                    <th scope=""col"" b-bdzd7do7tr>Name</th>
                    <th scope=""col"" b-bdzd7do7tr>Category</th>
                    <th scope=""col"" b-bdzd7do7tr>Description</th>
                    <th scope=""col"" b-bdzd7do7tr>Actions</th></tr></thead>
            ");
            __builder.OpenElement(20, "tbody");
            __builder.AddAttribute(21, "b-bdzd7do7tr");
#nullable restore
#line 26 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                 if (getBrand.Brands.Any())
                {
                    foreach (var brand in getBrand.Brands)
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(22, "tr");
            __builder.AddAttribute(23, "b-bdzd7do7tr");
            __builder.OpenElement(24, "td");
            __builder.AddAttribute(25, "b-bdzd7do7tr");
            __builder.AddContent(26, 
#nullable restore
#line 31 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                 brand.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                            ");
            __builder.OpenElement(28, "td");
            __builder.AddAttribute(29, "b-bdzd7do7tr");
            __builder.AddContent(30, 
#nullable restore
#line 32 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                 brand.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                            ");
            __builder.OpenElement(32, "td");
            __builder.AddAttribute(33, "b-bdzd7do7tr");
            __builder.AddContent(34, 
#nullable restore
#line 33 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                 brand.Category_Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                            ");
            __builder.OpenElement(36, "td");
            __builder.AddAttribute(37, "b-bdzd7do7tr");
            __builder.AddContent(38, 
#nullable restore
#line 34 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                 brand.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n\r\n                            ");
            __builder.OpenElement(40, "td");
            __builder.AddAttribute(41, "class", "d-flex");
            __builder.AddAttribute(42, "b-bdzd7do7tr");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(43);
            __builder.AddAttribute(44, "class", "nav-link");
            __builder.AddAttribute(45, "href", 
#nullable restore
#line 37 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                                                  $"addbrand/{brand.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(46, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(47, "<i class=\"fas fa-edit\" b-bdzd7do7tr></i>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(48, "\r\n                                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(49);
            __builder.AddAttribute(50, "class", "nav-link");
            __builder.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(52, "i");
                __builder2.AddAttribute(53, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                                   e =>{setBrandId(brand.Id);}

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(54, "class", "fas fa-trash-alt");
                __builder2.AddAttribute(55, "data-toggle", "modal");
                __builder2.AddAttribute(56, "data-target", "#deletebrandmodel");
                __builder2.AddAttribute(57, "b-bdzd7do7tr");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 45 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                    }
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 51 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
     if (getBrand.Message.Any())
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(58, "h1");
            __builder.AddAttribute(59, "b-bdzd7do7tr");
            __builder.AddContent(60, 
#nullable restore
#line 53 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
             getBrand.Message.FirstOrDefault()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 54 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
    }
    else if (!getBrand.Message.Any() && !getBrand.Brands.Any())
    {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(61, "<div class=\"d-flex justify-content-center\" b-bdzd7do7tr><span class=\"spinner-border\" b-bdzd7do7tr></span>\r\n            <span class=\"ml-3\" b-bdzd7do7tr>Loading...</span></div>");
#nullable restore
#line 61 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n");
            __builder.OpenComponent<MyManager.Client.Pages.Brand.DeleteBrandModel>(63);
            __builder.AddAttribute(64, "onDelete", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<MyManager.Shared.ResponseModels.BrandResponse>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<MyManager.Shared.ResponseModels.BrandResponse>(this, 
#nullable restore
#line 64 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                            brandDeleted

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(65, "brandid", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 64 "C:\Users\Toshiba\Desktop\College Final Year\FYP\fyp\MyManager\Client\Pages\Brand\ManageBrand.razor"
                                                    brandid

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