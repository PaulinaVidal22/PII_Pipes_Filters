using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeFork : IPipe
    {
        IPipe noFacePipe;
        IPipe hasFacePipe;

        ConditionalFilter filter;
        
        public PipeFork(ConditionalFilter filterConditional, IPipe hasFacePipe, IPipe noFacePipe) 
        {
            this.filter = filterConditional;
            this.noFacePipe = noFacePipe;
            this.hasFacePipe = hasFacePipe;           
        }
        public IPicture Send(IPicture picture)
        {

            if (filter.hasFace == true)
            {
                picture = hasFacePipe.Send(picture.Clone());
            } 
            else {
                picture = noFacePipe.Send(picture.Clone());
            }

            return picture;
        }
    }
}
