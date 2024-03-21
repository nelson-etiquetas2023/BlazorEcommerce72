using Microsoft.AspNetCore.Components;
using Orders.FrontEnd.Repositories;
using Orders.Shared.Entities;

namespace Orders.FrontEnd.Pages.Contries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<Country>? Countries { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("api/Countries");
            Countries = responseHttp.Response!;

        }
    }
}
 