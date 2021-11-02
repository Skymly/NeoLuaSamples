using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Skymly.NeoLuaSamples.Wpf.Extensions
{
    public static class DependencyObjectExtension
    {
        public static T FindAncestorOrSelf<T>(this DependencyObject source) where T : DependencyObject
        {
            return source is T t ? t : FindAncestor<T>(source);
        }

        public static T FindAncestor<T>(this DependencyObject source) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(source);
            return parent switch
            {
                var p when p is T t => t,
                var p when p is null => null,
                _ => FindAncestor<T>(parent)
            };
        }

        public static T FindChild<T>(this DependencyObject source) where T : DependencyObject
        {
            if (source != null)
            {
                foreach (var item in source.GetVisualChildren())
                {
                    if (item is T t)
                    {
                        return t;
                    }
                    if (FindChild<T>(item) is T tChild)
                    {
                        return tChild;
                    }
                }
            }
            return null;
        }

        public static T FindChild<T>(this DependencyObject source, int index) where T : DependencyObject
        {
            return source.FindChildren<T>().Skip(index).FirstOrDefault();
        }


        public static IEnumerable<T> FindChildren<T>(this DependencyObject source, Predicate<DependencyObject> predicate = null) where T : DependencyObject
        {
            foreach (var child in source.GetVisualChildren())
            {
                if (child != null && (predicate?.Invoke(child) ?? true) && child is T t)
                {
                    yield return t;
                }
                else
                {
                    foreach (var item in FindChildren<T>(child))
                    {
                        yield return item;
                    }
                }
            }
        }


        private static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject source)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
            {
                yield return VisualTreeHelper.GetChild(source, i);
            }
        }
    }
}
