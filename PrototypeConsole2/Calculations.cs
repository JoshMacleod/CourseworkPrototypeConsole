using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrototypeConsole2
{
    class Calculations
    {
        private double initialHeight;

        public double InitialHeight
        {
            get { return initialHeight; }
            set { initialHeight = value; }
        }

        private double initialVelocity;

        public double InitialVelocity
        {
            get { return initialVelocity; }
            set { initialVelocity = value; }
        }

        private double initialAngle;

        public double InitialAngle
        {
            get { return initialAngle; }
            set { initialAngle = value; }
        }

        public void InputInitialValues()
        {
            Console.WriteLine("Initial height: ");
            InitialHeight = double.Parse(Console.ReadLine());

            Console.WriteLine("Initial velocity: ");
            InitialVelocity = double.Parse(Console.ReadLine());

            Console.WriteLine("Initial angle: ");
            InitialAngle = double.Parse(Console.ReadLine());

            double verticalVelocity = VerticalVelocity(InitialVelocity, InitialAngle);
            Console.WriteLine(verticalVelocity);

            double horizontalVelocity = HorizontalVelocity(InitialVelocity, InitialAngle);
            Console.WriteLine(horizontalVelocity);

            double timeToPeak = TimeToPeak(verticalVelocity);
            Console.WriteLine(timeToPeak);

            double distanceToPeak = DistanceToPeak(verticalVelocity, timeToPeak);
            Console.WriteLine(distanceToPeak);

            for (double i = 0; i <= timeToPeak; i += 0.01)
            {
                double x = GetXCoordinate(horizontalVelocity, i);
                double y = GetYCoordinate(verticalVelocity, i);
                Console.WriteLine(x);
                Console.WriteLine(y);
                saveToFileX(x);
                saveToFileY(y);
            }
            Console.ReadLine();
        }

        public double VerticalVelocity(double initialVelocity, double initialAngle)
        {
            initialAngle = initialAngle * (Math.PI / 180);
            double verticalVelocity = initialVelocity * System.Math.Sin((Double)initialAngle);
            verticalVelocity = System.Math.Round(verticalVelocity, 2);
            return verticalVelocity;
        }

        public double HorizontalVelocity(double initialVelocity, double initialAngle)
        {
            initialAngle = initialAngle * (Math.PI / 180);
            double horizontalVelocity = initialVelocity * System.Math.Cos((Double)initialAngle);
            horizontalVelocity = System.Math.Round(horizontalVelocity, 2);
            return horizontalVelocity;
        }

        public double TimeToPeak(double verticalVelocity)
        {
            double timeToPeak = verticalVelocity / 9.81; // t = u / g
            timeToPeak = System.Math.Round(timeToPeak, 2);
            return timeToPeak;
        }

        public double DistanceToPeak(double verticalVelocity, double timeToPeak)
        {
            double distanceToPeak = (verticalVelocity * timeToPeak) - (0.5 * 9.81 * System.Math.Pow(timeToPeak, 2)); // s = ut + 0.5at^2
            distanceToPeak = System.Math.Round(distanceToPeak, 2);
            return distanceToPeak;
        }

        public double GetXCoordinate(double horizontalVelocity, double time)
        {
            double xCoordinate = horizontalVelocity * time;
            return xCoordinate;
        }

        public double GetYCoordinate(double verticalVelocity, double time)
        {
            double yCoordinate = (verticalVelocity * time) - (0.5 * 9.81 * System.Math.Pow(time, 2));
            return yCoordinate;
        }

        public void saveToFileX(double x)
        {
            StreamWriter file = new StreamWriter("H:\\Computing Coursework\\Code\\PrototypeConsole2\\testX.txt", true);
            file.WriteLine(x);
            file.Close();
        }

        public void saveToFileY(double y)
        {
            StreamWriter file = new StreamWriter("H:\\Computing Coursework\\Code\\PrototypeConsole2\\testY.txt", true);
            file.WriteLine(y);
            file.Close();
        }
    }
}
