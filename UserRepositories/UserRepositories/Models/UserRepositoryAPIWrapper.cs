using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using System.Threading.Tasks;

namespace UserRepositories.Models
{
    public class UserRepositoryAPIWrapper
    {
        private string baseUrl;

        public UserRepositoryAPIWrapper()
        {
            baseUrl = ConfigurationManager.AppSettings["GitRepositoryAPI"];
        }

        public User GetRepositories(string name, int count)
        {
            string fullUrlForUserRepository = baseUrl + name.Trim();
            var result = GetTopRepositories(fullUrlForUserRepository, count);

            return result;
        }

        private User GetTopRepositories(string fullUrlForUserRepository, int count)
        {
            User user = GetResultFromAPI<User>(fullUrlForUserRepository);
            List<Repository> repos = GetResultFromAPI<List<Repository>>(user.Repos_Url);

            var topRepos = (from repo in repos
                            orderby repo.Stargazers_count descending
                            select repo).Take(count).ToList();

            user.Repositories = topRepos;

            return user;
        }

        private T GetResultFromAPI<T>(string url)
        {
            T result;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "User Repository Application");

                var response = httpClient.GetAsync(url);
                result = response.Result.Content.ReadAsAsync<T>().Result;

            }
            return result;
        }

    }
}