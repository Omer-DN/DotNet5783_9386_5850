using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace PL.Converters
{
    /// <summary>
    /// Class of Converters for the PL Layer
    /// </summary>
    public class IntToStringConverter : IValueConverter
    {
        //convert from source property type to target property type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!int.TryParse(value.ToString()!, out int resulte))
            {
                MessageBox.Show("The Number Must Be Positive Number and not Characters", "Error");
                return 0;
            }
            else
                return int.Parse(value.ToString()!);
        }
        //convert from target property type to source property type
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value.ToString()!, out int resulte))
                return resulte;
            else
            {
                MessageBox.Show("The Number Must Be Positive Number and not Characters", "Error");
                return 0;
            }

        }

    }

    public class DoubleToStringConverter : IValueConverter
    {
        //convert from source property type to target property type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse(value.ToString()!, out double resulte))
                return double.Parse(value.ToString()!);
            else
            {
                MessageBox.Show("The Number Must Be Positive Number and not Characters", "Error");
                return 0;
            }
        }
        //convert from target property type to source property type
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(double.TryParse(value.ToString()!, out double resulte))
                return resulte;
            else
            {
                MessageBox.Show("The Number Must Be Positive Number and not Characters", "Error");
                return 0;
            }
        }
    }

    public class CategoryToStringConverter : IValueConverter
    {
        //convert from source property type to target property type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (Enum.Parse<BO.Enums.Category>(value.ToString()!) == 0)
                {
                    MessageBox.Show("Please Choose Specific Category", "Error");
                    return Enum.Parse<BO.Enums.Category>(value.ToString()!);
                }
                return Enum.Parse<BO.Enums.Category>(value.ToString()!);
            }
            return 0;
        }
        //convert from target property type to source property type
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value.ToString()! == "None")
            {
                MessageBox.Show("Please Choose Specific Category", "Error");
                return "vegetables";
            }
            return value.ToString()!;
        }
    }
    public class DateToStringConverter : IValueConverter
    {
        //convert from source property type to target property type
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "No Date";
            return value.ToString()!;
        }
        //convert from target property type to source property type
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "No Date";
            return DateTime.Parse(value.ToString()!);
        }
    }

    public class IntToListByCategoryConverter : IValueConverter
    {
        //convert from source property type to target property type
        BlApi.IBl? bl = BlApi.Factory.Get()!;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<BO.BoProductItem> list = new List<BO.BoProductItem>();

            if ((int)value == 0)
                return list = bl!.BoProduct!.GetProductsForCatalog()!;
            else
                return list = bl!.BoProduct!.CondGetProductsForCatalog(x => (int)x.Category == (int)value);
            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }

    }
}
