using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.Application.Responses {
    public class BaseResponse {
        public BaseResponse() {
            Success = true;
            Message = string.Empty;
        }
        public BaseResponse(string message) {
            Success = true;
            Message = message;
        }

        public BaseResponse(bool success, string message) {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
