﻿using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Responses.PageList;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastRepository
    {
        Task<Domain.Entities.WeatherForecast?> GetByIdAsync(WeatherForecastGetByIdRequest request);
        Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAllAsync();
        Task<PageListResponse<WeatherForecastGetListItemResponse>> GetListAsync(ISpecification<Domain.Entities.WeatherForecast> request);
        Task AddAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task UpdateAsync(Domain.Entities.WeatherForecast weatherForecast);
        Task DeleteAsync(Guid id);
    }
}
