using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using AForge.Neuro;
using AForge.Neuro.Learning;
using System.Drawing;
using AForge.Imaging;

namespace ANNProject
{
    class NeuralNet
    {
        //activations
        ActivationNetwork an;
        BackPropagationLearning bpl;
        SOMLearning sml;


        public void setActivationNetwork(int inputLayerCount, int hiddenLayerCount, int outputLayerCount)
        {
            an = new ActivationNetwork(new SigmoidFunction(), inputLayerCount, hiddenLayerCount, outputLayerCount);
        }

        public void loadArt(String filePath)
        {

            Bitmap image = AForge.Imaging.Image.FromFile(filePath);

        }
        
        public void runClassificationEpoch()
        {
            int epoch = 10000;
            double error = 0;
            for (int cycle = 0; cycle < epoch; cycle++)
            {
                error = an.Compute(0,0);
            }
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
