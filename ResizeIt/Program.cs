using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace ResizeIt
{
    class Program
    {
        private static void PrintUsage()
        {
            Console.WriteLine("Convert the icon files to different sizes");
            Console.WriteLine("resizeit <input-png-file> <output-size>");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("{0}", System.Environment.CurrentDirectory);
            Console.WriteLine("Length = {0}", args.Length);
            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine("{0}", args[i]);
            }
            if (args.Length < 2)
            {
                PrintUsage();
                return;
            }

            String inputFile = System.Environment.CurrentDirectory + "\\" + args[0];
            int targetSize = Int32.Parse(args[1]);
            float fTargetSize = (float)targetSize;
            String outputFile = String.Format("{0}_{1}.png", inputFile, targetSize);

            using (Image src = Image.FromFile(inputFile))
            using (Bitmap dst = new Bitmap(targetSize, targetSize))
            using (Graphics graph = Graphics.FromImage(dst))
            {
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graph.DrawImage(src, 0, 0, dst.Width, dst.Height);
                dst.Save(outputFile, ImageFormat.Png);
            }
            Console.WriteLine("Resized to {0}.", outputFile);
        }
    }
}
