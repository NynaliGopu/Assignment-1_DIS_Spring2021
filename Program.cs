// Assignment-1_Spring 2021
// ISM-6225 (Distributed Information Systems)
// Nynali Gopu
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
            Console.WriteLine("Q1 : Enter the number of rows for the triangle:");
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
          ///Print a pattern with n rows given n as input
          ///n – number of rows for the pattern, integer (int)
	      ///This method prints a triangle pattern.

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
        ///In mathematics, the Pell numbers are an infinite sequence of integers.
        ///The sequence of Pell numbers starts with 0 and 1, and then each Pell number is the sum of twice of the previous Pell number and 
        ///the Pell number before that.:thus, 70 is the companion to 29, and 70 = 2 × 29 + 12 = 58 + 12. The first few terms of the sequence are :
        ///0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860,… 
        ///Write a method that prints first n numbers of the Pell series

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
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: A = 3 will return the output : false
        ///Input: A = 4 will return the output: true
        ///Input: A = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.

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
        /// Given an array of integers and an integer n, you need to find the number of unique
        /// n-diff pairs in the array.Here a n-diff pair is defined as an integer pair (i, j),
        ///where i and j are both numbers in the array and their absolute difference is n.
        ///Example 1:
        ///Input: [3, 1, 4, 1, 5], k = 2
        ///Output: 2
        ///Explanation: There are two 2-diff pairs in the array, (1, 3) and(3, 5).
        ///Although we have two 1s in the input, we should only return the number of unique   
        ///pairs.
        ///Example 2:
        ///Input:[1, 2, 3, 4, 5], k = 1
        ///Output: 4
        ///Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and
        ///(4, 5).
        ///Example 3:
        ///Input: [1, 3, 1, 5, 4], k = 0
        ///Output: 1
        ///Explanation: There is one 0-diff pair in the array, (1, 1).
        ///Note : The pairs(i, j) and(j, i) count as same.

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
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails

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
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".

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
