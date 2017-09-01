using System;
using System.Collections.Generic;
using CookieJar.Enum;
using CookieJar.Objects;

namespace CookieJar.Factory
{
    /// <summary>
    /// This oven is used to create new cookies.
    /// </summary>
    internal static class Oven
    {
        /// <summary>
        /// Aw, so many fresh cookies! 
        /// </summary>
        /// <returns>All the cookies, hopefully none is burnt.</returns>
        /// <param name="aType">Chocolate cookie type!</param>
        /// <param name="aAmount">We want only so many...</param>
        public static IList<Cookie> Bake(CookieType aType, int aAmount)
        {
            var newCookies = new List<Cookie>(aAmount);
            for (int i = 0; i < aAmount; i++)
            {
                newCookies.Add(new Cookie(aType));
            }

            return newCookies;
        }
    }
}
