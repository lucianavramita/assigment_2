// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Assignment_1_.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Assignment_1_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\_Imports.razor"
using Assignment_1_.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\Pages\AddAdult.razor"
using Assignment_1_.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\Pages\AddAdult.razor"
using Assigment_1_.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\Pages\AddAdult.razor"
           [Authorize(Policy = "SecurityLevel2")]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddAdult")]
    public partial class AddAdult : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "C:\Users\User\Desktop\Assignment_1_\Assignment_1_\Assignment_1_\Pages\AddAdult.razor"
       
    private Adult newAdult = new Adult();
    private Job newJob = new Job();
    
    protected override async Task OnInitializedAsync()
    {
        newAdult.JobTitle = newJob;
    }

    private async void AddNewAdult()
    {
        Console.WriteLine("Trying...");
        if (newAdult != null)
        {
            await  PeopleService.AddAdult(newAdult);
        }
        NavigationManager.NavigateTo("/viewadultslist");
        Console.WriteLine("Done");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IPeopleService PeopleService { get; set; }
    }
}
#pragma warning restore 1591
