namespace PrimeNumberFactors
{
    public static class PrimeFactors
    {
        /// <summary>
        /// used to define if the number is prime or not  
        /// </summary>
        /// <param name="number"></param>
        /// <returns> true if the number specified is prime , false otherwise</returns>
        /// <exception cref="NegativeNumberException"> Thrown if The Number is Negative</exception>"
        /// See <see cref="GetPrimeFactors(int)" /> To get All The Prime Factors of The Number As A List Of Intgers>
        public static bool IsPrime(this int number)
        {
            if (number < 0)
            {
                throw new NegativeNumberException();
            }
            var Isprime = true;

            if (number == 1)
            {

                Isprime = true;
                return Isprime;
            }

            else
            {

                for (int j = 2; j < Math.Sqrt(number); j++)
                {
                    if (number % j == 0) { Isprime = false; }
                }

                return Isprime;
            }


        }


        /// <summary>
        /// used to get All the Prime Factors To the Number Spcecified 
        /// </summary>
        /// <param name="number"></param>
        /// <returns>returns The List That Containes All The Prime Foctors Of The Number Specified</returns>
        /// <exception cref="NegativeNumberException">Thrown if The Number is Negative </exception>
        public static List<int> GetPrimeFactors(this int number)
        {



            List<int> Facors = new List<int>();
            if (number < 0)
            {
                throw new NegativeNumberException();
            }

            else if (number.IsPrime())
            {

                Facors.Add(1);
                Facors.Add(number);

                return Facors;
            }
            else
            {
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        if (i.IsPrime())
                        {
                            Facors.Add(i);


                            var other = number / i;
                            if (!other.IsPrime())
                            {

                                Facors.AddRange(other.GetPrimeFactors());
                                break;


                            }
                            else
                            {
                                Facors.Add(other);
                                break;
                            };

                        }

                    }

                }
            }

            return Facors;
        }


        /// <summary>
        /// Retuns The Prime Factors As String Separated by <paramref name="separator"/>  
        /// </summary>
        /// <param name="ints"></param>
        /// <returns> A string That Contains All The Prime Factors Separated by <paramref name="separator"/> </returns>
        public static string PrintPrimeFactors(this IEnumerable<int> ints, char separator)
        {
            var result = "";
            foreach (var factor in ints)
            {
                result += ($" {factor} {separator}");
            }
            return result.TrimEnd(separator);

        }


    }

}