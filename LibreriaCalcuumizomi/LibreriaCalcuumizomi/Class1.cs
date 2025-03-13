using System;

namespace libreriacalcuumizomi
{
    public static class Operaciones
    {
        /// <summary>
        /// Suma dos números.
        /// </summary>
        /// <param name="num1">Primer número.</param>
        /// <param name="num2">Segundo número.</param>
        /// <returns>Resultado de la suma.</returns>
        public static double sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Resta dos números.
        /// </summary>
        /// <param name="num1">Primer número.</param>
        /// <param name="num2">Segundo número.</param>
        /// <returns>Resultado de la resta.</returns>
        public static double restar(double num1, double num2)
        {
            return num1 - num2;
        }

        /// <summary>
        /// Multiplica dos números.
        /// </summary>
        /// <param name="num1">Primer número.</param>
        /// <param name="num2">Segundo número.</param>
        /// <returns>Resultado de la multiplicación.</returns>
        public static double multiplicar(double num1, double num2)
        {
            return num1 * num2;
        }

        /// <summary>
        /// Divide dos números.
        /// </summary>
        /// <param name="num1">Dividendo.</param>
        /// <param name="num2">Divisor.</param>
        /// <returns>Resultado de la división.</returns>
        public static double division(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("No se puede dividir por cero.");
            }
            return num1 / num2;
        }

        /// <summary>
        /// Calcula la raíz cuadrada de un número.
        /// </summary>
        /// <param name="num">Número del que se calcula la raíz cuadrada.</param>
        /// <returns>Resultado de la raíz cuadrada.</returns>
        public static double raizCuadrada(double num)
        {
            if (num < 0)
            {
                throw new ArgumentException("No se puede calcular la raíz cuadrada de un número negativo.");
            }
            return Math.Sqrt(num);
        }

        /// <summary>
        /// Calcula la potencia de un número.
        /// </summary>
        /// <param name="baseNum">Base.</param>
        /// <param name="exponente">Exponente.</param>
        /// <returns>Resultado de la potencia.</returns>
        public static double potencia(double baseNum, double exponente)
        {
            return Math.Pow(baseNum, exponente);
        }

        /// <summary>
        /// Calcula el porcentaje de un número sobre otro.
        /// </summary>
        /// <param name="num1">Número del que se calcula el porcentaje.</param>
        /// <param name="num2">Número total.</param>
        /// <returns>Porcentaje.</returns>
        public static double porcentaje(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("No se puede calcular el porcentaje sobre cero.");
            }
            return (num1 / num2) * 100;
        }

        /// <summary>
        /// Simula una fracción (en este caso, simplemente devuelve el número como fracción de sí mismo).
        /// </summary>
        /// <param name="num">Número.</param>
        /// <returns>Representación como fracción (en este caso, siempre 1).</returns>
        public static string fraccion(double num)
        {
            int sign = Math.Sign(num);
            num = Math.Abs(num);

            int maxDenominator = 1000; // Máximo denominador permitido

            int bestNumerator = 0;
            int bestDenominator = 1;
            double bestError = double.MaxValue;

            for (int denominator = 1; denominator <= maxDenominator; denominator++)
            {
                int numerator = (int)Math.Round(num * denominator);

                double error = Math.Abs(numerator / (double)denominator - num);

                if (error < bestError && error < 0.00001) // Ajusta la precisión según sea necesario
                {
                    bestNumerator = numerator;
                    bestDenominator = denominator;
                    bestError = error;
                }
            }

            // Simplificar la fracción si es posible
            int gcd = GCD(bestNumerator, bestDenominator);
            bestNumerator /= gcd;
            bestDenominator /= gcd;

            // Ajustar el signo
            if (sign == -1)
            {
                bestNumerator = -bestNumerator;
            }

            // Devolver la fracción como cadena
            if (bestDenominator == 1)
            {
                return bestNumerator.ToString();
            }
            else
            {
                return $"{bestNumerator}/{bestDenominator}";
            }
        }

        // Función auxiliar para calcular el máximo común divisor (GCD)
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

    }
}