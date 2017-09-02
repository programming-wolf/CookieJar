using System;
using System.Threading.Tasks;
using CookieJar.Factory;

namespace CookieJar
{
    /// <summary>
    /// Here's where all the action happens. Cats, CookieMonster and good ol' Grandma.
    /// </summary>
    public static class MainClass
    {
        /// <summary>
        /// Let's go, bake some cookies!
        /// </summary>
        /// <param name="args">Who needs arguments.</param>
        public static void Main(string[] args)
        {
            // someone baked some cookies already. Very kind.
            Kitchen.GrabCookieJar().StoreCookies(Kitchen.BakeCookiesInOven(Enum.CookieType.DoubleChocolate, 7));


            var curiousCat = Task.Run(async () =>
            {
                // the cat sleeps for two seconds, before it tries to steal a cookie.
                await Task.Delay(2000);

                var jar = Kitchen.GrabCookieJar();
                var cookie = jar.TakeCookies(1);

                if (cookie.Count == 1)
                {
                    Console.WriteLine("Cat: I am happy! :) om nom");
                }
                else
                {
                    Console.WriteLine("Cat: I am so sad, no cookie!");
                }
            });

            var theCookieMonster = Task.Run(async () =>
            {
                // we do not know exactly what the monster does.
                await Task.Delay(new Random().Next(5000));

				// but when it awakes, it is hungry. 
				var cookies = Kitchen.GrabCookieJar().TakeCookies(6);

                if (cookies.Count == 0) {
                    Console.WriteLine("Monster: RAWWRRRRR!");
                }
                else 
                {
                    foreach (var cookie in cookies)
                    {
                        Console.WriteLine("Monster: Omnomnom.");
                    }
                }
            });

            var goodOlGrandMa = Task.Run(async () =>
            {
                // grand ma is slow
                await Task.Delay(8000);

                var cookies = Kitchen.BakeCookiesInOven(Enum.CookieType.TripleChocolate, 10);
                Kitchen.GrabCookieJar().StoreCookies(cookies);
                Console.WriteLine("Grandma: I was so kind and refilled the cookies.");
            });

            Task.WhenAll(new[] { curiousCat, theCookieMonster, goodOlGrandMa }).GetAwaiter().GetResult();
        }
    }
}
