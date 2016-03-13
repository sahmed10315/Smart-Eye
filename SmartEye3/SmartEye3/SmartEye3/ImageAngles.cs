using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace SmartEye3
{
    public enum Side
    { 
        Left,
        Right
    }
    
    public class ImageAngles
    {
        private int imageWidth;
        private float camDistance;
        private Side side;
        private Double[] pixelAngles;

        public ImageAngles(int imageWidth, float camDistance, Side side)
        {
            this.imageWidth = imageWidth;
            this.camDistance = camDistance;
            this.side = side;

            pixelAngles = new Double[this.imageWidth];
        }

        public void SetPixelAngles()
        {
            int Base;
            double theta;
            int imageCenter = (imageWidth + 1) / 2;

            if (side == Side.Left)
            {
                for (int i = 0; i < imageWidth; i++)
                {
                    if (i < imageCenter)
                    {
                        Base = imageCenter - i;
                        theta = Math.Atan(camDistance / Base);
                        //theta *= 180 / Math.PI;
                        pixelAngles[i] = Math.PI - theta;
                    }
                    else if (i == imageCenter)
                    {
                        pixelAngles[i] = Math.PI / 2;
                    }
                    else
                    {
                        Base = i - imageCenter;
                        theta = Math.Atan(camDistance / Base);
                        //theta *= 180 / Math.PI;
                        pixelAngles[i] = theta;
                    }
                }
            }
            else if (side == Side.Right)
            {
                for (int i = 0; i < imageWidth; i++)
                {
                    if (i < imageCenter)
                    {
                        Base = imageCenter - i;
                        theta = Math.Atan(camDistance / Base);
                        //theta *= 180 / Math.PI;
                        pixelAngles[i] = theta;
                    }
                    else if (i == imageCenter)
                    {
                        pixelAngles[i] = Math.PI / 2;
                    }
                    else
                    {
                        Base = i - imageCenter;
                        theta = Math.Atan(camDistance / Base);
                        //theta *= 180 / Math.PI;
                        pixelAngles[i] = Math.PI - theta;
                    }
                }
            }
        }

        public Double GetPixelAngle(Point point)
        {
            return pixelAngles[point.X];
        }

        public Double GetPixelAngle(int index)
        {
            return pixelAngles[index];
        }

        public int GetImageWidth()
        {
            return imageWidth;
        }

        public void FileImageAngles(String FileName)
        {
            String path = ConfigurationManager.AppSettings["ApplicationFolder"] + FileName;
            StreamWriter sw = File.CreateText(@path);

            for (int i = 0; i < imageWidth; i++)
            {
                sw.Write(i + ": ");
                sw.WriteLine(pixelAngles[i] * (180 / Math.PI));
            }
            sw.Close();
        }
    }
}
