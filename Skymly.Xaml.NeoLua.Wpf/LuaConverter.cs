using Neo.IronLua;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
namespace Skymly.Xaml.NeoLua.Wpf
{
    public class LuaConverter : IValueConverter
    {
        public bool IgnoreException { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                using Lua lua = new Lua();
                var g = lua.CreateEnvironment();
                g["value"] = value;
                if (parameter is string code)
                {
                    LuaResult result = g.DoChunk(code,"Convert");
                    return result.Values.FirstOrDefault();
                }
                throw new ArgumentException($"{nameof(LuaConverter)}.{nameof(Convert)} 参数{nameof(parameter)}必须是字符串");
            }
            catch (Exception)
            {
                if (IgnoreException)
                {
                    return Binding.DoNothing;
                }
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
