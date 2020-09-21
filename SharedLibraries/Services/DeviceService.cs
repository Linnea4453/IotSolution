using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MAD = Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using SharedLibraries.Models;

namespace SharedLibraries.Services
{
    public static class DeviceService
    {
        private static readonly Random rnd = new Random();


        //DeviceClient = Iot (Bilen)
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            while (true)
            {

                var data = new TemperatureModel
                {
                    Temperature = rnd.Next(20, 30),
                    Humidity = rnd.Next(40, 50)

                };
                //JSON skriver ut såhär STANDARD som alla applikationer kan läsa, därför konverterar vi {temperature : 20, humidity 44 }
                var json = JsonConvert.SerializeObject(data);

                var payload = new Message(Encoding.UTF8.GetBytes(json)); 
                await deviceClient.SendEventAsync(payload);

                Console.WriteLine($"Message sent {json}");

                await Task.Delay(10 * 1000);

            }
        }       //Skicka meddelande
        //Deviceclient = iot (Bilden
        public static async Task ReciveMessageAsync(DeviceClient deviceClient)   
        { while (true)
            {
                var payload = await deviceClient.ReceiveAsync();

                if (payload == null)
                    continue;

                Console.WriteLine($"Message recived: { Encoding.UTF8.GetString(payload.GetBytes())}");

                await deviceClient.CompleteAsync(payload);
            
            }


        }

        //VG del
        //Service Client = IotHub (Mobilen)
        public static async Task SendMessageToDeviceAsync(MAD.ServiceClient serviceClient, string targetDeviceId, string message)
        {
            var payload = new MAD.Message(Encoding.UTF8.GetBytes(message));
            await serviceClient.SendAsync(targetDeviceId, payload);

        }
    }
}
