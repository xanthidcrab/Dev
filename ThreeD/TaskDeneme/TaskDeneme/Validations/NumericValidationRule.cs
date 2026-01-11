using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace TaskDeneme.Validations
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value as string;
            if (string.IsNullOrEmpty(text))
            {
                return new ValidationResult(false, "Value cannot be empty.");
            }
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    value = "";
                    return new ValidationResult(false, "Sadece Sayi Girilebbilir");
                }
            }
            // Fix: Removed the invalid extra comma in the method call
            return ValidationResult.ValidResult;
        }
    }
}
