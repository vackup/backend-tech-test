using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 
                                                              | SecurityProtocolType.Tls11 
                                                              | SecurityProtocolType.Tls12
                                                              | SecurityProtocolType.Tls13;

            Console.WriteLine("Book Seller");

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:49157/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var client = new BookSalesClient(httpClient);
            var bookSaleModelList = new List<BookSaleModel>
            {
                GetNewBook(1),
                GetNewBook(2),
                GetNewBook(3),
                GetNewBook(4),
                GetNewBook(5),
            };

            var tasks = new List<Task<Tuple<BookSaleModel, int, double>>>();
            var times = 1000;

            Console.WriteLine($"Selling {bookSaleModelList.Count} books {times} times.");

            Parallel.ForEach(bookSaleModelList, bookSaleModel =>
            {
                for (int i = 0; i < times - 1; i++)
                {
                    async Task<Tuple<BookSaleModel, int, double>> Func(int execution)
                    {
                        var start = DateTime.Now;

                        try
                        {
                            await client.SaleBookAsync(bookSaleModel);
                        }
                        catch (Exception e)
                        {
                            // ignored
                            Console.WriteLine(e.ToString());
                        }

                        var elapsedMiliseconds = (DateTime.Now - start).TotalMilliseconds;

                        return new Tuple<BookSaleModel, int, double>(bookSaleModel, execution, elapsedMiliseconds);
                    }

                    tasks.Add(Func(i));
                }
            });

            Console.WriteLine("Waitin for results.");

            var taskResults = await Task.WhenAll(tasks);

            Console.WriteLine("Results:");

            foreach (var bookSaleModel in bookSaleModelList)
            {
                var bookExecutions = taskResults.Where(t => t.Item1.Id == bookSaleModel.Id).ToList();

                Console.WriteLine($"Book {bookSaleModel.Id}     {bookExecutions.Count}      {bookExecutions.Average(b => b.Item3)}");
            }

            Console.WriteLine("Press Enter to finish.");
            Console.ReadLine();
        }

        private static BookSaleModel GetNewBook(int id)
        {
            return new BookSaleModel { Id = id };
        }
    }
}
