﻿using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Web.Contracts;
using GloboTicket.TicketManagement.Web.Services.Base;
using GloboTicket.TicketManagement.Web.ViewModels;

namespace GloboTicket.TicketManagement.Web.Services
{
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;

        public CategoryDataService(IClient client, IMapper mapper, ILocalStorageService localStorage): base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var allCategories = await _client.ApiCategoryAllAsync();
            var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
            return mappedCategories.ToList();

        }

        public async Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory)
        {
            var allCategories = await _client.ApiCategoryAllWithEventsAsync(includeHistory);
            var mappedCategories = _mapper.Map<ICollection<CategoryEventsViewModel>>(allCategories);
            return mappedCategories.ToList();
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                ApiResponse<CategoryDto> apiResponse = new ApiResponse<CategoryDto>();
                CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
                var createCategoryCommandResponse = await _client.ApiCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CategoryDto>(createCategoryCommandResponse.Category);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCategoryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CategoryDto>(ex);
            }
        }
    }
}