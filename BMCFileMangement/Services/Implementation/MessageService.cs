﻿using BMCFileMangement.Services.Interface;
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

       
    }
}
