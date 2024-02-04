using BMCFileMangement.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.Implementation
{
    public class MessageService : IMessageService
    {
        public string GetSuccessMessage()
        {
            return "Successful Operation!!";
        }

        public string GetUserIPAddress()
        {
            string ipAddress = "NA";
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Check if the network interface is up and not a loopback or tunnel interface
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    // Get the IP properties of the network interface
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                    // Iterate through the unicast addresses associated with the network interface
                    foreach (UnicastIPAddressInformation unicastAddress in ipProperties.UnicastAddresses)
                    {
                        // Filter for IPv4 addresses
                        if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress += unicastAddress.Address;
                        }
                    }
                }
            }
            return ipAddress;
        }
    }
}
