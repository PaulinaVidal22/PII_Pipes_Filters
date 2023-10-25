using System;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </remarks>
    public class ConditionalFilter
    {
        /// <summary>
        /// Un filtro que retorna la imagen recibida con un filtro diferente según si tiene cara o no.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero con el filtro aplicado.</returns>
        
        public bool hasFace { get; set; }
        public IPicture Filter(IPicture image)
        {

            CognitiveFace cognitiveFace = new CognitiveFace();
            cognitiveFace.Recognize(@"luke.jpg");

            hasFace = cognitiveFace.FaceFound;

            return image;
        }
    }
}