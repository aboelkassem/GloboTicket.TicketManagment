﻿using GloboTicket.TicketManagement.Web.Contracts;
using GloboTicket.TicketManagement.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Web.Pages
{
    public partial class CategoryOverview
    {
        [Inject]
        public ICategoryDataService CategoryDataService{ get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryEventsViewModel> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if((bool)args.Value)
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
            }
            else
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
            }
        }
    }
}
