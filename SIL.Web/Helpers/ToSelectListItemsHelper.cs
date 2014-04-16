using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIL.Domain;
using System.Web.Mvc;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SIL.Web.Helpers
{
    public static class ToSelectListItemsHelper
    {

        public static IList<System.Web.Mvc.SelectListItem> ToSelectItemList<T>(this IEnumerable<T> list, Func<T, string> textSelector, Func<T, string> valueSelector, IEnumerable<T> selected)
        {
            IList<System.Web.Mvc.SelectListItem> results = new List<System.Web.Mvc.SelectListItem>();
            foreach (T item in list)
            {
                results.Add(new System.Web.Mvc.SelectListItem { Text = textSelector.Invoke(item), Value = valueSelector.Invoke(item), Selected = selected.Contains(item) });
            }

            return results;
        }



        public static IList<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> list, Func<T, string> textSelector, Func<T, string> valueSelector)
        {
            return ToSelectItemList(list, textSelector, valueSelector, new List<T>());
        }

       public static SelectList ToSelectList<TEnum>(this TEnum enumObj, bool addPleaseSelect = false)
            
       {
                 IEnumerable<TEnum> values = (from TEnum e in Enum.GetValues(typeof(TEnum))
                         select e);


                var valuesoutputd = (from TEnum e in values
                          select new SelectListItem { Value = e.ToString(), Text = (e as Enum).GetDescriptionString() });
                
                if (addPleaseSelect)
                {
                    var pleaseSelect = new List<SelectListItem> { new SelectListItem { Text = "--- Select ---", Value = "" } };
                    valuesoutputd = pleaseSelect.Concat(valuesoutputd).ToList();
                }

                return new SelectList(valuesoutputd, "Value", "Text", enumObj);
       }

       public static string PascalCaseToPrettyString(this string s)
       {
           return Regex.Replace(s, @"(\B[A-Z]|[0-9]+)", " $1");
       }

       public static string GetDescriptionString(this Enum val)
       {
           try
           {
               var attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

               return attributes.Length > 0 ? attributes[0].Description : val.ToString().PascalCaseToPrettyString();
           }
           catch (Exception)
           {
               return val.ToString().PascalCaseToPrettyString();
           }
       }



       public static IEnumerable<System.Web.Mvc.SelectListItem> SpecialSelectListSelector<T>(IEnumerable<T> list, Func<T, string> textSelector, Func<T, string> selectedId, Func<T, bool> selected)
       {

           return
               list.OrderBy(item => textSelector(item))
               .Select(item => new SelectListItem
               {
                   Selected = selected(item),
                   Text = textSelector(item),
                   Value = selectedId(item)
               });
       }

        public static IEnumerable<System.Web.Mvc.SelectListItem> ToSelectListOfCustomers(this IEnumerable<Customer> companies, int selectedId)
        {
            return

                companies.OrderBy(company => company.Name)
                      .Select(company =>
                          new System.Web.Mvc.SelectListItem
                          {
                              Selected = (company.CustomerId == selectedId),
                              Text = company.Name,
                              Value = company.CustomerId.ToString()
                          });
        }

        public static IEnumerable<System.Web.Mvc.SelectListItem> ToSelectListOfWebsites(this IEnumerable<Website> web, int selectedId)
        {
            return

                web.OrderBy(w => w.SiteName)
                      .Select(w =>
                          new System.Web.Mvc.SelectListItem
                          {
                              Selected = (w.WebsiteId == selectedId),
                              Text = w.SiteName,
                              Value = w.WebsiteId.ToString()
                          });
        }


        public static IEnumerable<System.Web.Mvc.SelectListItem> ToSelectListOfContacts(this IEnumerable<Contact> contacts, int selectedId)
        {
            return

                contacts.OrderBy(c => c.Name)
                      .Select(c =>
                          new System.Web.Mvc.SelectListItem
                          {
                              Selected = (c.ContactId == selectedId),
                              Text = c.Name,
                              Value = c.ContactId.ToString()
                          });
        }


        public static IEnumerable<System.Web.Mvc.SelectListItem> ToSelectListOfServers(this IEnumerable<Server> severs, int selectedId)
        {
            return

                severs.OrderBy(s => s.FriendlyName)
                      .Select(s =>
                          new System.Web.Mvc.SelectListItem
                          {
                              Selected = (s.ServerId == selectedId),
                              Text = s.FriendlyName,
                              Value = s.ServerId.ToString()
                          });
        }


        public static IEnumerable<System.Web.Mvc.SelectListItem> ToSelectListOfIps(this IEnumerable<IP> ips, int selectedId)
        {
            return

                ips.OrderBy(i => i.InternalIPAddress)
                      .Select(i =>
                          new System.Web.Mvc.SelectListItem
                          {
                              Selected = (i.IpId == selectedId),
                              Text = i.InternalIPAddress,
                              Value = i.IpId.ToString()
                          });
        }


    }
}