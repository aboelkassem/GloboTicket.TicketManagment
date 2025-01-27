﻿using GloboTicket.TicketManagement.Web.Contracts;
using GloboTicket.TicketManagement.Web.Services;
using GloboTicket.TicketManagement.Web.Services.Base;
using GloboTicket.TicketManagement.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Web.Pages
{
    public partial class AddCategory
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CategoryViewModel CategoryViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CategoryDataService.CreateCategory(CategoryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CategoryDto> response)
        {
            if (response.Success)
            {
                Message = "Category added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
