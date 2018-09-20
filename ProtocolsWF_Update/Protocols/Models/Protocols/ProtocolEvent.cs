﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolEvent
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int status { get; set; }

        public ProtocolEvent()
        {
            ID = -1;
            Type = "";
            Description = "";
            IsActive = true;
            status = 1;

        }

        public ProtocolEvent(int eventID)
        {
            this.ID = eventID;
            
        }
    }
}
