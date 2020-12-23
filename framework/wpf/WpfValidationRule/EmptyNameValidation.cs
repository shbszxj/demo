using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfValidationRule
{
    public class EmptyNameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(!string.IsNullOrWhiteSpace(GetBoundValue(value) as string), "name required");
        }

        private object GetBoundValue(object value)
        {
            if (value is BindingExpression)
            {
                var binding = (BindingExpression)value as BindingExpression;

                // Get the bound object and name of the property
                object dataItem = binding.DataItem;
                string propertyName = binding.ParentBinding.Path.Path;

                // Extract the value of the property.
                return dataItem.GetType().GetProperty(propertyName).GetValue(dataItem, null);
            }

            return value;
        }
    }
}
