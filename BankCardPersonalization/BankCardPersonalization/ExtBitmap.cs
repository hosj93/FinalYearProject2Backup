using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;

namespace BankCardPersonalization
{
    public static class ExtBitmap
    {
        public enum ColorShiftType
        {
            None,
            //ShiftLeft,
            //ShiftRight
        }

        public enum EdgeTracingType
        {
            Black,
            //White,
            //HalfIntensity,
            //DoubleIntensity,
            //ColorInversion
        }
        public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        public static Bitmap Bitonal(this Bitmap sourceBitmap, Color darkColor,
                                          Color lightColor, int threshold)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                if (pixelBuffer[k] + pixelBuffer[k + 1] + pixelBuffer[k + 2] <= threshold)
                {
                    pixelBuffer[k] = darkColor.B;
                    pixelBuffer[k + 1] = darkColor.G;
                    pixelBuffer[k + 2] = darkColor.R;
                }
                else
                {
                    pixelBuffer[k] = lightColor.B;
                    pixelBuffer[k + 1] = lightColor.G;
                    pixelBuffer[k + 2] = lightColor.R;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                     ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public static Bitmap GradientBasedEdgeDetectionFilter(
                                        this Bitmap sourceBitmap,
                                        EdgeFilterType filterType,
                                        DerivativeLevel derivativeLevel,
                                        float redFactor = 1.0f,
                                        float greenFactor = 1.0f,
                                        float blueFactor = 1.0f,
                                        byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            int derivative = (int)derivativeLevel;
            int byteOffset = 0;
            int blueGradient, greenGradient, redGradient = 0;
            double blue = 0, green = 0, red = 0;

            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX <
                    sourceBitmap.Width - 1; offsetX++)
                {
                    byteOffset = offsetY * sourceData.Stride +
                                 offsetX * 4;

                    blueGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;

                    blueGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;

                    byteOffset++;

                    greenGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;

                    greenGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;

                    byteOffset++;

                    redGradient =
                    Math.Abs(pixelBuffer[byteOffset - 4] -
                    pixelBuffer[byteOffset + 4]) / derivative;

                    redGradient +=
                    Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                    pixelBuffer[byteOffset + sourceData.Stride]) / derivative;

                    if (blueGradient + greenGradient + redGradient > threshold)
                    { exceedsThreshold = true; }
                    else
                    {
                        byteOffset -= 2;

                        blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                 pixelBuffer[byteOffset + 4]);
                        byteOffset++;

                        redGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                               pixelBuffer[byteOffset + 4]);

                        if (blueGradient + greenGradient + redGradient > threshold)
                        { exceedsThreshold = true; }
                        else
                        {
                            byteOffset -= 2;

                            blueGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            greenGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            byteOffset++;

                            redGradient =
                            Math.Abs(pixelBuffer[byteOffset - sourceData.Stride] -
                            pixelBuffer[byteOffset + sourceData.Stride]);

                            if (blueGradient + greenGradient +
                                      redGradient > threshold)
                            { exceedsThreshold = true; }
                            else
                            {
                                byteOffset -= 2;

                                blueGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                blueGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                byteOffset++;

                                greenGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                greenGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                byteOffset++;

                                redGradient =
                                Math.Abs(pixelBuffer[byteOffset - 4 - sourceData.Stride] -
                                pixelBuffer[byteOffset + 4 + sourceData.Stride]) / derivative;

                                redGradient +=
                                Math.Abs(pixelBuffer[byteOffset - sourceData.Stride + 4] -
                                pixelBuffer[byteOffset + sourceData.Stride - 4]) / derivative;

                                if (blueGradient + greenGradient + redGradient > threshold)
                                { exceedsThreshold = true; }
                                else
                                { exceedsThreshold = false; }
                            }
                        }
                    }

                    byteOffset -= 2;

                    if (exceedsThreshold)
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono)
                        {
                            blue = green = red = 255;
                        }
                        else if (filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = blueGradient * blueFactor;
                            green = greenGradient * greenFactor;
                            red = redGradient * redFactor;
                        }
                        else if (filterType == EdgeFilterType.Sharpen)
                        {
                            blue = pixelBuffer[byteOffset] * blueFactor;
                            green = pixelBuffer[byteOffset + 1] * greenFactor;
                            red = pixelBuffer[byteOffset + 2] * redFactor;
                        }
                        else if (filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset] + blueGradient * blueFactor;
                            green = pixelBuffer[byteOffset + 1] + greenGradient * greenFactor;
                            red = pixelBuffer[byteOffset + 2] + redGradient * redFactor;
                        }
                    }
                    else
                    {
                        if (filterType == EdgeFilterType.EdgeDetectMono ||
                            filterType == EdgeFilterType.EdgeDetectGradient)
                        {
                            blue = green = red = 0;
                        }
                        else if (filterType == EdgeFilterType.Sharpen ||
                                 filterType == EdgeFilterType.SharpenGradient)
                        {
                            blue = pixelBuffer[byteOffset];
                            green = pixelBuffer[byteOffset + 1];
                            red = pixelBuffer[byteOffset + 2];
                        }
                    }

                    blue = (blue > 255 ? 255 :
                           (blue < 0 ? 0 :
                            blue));

                    green = (green > 255 ? 255 :
                            (green < 0 ? 0 :
                             green));

                    red = (red > 255 ? 255 :
                          (red < 0 ? 0 :
                           red));

                    resultBuffer[byteOffset] = (byte)blue;
                    resultBuffer[byteOffset + 1] = (byte)green;
                    resultBuffer[byteOffset + 2] = (byte)red;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public static Bitmap FlipPixels(this Bitmap sourceImage)
        {
            List<ArgbPixel> pixelList = GetPixelListFromBitmap(sourceImage);

            pixelList.Reverse();

            Bitmap resultBitmap = GetBitmapFromPixelList(pixelList,
                                sourceImage.Width, sourceImage.Height);

            return resultBitmap;
        }

        private static Bitmap GetBitmapFromPixelList(List<ArgbPixel> pixelList, int width, int height)
        {
            Bitmap resultBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                        resultBitmap.Width, resultBitmap.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[resultData.Stride * resultData.Height];

            using (MemoryStream memoryStream = new MemoryStream(resultBuffer))
            {
                memoryStream.Position = 0;
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

                foreach (ArgbPixel pixel in pixelList)
                {
                    binaryWriter.Write(pixel.GetColorBytes());
                }

                binaryWriter.Close();
            }

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        private static List<ArgbPixel> GetPixelListFromBitmap(Bitmap sourceImage)
        {
            BitmapData sourceData = sourceImage.LockBits(new Rectangle(0, 0,
                        sourceImage.Width, sourceImage.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, sourceBuffer.Length);
            sourceImage.UnlockBits(sourceData);

            List<ArgbPixel> pixelList = new List<ArgbPixel>(sourceBuffer.Length / 4);

            int x = 0;
            int y = 0;

            using (MemoryStream memoryStream = new MemoryStream(sourceBuffer))
            {
                memoryStream.Position = 0;
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                while (memoryStream.Position + 4 <= memoryStream.Length)
                {
                    ArgbPixel pixel = new ArgbPixel(binaryReader.ReadBytes(4), x, y);
                    pixelList.Add(pixel);

                    x += 1;

                    if (x >= sourceData.Width)
                    {
                        x = 0;
                        y += 1;
                    }
                }

                binaryReader.Close();
            }

            return pixelList;
        }
        public class ArgbPixel
        {
            public int pixelX = 0;
            public int pixelY = 0;

            public byte blue = 0;
            public byte green = 0;
            public byte red = 0;
            public byte alpha = 0;

            public ArgbPixel()
            {

            }

            public ArgbPixel(byte[] colorComponents)
            {
                blue = colorComponents[0];
                green = colorComponents[1];
                red = colorComponents[2];
                alpha = colorComponents[3];
            }

            public ArgbPixel(byte[] colorComponents, int x, int y)
            {
                blue = colorComponents[0];
                green = colorComponents[1];
                red = colorComponents[2];
                alpha = colorComponents[3];

                pixelX = x;
                pixelY = y;
            }

            public byte[] GetColorBytes()
            {
                return new byte[] { blue, green, red, alpha };
            }

            public byte this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return blue;
                        case 1: return green;
                        case 2: return red;
                        case 3: return alpha;
                        default: return 0;
                    }
                }
            }
        }
        public static Bitmap FuzzyEdgeBlurFilter(this Bitmap sourceBitmap,
                                                 int filterSize,
                                                 float edgeFactor1,
                                                 float edgeFactor2)
        {
            return
            sourceBitmap.BooleanEdgeDetectionFilter(edgeFactor1).
            MeanFilter(filterSize).BooleanEdgeDetectionFilter(edgeFactor2);
        }

        public static Bitmap BooleanEdgeDetectionFilter(
               this Bitmap sourceBitmap, float edgeFactor)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];
            Buffer.BlockCopy(pixelBuffer, 0, resultBuffer,
                             0, pixelBuffer.Length);

            List<string> edgeMasks = GetBooleanEdgeMasks();

            int imageStride = sourceBitmap.Width * 4;
            int matrixMean = 0, pixelTotal = 0;
            int filterY = 0, filterX = 0, calcOffset = 0;
            string matrixPatern = String.Empty;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                matrixPatern = String.Empty;
                matrixMean = 0; pixelTotal = 0;
                filterY = -1; filterX = -1;

                while (filterY < 2)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    matrixMean += pixelBuffer[calcOffset];
                    matrixMean += pixelBuffer[calcOffset + 1];
                    matrixMean += pixelBuffer[calcOffset + 2];

                    filterX += 1;

                    if (filterX > 1)
                    { filterX = -1; filterY += 1; }
                }

                matrixMean = matrixMean / 9;
                filterY = -1; filterX = -1;

                while (filterY < 2)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    pixelTotal = pixelBuffer[calcOffset];
                    pixelTotal += pixelBuffer[calcOffset + 1];
                    pixelTotal += pixelBuffer[calcOffset + 2];

                    matrixPatern += (pixelTotal > matrixMean
                                                 ? "1" : "0");
                    filterX += 1;

                    if (filterX > 1)
                    { filterX = -1; filterY += 1; }
                }

                if (edgeMasks.Contains(matrixPatern))
                {
                    resultBuffer[k] =
                    ClipByte(resultBuffer[k] * edgeFactor);

                    resultBuffer[k + 1] =
                    ClipByte(resultBuffer[k + 1] * edgeFactor);

                    resultBuffer[k + 2] =
                    ClipByte(resultBuffer[k + 2] * edgeFactor);
                }
            }

            return resultBuffer.GetImage(sourceBitmap.Width, sourceBitmap.Height);
        }
          public static List<string> GetBooleanEdgeMasks()
        {
            List<string> edgeMasks = new List<string>();

            edgeMasks.Add("011011011");
            edgeMasks.Add("000111111");
            edgeMasks.Add("110110110");
            edgeMasks.Add("111111000");
            edgeMasks.Add("011011001");
            edgeMasks.Add("100110110");
            edgeMasks.Add("111011000");
            edgeMasks.Add("111110000");
            edgeMasks.Add("111011001");
            edgeMasks.Add("100110111");
            edgeMasks.Add("001011111");
            edgeMasks.Add("111110100");
            edgeMasks.Add("000011111");
            edgeMasks.Add("000110111");
            edgeMasks.Add("001011011");
            edgeMasks.Add("110110100");

            return edgeMasks;
        }

        private static Bitmap MeanFilter(this Bitmap sourceBitmap,
                                         int meanSize)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            double blue = 0.0, green = 0.0, red = 0.0;
            double factor = 1.0 / (meanSize * meanSize);

            int imageStride = sourceBitmap.Width * 4;
            int filterOffset = meanSize / 2;
            int calcOffset = 0, filterY = 0, filterX = 0;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = 0; green = 0; red = 0;
                filterY = -filterOffset;
                filterX = -filterOffset;

                while (filterY <= filterOffset)
                {
                    calcOffset = k + (filterX * 4) +
                    (filterY * imageStride);

                    calcOffset = (calcOffset < 0 ? 0 :
                    (calcOffset >= pixelBuffer.Length - 2 ?
                    pixelBuffer.Length - 3 : calcOffset));

                    blue += pixelBuffer[calcOffset];
                    green += pixelBuffer[calcOffset + 1];
                    red += pixelBuffer[calcOffset + 2];

                    filterX++;
                    
                    if (filterX > filterOffset)
                    {
                        filterX = -filterOffset;
                        filterY++;
                    }
                }

                resultBuffer[k] = ClipByte(factor * blue);
                resultBuffer[k + 1] = ClipByte(factor * green);
                resultBuffer[k + 2] = ClipByte(factor * red);
                resultBuffer[k + 3] = 255;
            }

            return resultBuffer.GetImage(sourceBitmap.Width, sourceBitmap.Height);
        }

        public static byte[] GetByteArray(this Bitmap sourceBitmap)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] sourceBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];

            Marshal.Copy(sourceData.Scan0, sourceBuffer, 0,
                                       sourceBuffer.Length);

            sourceBitmap.UnlockBits(sourceData);

            return sourceBuffer;
        }

        public static Bitmap GetImage(this byte[] resultBuffer, int width, int height)
        {
            Bitmap resultBitmap = new Bitmap(width, height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap AbstractColorsFilter(this Bitmap sourceBitmap,
                                                  int matrixSize,
                                                  byte edgeThreshold,
                                                  bool applyBlue = true,
                                                  bool applyGreen = true,
                                                  bool applyRed = true,
                                                  EdgeTracingType edgeType =
                                                  EdgeTracingType.Black,
                                                  ColorShiftType shiftType =
                                                  ColorShiftType.None)
        {
            Bitmap edgeBitmap =
            sourceBitmap.GradientBasedEdgeDetectionFilter(edgeThreshold);

            Bitmap colorBitmap =
            sourceBitmap.AverageColoursFilter(matrixSize,
                         applyBlue, applyGreen, applyRed, shiftType);

            byte[] edgeBuffer = edgeBitmap.GetByteArray();
            byte[] colorBuffer = colorBitmap.GetByteArray();
            byte[] resultBuffer = colorBitmap.GetByteArray();

            for (int k = 0; k + 4 < edgeBuffer.Length; k += 4)
            {
                if (edgeBuffer[k] == 255)
                {
                    switch (edgeType)
                    {
                        case EdgeTracingType.Black:
                            resultBuffer[k] = 0;
                            resultBuffer[k + 1] = 0;
                            resultBuffer[k + 2] = 0;
                            break;
                        //case EdgeTracingType.White:
                            //resultBuffer[k] = 255;
                            //resultBuffer[k + 1] = 255;
                            //resultBuffer[k + 2] = 255;
                            //break;
                        //case EdgeTracingType.HalfIntensity:
                            //resultBuffer[k] = ClipByte(resultBuffer[k] * 0.5);
                            //resultBuffer[k + 1] = ClipByte(resultBuffer[k + 1] * 0.5);
                            //resultBuffer[k + 2] = ClipByte(resultBuffer[k + 2] * 0.5);
                            //break;
                        //case EdgeTracingType.DoubleIntensity:
                            //resultBuffer[k] = ClipByte(resultBuffer[k] * 2);
                            //resultBuffer[k + 1] = ClipByte(resultBuffer[k + 1] * 2);
                            //resultBuffer[k + 2] = ClipByte(resultBuffer[k + 2] * 2);
                            //break;
                        //case EdgeTracingType.ColorInversion:
                            //resultBuffer[k] = ClipByte(255 - resultBuffer[k]);
                            //resultBuffer[k + 1] = ClipByte(255 - resultBuffer[k + 1]);
                            //resultBuffer[k + 2] = ClipByte(255 - resultBuffer[k + 2]);
                            //break;
                    }
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                            sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        public static Bitmap AverageColoursFilter(this Bitmap sourceBitmap,
                                                 int matrixSize,
                                                 bool applyBlue = true,
                                                 bool applyGreen = true,
                                                 bool applyRed = true,
                                                 ColorShiftType shiftType =
                                                 ColorShiftType.None)
        {
            byte[] pixelBuffer = sourceBitmap.GetByteArray();
            byte[] resultBuffer = new byte[pixelBuffer.Length];

            int calcOffset = 0;
            int byteOffset = 0;
            int blue = 0; int green = 0; int red = 0;
            int filterOffset = (matrixSize - 1) / 2;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    byteOffset = offsetY * sourceBitmap.Width * 4 +
                                 offsetX * 4;

                    blue = 0; green = 0; red = 0;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                            (filterX * 4) +
                            (filterY * sourceBitmap.Width * 4);

                            blue += pixelBuffer[calcOffset];
                            green += pixelBuffer[calcOffset + 1];
                            red += pixelBuffer[calcOffset + 2];
                        }
                    }

                    blue = blue / matrixSize;
                    green = green / matrixSize;
                    red = red / matrixSize;

                    if (applyBlue == false)
                    { blue = pixelBuffer[byteOffset]; }

                    if (applyGreen == false)
                    { green = pixelBuffer[byteOffset + 1]; }

                    if (applyRed == false)
                    { red = pixelBuffer[byteOffset + 2]; }

                    if (shiftType == ColorShiftType.None)
                    {
                        resultBuffer[byteOffset] = (byte)blue;
                        resultBuffer[byteOffset + 1] = (byte)green;
                        resultBuffer[byteOffset + 2] = (byte)red;
                        resultBuffer[byteOffset + 3] = 255;
                    }
                    //else if (shiftType == ColorShiftType.ShiftLeft)
                    //{
                    //    resultBuffer[byteOffset] = (byte)green;
                    //    resultBuffer[byteOffset + 1] = (byte)red;
                    //    resultBuffer[byteOffset + 2] = (byte)blue;
                    //    resultBuffer[byteOffset + 3] = 255;
                    //}
                    //else if (shiftType == ColorShiftType.ShiftRight)
                    //{
                    //    resultBuffer[byteOffset] = (byte)red;
                    //    resultBuffer[byteOffset + 1] = (byte)blue;
                    //    resultBuffer[byteOffset + 2] = (byte)green;
                    //    resultBuffer[byteOffset + 3] = 255;
                    //}
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                             sourceBitmap.Height);

            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap GradientBasedEdgeDetectionFilter(
                                this Bitmap sourceBitmap,
                                byte threshold = 0)
        {
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int sourceOffset = 0, gradientValue = 0;
            bool exceedsThreshold = false;

            for (int offsetY = 1; offsetY <
                                  sourceBitmap.Height - 1; offsetY++)
            {
                for (int offsetX = 1; offsetX <
                                      sourceBitmap.Width - 1; offsetX++)
                {
                    sourceOffset = offsetY * sourceData.Stride +
                                   offsetX * 4;
                    gradientValue = 0;
                    exceedsThreshold = true;

                    // Horizontal Gradient
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - 4,
                                   sourceOffset + 4,
                                   ref gradientValue, threshold, 2);
                    // Vertical Gradient
                    exceedsThreshold =
                    CheckThreshold(pixelBuffer,
                                   sourceOffset - sourceData.Stride,
                                   sourceOffset + sourceData.Stride,
                                   ref gradientValue, threshold, 2);

                    if (exceedsThreshold == false)
                    {
                        gradientValue = 0;

                        // Horizontal Gradient
                        exceedsThreshold =
                        CheckThreshold(pixelBuffer,
                                       sourceOffset - 4,
                                       sourceOffset + 4,
                                       ref gradientValue, threshold);

                        if (exceedsThreshold == false)
                        {
                            gradientValue = 0;

                            // Vertical Gradient
                            exceedsThreshold =
                            CheckThreshold(pixelBuffer,
                                           sourceOffset - sourceData.Stride,
                                           sourceOffset + sourceData.Stride,
                                           ref gradientValue, threshold);

                            if (exceedsThreshold == false)
                            {
                                gradientValue = 0;

                                // Diagonal Gradient : NW-SE
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - 4 - sourceData.Stride,
                                               sourceOffset + 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);
                                // Diagonal Gradient : NE-SW
                                exceedsThreshold =
                                CheckThreshold(pixelBuffer,
                                               sourceOffset - sourceData.Stride + 4,
                                               sourceOffset - 4 + sourceData.Stride,
                                               ref gradientValue, threshold, 2);

                                if (exceedsThreshold == false)
                                {
                                    gradientValue = 0;

                                    // Diagonal Gradient : NW-SE
                                    exceedsThreshold =
                                    CheckThreshold(pixelBuffer,
                                                   sourceOffset - 4 - sourceData.Stride,
                                                   sourceOffset + 4 + sourceData.Stride,
                                                   ref gradientValue, threshold);

                                    if (exceedsThreshold == false)
                                    {
                                        gradientValue = 0;

                                        // Diagonal Gradient : NE-SW
                                        exceedsThreshold =
                                        CheckThreshold(pixelBuffer,
                                                       sourceOffset - sourceData.Stride + 4,
                                                       sourceOffset + sourceData.Stride - 4,
                                                       ref gradientValue, threshold);
                                    }
                                }
                            }
                        }
                    }

                    resultBuffer[sourceOffset] = (byte)(exceedsThreshold ? 255 : 0);
                    resultBuffer[sourceOffset + 1] = resultBuffer[sourceOffset];
                    resultBuffer[sourceOffset + 2] = resultBuffer[sourceOffset];
                    resultBuffer[sourceOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        private static bool CheckThreshold(byte[] pixelBuffer,
                                          int offset1, int offset2,
                                          ref int gradientValue,
                                          byte threshold,
                                          int divideBy = 1)
        {
            gradientValue +=
            Math.Abs(pixelBuffer[offset1] -
            pixelBuffer[offset2]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 1] -
            pixelBuffer[offset2 + 1]) / divideBy;

            gradientValue +=
            Math.Abs(pixelBuffer[offset1 + 2] -
            pixelBuffer[offset2 + 2]) / divideBy;

            return (gradientValue >= threshold);
        }

        private static byte ClipByte(double colour)
        {
            return (byte)(colour > 255 ? 255 :
                   (colour < 0 ? 0 : colour));
        }
        public static Bitmap ArithmeticBlend(this Bitmap sourceBitmap, Bitmap blendBitmap,
                                        ColorCalculator.ColorCalculationType calculationType)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            BitmapData blendData = blendBitmap.LockBits(new Rectangle(0, 0,
                                    blendBitmap.Width, blendBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] blendBuffer = new byte[blendData.Stride * blendData.Height];
            Marshal.Copy(blendData.Scan0, blendBuffer, 0, blendBuffer.Length);
            blendBitmap.UnlockBits(blendData);

            for (int k = 0; (k + 4 < pixelBuffer.Length) &&
                            (k + 4 < blendBuffer.Length); k += 4)
            {
                pixelBuffer[k] = ColorCalculator.Calculate(pixelBuffer[k],
                                 blendBuffer[k], calculationType);

                pixelBuffer[k + 1] = ColorCalculator.Calculate(pixelBuffer[k + 1],
                                     blendBuffer[k + 1], calculationType);

                pixelBuffer[k + 2] = ColorCalculator.Calculate(pixelBuffer[k + 2],
                                     blendBuffer[k + 2], calculationType);
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap SwapColorsCopy(this Bitmap originalImage, ColorSwapFilter swapFilterData)
        {
            BitmapData sourceData = originalImage.LockBits
                                    (new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, resultBuffer, 0, resultBuffer.Length);
            originalImage.UnlockBits(sourceData);

            byte sourceBlue = 0, resultBlue = 0,
                 sourceGreen = 0, resultGreen = 0,
                 sourceRed = 0, resultRed = 0;
            byte byte2 = 2, maxValue = 255;

            for (int k = 0; k < resultBuffer.Length; k += 4)
            {
                sourceBlue = resultBuffer[k];
                sourceGreen = resultBuffer[k + 1];
                sourceRed = resultBuffer[k + 2];

                if (swapFilterData.InvertColorsWhenSwapping == true)
                {
                    sourceBlue = (byte)(maxValue - sourceBlue);
                    sourceGreen = (byte)(maxValue - sourceGreen);
                    sourceRed = (byte)(maxValue - sourceRed);
                }

                if (swapFilterData.SwapHalfColorValues == true)
                {
                    sourceBlue = (byte)(sourceBlue / byte2);
                    sourceGreen = (byte)(sourceGreen / byte2);
                    sourceRed = (byte)(sourceRed / byte2);
                }

                switch (swapFilterData.SwapType)
                {
                    case ColorSwapFilter.ColorSwapType.ShiftRight:
                        {
                            resultBlue = sourceGreen;
                            resultRed = sourceBlue;
                            resultGreen = sourceRed;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.ShiftLeft:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceGreen;
                            resultGreen = sourceBlue;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapBlueAndRed:
                        {
                            resultBlue = sourceRed;
                            resultRed = sourceBlue;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapBlueAndGreen:
                        {
                            resultBlue = sourceGreen;
                            resultGreen = sourceBlue;

                            break;
                        }
                    case ColorSwapFilter.ColorSwapType.SwapRedAndGreen:
                        {
                            resultRed = sourceGreen;
                            resultGreen = sourceGreen;

                            break;
                        }
                }

                resultBuffer[k] = resultBlue;
                resultBuffer[k + 1] = resultGreen;
                resultBuffer[k + 2] = resultRed;
            }

            Bitmap resultBitmap = new Bitmap(originalImage.Width, originalImage.Height,
                                             PixelFormat.Format32bppArgb);

            BitmapData resultData = resultBitmap.LockBits
                                    (new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

    }

    public class ColorSwapFilter
    {
        private ColorSwapType swapType = ColorSwapType.ShiftRight;
        public ColorSwapType SwapType
        {
            get { return swapType; }
            set { swapType = value; }
        }

        private bool swapHalfColorValues = false;
        public bool SwapHalfColorValues
        {
            get { return swapHalfColorValues; }
            set { swapHalfColorValues = value; }
        }

        private bool invertColorsWhenSwapping = false;
        public bool InvertColorsWhenSwapping
        {
            get { return invertColorsWhenSwapping; }
            set { invertColorsWhenSwapping = value; }
        }

        public enum ColorSwapType
        {
            ShiftRight,
            ShiftLeft,
            SwapBlueAndRed,
            SwapBlueAndGreen,
            SwapRedAndGreen,
        }
    }
    public enum EdgeFilterType
    {
        None,
        EdgeDetectMono,
        EdgeDetectGradient,
        Sharpen,
        SharpenGradient,
    }

    public enum DerivativeLevel
    {
        First = 1,
        Second = 2
    }
}
       
