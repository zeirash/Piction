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

        public void preLoad()
        {
            //this load files
        }

        public void preExit()
        {
            //this save files
        }
        


    }
}
