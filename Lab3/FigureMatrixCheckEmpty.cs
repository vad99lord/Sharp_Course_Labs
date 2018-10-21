using System;

namespace Lab3
{
    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<GeometricFigure>
    {
        /// <summary>
        /// В качестве пустого элемента возвращается null
        /// </summary>
        public GeometricFigure getEmptyElement()
        {
            return null;
        }

        /// <summary>
        /// Проверка что переданный параметр равен null
        /// </summary>
        public bool checkEmptyElement(GeometricFigure element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}
