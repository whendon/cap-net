using System;

namespace EDXLNet.Models
{
    public class DistributionKindDefault
    {
        public Uri ValueListUri
        {
            get
            {
                return new Uri("urn:oasis:names:tc:emergency:EDXL:DE:2.0:Defaults:DistributionType");
            }
        }

        public DistTypeDefaultValues Value { get; set; }
    }
}