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
using Accord.Imaging.Converters;
using Accord.Statistics.Analysis;

namespace ANNProject
{
    class NeuralNet
    {
        static int WIDTH = 10;
        static int HEIGHT = 10;
        private int NEURON_COUNT = 0;

        ActivationNetwork an;
        DistanceNetwork dn;
        BackPropagationLearning bpnn;
        PrincipalComponentAnalysis pca;
        SOMLearning som;

        public List<double[]> listInput;
        public List<double[]> listOutput;
        List<double[]> tempOutput;
        List<String> listImageName;
        public List<String> listCategoryNames;
        List<double[]> temp_data;

        double[][] inputPCA;
        public bool isEmpty = true;

        public NeuralNet()
        {
            listInput = new List<double[]>();
            listOutput = new List<double[]>();
            tempOutput = new List<double[]>();
            listImageName = new List<String>();
            listCategoryNames = new List<String>();
            temp_data = new List<double[]>();

            an = new ActivationNetwork(new SigmoidFunction(), WIDTH * HEIGHT, 8, 1);
            bpnn = new BackPropagationLearning(an);
        }

        public Bitmap preprocessing(Bitmap image)
        {
            Bitmap result = new Bitmap(image);
            //Grayscaling
            result = Grayscale.CommonAlgorithms.RMY.Apply(result);

            //threshold
            result = new Threshold(128).Apply(result);

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

        public double[] inputNormalization(Bitmap edited)
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
        //masih gk tau bener ato kgk/perlu or kgk
        public void ouputNormalization(int totalInput)
        {
            double[] output = new double[1];
            output[0] = totalInput - 1;
            tempOutput.Add(output);

            //normalization output
            listOutput = new List<double[]>();
            for (int i = 0; i < tempOutput.Count(); i++)
            {
                double[] outputNormal = new double[1];
                outputNormal[0] = tempOutput[i][0] / (double)tempOutput.Count();
                listOutput.Add(outputNormal);
            }
        }


        public void convertImageToArray(Bitmap image)
        {
            //convert image to array
            ImageToArray array_converter = new ImageToArray(min: 0, max: 1);
            double[] data;
            array_converter.Convert(image, out data);
            temp_data.Add(data);
        }

        public void computePCA()
        {
            //calculate pca
            pca = new PrincipalComponentAnalysis(temp_data.ToArray());
            pca.Compute();

            //input pca compute result to array
            inputPCA = new double[pca.Result.GetLength(0)][];

            for (int i = 0; i < pca.Result.GetLength(0); i++)
            {
                inputPCA[i] = new double[pca.Result.GetLength(0)];
                for (int j = 0; j < pca.Result.GetLength(1); j++)
                {
                    inputPCA[i][j] = pca.Result[i, j];
                }
            }
        }

        public void trainSOM(int total_input)
        {
            int epoch = 10000;
            double errorrate = 0;
            double minerror = 0.0000001;
            int neuronSquared = 1;
            NEURON_COUNT = neuronSquared;

            //check Neuron is quadratically more then input
            while (total_input > NEURON_COUNT)
            {
                neuronSquared++;
                NEURON_COUNT = neuronSquared ^ 2;

            }

            dn = new DistanceNetwork(total_input, NEURON_COUNT);
            som = new SOMLearning(dn);

            //train som
            for (int i = 0; i < epoch; i++)
            {
                errorrate = som.RunEpoch(inputPCA);

                if (errorrate < minerror)
                    break;
            }
        }

        public double trainBPL(double [][] input, double [][] output)
        {
            int epoch = 10000;
            double errorrate = 0;
            double error = 0.0000001;

            an = new ActivationNetwork(new SigmoidFunction(), WIDTH * HEIGHT, 8, 1);
            bpnn = new BackPropagationLearning(an);

            for (int i = 0; i < epoch; i++)
            {
                errorrate = bpnn.RunEpoch(input, output);

                 if(error == errorrate)
                {
                    return errorrate;
                }
            }
            return errorrate;
        }

        public void computeBPL(Bitmap image)
        {
            an = new ActivationNetwork(new SigmoidFunction(), WIDTH * HEIGHT, 8, 1);
            bpnn = new BackPropagationLearning(an);

            Bitmap processedImage = preprocessing(image);
            double[] imageData = inputNormalization(processedImage);

            an.Compute(imageData);

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
