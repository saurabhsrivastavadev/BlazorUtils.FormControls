using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.FormControls.Validation
{
    public enum ValidatorType
    {
        TEXT_EMAIL,
        TEXT_PHONE,
        URL_YOUTUBE
    }

    public interface IValidator<T>
    {
        public ValidatorType Type { get; }

        public ValidationResult<T> Validate(T value);
    }

    public class ValidationResult<T>
    {
        public IValidator<T> Validator { get; set; }

        public bool Result { get; set; }

        public string Message { get; set; }
    }
}
