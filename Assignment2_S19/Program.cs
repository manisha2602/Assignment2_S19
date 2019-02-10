using System;
using System.Collections.Generic;
using System.Globalization;      // importing libraries for CultureInfo

namespace Assignment2_S19
{
    class Program
    {
        static void Main(string[] args)
        {
            // left rotation
            Console.WriteLine("Left Rotation");
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] r = rotLeft(a, d);
            displayArray(r);

            // Maximum toys
            Console.WriteLine("\n\nMaximum toys");
            int k = 50;
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            Console.WriteLine(maximumToys(prices, k));

            // Balanced sums
            Console.WriteLine("\n\nBalanced sums");
            List<int> arr = new List<int> { 1, 2, 3 };
            Console.WriteLine(balancedSums(arr));

            // Missing numbers
            Console.WriteLine("\n\nMissing numbers");
            int[] arr1 = { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206};
            int[] brr = {203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204};
            int[] r2 = missingNumbers(arr1, brr);
            displayArray(r2);

            // grading students
            Console.WriteLine("\n\nGrading students");
            int[] grades = { 73, 67, 38, 33 };
            int[] r3 = gradingStudents(grades);
            displayArray(r3);

            // find the median
            Console.WriteLine("\n\nFind the median");
            int[] arr2 = { 0, 1, 2, 4, 6, 5, 3};
            Console.WriteLine(findMedian(arr2));

            // closest numbers
            Console.WriteLine("\n\nClosest numbers");
            int[] arr3 = { 5, 4, 3, 2 };
            int[] r4 = closestNumbers(arr3);
            displayArray(r4);

            // Day of programmer
            Console.WriteLine("\n\nDay of Programmer");
            int year = 2017;
            Console.WriteLine(dayOfProgrammer(year));
            Console.ReadLine();
        }

        static void displayArray(int []arr) {
            Console.WriteLine();
            foreach(int n in arr) {
                Console.Write(n + " ");
            }
        }

        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            int n = 0;
            n = a.Length; //to calculate length of an array

            for (int i = 0; i < d; i++)  //outer loop to rotate array d times
            {
                int temp = a[0];     // storing the first number in temporary variable
                for (int j = 0; j < n - 1; j++) // inner array to rotate array once
                {
                    a[j] = a[j + 1];
                }
                a[n - 1] = temp;            //assigning the temp to the last index
            }
            return a;
        }

        // Complete the maximumToys function below.
        static int maximumToys(int[] prices, int k)
        {
            int[] sarr = new int[prices.Length];
            sarr = sortArray(prices);
            int sum = 0;
            int count = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                sum += prices[i];
                if (sum >= k)
                {
                    break;
                }

                count += 1;

            }
            return count;
        }

        // Complete the balancedSums function below.
        static string balancedSums(List<int> arr)
        {
            int n = arr.Count;           //taking count of the array
            int leftSum = arr[0];        //left of the array
            int rightSum = 0;           //right of the array
            for (int i = 0; i < n; i++)
            {
                rightSum += arr[i];
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (leftSum == rightSum)     //cheking if left sum is equal to right
                    return "YES";            //return YES
                leftSum += arr[i + 1];      //adding to the left array 
                rightSum -= arr[i];        // adding to the right array
            }
            return "NO";                  //return NO
        }

        // Complete the missingNumbers function below.
        static int[] missingNumbers(int[] arr, int[] brr)
        {
            int n = arr.Length;
            Boolean[] counted = new Boolean[n];  //boolean array to find if no. is counted or not
            var miss = new List<int>();  //creating list to save missing numbers

            for (int i = 0; i < brr.Length; i++)
            {
                int f = 0;   //counter to check if the no. is matched
                for (int j = 0; j < n; j++)
                {
                    if (counted[j] == true)
                        continue;     // if no. is alreadey matched than continue to next
                    if (brr[i] == arr[j])
                    {
                        counted[j] = true;
                        f++;    //if number matches than increase f by 1
                        break;
                    }
                }
                if (f == 0)
                {
                    int c = miss.Count;
                    for (int k = 0; k < c; k++)   // loop to check if the missing number is already missing list
                    {
                        if (brr[i] == miss[k])
                            f = 1;
                    }
                    if (f == 0)   //If no. is neither matched nor already added to missing list than add it 
                    {
                        miss.Add(brr[i]);
                    }
                }
            }

            int[] output = new int[miss.Count];
            output = miss.ToArray();     //converting list to an array
            sortArray(output);
            return output;
        }


        // Complete the gradingStudents function below.
        static int[] gradingStudents(int[] grades)
        {
            int n = grades.Length;
            for (int i = 0; i < n; i++)
            {
                int next_round = 0;
                next_round = grades[i] + (5 - (grades[i] % 5));  //rounding grade upto next multiple of 5
                if (grades[i] < 38)  //if grade less than 38 return same grade
                    continue;
                else if (next_round - grades[i] > 2) //if diff b/w grade and next multiple of 5 is greater than 2, return grade
                    continue;
                else
                    grades[i] = next_round;
            }
            return grades;
        }

        // Complete the findMedian function below.
       
        static int findMedian(int[] arr)
        {
            int[] sarr = new int[arr.Length];
            sarr = sortArray(arr);
            if (arr.Length % 2 == 1)
            {
                return sarr[((sarr.Length + 1) / 2) - 1];
            }
            else
            {
                return (sarr[(sarr.Length / 2) - 1] + sarr[(sarr.Length / 2)]) / 2;
            }

        }
        // Complete the closestNumbers function below.
        static int[] closestNumbers(int[] arr)
        {
            sortArray(arr);  //sorting the array with customizaed function
            int diff = arr[arr.Length - 1];     //assigning length to difference
            var res = new List<int>();        //creating a list to result
            int[] output = new int[arr.Length * 2];   //assigning twice the length to output
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] - arr[i] <= diff)
                {
                    diff = arr[i + 1] - arr[i];     //calculating the difference
                }
            }
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i + 1] - arr[i] == diff)
                {
                    res.Add(arr[i]);      //assigning first value of array
                    res.Add(arr[i + 1]);  //assigning second value of array
                }
            }
            output = res.ToArray();   //converting list to array
            return output;           //returning output
        }

        // Complete the dayOfProgrammer function below.
        static string dayOfProgrammer(int year)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            int dayOfProgrammer = 256;
            int adjustedDays = 0;
            int daysForLeapYear = 244; //29 days in Feb
            int daysForNonLeapYear = 243; //28 days in Feb
            if (year >= 1919)  //gregorian
            {
                if (isLeap(year))  //calling the customized leap year function
                {
                    adjustedDays = dayOfProgrammer - daysForLeapYear;
                }
                else
                {
                    adjustedDays = dayOfProgrammer - daysForNonLeapYear;
                }
            }
            else if (year <= 1917)  //julian
            {
                if (isLeap(year))   //calling the customized leap year function
                {
                    adjustedDays = dayOfProgrammer - daysForLeapYear;
                }
                else
                {
                    adjustedDays = dayOfProgrammer - daysForNonLeapYear;
                }
            }
            else
            {
                adjustedDays = 26;
            }

            date = adjustedDays.ToString() + ".09." + year.ToString(); //final date calculation
            return date;   //returning date
        }
        static bool isLeap(int year)
        {
            if (year % 4 != 0)   //checking if year is leay year or not
            {
                return false;
            }
            else if (year > 1918 && year % 100 == 0 && year % 400 != 0) //checking if year is leay year or not
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static int[] sortArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int temp = 0;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            return a;
        }
    }
}
