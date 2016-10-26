using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;

using AForge.Neuro;
using AForge.Neuro.Learning;
using AForge.Imaging.Filters;
using AForge.Imaging;
using Accord.Imaging.Converters;

namespace ANNProject
{
    class NeuralNet
    {
        ActivationNetwork AN;
        DistanceNetwork DN;

        public double [][] imageProcessing(String [] images)
        {
            BackPropagationLearning bpnn;
            ActivationNetwork an;
            var imageToArray = new ImageToArray(min: -1, max: +1);
            var toGrayscale = new Grayscale(0, 0, 0);
            var goThreshold = new Threshold(128);
            var reduceNoise = new AdditiveNoise();
            var reScaling = new ResizeBicubic(10, 10);
            double [][] processed = new double[images.Length][];

            int i = 0;
            foreach (String file in images)
            {
                var image = AForge.Imaging.Image.FromFile(file);
                image = toGrayscale.Apply(image);
                image = goThreshold.Apply(image);
                image = reduceNoise.Apply(image);
                image = reScaling.Apply(image);
                imageToArray.Convert(image, out processed[i]);
                i++;
            }
            return processed;
        }

        public double trainBPL(double [][] input, double [][] output)
        {
            int epoch = 10000;
            double errorrate = 0;
            double error = 0.0000001;

            var bpl = new BackPropagationLearning(AN);

            for (int i = 0; i < epoch; i++)
            {
                errorrate = bpl.RunEpoch(input,output);

                if(error == errorrate)
                {
                    return errorrate;
                }
            }
            return errorrate;
        }

        

        public double trainSOM(double[][] input)
        {
            int epoch = 10000;
            double errorrate = 0;
            double error = 0.0000001;

            var som = new SOMLearning(DN);

            for (int i = 0; i < epoch; i++)
            {
                errorrate = som.RunEpoch(input);

                if (error == errorrate)
                {
                    return errorrate;
                }
            }
            return errorrate;
        }

        public void computeBPL()
        {

        }


        public void preLoad()
        {
            //this load files
            try
            {
                AN = (ActivationNetwork) ActivationNetwork.Load("BPNNBrain.net");
                DN = (DistanceNetwork)DistanceNetwork.Load("SOMBrain.net");
            }
            catch (Exception)
            {
                AN = new ActivationNetwork(new SigmoidFunction(), 100, 100, 1);
                DN = new DistanceNetwork(100, 100);
            }
        }

        public void preExit()
        {
            //this save files
            AN.Save("BPNNBrain.net");
            DN.Save("SOMBrain.net");
        }
        


    }
}
