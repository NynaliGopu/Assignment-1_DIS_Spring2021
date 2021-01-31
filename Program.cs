using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment1_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Question 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" }, { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);
        }
        //methods for question 1
        private static void printTriangle(int n)
        {
            try
            {   //function to print pattern
                pattern(n, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //function to print pattern
        private static void pattern(int n, int i)
        {
            // base case
            if (n == 0)
                return;
            //print spaces before *
            Console.Write(new string(' ', n));

            //function to print * in a row
            printn(i);

            //print spaces after  *
            Console.Write(new string(' ', n));

            Console.WriteLine();
            // recursively calling pattern()  
            pattern(n - 1, i + 2);
        }
        // function to print * in a row
        private static void printn(int num)
        {
            // base case  
            if (num == 0)
                return;
            Console.Write("*");
            // recursively calling printn()  
            printn(num - 1);
        }


        //methods for question 2
        private static void printPellSeries(int n2)
        {
            try
            {
                //if input entered is less than 1
                if (n2 < 1)
                {
                    Console.WriteLine("Invalid entry!");
                    return;
                }
                var tempFirstNum = 0;
                var tempSecondNum = 1;
                var sum = 0;
                //0 is the first number in the series
                if (n2 == 1 || n2 > 1)
                {
                    Console.Write("0 ");
                }
                //1 is the second number in the series
                if (n2 == 2 || n2 > 2)
                {
                    Console.Write("1 ");
                }
                //below logic calculates the next numbers after 0 and 1
                if (n2 > 2)
                {
                    for (var i = 0; i < n2 - 2; i++)
                    {
                        sum = 2 * (tempSecondNum) + tempFirstNum;
                        Console.Write(sum + " ");

                        //set first and second num to latest values
                        tempFirstNum = tempSecondNum;
                        tempSecondNum = sum;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //methods for question 3
        private static bool squareSums(int n3)
        {
            try
            {
                // i and j will increment by 1 from 0 to the given input number to see all possible squaresums
                for (long i = 0; i * i <= n3; i++)
                {
                    for (long j = 0; j * j <= n3; j++)
                    {
                        if (i * i + j * j == n3)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //methods for question 4
        private static int diffPairs(int[] nums, int k)
        {
            try
            {   //sorting the given array in ascending order
                Array.Sort<int>(nums);
                // initializing the variables
                var count = 0;
                int leftIndex = 0;
                int rightIndex = 1;
                while (rightIndex < nums.Length && leftIndex < nums.Length)
                {
                    // if the difference of the number pair is K, then the count and indexes are incremented
                    if (nums[rightIndex] - nums[leftIndex] == k)
                    {
                        count++;
                        leftIndex++;
                        rightIndex++;
                    }
                    //if the difference is less than K only right index is incremented
                    else if (nums[rightIndex] - nums[leftIndex] < k)
                    {
                        rightIndex++;
                    }

                    else
                    {
                        leftIndex++;
                    }
                    //if the numbers at both right and left indexes are same, then right index is incremented by 1
                    if (rightIndex < nums.Length && leftIndex < nums.Length && nums[rightIndex] == nums[leftIndex])
                    {
                        leftIndex = rightIndex;
                        rightIndex++;
                    }
                }
                //returing the total count
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }

        //methods for question 5
        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                int count = 0;
                // create a new list to store output emaails
                List<string> outputEmails = new List<string>();
                //convert them to lower case
                emails.ForEach(y => y.ToLower());

                //Iterating through each email in the input email list
                foreach (var email in emails)
                {
                    string localName = email?.Substring(0, email.IndexOf('@'));
                    string domainName = email?.Substring(email.IndexOf('@') + 1, (email.Length - 1 - email.IndexOf('@')));
                    //replace . with nothing
                    localName = localName.Replace(".", "");

                    //remove multiple spaces from localname and domain  
                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex("[ ]{1,}", options);
                    localName = regex.Replace(localName, "");
                    domainName = regex.Replace(domainName, "");

                    //remove everything after +
                    int index = localName.IndexOf("+");
                    if (index > 0)
                        localName = localName.Substring(0, index);

                    //trim both strings
                    localName = localName?.Trim();
                    domainName = domainName?.Trim();

                    //check if the list already contains emails if yes do not count
                    if (!outputEmails.Contains(localName + domainName))
                    {
                        count += 1;
                        outputEmails.Add(localName + domainName);
                    }
                }
                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //methods for question 6
        private static string DestCity(string[,] paths)
        {
            try
            {
                List<string> sourcePath = new List<string>();
                List<string> destinationPath = new List<string>();
                string output = string.Empty;
                //get the list of source , destinations  
                for (int i = 0; i < paths.Length / 2; i++)
                {
                    sourcePath.Add(paths[i, 0]);
                    destinationPath.Add(paths[i, 1]);
                }
                //if the destination path is not in source then its the one which is not traversed
                foreach (var o in destinationPath)
                {
                    if (!sourcePath.Contains(o))
                        output = o;
                }
                //returning the output
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
