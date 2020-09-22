using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Azure.Devices.Client;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        class Program
        {
            private static readonly string _conn = "HostName=linneaec-iothub.azure-devices.net;DeviceId=ConsoleApp;SharedAccessKey=qeGeFlp6JF34sorATZI6QM8ik1bwGnWfE3/zeCLaE7E=";   //"Här lägger du meddelande från azure, Connection string "

            private static readonly DeviceClient deviceClient = DeviceClient
                .CreateFromConnectionString(_conn, TransportType.Mqtt);


            static void Main(string[] args)
            {

                DeviceServiceUWP.SendMessageAsync(deviceClient).GetAwaiter();
                DeviceServiceUWP.ReciveMessageAsync(deviceClient).GetAwaiter();

                Console.ReadKey();


            }




        }
    }
}