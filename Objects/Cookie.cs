using System;
using CookieJar.Enum;

namespace CookieJar.Objects
{

    /// <summary>
    /// Obviously, this thing is a cookie. 
    /// </summary>
    public class Cookie
    {
        /// <summary>
        /// Each cookie has to have a type, don't you think?
        /// </summary>
        private readonly CookieType _type;

        /// <summary>
        /// Create new cookie of specific type <paramref name="aType"/>.
        /// </summary>
        /// <param name="aType">The type of the cookie.</param>
        public Cookie(CookieType aType)
        {
            _type = aType;
        }
    }
}
