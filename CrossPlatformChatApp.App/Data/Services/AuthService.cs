using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace CrossPlatformChatApp.App.Data.Services {
    public class AuthService : IAuthService {

        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
    

        public AuthService() {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            _httpClient = new HttpClient(handler);
            _url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5205" : "http://localhost:5205";
            //_url = "https://localhost:7018/";

            _jsonSerializerOptions = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<UserDto> Login(string email, string password) {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) {
                Debug.WriteLine("No Internet Access");
                return null;
            }

            try {
                var serializedObject = JsonConvert.SerializeObject(new { email, password });
                var request = new HttpRequestMessage(HttpMethod.Post, "authenticate") {
                    Content = new StringContent(serializedObject, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Auth/Login", request.Content);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    ResponseBaseDto<UserDto> user = JsonConvert.DeserializeObject<ResponseBaseDto<UserDto>>(content);

                    dynamic data = JObject.Parse(content);
                    //string token = data["token"];
                    //await SecureStorage.Default.SetAsync("bearerToken", token);

                    return user.Data;
                }
                return null;
            } 
            catch (Exception ex) {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
