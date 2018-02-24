// Author: Leonardo Tazzini

using System;

[AttributeUsage(AttributeTargets.Field)]
/// <summary>
/// An attribute that can be applied to fields (like enum fields) and add two string descriptions called getter and setter
/// </summary>
public class GetterSetterAttribute : Attribute
{
    public string Getter { get; set; }
    public string Setter { get; set; }

    public GetterSetterAttribute(string getter_setter)
    {
        Getter = Setter = getter_setter;
    }
    public GetterSetterAttribute(string getter, string setter)
    {
        Getter = getter;
        Setter = setter;
    }
}

public static class GetterSetterExtension
{
    /// <summary>
    /// Return Getter description from an enum marked with GetterSetterAttribute, otherwise the enum value
    /// </summary>
    public static string GetterDescription(this Enum value)
    {
        var getterSetterAttributes = (GetterSetterAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(GetterSetterAttribute), false);
        return getterSetterAttributes.Length > 0 ? getterSetterAttributes[0].Getter : value.ToString();
    }

    /// <summary>
    /// Return Setter description from an enum marked with GetterSetterAttribute, otherwise the enum value
    /// </summary>
    public static string SetterDescription(this Enum value)
    {
        var getterSetterAttributes = (GetterSetterAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(GetterSetterAttribute), false);
        return getterSetterAttributes.Length > 0 ? getterSetterAttributes[0].Setter : value.ToString();
    }

    /// <summary>
    /// Return Enum with description that correspond to GetterSetterAttribute
    /// </summary>
    public static Enum FromDescription<T>(string description)
    {
        foreach (Enum item in Enum.GetValues(typeof(T)))
        {
            if (item.GetterDescription() == description)
            {
                return item;
            }
        }
        throw new Exception("Enum not found: [" + description + "]");
    }
}
