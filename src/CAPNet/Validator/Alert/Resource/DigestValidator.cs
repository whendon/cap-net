using CAPNet.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class DigestValidator : Validator<Resource>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        public DigestValidator(Resource resource) : base(resource) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new DigestError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (Entity.Digest == null) return true;

                var digestLengthIs40 = Entity.Digest.Length == 40;
                var digestMatchesHexaDigits = Regex.Match(Entity.Digest, "^[a-fA-F0-9]*$");

                return digestLengthIs40 && digestMatchesHexaDigits.Success;
            }
        }
    }
}
