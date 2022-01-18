using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Dynamic;
using Moduit.Interview.Models;

namespace Moduit.Interview.Repositories
{

    public class QuestionRepository : IQuestionRepository
    {
        HttpClient client;
        public QuestionRepository(string baseUrl)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer put-the-token");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
        }

        public async Task<Response> GetQuestionOne()
        {
            Response response = new Response();

            using (var httpResponse = await client.GetAsync("/backend/question/one"))
            {
                if (httpResponse != null)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentResponse = await httpResponse.Content.ReadAsStringAsync();
                        response = JsonSerializer.Deserialize<Response>(contentResponse);
                    }
                }
            }

            return response;
        }


        public async Task<List<Response>> GetQuestionTwo()
        {
            List<Response> responseList = new List<Response>();

            using (var httpResponse = await client.GetAsync("/backend/question/two"))
            {
                if (httpResponse != null)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentResponse = await httpResponse.Content.ReadAsStringAsync();
                        responseList = JsonSerializer.Deserialize<List<Response>>(contentResponse);
                        string filter1 = "Ergonomi";
                        string filter2 = "Sports";
                        if (responseList.Count > 0)
                        {
                            responseList = responseList.Where(x =>
                                (x.description.Contains(filter1) || x.title.Contains(filter1))
                                && (x.tags != null && x.tags.Contains(filter2))
                            )
                            .OrderByDescending(x => x.id)
                            .Take(3)
                            .ToList();
                        }
                    }
                }
            }

            return responseList;
        }

        public async Task<List<Response>> GetQuestionThree()
        {
            List<Response> responseList = new List<Response>();

            using (var httpResponse = await client.GetAsync("/backend/question/three"))
            {
                if (httpResponse != null)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentResponse = await httpResponse.Content.ReadAsStringAsync();
                        List<ResponseItems> responseItemList = JsonSerializer.Deserialize<List<ResponseItems>>(contentResponse);
                        if (responseItemList.Count > 0)
                        {
                            responseItemList.OrderBy(x => x.id)
                            .ToList().ForEach(x =>
                            {
                                if (x.items != null)
                                {
                                    x.items.OrderBy(i => i.title)
                                    .ToList().ForEach(i =>
                                    {
                                        Response response = new Response();
                                        response.id = x.id;
                                        response.category = x.category;
                                        response.tags = x.tags;
                                        response.createdAt = x.createdAt;
                                        response.title = i.title;
                                        response.description = i.description;
                                        response.footer = i.footer;
                                        
                                        responseList.Add(response);
                                    });
                                }
                                else
                                {
                                    Response response = new Response();
                                    response.id = x.id;
                                    response.category = x.category;
                                    response.tags = x.tags;
                                    response.createdAt = x.createdAt;

                                    responseList.Add(response);
                                }
                            });
                        }
                    }
                }
            }

            return responseList;
        }
    }
}
