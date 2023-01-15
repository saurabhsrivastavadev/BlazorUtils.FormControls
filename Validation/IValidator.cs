using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.FormControls.Validation
{
    public enum ValidatorType
    {
        EMAIL,
        PHONE_NUMBER,
        YOUTUBE_URL
    }

    public interface IValidator<T>
    {
        public ValidatorType Type { get; }

        public ValidationResult<T> Validate(T value);
    }

    public class ValidationResult<T>
    {
        public ValidationResult(IValidator<T> validator) { Validator = validator; }

        public IValidator<T> Validator { get; }   

        public bool Result { get; set; }

        public string Message { get; set; }
    }
}
