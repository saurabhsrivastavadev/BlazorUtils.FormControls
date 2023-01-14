using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.FormControls.Validation
{
    public class ValidatorUrlYoutube : IValidator<string>
    {
        private static ValidatorUrlYoutube _instance;
        public static ValidatorUrlYoutube Instance
        {
            get
            {
                _instance ??= new ValidatorUrlYoutube();
                return _instance;
            }
        }

        public ValidatorType Type { get; } = ValidatorType.URL_YOUTUBE;

        public bool Validate(string value)
        {
            throw new NotImplementedException();
        }

        ValidationResult<string> IValidator<string>.Validate(string value)
        {
            throw new NotImplementedException();
        }
    }
}
