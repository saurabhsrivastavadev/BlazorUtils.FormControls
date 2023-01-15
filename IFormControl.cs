using BlazorUtils.FormControls.Validation;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorUtils.FormControls
{
    /// <summary>
    /// A Form Control with input value type T 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFormControl<T>
    {
        public List<IValidator<T>> Validators { get; set; }

        internal void HandleValidationResults(List<ValidationResult<T>> results, bool allPassed);

        public void RunValidations(T value)
        {
            var results = new List<ValidationResult<T>>();
            if (Validators != null && Validators.Any())
            {
                bool allPassed = true;
                foreach (var validator in Validators)
                {
                    var result = validator.Validate(value);
                    allPassed &= result.Result;
                    results.Add(result);
                }
                HandleValidationResults(results, allPassed);
            }
        }
    }
}
