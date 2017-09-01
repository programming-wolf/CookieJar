using System;
using System.Collections.Generic;
using CookieJar.Enum;
using CookieJar.Objects;

namespace CookieJar.Factory
{
    /// <summary>
    /// The place where our story will take place.
    /// </summary>
    public static class Kitchen
    {
        /// <summary>
        /// This is it. Our cookie jar, the holy grail of cookies.
        /// </summary>
        private static readonly Jar _almightyCookieJar = new Jar();

        /// <summary>
        /// Grabs the jar (literlly).
        /// </summary>
        /// <returns>The one and only cookie jar.</returns>
        public static Jar GrabCookieJar() => _almightyCookieJar;

        /// <summary>
        /// Bakes the cookies in the oven. 
        /// </summary>
        /// <returns>Frehsly baked cookies!</returns>
        /// <param name="aType">Cookie type.</param>
        /// <param name="aAmount">Amount of cookies we want.i</param>
        public static IList<Cookie> BakeCookiesInOven(CookieType aType, int aAmount) => Oven.Bake(aType, aAmount);
    }
}
