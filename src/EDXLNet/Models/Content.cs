using System.Collections.Generic;

namespace EDXLNet.Models
{
    public class Content
    {
        private readonly ICollection<ContentObject> contentObjects = new List<ContentObject>();

        public ICollection<ContentObject> ContentObjects
        {
            get { return contentObjects; }
        }
    }
}