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
        public MimeTypeValidator(Resource resource) : base(resource) { }

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

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.MimeType == null) return false;
                var splittedMimeType = Entity.MimeType.Split('/');

                if (splittedMimeType[0] == Entity.MimeType)
                {
                    return false;
                }

                return TopLevelMediaTypeIsValid(splittedMimeType[0]);
            }
        }

        private static bool TopLevelMediaTypeIsValid(string splittedMimeType)
        {
            ICollection<string> topLevelMediaType = new List<string>();
            topLevelMediaType.Add("text");
            topLevelMediaType.Add("image");
            topLevelMediaType.Add("audio");
            topLevelMediaType.Add("video");
            topLevelMediaType.Add("application");
            topLevelMediaType.Add("multipart");
            topLevelMediaType.Add("message");

            if (topLevelMediaType.Contains(splittedMimeType))
                return true;
            else return false;
        }
    }
}
