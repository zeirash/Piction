using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge.Imaging;
using System.IO;
using AForge.Neuro;
using AForge.Neuro.Learning;


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
