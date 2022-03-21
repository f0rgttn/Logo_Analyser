using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Dnn;
using Emgu.CV.Util;
using System.IO;

namespace Logo_Anl
{
    public partial class MenuScreen : Form
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private static string LogoPath { get; set; }

        public void SetLogoPath()
        {
            string logopath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            //filters logo so that only the most common image fformats can be accepted
            dialog.Filter = "Image Files (*.jpg;**.png;*.bmp;)|*.jpg;**.png;*.bmp;|All Files (*.*)|*.*;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                logopath = dialog.FileName;
            }
            LogoPath = logopath;
        }

        public string GetLogoPath()
        {
            return LogoPath;
        }

        //ensures a logo has been selected by the user
        public void CheckPathFilled()
        {
            if (GetLogoPath() == null)
            {
                MessageBox.Show("Please assign a logo");
                SetLogoPath();
                Bitmap logo = new Bitmap(GetLogoPath());
                pictureBox1.Image = logo;
            }
        }

        //Load model for object detection
        Net Model = null;
        List<string> ClassLabels = null;

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var PathWeights = dialog.FileNames.Where(x => x.EndsWith(".weights")).First();
                    var Pathconfig = dialog.FileNames.Where(x => x.EndsWith(".cfg")).First();
                    var PathClasses = dialog.FileNames.Where(x => x.EndsWith(".names")).First();

                    //will read the pretrained models and weights already provided
                    Model = DnnInvoke.ReadNetFromDarknet(Pathconfig, PathWeights);
                    //read labels
                    ClassLabels = File.ReadAllLines(PathClasses).ToList();
                    MessageBox.Show("Model Loaded");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Object Detection
        private void detectObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //check model has been loaded
                if (Model == null)
                {
                    throw new Exception("Load the model.");
                }

                //parameters, yolo can process at different sizes. 
                //set the parameters to the size of images providedd

                //confThreshold will is the minimum value for confidence
                //confidence.. if 8 it is a float
                float confThreshold = 0.8f;
                //non maximum seperation threshold, if two objects are close it is how to combine them
                float nmsThreshold = 0.4f;
                //default size
                int imgDefaultSize = 416;

                //creating image instance
                Image<Bgr, byte> img = new Image<Bgr, byte>(GetLogoPath())
                        .Resize(imgDefaultSize, imgDefaultSize, Emgu.CV.CvEnum.Inter.Cubic); ;
                
                //BlobfromImage takes the image as an input and converts it into a tensor in such a dimension that is acceptible by the model
                //inside BlobFromImage, the second variable is scaling the image by 1/255
                //swapRB will swap the colour chanels as the input provides colour chanel Bgr, while the tensor expects Rgb
                var input = DnnInvoke.BlobFromImage(img, 1 / 255.0, swapRB: true);

                Model.SetInput(input);
                //making sure that OpenCv is being used as the backend
                Model.SetPreferableBackend(Emgu.CV.Dnn.Backend.OpenCV);
                //use the cpu when training model, this means that the program can run on systems that do not have a gpu
                Model.SetPreferableTarget(Target.Cpu);

                //Pass the input through all the layers so to get the output
                VectorOfMat vectorOfMat = new VectorOfMat();
                //use the Forward method, decide output type, names of layers but as they are unkown use Model.UnconnectedOutLayersNames
                Model.Forward(vectorOfMat, Model.UnconnectedOutLayersNames);
                //yolo has given the outputs to us

                //post processing- Need to do the prost processing to see what is the output, what was the bounding box, where is the bounding box,
                // how can we calculate the score, what are the indices of those scores (in this there are 80 classes, therefore 80 possibilities+bounding boxes+confidence score).

                VectorOfRect bboxes = new VectorOfRect(); //vector of rectangles to draw bounding boxes 
                VectorOfFloat scores = new VectorOfFloat(); //vector of Floats for the scores obtained for each class
                VectorOfInt indices = new VectorOfInt(); //vector of integers for each class- what to retain and what to remove

                for (int k = 0; k < vectorOfMat.Size; k++)
                {
                    var mat = vectorOfMat[k];
                    //make mat into 2d list of floats
                    var data = HelperClass.ArrayTo2DList(mat.GetData());

                    //loop through all data, look through each column, if data score > confidence score
                    //consider for further processing otherwise reject it

                    for (int i = 0; i < data.Count; i++)
                    {
                        var row = data[i];
                        var rowsscores = row.Skip(5).ToArray();
                        //find from rowsscore which class has the highest confidence score 
                        var classId = rowsscores.ToList().IndexOf(rowsscores.Max()); //index will give the class id as starts from 0, 1, 2 ...
                        var confidence = rowsscores[classId];

                        if (confidence > confThreshold)
                        {
                            var center_x = (int)(row[0] * img.Width); //center value for x
                            var center_y = (int)(row[1] * img.Height); //center value for y

                            var width = (int)(row[2] * img.Width);
                            var height = (int)(row[3] * img.Height);

                            //need to find top left corner value to allow the box to be drawn from
                            //using width, height and center the top left can be found

                            var x = (int)(center_x - (width / 2));
                            var y = (int)(center_y - (height / 2));


                            bboxes.Push(new Rectangle[] { new Rectangle(x, y, width, height) });  //obtain the bounding boxes
                            indices.Push(new int[] { classId });                                 //obtain their labels
                            scores.Push(new float[] { confidence });                             //what was there score being stored
                        }
                    }
                }
                //prevent multiple bounding boxes for one object
                //NMS = non-maxim expression, will return an integer array for labels retained
                var idx = DnnInvoke.NMSBoxes(bboxes.ToArray(), scores.ToArray(), confThreshold, nmsThreshold);
                //Only going to get one id if a location is "pinged" too many times 

                var imgOutput = img.Clone();

                for (int i = 0; i < idx.Length; i++)
                {
                    int index = idx[i];
                    var bbox = bboxes[index];
                    imgOutput.Draw(bbox, new Bgr(0, 255, 0), 2);//bounding box colour and size
                    CvInvoke.PutText(imgOutput, ClassLabels[indices[index]], new Point(bbox.X, bbox.Y + 20),
                        Emgu.CV.CvEnum.FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), 2);
                }

                pictureBox1.Image = imgOutput.AsBitmap();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Colourimetrics


        //Provides the values for each and and every pixel in the logo
        private void getAllValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckPathFilled();
            Image Logo = Image.FromFile(GetLogoPath());
            List<string> pixel_colours = Colourimetrics.Colour(Logo, true);
            colourimetricOutput(pixel_colours, Logo);
        }
        //Provides the unique values for pixels
        private void getUniqueValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckPathFilled();
            Image Logo = Image.FromFile(GetLogoPath());
            List<string> pixel_colours = Colourimetrics.Colour(Logo, false);
            colourimetricOutput(pixel_colours, Logo);
        }




        public void colourimetricOutput(List<string> pixel_colours, Image Logo)
        {
            pictureBox1.Image = Logo;
            richTextBox1.Visible = true;
            richTextBox1.Text = String.Join(Environment.NewLine, pixel_colours);
        }

        private void classifyBusinessTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Stack<string> Output = null;
                ML_Main.ML_Hub(Output);

                while (Output.Count != 0)
                {
                    richTextBox1.Text = Output.Peek();
                    Output.Pop();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        // readTextToolStripMenuItem_Click method returns the text in a logo to the user via optical character recognition ("OCR")
        private void readTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string logopath = GetLogoPath();
                //logopath = Image.FromFile(logopath);
                //using (var objectOcr = OcrApi.Create())

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //File -> load image
        private void loadLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLogoPath();
            Bitmap logo = new Bitmap(GetLogoPath());
            pictureBox1.Image = logo;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
