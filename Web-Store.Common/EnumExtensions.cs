using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetEnumDisplayName<TEnum>(this TEnum enumValue) where TEnum : Enum
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>()?
            .GetName();
    }

    public static string GetEnumDisplayName<TModel, TEnum>(this TModel model, Expression<Func<TModel, TEnum>> expression) where TEnum : Enum
    {
        var enumValue = expression.Compile()(model);
        return GetEnumDisplayName(enumValue);
    }
}