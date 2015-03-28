using System;

namespace EDXLNet.Models
{
    public class StatusKindDefault
    {
        public Uri ValueListUri
        {
            get
            {
                return new Uri("urn:oasis:names:tc:emergency:EDXL:DE:2.0:Defaults:StatusKind");
            }
        }

        public StatusKindDefaultValues Value { get; set; }
    }
}