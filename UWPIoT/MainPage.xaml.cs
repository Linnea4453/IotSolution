using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibraryUWP.ModelsUWP;
using SharedLibraryUWP.Services;
using Windows.Devices.Sms;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPIoT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {



        public MainPage()
        {
            this.InitializeComponent();


        }
        private static readonly string _conn = "HostName=linneaec-iothub.azure-devices.net;DeviceId=UWPIot;SharedAccessKey=OBlP9NT32G2sMTUoe3OyyWfvK51jwoSQAlbbFSuNYYE=";   //"Här lägger du meddelande från azure, Connection string "

        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(_conn, TransportType.Mqtt);


        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
            {
            DeviceServiceUWP.SendMessageAsync(deviceClient);
            }

            
    }
}

