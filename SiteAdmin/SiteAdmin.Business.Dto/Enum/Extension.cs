using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace SiteAdmin.Business.Dto
{
    public static class EnumExtension
    {
        //Busca a descrição do enum
        public static string GetDescription(this Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (atributos.Length > 0)
                return atributos[0].Description;
            else
                return valor.ToString();
        }

        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        public static dynamic GetValue(this Enum value)
        {
            // Get fieldinfo for this type
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            // Get the stringvalue attributes
            ValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(ValueAttribute), false) as ValueAttribute[];

            // Return the first if there was a match.
            if (attribs.Length > 0)
            {
                if (!string.IsNullOrEmpty(attribs[0].StringValue))
                    return attribs[0].StringValue;
                else if (attribs[0].IntegerValue.HasValue)
                    return attribs[0].IntegerValue;
                else if (attribs[0].BoolValue.HasValue)
                    return attribs[0].BoolValue;
                else
                    return null;
            }
            else
                return null;
        }

        public static IEnumerable<T> GetValues<T>()
        {
            Type t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentOutOfRangeException(t.FullName + " is not an Enum");
            }
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }

    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class ValueAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Holds the value for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }
        public bool? BoolValue { get; protected set; }
        public int? IntegerValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a Value Attribute
        /// </summary>
        /// <param name="value"></param>
        public ValueAttribute(string value)
        {
            this.StringValue = value;
        }

        public ValueAttribute(bool value)
        {
            this.BoolValue = value;
        }

        public ValueAttribute(int value)
        {
            this.IntegerValue = value;
        }

        #endregion
    }
}
