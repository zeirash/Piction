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
using Accord.Statistics.Analysis;

namespace ANNProject
{
    class NeuralNet
    {
        ActivationNetwork an;
        DistanceNetwork dn;
        static int WIDTH = 10;
        static int HEIGHT = 10;
        PrincipalComponentAnalysis pca;
        List<double[]> listInput;
        List<double[]> listOutput;
        List<double[]> tempOutput;
        List<String> listImageName;
        BackPropagationLearning bpnn;

        /*
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
        }*/

        public Bitmap preprocessing(Bitmap image)
        {
            Bitmap result = new Bitmap(image);
            //Grayscaling
            result = Grayscale.CommonAlgorithms.RMY.Apply(result);

            //Detect edge
            result = new HomogenityEdgeDetector().Apply(result);

            //Reduce noise
            int xMin, yMin, xMax, yMax;
            xMin = result.Width; yMin = result.Height;
            xMax = 0; yMax = 0;
            for (int i = 0; i < result.Width; i++)
            {
                for (int j = 0; j < result.Height; j++)
                {
                    if (result.GetPixel(i, j).R > 128)
                    {
                        if (i < xMin) xMin = i;
                        if (j < yMin) yMin = j;
                        if (i > xMax) xMax = i;
                        if (j > yMax) yMax = j;
                    }
                }
            }
            if (xMin == result.Width) xMin = 0;
            if (yMin == result.Height) yMin = 0;
            if (xMax == 0) xMax = result.Width;
            if (yMax == 0) yMax = result.Height;

            //Crop
            Bitmap cropped = new Bitmap(xMax, yMax);
            Graphics.FromImage(cropped).DrawImage(result, xMin, yMin, xMax, yMax);

            //Resize
            result = new ResizeBilinear(WIDTH, HEIGHT).Apply(result);

            return result;
        }

        private double[] inputNormalization(Bitmap edited)
        {
            double[] inputNormal = new double[WIDTH * HEIGHT];

            //normalization input
            int index = 0;
            for (int i = 0; i < edited.Width; i++)
            {
                for (int j = 0; j < edited.Height; j++)
                {
                    int input = edited.GetPixel(i, j).B / 255;
                    inputNormal[index] = input;
                    index++;
                }

            }


            return inputNormal;
        }

        /*private void outputNormalization()
        {
            double[] output = new double[1];
            output[0] = listInput.Count - 1;
        }*/

        public double trainBPL(double [][] input, double [][] output)
        {
            int epoch = 10000;
            double errorrate = 0;
            double error = 0.0000001;

            bpnn = new BackPropagationLearning(an);

            for (int i = 0; i < epoch; i++)
            {
                errorrate = bpnn.RunEpoch(input,output);

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

            var som = new SOMLearning(dn);

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
                an = (ActivationNetwork) ActivationNetwork.Load("BPNNBrain.net");
                dn = (DistanceNetwork)DistanceNetwork.Load("SOMBrain.net");
            }
            catch (Exception)
            {
                an = new ActivationNetwork(new SigmoidFunction(), 100, 100, 1);
                dn = new DistanceNetwork(100, 100);
            }
        }

        public void preExit()
        {
            //this save files
            an.Save("BPNNBrain.net");
            dn.Save("SOMBrain.net");
        }
        


    }
}
