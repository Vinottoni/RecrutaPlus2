using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safety.Infra.Data
{
    public class SqlQueryBuilder
    {
        public string GetPropertyName<T>()
        {
            StringBuilder querySql = new StringBuilder();
            Type type = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
            {

                if (prop.PropertyType.Name == nameof(Int16) ||
                    prop.PropertyType.Name == nameof(Int32) ||
                    prop.PropertyType.Name == nameof(Int64) ||
                    prop.PropertyType.Name == nameof(Decimal) ||
                    prop.PropertyType.Name == nameof(Double) ||
                    prop.PropertyType.Name == nameof(Single) ||
                    prop.PropertyType.Name == nameof(DateTime) ||
                    prop.PropertyType.Name == nameof(TimeSpan) ||
                    prop.PropertyType.Name == nameof(Boolean) ||
                    prop.PropertyType.Name == nameof(Guid) ||
                    prop.PropertyType.Name == nameof(String))
                {
                    List<NotMappedAttribute> notMappedAttribute = new List<NotMappedAttribute>();
                    foreach (NotMappedAttribute attributo in (type.GetProperty(prop.Name.ToString()).GetCustomAttributes(typeof(NotMappedAttribute), true)))
                    {
                        notMappedAttribute.Add(attributo);
                    }

                    if (notMappedAttribute.Count == 0)
                    {
                        if (querySql.Length == 0)
                        {
                            querySql.AppendLine($"	 {prop.Name} ");
                        }
                        else
                        {
                            querySql.AppendLine($"	,{prop.Name} ");
                        }
                    }
                }
            }

            return querySql.ToString();
        }
    }
}
