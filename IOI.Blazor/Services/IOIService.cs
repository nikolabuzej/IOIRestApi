using FrontEnd.Domain;
using IOI.Blazor.Utilities;
using System.Net.Http.Json;
using System.Text.Json;
using domain = FrontEnd.Domain;
namespace IOI.Blazor.Services
{
    public class IOIService
    {
        private readonly HttpClient _httpClient;

        public IOIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<domain.IOI>> VratiInformacije()
        {
            var response = (await _httpClient.GetAsync(UrlRegistry.IOI)).EnsureSuccessStatusCode();

            return await DecodeBody<IEnumerable<domain.IOI>>(response);
        }
        public async Task<domain.IOI> VratiInformaciju(int id)
        {
            var response = (await _httpClient.GetAsync($"{UrlRegistry.IOI}{id}")).EnsureSuccessStatusCode();

            return await DecodeBody<domain.IOI>(response);
        }
        public async Task<domain.IOI> Azuriraj(domain.IOI ioi)
        {
            var response = (await _httpClient.PutAsJsonAsync($"{UrlRegistry.IOI}{ioi.IOIid}", ioi)).EnsureSuccessStatusCode();

            return await DecodeBody<domain.IOI>(response);
        }
        public async Task Obrisi(int id)
        {
            _ = (await _httpClient.DeleteAsync($"{UrlRegistry.IOI}{id}")).EnsureSuccessStatusCode();
        }
        public async Task<domain.IOI> KreirajIOI(domain.IOI ioi)
        {
            HttpResponseMessage response = (await _httpClient.PostAsJsonAsync(UrlRegistry.IOI, ioi))
                                                            .EnsureSuccessStatusCode();

            return (await DecodeBody<domain.IOI>(response));
        }
        public async Task<IEnumerable<Warranty>> VratiGarancije()
        {
            HttpResponseMessage? response = (await _httpClient.GetAsync(UrlRegistry.Warranty)).EnsureSuccessStatusCode();

            return (await DecodeBody<IEnumerable<Warranty>>(response));
        }
        private static async Task<T> DecodeBody<T>(HttpResponseMessage response)
        {

            var body = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<T>(body);

            return result;
        }
    }
}
