using System;
using System.Collections.Generic;
using NumberType = System.Double;
using TestSimpleRNG;


namespace KalmanCS
{
    /// <summary>
    /// Represents a class that can test out an implementation of the Kalman filter from 
    /// http://kkjkok.blogspot.com/2012/02/bayesian-approach-to-kalman-filtering.html
    /// </summary>
    public static class KalmanFilter
    {
        /// <summary>
        /// Specifies constants that define the type of signal we generate for testing
        /// </summary>
        public enum TestSignalFormat
        {
            RandomWalk,
            SineWave,
            SquareWave
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generate data to represent the "actual" signal measured by the filter. This
        /// method generates random values by stepping a little bit away from the previous
        /// value.</summary>
        /// <param name="numEntries">The number of entries that will be generated in the returned
        /// array.</param>
        /// <param name="sourceScale">The scale factor of the source</param>
        /// <param name="sourceSigma">From the article: "The standard deviation of the
        /// measurements. I chose .5, but this is a parameter you can play around with. The higher
        /// the measurement sigma gets, the worse our filter performs, due to signal to noise ratio
        /// effects. An intial deviation of .5 is fairly high, so dropping this number to something
        /// like .25 will give "prettier" results.</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType[] RandomWalk(int numEntries, NumberType sourceScale, NumberType sourceSigma)
        {
            NumberType[] randomWalk = new NumberType[numEntries];

            randomWalk[0] = (NumberType)SimpleRNG.GetNormal( 0f, sourceSigma );

            Random rng = new Random();
            for( int curEntryIndex = 1; curEntryIndex < randomWalk.Length; ++curEntryIndex )
                randomWalk[curEntryIndex] = (NumberType)( sourceScale * randomWalk[curEntryIndex - 1] + SimpleRNG.GetNormal( 0f, sourceSigma ) );

            return randomWalk;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generate data to represent the "actual" signal measured by the filter. This
        /// method generates values that represent one cycle of a sine wave.</summary>
        /// <param name="numEntries">The number of entries that will be generated in the returned
        /// array.</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType[] SineWave(int numEntries)
        {
            NumberType[] sineValues = new NumberType[numEntries];

            double numEntriesDbl = (double)numEntries;
            for( int curEntryIndex = 0; curEntryIndex < numEntries; ++curEntryIndex )
                sineValues[curEntryIndex] = Math.Sin( (double)( curEntryIndex / numEntriesDbl ) * Math.PI * 2.0D );

            return sineValues;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Generate data to represent the "actual" signal measured by the filter. This
        /// method generates values that represent two cycles of a square wave.</summary>
        /// <param name="numEntries">The number of entries that will be generated in the returned
        /// array.</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType[] SquareWave(int numEntries)
        {
            NumberType[] squareValues = new NumberType[numEntries];

            double curValue = 1;
            int quarterOfEntries = numEntries / 4;
            for( int curEntryIndex = 0; curEntryIndex < numEntries; ++curEntryIndex )
            {
                if( curEntryIndex / quarterOfEntries == 0 || curEntryIndex / quarterOfEntries == 2 ) 
                    squareValues[curEntryIndex] = 1;
                else
                    squareValues[curEntryIndex] = -1;
            }

            return squareValues;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Distort our "actual" signal to generate the "measured" signal. This simulates
        /// measurement equipment not being perfect</summary>
        /// <param name="sent">The "actual" signal</param>
        /// <param name="measuredSigma">How inaccurate our measurements are, 0 for perfect 1 for
        /// terrible, higher for even worse.</param>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType[] Received(NumberType[] sent, NumberType measuredSigma)
        {
            NumberType[] measured = new NumberType[ sent.Length ];

            for( int curEntryIndex = 0; curEntryIndex < sent.Length; ++curEntryIndex )
                measured[curEntryIndex] = (NumberType)( sent[curEntryIndex] + SimpleRNG.GetNormal( 0D, (double)measuredSigma ) );

            return measured;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Search for "but where on earth did the pred_mean and pred_sigma functions come
        /// from" in the blog article for an explanation of this method.</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType PredictedMean(NumberType sourceScale, NumberType previousMean)
        {
            return sourceScale * previousMean;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Search for "but where on earth did the pred_mean and pred_sigma functions come
        /// from" in the blog article for an explanation of this method.</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType PredictedSigma(NumberType sourceScale, NumberType previousSigma, NumberType sourceSigma)
        {
            return (NumberType)Math.Sqrt( ( sourceScale * sourceScale ) * ( previousSigma * previousSigma ) + ( sourceSigma * sourceSigma ) );
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Explained at the beginning of the blog article</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType UpdateMean(NumberType predictedMean, NumberType predictedSigma, NumberType measuredValue, NumberType measuredSigma)
        {
            NumberType numerator = ( predictedMean / ( predictedSigma * predictedSigma ) ) + ( measuredValue / ( measuredSigma * measuredSigma ) );

            NumberType denominator = ( (NumberType)1 / ( predictedSigma * predictedSigma ) ) + ( (NumberType)1 / ( measuredSigma * measuredSigma ) );

            return numerator / denominator;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Explained at the beginning of the blog article</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType UpdateSigma(NumberType predictedSigma, NumberType measuredSigma)
        {
            double r = ( 1 / ( predictedSigma * predictedSigma ) ) + ( 1 / ( measuredSigma * measuredSigma ) );

            return (NumberType)( 1.0 / Math.Sqrt( r ) );
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Apply the kalman filter to our measured signal to produce the "filtered"
        /// signal</summary>
        /// <param name="measuredValues">The "measured" signal</param>
        /// <param name="sourceScale"></param>
        /// <param name="sourceSigma"></param>
        /// <param name="measuredSigma"></param>
        /// <returns></returns>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static NumberType[] Filter(NumberType[] measuredValues, NumberType sourceScale, NumberType sourceSigma, NumberType measuredSigma)
        {
            NumberType lastMean = 0;

            NumberType lastSigma = sourceSigma;

            NumberType[] filteredValues = new NumberType[measuredValues.Length];

            for( int curEntryIndex = 0; curEntryIndex < measuredValues.Length; ++curEntryIndex )
            {
                NumberType estimatedMean = PredictedMean( sourceScale, lastMean );
                NumberType estimatedSigma = PredictedSigma( sourceScale, lastSigma, sourceSigma );

                filteredValues[curEntryIndex] = estimatedMean + (NumberType)SimpleRNG.GetNormal( 0D, (double)estimatedSigma );

                lastMean = UpdateMean( estimatedMean, estimatedSigma, measuredValues[curEntryIndex], measuredSigma );
                lastSigma = UpdateSigma( estimatedSigma, measuredSigma );
            }

            return filteredValues;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Run a test with some default values</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static KalmanResults RunIt()
        {
            return RunIt( (NumberType).01, (NumberType).4, TestSignalFormat.RandomWalk );
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Run a test of the Kalman filter</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static KalmanResults RunIt(NumberType sourceSigma, NumberType measuredSigma, TestSignalFormat signalFormat)
        {
            NumberType sourceScale = (NumberType)Math.Sqrt( 1 - ( sourceSigma * sourceSigma ) );

            KalmanResults results = new KalmanResults();

            // Generate our "actual" signal data
            const int NumEntries = 1000;
            if( signalFormat == TestSignalFormat.SineWave )
                results.ActualValues = SineWave( NumEntries );
            else if( signalFormat == TestSignalFormat.SquareWave )
                results.ActualValues = SquareWave( NumEntries );
            else
                results.ActualValues = RandomWalk( NumEntries, sourceScale, sourceSigma );

            // Simulate equipment imperfectly measuring our actual signal
            results.MeasuredValues = Received( results.ActualValues, measuredSigma );

            // Apply the filter to that "measured" data
            results.FilteredValues = Filter( results.MeasuredValues, sourceScale, sourceSigma, measuredSigma );

            return results;
        }
    }


    /// <summary>
    /// Represents the results of running a test with the Kalman filter
    /// </summary>
    public class KalmanResults
    {
        public NumberType[] ActualValues;
        public NumberType[] MeasuredValues;
        public NumberType[] FilteredValues;
    }
}
