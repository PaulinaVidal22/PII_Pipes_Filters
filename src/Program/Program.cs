using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPipe pipeNull = new PipeNull();
            picture = pipeNull.Send(picture);

            IFilter filterNegative = new FilterNegative();

            IPipe pipeSerial = new PipeSerial(filterNegative, pipeNull);
            picture = pipeSerial.Send(picture);

            //part two
            //PictureProvider picProvider = new PictureProvider();
            provider.SavePicture(picture ,"lukeNegative.jpg");

            IFilter filterGreyScale = new FilterGreyscale();

            IPipe secondPipeSerial = new PipeSerial(filterGreyScale, pipeSerial);

            picture = pipeSerial.Send(picture);

            //part two implementation
            picture = secondPipeSerial.Send(picture);

            //part one
            /*PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, @"luke.jpg");*/

            //part two
            //PictureProvider imageProvider = new PictureProvider();
            provider.SavePicture(picture ,"lukeAfterFilters.jpg");

            //part three
            IFilter twitterFilter = new TwitterFilter();
            IPipe twitterPipeSerial = new PipeSerial(twitterFilter, pipeNull);
            picture = twitterPipeSerial.Send(picture); 

            //part four
            ConditionalFilter conditionalFilter = new ConditionalFilter();

            IPipe hasFacePipe = new PipeSerial(twitterFilter, pipeNull);
            IPipe noFacePipe = new PipeSerial(filterNegative, pipeNull);

            IPipe pipeFork = new PipeFork(conditionalFilter, hasFacePipe, noFacePipe);

            IPipe thirdPipeSerial = new PipeSerial(filterGreyScale,pipeFork);
            picture = thirdPipeSerial.Send(picture);
            provider.SavePicture(picture, "finalProduct.jpg");

            
        }
    }
}

