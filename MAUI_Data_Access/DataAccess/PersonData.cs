using MAUI_Data_Access.Models;
using Newtonsoft.Json;

namespace MAUI_Data_Access.DataAccess
{
    // Data access now goes through the PeopleWebAPI RESTful web service instead of a local SQLite file
    public class PersonData
    {
        // Port must match the running PeopleWebAPI (see Properties/launchSettings.json in that project)
        const string ApiUrl = "http://localhost:5080/api/Person";

        public async Task<List<Person>> GetPeopleAsync()
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                List<Person> people = new List<Person>();

                var response = await client.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!String.IsNullOrEmpty(content))
                    {
                        people = JsonConvert.DeserializeObject<List<Person>>(content) ?? new List<Person>();
                    }
                }

                return people;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SavePersonAsync(Person person)
        {
            HttpClient client;

            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");

                var content = JsonConvert.SerializeObject(person);
                var buff = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buff);
                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(ApiUrl, byteContent);
                return response.IsSuccessStatusCode ? 1 : 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
