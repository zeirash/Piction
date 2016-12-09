using System;
using System.Collections.Generic;
using System.Linq;

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
        string path = "pictures/";

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
        public Dictionary<int, string> dictCategory = new Dictionary<int, string>();

        double[][] inputPCA;

        public NeuralNet()
        {
            listInput = new List<double[]>();
            listOutput = new List<double[]>();
            tempOutput = new List<double[]>();
            listImageName = new List<String>();
            listCategoryNames = new List<String>();
            temp_data = new List<double[]>();

            an = new ActivationNetwork(new SigmoidFunction(), WIDTH * HEIGHT, 10, 1);
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

        public void reloadPic()
        {
            var dir = Directory.GetDirectories(path);

            foreach (var subdir in dir)
            {
                foreach (var img in Directory.GetFiles(subdir))
                {
                    Bitmap image = new Bitmap(img);
                    image = preprocessing(image);
                    input(image);
                }
            }
        }

        private double normalizedInput(double input)
        {
            double maxInput = 255, minInput = 0;
            int high = 1, low = 0;

            double normalizeInput = low + (input - minInput) / (maxInput - minInput) * (high - low);

            return normalizeInput;
        }

        public void input(Bitmap edited)
        {
            //double[][] inputData = new double[allpic][];
            //input
            //for (int x = 0; x < allpic; x++)
            //{
            //available pic
            double[] inputData = new double[WIDTH * HEIGHT];
            int index = 0;
            for (int i = 0; i < edited.Width; i++)
            {
                for (int j = 0; j < edited.Height; j++)
                {
                    //int input = edited.GetPixel(i, j).B / 255;
                    int pixel = edited.GetPixel(i, j).B;
                    //normalized input
                    //double normalizeInput = low + (pixel - minInput) / (maxInput - minInput) * (high - low);
                    inputData[index] = normalizedInput(pixel);
                    index++;
                }

            }
            listInput.Add(inputData);
            //}

            //return inputData;
        }
        
        public void output()
        {
            int allcategory = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories).Count();
            double maxOutput = allcategory, minOutput = 1;
            int high = 1, low = 0;
            double[] outputData = new double[1];
            //outputData[0] = totalInput - 1;
            //tempOutput.Add(output);
            var dir = Directory.GetDirectories(path);
            int category = 0;
            foreach (var subdir in dir)
            {
                category++;
                foreach (var img in Directory.GetFiles(subdir))
                {
                    outputData[0] = category;
                    //normalized output
                    double normalizeOutput = low + (outputData[0] - minOutput) / (maxOutput - minOutput) * (high - low);
                    outputData[0] = normalizeOutput;
                    listOutput.Add(outputData);
                }
            }
            //normalization output
            //listOutput = new List<double[]>();
        }

        public void getCategory()
        {
            var dir = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories);
            int category = 0;
            foreach (DirectoryInfo subdir in dir)
            {
                category++;
                dictCategory.Add(category, subdir.Name);
            }

        }

        public double trainBPL()
        {
            int epoch = 10000;
            double errorrate = 0;
            double error = 0.0000001;

            for (int i = 0; i < epoch; i++)
            {
                errorrate = bpnn.RunEpoch(listInput.ToArray(), listOutput.ToArray());

                 if(error == errorrate)
                {
                    return errorrate;
                }
            }
            return errorrate;
        }

        public void convertImageToArray(Bitmap image)
        {
            //convert image to array
            ImageToArray array_converter = new ImageToArray(min: 0, max: 1);
            double[] data;
            array_converter.Convert(image, out data);
            temp_data.Add(data);
        }

        public double[][] computePCA(double[][] input)
        {
            //reloadPic();
            //calculate pca
            pca = new PrincipalComponentAnalysis(input);
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

            return inputPCA;
        }

        public void trainSOM()
        {
            int epoch = 10000;
            double errorrate = 0;
            double minerror = 0.0000001;
            int neuronSquared = 1;
            int allcategory = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories).Count();
            NEURON_COUNT = neuronSquared;

            
            while (allcategory > NEURON_COUNT)
            {
                neuronSquared++;
                NEURON_COUNT = neuronSquared * neuronSquared;

            }

            dn = new DistanceNetwork(listInput.Count, NEURON_COUNT);
            som = new SOMLearning(dn);

            //train som
            double[][] pcaresult = computePCA(listInput.ToArray());
            for (int i = 0; i < epoch; i++)
            {
                errorrate = som.RunEpoch(pcaresult);
                //Console.WriteLine(errorrate);
                if (errorrate < minerror)
                    break;
            }
        }

        public void computeSOM(Bitmap image)
        {
            Bitmap edited = new Bitmap(image);
            edited = preprocessing(edited);
            double[][] imageData = new double[1][];
            imageData[0] = new double[WIDTH * HEIGHT];
            int index = 0;

            for (int i = 0; i < edited.Width; i++)
            {
                for (int j = 0; j < edited.Height; j++)
                {
                    int pixel = edited.GetPixel(i, j).B;
                    //normalized input
                    imageData[0][index] = normalizedInput(pixel);
                    index++;
                }
            }
            double[][] pcaresult = computePCA(imageData);
            //error, wrong length of the input vector
            dn.Compute(pcaresult[0]);
            int cluster = dn.GetWinner();
        }

        public int computeBPL(Bitmap image)
        {
            Bitmap edited = new Bitmap(image);
            edited = preprocessing(edited);
            int allcategory = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories).Count();
            double maxOutput = allcategory, minOutput = 1;
            int high = 1, low = 0;
            double[] imageData = new double[WIDTH * HEIGHT];
            int index = 0;

            for (int i = 0; i < edited.Width; i++)
            {
                for (int j = 0; j < edited.Height; j++)
                {
                    //int input = edited.GetPixel(i, j).B / 255;
                    int pixel = edited.GetPixel(i, j).B;
                    //normalized input
                    //double normalizeInput = low + (pixel - minInput) / (maxInput - minInput) * (high - low);
                    imageData[index] = normalizedInput(pixel);
                    index++;
                }

            }
            double[] result = an.Compute(imageData);

            //denormalize result
            double imageResult = minOutput + (result[0] - low) / (high - low) * (maxOutput - minOutput);
            imageResult = Math.Round(imageResult);

            return (int)imageResult;
        }

        public string classifying(Bitmap input)
        {
            string category = "";
            int result = computeBPL(input);

            var subdir = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories);
            for(int i = 0; i < subdir.Count(); i++)
            {
                if (result-1 == i) category = subdir[i].Name;
            }

            return category;
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
                dn = new DistanceNetwork(listInput.Count, NEURON_COUNT);
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
