namespace Hydac
{
    /// <summary>
    /// <br>This was not originally made by me, but rather this very talented <see href="https://github.com/servetgulnaroglu">fella from GitHub</see>.</br>
    /// <br>The source code that provides the basis for this class can be found at <see href="https://github.com/servetgulnaroglu/cube.c/blob/master/cube.c">this github link right here</see>.</br>
    /// <para>
    /// <br>The source code is written in C, so all I've done is convert it from C to C#.</br> 
    /// <br>Thats not to say that it was easy though, as I have never coded a single line of C code, so I had to do some guessing, but eventually it all fell into place.</br> 
    /// <br>And to top it off, I did this at 3 AM, for no reason at all...</br>
    /// </para>
    /// <para>Kasper Nissen, KasperNissen1997@gmail.com</para>
    /// </summary>
    [System.Runtime.Versioning.SupportedOSPlatform("windows")] // this only works on the windows platform
    internal class SpinningCube
    {
        static double A = 0, B = 0, C = 0;
        static double aSpeed = .1, bSpeed = .1, cSpeed = .025; // this controls the speed the cube rotates at
        static int sleepTimer = 10; // how long the program will wait before it clears the console, and rotates the cube

        static double cubeSize = 17; // the size of the cube

        static int width = 117; // the width of the area shown
        static int height = 27; // the height of the area shown
        static double[] zBuffer = new double[width * height];
        static char[] buffer = new char[width * height];

        static int background = ' '; // the char shown in the background
        static int camDistance = 100; // the distance the cube is from the "camera" viewing it

        static double K1 = 40; // unsure what this does, but changing it scales the cube
        static double incrementSpeed = .6; // this determines the space between each char in the cube - a higher value will show a more incomplete cube, but will be calculated faster

        static int spinTimeInSeconds = 10; // this determines the amount of time the cube is shown
        static int remainingTimePrintOffset = 14; // this specifies how far in from the left the remaining time will be printed

        internal static void ShowCube()
        {
            Console.Clear();
            Console.SetWindowSize(117, 45); // set the size of the console window to fit the area showing the cube
            Console.CursorVisible = false; // hides the cursor in the console window, preventing flickering
            
            
            PrintTeam13Hydac(); // rep the team number

            TimeOnly startTime = TimeOnly.FromDateTime(DateTime.Now);
            TimeOnly endTime = startTime.Add(new TimeSpan(0, 0, spinTimeInSeconds));

            while (TimeOnly.FromDateTime(DateTime.Now) < endTime) // if the specified amount of time hasn't passed yet
            {
                // Console.Clear();
                Console.SetCursorPosition(0,10);

                Array.Fill(buffer, (char) background);
                Array.Fill(zBuffer, 0);

                // create the cube
                for (double cubeX = -cubeSize; cubeX < cubeSize; cubeX += incrementSpeed)
                {
                    for (double cubeY = -cubeSize; cubeY < cubeSize;
                        cubeY += incrementSpeed)
                    {
                        calculateForSurface(cubeX, cubeY, -cubeSize, '@'); // set all '@' into the buffer array at the side of the cube, if showing
                        calculateForSurface(cubeSize, cubeY, cubeX, '$'); // same as above, but wit '$'
                        calculateForSurface(-cubeSize, cubeY, -cubeX, '~'); // and again
                        calculateForSurface(-cubeX, cubeY, cubeSize, '#'); // you get the gist
                        calculateForSurface(cubeX, -cubeSize, -cubeY, ';'); // ...
                        calculateForSurface(cubeX, cubeSize, cubeY, '+'); // and done!
                    }
                }

                // "write" out the cube
                for (int k = 0; k < width * height; k++)
                {
                    string remainingTime = (endTime - TimeOnly.FromDateTime(DateTime.Now)).ToString("c");

                    if (k >= remainingTimePrintOffset && k < remainingTime.Length - 5 + remainingTimePrintOffset)
                        Console.Write(remainingTime[k - remainingTimePrintOffset]);
                    else
                        Console.Write((k % width != 0) ? buffer[k] : (char) 10); // (char) 10 is a new line feed
                }

                A += aSpeed;
                B += bSpeed;
                C += cSpeed;

                Thread.Sleep(sleepTimer);
            }
        }

        // https://en.wikipedia.org/wiki/Rotation_matrix#In_three_dimensions
        // Visit the above site to read up on the math behind the rotations - the formulas aren't copied, as they had to be restructured to suit the case.
        // More information can probably be found in the book about Linear Algebra and Its Applications.
        #region Calculate methods
        static double CalculateX(double i, double j, double k)
        {
            return j * Math.Sin(A) * Math.Sin(B) * Math.Cos(C) - 
                k * Math.Cos(A) * Math.Sin(B) * Math.Cos(C) +
                j * Math.Cos(A) * Math.Sin(C) + 
                k * Math.Sin(A) * Math.Sin(C) + 
                i * Math.Cos(B) * Math.Cos(C);
        }

        static double CalculateY(double i, double j, double k)
        {
            return j * Math.Cos(A) * Math.Cos(C) + 
                k * Math.Sin(A) * Math.Cos(C) -
                j * Math.Sin(A) * Math.Sin(B) * Math.Sin(C) + 
                k * Math.Cos(A) * Math.Sin(B) * Math.Sin(C) -
                i * Math.Cos(B) * Math.Sin(C);
        }

        static double CalculateZ(double i, double j, double k)
        {
            return k * Math.Cos(A) * Math.Cos(B) - 
                j * Math.Sin(A) * Math.Cos(B) + 
                i * Math.Sin(B);
        }

        static void calculateForSurface(double cubeX, double cubeY, double cubeZ, char ch)
        {
            double x = CalculateX(cubeX, cubeY, cubeZ);
            double y = CalculateY(cubeX, cubeY, cubeZ);
            double z = CalculateZ(cubeX, cubeY, cubeZ) + camDistance;

            double ooz = 1 / z;

            int xp = (int) (width / 2 + K1 * ooz * x * 2);
            int yp = (int) (height / 2 + K1 * ooz * y);

            int idx = xp + yp * width;
            if (idx >= 0 && idx < width * height)
            {
                if (ooz > zBuffer[idx])
                {
                    zBuffer[idx] = ooz;
                    buffer[idx] = ch;
                }
            }
        }
        #endregion

        static void PrintTeam13Hydac ()
        {
            Console.Write(
                "\n\n" +
                "       ████████╗███████╗░█████╗░███╗░░░███╗  ░░███╗░░██████╗░  ░░░░░░  ██╗░░██╗██╗░░░██╗██████╗░░█████╗░░█████╗░\n" +
                "       ╚══██╔══╝██╔════╝██╔══██╗████╗░████║  ░████║░░╚════██╗  ░░░░░░  ██║░░██║╚██╗░██╔╝██╔══██╗██╔══██╗██╔══██╗\n" +
                "       ░░░██║░░░█████╗░░███████║██╔████╔██║  ██╔██║░░░█████╔╝  █████╗  ███████║░╚████╔╝░██║░░██║███████║██║░░╚═╝\n" +
                "       ░░░██║░░░██╔══╝░░██╔══██║██║╚██╔╝██║  ╚═╝██║░░░╚═══██╗  ╚════╝  ██╔══██║░░╚██╔╝░░██║░░██║██╔══██║██║░░██╗\n" +
                "       ░░░██║░░░███████╗██║░░██║██║░╚═╝░██║  ███████╗██████╔╝  ░░░░░░  ██║░░██║░░░██║░░░██████╔╝██║░░██║╚█████╔╝\n" +
                "       ░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚═╝  ╚══════╝╚═════╝░  ░░░░░░  ╚═╝░░╚═╝░░░╚═╝░░░╚═════╝░╚═╝░░╚═╝░╚════╝░\n" +
                "\n\n");
        }
    }
}