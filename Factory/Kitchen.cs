using System;
using CookieJar.Objects;

namespace CookieJar
{
    /// <summary>
    /// The place where our story will take place.
    /// </summary>
    public static class Kitchen
    {
        private static readonly Jar _almightyCookieJar = new Jar();

        /// <summary>
        /// Grabs the jar (literlly).
        /// </summary>
        /// <returns>The one and only cookie jar.</returns>
        public static Jar GrabCookieJar() => _almightyCookieJar;

    }
}
