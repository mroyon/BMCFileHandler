using AppConfig.HelperClasses;
using BDO.Core.Base;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BMCFileMangement.forms.UserControls;
using BMCFileMangement.Services.Implementation;
using BMCFileMangement.Services.Interface;
using CLL.LLClasses.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BMCFileMangement.Services.DisServices
{
    public class clsSecurityCapsule : IDisposable
    {

        public clsSecurityCapsule()
        {
        }


        #region Disposable

        // Flag to track whether Dispose has been called already
        private bool disposed = false;

        // Unmanaged resources or other disposable objects can be declared here



        // Custom method of the class
        public void SomeMethod()
        {
            Console.WriteLine("SomeMethod is called.");
        }

        // Implementation of IDisposable.Dispose()
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected method to handle the actual cleanup logic
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources (if any)
                }

                // Dispose unmanaged resources (if any)

                // Mark as disposed to avoid redundant disposal
                disposed = true;
            }
        }

        // Finalizer (destructor) to be used if the consumer of the class
        // forgets to call Dispose explicitly
        ~clsSecurityCapsule()
        {
            Dispose(false);
        }

        #endregion Disposable

        public SecurityCapsule GetSecurityCapsule(DateTime dt, string userName)
        {
            AppConfig.HelperClasses.transactioncodeGen objTrans = new transactioncodeGen();
            SecurityCapsule objSec = new BDO.Core.Base.SecurityCapsule();
            objSec.transid = objTrans.GetRandomAlphaNumericStringForTransactionActivity("FST", dt);
            objSec.createdbyusername = userName;
            objSec.createddate = dt;
            objSec.updatedbyusername = userName;
            objSec.updateddate = dt;
            objSec.ipaddress = GetUserIPAddress();
            return objSec;
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
