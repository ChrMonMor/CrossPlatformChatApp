using CommunityToolkit.Mvvm.ComponentModel;
using CrossPlatformChatApp.App.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformChatApp.App.ViewModels {

    [QueryProperty(nameof(Email), "Email")]
    public partial class SignUpViewModel : ObservableObject {

        [ObservableProperty]
        string _email;

    }
}
