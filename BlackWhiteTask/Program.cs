using System;

namespace BlackWhiteTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImageHelper.ReadImage("photo.jpg",
                out var redColor,
                out var greenColor,
                out var blueColor);

            ConvertToBlackWhite(redColor, greenColor, blueColor);
            ImageHelper.WriteImage("photo_BlackWhite.jpg", redColor, greenColor, blueColor);
        }

        public static void ConvertToBlackWhite(byte[,] red, byte[,] green, byte[,] blue)
        {
            // TODO: Напишите реализацию данного метода
            // Если яркость конкретного пикселя меньше чем средняя яркость его цвет должен быть 0, 0, 0
            // Иначе 255, 255, 255
            double mainBrightness = GetAverageBrightness(red, green, blue);
            for (var x = 0; x < red.GetLength(0); x++)
            {
                for (var y = 0; y < red.GetLength(1); y++)
                {
                    if (GetBrightnessPixel(red[x, y], green[x, y], blue[x, y]) < mainBrightness)
                    {
                        red[x, y] = 0;
                        green[x, y] = 0;
                        blue[x, y] = 0;
                    }
                    else
                    {
                        red[x, y] = 255;
                        green[x, y] = 255;
                        blue[x, y] = 255;
                    }
                }
            }
        }

        public static double GetAverageBrightness(byte[,] red, byte[,] green, byte[,] blue)
        {
            double brightness = 0;
            // TODO: Напишите вашу реализацию этого метода
            
            for (var x = 0; x < red.GetLength(0); x++)
            {
                for (var y = 0; y < red.GetLength(1); y++)
                {
                    brightness += GetBrightnessPixel(red[x, y], green[x, y], blue[x, y]);
                }
            }

            brightness = brightness / (red.GetLength(0) * red.GetLength(1));

            return brightness;
        }

        public static double GetBrightnessPixel(byte red, byte green, byte blue)
        {
            // Формула вычисления яркости = (0.299*R + 0.587*G + 0.114*B) / 255
            // TODO: Напишите вашу реализацию этого метода
            double brightnessPixel = (0.299 * red + 0.587 * green + 0.114 * blue) / 255;
            return brightnessPixel;
        }
    }
}