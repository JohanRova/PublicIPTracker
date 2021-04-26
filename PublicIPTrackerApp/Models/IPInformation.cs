using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicIPTrackerApp.Models
{
    struct IPInformation
    {
        public readonly string publicIP { get; }
        public readonly DateTime IPTimeStamp { get; }
        public readonly bool Unique { get; }

        public IPInformation(string publicIP, DateTime IPTimestamp, bool unique)
        {
            this.publicIP = publicIP;
            this.IPTimeStamp = IPTimestamp;
            this.Unique = unique;
        }
    }
}
