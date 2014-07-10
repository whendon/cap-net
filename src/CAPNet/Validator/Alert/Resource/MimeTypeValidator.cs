using CAPNet.Models;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class MimeTypeValidator : Validator<Resource>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public MimeTypeValidator(Resource resource) : base(resource) 
        {
            topLevelMediaType = new List<string>();
            topLevelMediaType.Add("text");
            topLevelMediaType.Add("image");
            topLevelMediaType.Add("audio");
            topLevelMediaType.Add("video");
            topLevelMediaType.Add("application");
            topLevelMediaType.Add("multipart");
            topLevelMediaType.Add("message");
        }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new MimeTypeError();
            }
        }

        private static ICollection<string> topLevelMediaType;

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.MimeType == null) return false;
                if (!Entity.MimeType.Contains("/")) return false;

                var splittedMimeType = Entity.MimeType.Split('/');

                return topLevelMediaType.Contains(splittedMimeType[0]);
            }
        }
    }
}
