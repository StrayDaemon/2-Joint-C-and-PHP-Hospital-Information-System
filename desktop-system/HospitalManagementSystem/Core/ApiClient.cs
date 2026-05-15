using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HospitalManagementSystem.Core
{
    public static class ApiClient
    {
        // ── Node.js API base URL ────────────────────────────────
        private const string BaseUrl = "http://localhost:3000/api/";

        private static readonly HttpClient _client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        // ════════════════════════════════════════════════════════
        //  GET  BaseUrl + endpoint
        //  e.g. GET /api/patients
        //       GET /api/patients/4
        //       GET /api/appointments?pid=4&filter=1
        // ════════════════════════════════════════════════════════
        public static async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                string url = BaseUrl + endpoint;
                HttpResponseMessage response = await _client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var err = JsonConvert.DeserializeObject<ApiResponse>(json);
                    throw new Exception(err?.Message ?? "Request failed.");
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Request timed out. Is the Node.js server running?");
            }
            catch (Exception ex)
            {
                throw new Exception($"GET [{endpoint}] failed: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════
        //  POST  BaseUrl + endpoint
        //  Sends form data as application/x-www-form-urlencoded
        // ════════════════════════════════════════════════════════
        public static async Task<T> PostAsync<T>(
            string endpoint,
            Dictionary<string, string> formData)
        {
            try
            {
                string url = BaseUrl + endpoint;
                var content = new FormUrlEncodedContent(formData);

                HttpResponseMessage response =
                    await _client.PostAsync(url, content);

                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var err = JsonConvert.DeserializeObject<ApiResponse>(json);
                    throw new Exception(err?.Message ?? "Request failed.");
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Request timed out. Is the Node.js server running?");
            }
            catch (Exception ex)
            {
                throw new Exception($"POST [{endpoint}] failed: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════
        //  PUT  BaseUrl + endpoint
        //  Sends form data as application/x-www-form-urlencoded
        // ════════════════════════════════════════════════════════
        public static async Task<T> PutAsync<T>(
            string endpoint,
            Dictionary<string, string> formData)
        {
            try
            {
                string url = BaseUrl + endpoint;
                var content = new FormUrlEncodedContent(formData);

                var request = new HttpRequestMessage(HttpMethod.Put, url)
                {
                    Content = content
                };

                HttpResponseMessage response =
                    await _client.SendAsync(request);

                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var err = JsonConvert.DeserializeObject<ApiResponse>(json);
                    throw new Exception(err?.Message ?? "Request failed.");
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Request timed out. Is the Node.js server running?");
            }
            catch (Exception ex)
            {
                throw new Exception($"PUT [{endpoint}] failed: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════
        //  DELETE  BaseUrl + endpoint
        // ════════════════════════════════════════════════════════
        public static async Task<T> DeleteAsync<T>(string endpoint)
        {
            try
            {
                string url = BaseUrl + endpoint;

                HttpResponseMessage response =
                    await _client.DeleteAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    var err = JsonConvert.DeserializeObject<ApiResponse>(json);
                    throw new Exception(err?.Message ?? "Request failed.");
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (TaskCanceledException)
            {
                throw new Exception("Request timed out. Is the Node.js server running?");
            }
            catch (Exception ex)
            {
                throw new Exception($"DELETE [{endpoint}] failed: {ex.Message}");
            }
        }
    }

    // ════════════════════════════════════════════════════════════
    //  Standard response wrapper — matches Node.js API shape:
    //  { "success": bool, "message": string, "data": T }
    // ════════════════════════════════════════════════════════════
    public class ApiResponse<T>
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }

    // For responses with no data payload
    public class ApiResponse : ApiResponse<object> { }
}