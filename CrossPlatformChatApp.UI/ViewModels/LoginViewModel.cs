using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.UI.ViewModels {
    public class LoginViewModel : ObservableObject {
        [ObservableProperty]
        string _test;
        public LoginViewModel() {
            Test = "";
        }
    }

}
