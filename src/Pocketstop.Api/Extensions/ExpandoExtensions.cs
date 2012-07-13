using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Pocketstop
{
	internal static class ExpandoExtensions
	{
		/// <summary>
		/// Turns the object into an ExpandoObject
		/// </summary>
		internal static dynamic ToExpando(this object o)
		{
			var result = new ExpandoObject();
			var d = result as IDictionary<string, object>; //work with the Expando as a Dictionary
			if (o is ExpandoObject) return o; //shouldn't have to... but just in case
			if (o is NameValueCollection || o.GetType().IsSubclassOf(typeof(NameValueCollection)))
			{
				var nv = (NameValueCollection)o;
				nv.Cast<string>().Select(key => new KeyValuePair<string, object>(key, nv[key])).ToList().ForEach(i => d.Add(i));
			}
			else
			{
				var props = o.GetType().GetProperties();
				foreach (var item in props)
				{
					d.Add(item.Name, item.GetValue(o, null));
				}
			}
			return result;
		}

		/// <summary>
		/// Turns the object into a Dictionary
		/// </summary>
		internal static IDictionary<string, object> ToDictionary(this object thingy)
		{
			return (IDictionary<string, object>)thingy.ToExpando();
		}
	}
}
