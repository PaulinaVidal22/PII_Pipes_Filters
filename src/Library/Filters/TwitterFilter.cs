using System;
using System.Drawing;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class TwitterFilter : IFilter
    {
        /// Un filtro que publica la imagen en twitter.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el "filtro".</param>
        /// <returns>La imagen recibida pero ....</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            var twitter = new TwitterImage();

            string tweetText = "look at my new post!";
            string imagePath = "lukeAfterFilers.jpg";

            string tweet = twitter.PublishToTwitter(tweetText, imagePath);

            Console.WriteLine($"Tweet result : {tweet}");
            
            return result; 
        }
    }
}