using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SharedLibraryUWP.ModelsUWP;
using SharedLibraryUWP.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPIoT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Message message = new Message();
        public MainPage()
        {
            this.InitializeComponent();
        }

        class Program
        {
            private static readonly string _conn = "HostName=linneaec-iothub.azure-devices.net;DeviceId=UWPIot;SharedAccessKey=OBlP9NT32G2sMTUoe3OyyWfvK51jwoSQAlbbFSuNYYE=";   //"Här lägger du meddelande från azure, Connection string "

            private static readonly DeviceClient deviceClient = DeviceClient
                .CreateFromConnectionString(_conn, TransportType.Mqtt);


        }
     
        private static readonly Random rnd = new Random();
      
        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {

                var data = new TemperatureModelsUWP
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(40, 50)

                };


                //JSON skriver ut såhär STANDARD som alla applikationer kan läsa, därför konverterar vi {temperature : 20, humidity 44 }
                var json = JsonConvert.SerializeObject(data);

                var payload = new Message(Encoding.UTF8.GetBytes(json));
                Console.WriteLine(lvTemperature);

                Console.WriteLine($"Message sent {json}");

                //  await Task.Delay(10 * 1000);


            }
        }
    }
}
