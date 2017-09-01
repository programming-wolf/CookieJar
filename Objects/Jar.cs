// Copyright Ben Wolf
//
// Author: Ben Wolf
// Date: 2017-09-01

using System;
using System.Collections.Generic;

namespace CookieJar.Objects
{
    /// <summary>
    /// Class symbolizes a jar for cookies (or whatever else).
    /// </summary>
    public sealed class Jar
    {
        /// <summary>
        /// We use this lid as "lock" for access to the jar.
        /// </summary>
        private readonly object _jarLid = new object();

        /// <summary>
        /// Our cookies in the jar (some would hope for whisky). They are "stack"ed. 
        /// </summary>
        private Stack<Cookie> _cookies = new Stack<Cookie>();


        /// <summary>
        /// Takes some (<paramref name="aNumberOfCookies"/>) cookies out of the jar. If the caller wants more cookies than there are in the jar, they take all of them. No mercy.
        /// </summary>
        /// <returns>Yay, cookies.</returns>
        /// <param name="aNumberOfCookies">Number of cookies that are desired.</param>
        public IList<Cookie> TakeCookies(int aNumberOfCookies)
        {
            var cookies = new List<Cookie>();

            // at first, open the lid of the jar
            lock (_jarLid)
            {
                // we only need to take cookies out if there are any. 
                // however, Any() does not seem to be supported by this version of mono
                if (_cookies.Count > 0)
                {
                    if (_cookies.Count <= aNumberOfCookies)
                    {
                        // someone tried to at least as many cookies as there a left, so we can return all and clear the jar. 
                        cookies.AddRange(_cookies);
                        _cookies.Clear();
                    }
                    else
                    {
                        for (int i = 0; i < aNumberOfCookies; i++)
                        {
                            cookies.Add(_cookies.Pop());
                        }
                    }
                }
            }

            return cookies;
        }

        /// <summary>
        /// Uuh, someone was kind enough to bake new cookies and puts them into the jar.
        /// </summary>
        /// <param name="aNewCookies">All the freshly made cookies!</param>
        public void StoreCookies(IList<Cookie> aNewCookies)
        {
            // again, open the lid of the jar first, so that no one else can use the jar.
            lock (_jarLid)
            {
                // we have to add each cookie one by one (they would break otherwise)
                foreach (var cookie in aNewCookies)
                {
                    _cookies.Push(cookie);
                }
            }
        }
    }
}
