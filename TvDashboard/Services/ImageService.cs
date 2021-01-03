using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TvDashboard.Dtos.ImageDtos;

namespace TvDashboard.Services
{
    public interface IImageService : ISubscribable<string>
    {
        Task<string> GetImageUrl();
    }
    
    public class ImageService : IImageService
    {
        private readonly HttpClient httpClient;
        private readonly string uri;
        private int page = 1;

        public ImageService(IConfiguration configuration)
        {
            uri = configuration["imageApiUrl"];
            httpClient = new()
            {
                DefaultRequestHeaders = {{"Authorization", configuration["imageApiKey"]}}
            };
        }

        public async Task<string> GetImageUrl()
        {
            var res = await httpClient.GetFromJsonAsync<PexelsResponse>(
                $"{uri}?query=nature&per_page=1&page={page}&orientation=landscape");

            page += 1;
            if (page > res?.TotalResults) page = 1;
            
            return res?.Photos.First().Src.Original;
        }

        public void Subscribe(Action<string> setUrl)
        {   
            var timer = new Timer(async _ =>
            {
                setUrl(await GetImageUrl());
            }, null, 0, 100000);
        }
    }
}