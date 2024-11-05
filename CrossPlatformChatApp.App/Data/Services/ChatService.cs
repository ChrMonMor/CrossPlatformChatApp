using CrossPlatformChatApp.App.Data.Interfaces;
using CrossPlatformChatApp.App.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CrossPlatformChatApp.App.Data.Services {
    public class ChatService : IChatService {

        private readonly HttpClient _httpClient;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;


        public ChatService() {
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

        public async Task<ChatDto> GetChatDto(Guid id) {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet) {
                Debug.WriteLine("No Internet Access");
                return null;
            }

            try {
                int count = 1;
                var serializedObject = JsonConvert.SerializeObject(new { id, count });
                var request = new HttpRequestMessage(HttpMethod.Post, "authenticate") {
                    Content = new StringContent(serializedObject, Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Chat/GetById", request.Content);
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    ResponseBaseDto<ChatDto> chat = JsonConvert.DeserializeObject<ResponseBaseDto<ChatDto>>(content);

                    dynamic data = JObject.Parse(content);
                    //string token = data["token"];
                    //await SecureStorage.Default.SetAsync("bearerToken", token);

                    return chat.Data;
                }
                return null;
            } catch (Exception ex) {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
