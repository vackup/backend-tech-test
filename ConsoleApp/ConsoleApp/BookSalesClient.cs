using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BookSalesClient
    {
        readonly HttpClient client;

        public BookSalesClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task SaleBookAsync(BookSaleModel bookSaleModel)
        {
            var aaa = await this.client.GetAsync("api/Books");

            HttpResponseMessage response = await this.client.PostAsJsonAsync("api/BooksSales", bookSaleModel);
            response.EnsureSuccessStatusCode();
        }
    }
}