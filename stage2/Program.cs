using System;

namespace stage2
{
    class Program
    {
        static void Main(string[] args)
        {
            ReferenceFigure samplereferencefigure = new ReferenceFigure()
                {NumberOfFaces = 4, FaceLength = 4.0, Area = 0};
            ReferenceFigure definitereferencefigure = CalcNewArea(samplereferencefigure);
            CalcOldArea(samplereferencefigure);
            Console.WriteLine($"ReferenceArea = {samplereferencefigure.Area}");
            Console.WriteLine($"ReferenceAreaCalc = {definitereferencefigure.Area}");

            ValueFigure samplevaluefigure = new ValueFigure() {NumberOfFaces = 4, FaceLength = 4.0, Area = 0};
            ValueFigure definitevaluefigure = CalcNewStructArea(samplevaluefigure);
            CalcOldStructArea(samplevaluefigure);
            Console.WriteLine($"ValueArea = {samplevaluefigure.Area}");
            Console.WriteLine($"ValueAreaCalc = {definitevaluefigure.Area}");
        }

        public static ReferenceFigure CalcNewArea(ReferenceFigure figure)
        {
            ReferenceFigure calculatedfigure = new ReferenceFigure()
            {
                NumberOfFaces = figure.NumberOfFaces, FaceLength = figure.FaceLength,
                Area = Calculator(figure.NumberOfFaces, figure.FaceLength)
            };

            return calculatedfigure;
        }

        public static void CalcOldArea(ReferenceFigure figure)
        {
            figure.Area = Calculator(figure.NumberOfFaces, figure.FaceLength);
        }

        public static ValueFigure CalcNewStructArea(ValueFigure figure)
        {
            ValueFigure calculatedfigure = new ValueFigure()
            {
                NumberOfFaces = figure.NumberOfFaces, FaceLength = figure.FaceLength,
                Area = Calculator(figure.NumberOfFaces, figure.FaceLength)
            };

            return calculatedfigure;
        }

        public static void CalcOldStructArea(ValueFigure figure)
        {
            figure.Area = Calculator(figure.NumberOfFaces, figure.FaceLength);
        }

        public static double Calculator(int numberoffaces, double facelength)
        {
            double result = Math.Round((numberoffaces * Math.Pow(facelength, 2)) /
                                       (4 * Math.Round(Math.Tan(Math.PI / numberoffaces), 4)), 4);
            return result;
        }
    }
}