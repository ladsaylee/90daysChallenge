using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        private static object unsigned;

        // recursion ---- print -> function call 
        static void f(int i, int n) // print n to 1 recusion
        {
            if(i == n)
                return;
            Console.WriteLine(n-i);
            f(i + 1, n);
        }
        //backtracking -- call function + print 
        static void f1(int i, int n) // print 1 to n backtracking
        {
            if (i < 1)
                return;
            
            f1(i - 1, n);
            Console.WriteLine(i);
        }

        //backtracking -- call function + print 
        static void f2(int i, int n) // print n to 1 backtracking
        {
            if (i > 3)
                return;

            f2(i + 1, n);
            Console.WriteLine(i);
        }

        //sum of n numbers - paramter way

        static void sump(int i, int sum)
        {
            if(i<1)
            {
                Console.WriteLine(sum);
                return;
            }
            sump(i - 1, sum + i);
        }

        // sum of n number - return by function
        // sum of n number -- n +f(n-1)
        static int sumf(int n)
        {
            if (n == 0)
            {              
                return 0;
            }
            return n + sumf(n-1);
        }

        //fact of n -- return by function

        static int fact(int n)
        {
            if (n == 1)
                return 1;
            return n * fact(n - 1);
        }

        //reverse array using recusion -- prameterised
        static void reverse(int []n, int i)
        {
            if (i<0)
                return;
            Console.WriteLine(n[i]);
            reverse(n, i-1);
        }

        static void swap( int []n,int a, int b)
        {
            int temp = n[a];
            n[a] = n[b];
            n[b] = temp;
        }

        //reverse array using recusion -- function
        static void reverse_fun(int[] n,int start, int end)
        {
            if (start > end)
                return ;
            swap(n, start, end);
            reverse_fun(n, start+1, end-1);
        }

        //reverse array using recusion -- function -- use single variable
        static void reverse_f(int[] n, int start)
        {
            if (start > n.Length - start - 1)
                return;
            swap(n, start, n.Length-start -1);
            reverse_f(n, start + 1);
        }


        //check if string is parlindrom
        static int pall_f(string a,int start)
        {
            if (a[start] != a[a.Length - start - 1])
                return 0;
            if (start > a.Length - start - 1)
                return 1;
            return pall_f(a,start + 1);
        }

        static int recusrion(int n)
        {
            if (n <= 1)
                return n;
            else
                return recusrion(n - 2) + recusrion(n - 1);
        }

        static void Printsubsequence(int i, int n, List<int>arr, List<int> empty)
        {
            if(i >=n)
            {
                PrintArr(empty);
                return;
            }
            empty.Add(arr[i]);
            Printsubsequence(i+1,n,arr,empty);
            empty.Remove(arr[i]);
            Printsubsequence(i + 1, n, arr, empty);
        }

        private static void PrintArr(List<int> empty)
        {
            for(int i = 0; i < empty.Count; i++)
            {
                Console.Write(empty[i]);               
            }
            Console.WriteLine();
        }

        static bool Printsubsequence1(int i,List <int>arr,List<int>empty, int k,int sum)
        {
            if (i >= arr.Count)
            {
                //int sum = findsum(empty);
                if(sum == k)
                {
                    PrintArr(empty);
                    return true;
                }
                return false;   
            }
            empty.Add(arr[i]);
            sum = sum + arr[i];
            if (Printsubsequence1(i + 1, arr, empty, k, sum) == true)
                return true;
            sum = sum - arr[i];
            empty.Remove(arr[i]);
            if (Printsubsequence1(i + 1, arr, empty, k, sum) == true)
                return true;

            return false;
        }


        static int PrintsubsequenceCount(int i, List<int> arr, List<int> empty, int k, int sum)
        {
            if (i >= arr.Count)
            {
                if (sum == k)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            empty.Add(arr[i]);
            sum = sum + arr[i];
            int l = PrintsubsequenceCount(i + 1, arr, empty, k, sum);
            sum = sum - arr[i];
            empty.Remove(arr[i]);
            int r = PrintsubsequenceCount(i + 1, arr, empty, k, sum);
            return l + r;
        }

        private static int findsum(List<int> empty)
        {
            int sum = 0;
            for (int i = 0; i < empty.Count; i++)
            {
                sum = sum + empty[i];
            }
            return sum;
        }

        static void merge(int []arr, int low, int mid, int high)
            {                     //le       ri
                                  //l     m        h
                                  //0  1  2  3  4  5  
          //int[] arr = new int[] { 1, 8, 1, 4, 7, 9 };
            int left = low;
            int right = mid+1;
           // int temp_index = 0;
            List<int> temp = new List<int>();
            while(left<=mid && right <=high )
            {
                if(arr[left]<=arr[right])
                {
                    temp.Add(arr[left]);
                    //temp[temp_index] = arr[left];
                    //temp_index++;
                    left++;
                }
                else
                {
                    temp.Add(arr[right]);
                    //temp[temp_index] = arr[right];
                    //temp_index++;
                    right++;
                }


            }
            while(left <= mid)
            {
                temp.Add(arr[left]);
                //temp[temp_index] = arr[left];
                //temp_index++;
                left++;
            }
            while(right <= high)
            {
                temp.Add(arr[right]);
                //temp[temp_index] = arr[right];
                //temp_index++;
                right++;
            }
            int j = 0;
            for(int i= low; i<=high; i++)
            {
                arr[i] = temp[j];
                j++;
            }
        }

        static void mergesort(int []arr, int low, int high)
        {
            if (low >= high)
                return;
            int mid = (low + high) / 2;
            mergesort(arr, low, mid);
            mergesort(arr, mid+1, high);
            merge(arr, low, mid, high);
        }

        static void quicksort(int []arr,int low, int high)
        {
            if (low >= high)
                return;
            int partition_ele = sort(arr,low,high);
            quicksort(arr, low, partition_ele - 1);
            quicksort(arr, partition_ele + 1, high);

        }

        private static int sort(int[] arr, int low, int high)
        {
            int pivot = arr[low];
            int i = low;
            int j = high;
            while(i<j)
            {
                while (i <= high && pivot >= arr[i])
                {
                    i++;
                }
                while (j >= low && pivot < arr[j])
                {
                    j--;
                }
                if(i<j)
                 swap1(arr,i, j);
            }
            swap1(arr, low, j);
            return j;
            
        }

        private static void swap1(int []a,int v1, int v2)
        {
            int temp = a[v1];
            a[v1] = a[v2];
            a[v2] = temp;
        }
        // finding combiation of the numbers from array which equals to sum

        /* private static void FindCombinationOfSum(int index, int sum, List<int>arr,List<int> indArr, List<List<int>> found)
         {
             if(index >= arr.Count || sum == 0 )
             {
                 if (sum == 0)
                     found.Add(indArr);
                 return;
             }



             if(sum- arr[index] >= 0)
             {
                 indArr.Add(arr[index]);
                 sum = sum - arr[index];
                 FindCombinationOfSum(index, sum, arr, indArr, found);
             }
             else
             {
                 FindCombinationOfSum(index + 1, sum, arr, indArr, found);
             }


             indArr.Remove(indArr.Count-1);

             if (sum - arr[index] >= 0)
             {
                 indArr.Add(arr[index]);
                 sum = sum - arr[index];
                 FindCombinationOfSum(index, sum, arr, indArr, found);
             }
             else
             {
                 FindCombinationOfSum(index + 1, sum, arr, indArr, found);
             }

         }*/
        static void PrintPattern(int row, int column)
        {
            for (int i =0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write("* \t");
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintPattern1(int row)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write("* \t");
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintPattern2(int row)
        {
            for (int i = 1; i < row+1; i++)
            {
                for (int j = 1; j < i + 1; j++)
                {
                    Console.Write(i);
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintPattern3(int row)
        {
            for (int i = 0; i <row; i++)
            {
                for (int j = row; j >i; j--)
                {
                    Console.Write("* \t");
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintPattern4(int row)
        {
            for (int i = 1; i <= row+1; i++)
            {
                for (int j = 1; j <=row-i+1; j++)
                {
                    Console.Write(j);
                    Console.Write("\t");
                }
                Console.WriteLine("\n");
            }
        }

        static void PrintPattern5(int row)
        {
            for (int i = 0; i < row; i++)
            {
                for(int j =0; j<i;j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2 * (row - i) - 1; j++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j <i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
            
        }

        static void PrintPattern6(int row)
        {
            for (int i = 0; i < row; i++)
            {
                
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                
                Console.Write("\n");

            }
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < row-i-1; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n");

            }

        }

        static void PrintPattern7(int row)
        {
            int x = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(x);
                    Console.Write("\t");
                    x = ~x;
                }
                Console.WriteLine("\n");
            }
            

        }

        static void patternprint8(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write(j);
                for (int j = 1 + i; j <= n * 2 - i; j++)
                    Console.Write("0");
                for (int j = i; j >= 1; j--)
                    Console.Write(j);

                Console.WriteLine("\n");

            }
            
        }

        static void patternprint9(int n)
        {
            int x = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(x+" ");
                    x++;
                }
                   

                Console.WriteLine("\n");

            }

        }

        static void patternprint10(int n)
        {
            
            for (int i = 1; i <= n; i++)
            {
                char x = 'A';
                for (int j = 0; j <= n-i; j++)
                {
                    Console.Write(x + " ");
                    x++;
                }


                Console.WriteLine("\n");

            }

        }

        static void patternprint11(int n)
        {


            for (int i = 1; i <= n; i++)
            {
                for(char ch ='A'; ch<='A'+(n-i-1);ch++)
                {
                    Console.Write(ch + " ");
                   // x++;
                }


                Console.WriteLine("\n");

            }

        }


        static void patternprint12(int n)
        {
            char x = 'A';
            for (int i = 1; i <= n; i++)
            {
              
                for (int j = 0; j <= n - i; j++)
                {
                    Console.Write(x + " ");
                   
                }

                x++;
                Console.WriteLine("\n");

            }

        }

        static void patternprint13(int n)
        {
           
            for (int i = 0; i < n; i++)
            {
                char x = 'A';
                for (int j = 1; j <= n-i-1; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(x);
                    x++;
                }
                x--;
                for (int j = i; j >0; j--)
                {
                    x--;
                    Console.Write(x);
                }

                for (int j = 1; j <= n - i - 1; j++)
                {
                    Console.Write(" ");
                }

                Console.WriteLine("\n");

            }

        }

        static void patternprint14(int n)
        {
           
            for (int i = 0; i < n; i++)
            {
                char x = 'E';
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(x-j + " ");
                }
              
                Console.WriteLine("\n");
            }

        }

        static void patternprint15(int n)
        {

            for (int i = 0; i < n; i++)
            {
                 for (int j = i; j <n; j++)
                 {
                     Console.Write("*");
                 }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("0");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("0");
                }
                for (int j = i; j < n; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine("\n");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int j = i; j < n-1; j++)
                {
                    Console.Write("0");
                }
                for (int j = i; j < n - 1; j++)
                {
                    Console.Write("0");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine("\n");
            }

        }

        static void patternprint16(int n)
        {

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                for (int j = i; j < n-1; j++)
                {
                    Console.Write("0");
                }
                for (int j = i; j < n-1; j++)
                {
                    Console.Write("0");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine("\n");
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("0");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("0");
                }
                for (int j = i; j < n; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine("\n");
            }

        }

        static void patternprint17(int n)
        {
            for(int i=0; i<n; i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
            for (int i = 2; i < n; i++)
            {
                for (int j = 0; j < 1; j++)
                    Console.Write("*");
                for (int j = 0; j < n-2; j++)
                    Console.Write("0");
                for (int j = 0; j < 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
           
            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }

        static void patternprint18(int n)
        {
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n;j++ )
                {
                    if(i==0||i==n-1||j==0||j==n-1)
                    {
                        Console.Write("*");
                    }
                    else
                        Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
        static void patternprint19(int n)
        {
            for(int i=0; i<2*n-1; i++)
            {
                for (int j = 0; j < 2*n-1; j++)
                {
                    int top = i;
                    int left = j;
                    int right = (2 * n - 2) - j;
                    int down = (2 * n - 2) - i;

                    Console.Write(n-Math.Min(Math.Min(top,left), Math.Min(right, down)));
                }
                Console.Write("\n");
            }
        }

        //find GCD and HCF - The largest common no which divides both the number
        /*Method 1
         * go from 1 to min(n1,n2) and see which max number divides both n1 and n2
         */
        /*Method 2
         * go from min(n1,n2) to 1 and see which max number divides both n1 and n2
         */
        //this will have time complexity O(n1,n2)
        private static int GCD_HCF(int n1, int n2)
        {
            int gcd = 1;
            for (int i=Math.Min(n1,n2); i>=1; i--)
            {
                if(n1%i == 0 && n2%i == 0)
                {
                    gcd = i;
                    break;
                }
                    
            }
            return gcd;
        }

        //
        private static int GCD_HCF_Euclidean(int n1, int n2)
        {
            while(n1!=0 && n2!=0)
            {
                if (n1 > n2)
                    n1 = n1 - n2;
                else
                    n2 = n2 - n1;
            }
            if (n1 == 0)
                return n2;
            else
                return n1;
        }

        private static int GCD_HCF_Euclidean2(int n1, int n2)
        {
            while (n1 != 0 && n2 != 0)
            {
                if (n1 > n2)
                    n1 = n1 % n2;
                else
                    n2 = n2 % n1;
            }
            if (n1 == 0)
                return n2;
            else
                return n1;
        }

        //find prime number
        private static bool PrimeNo(int v)
        {
            List<int> a = new List<int>();
            for (int i = 1; i <= Math.Sqrt(v); i++)
            {
                if (v % i == 0)
                {
                    a.Add(v / i);
                    if (v / i != i)
                        a.Add(i);
                }

            }
            if (a.Count == 2)
                return true;
            else
                return false;
        }



        // divide n check for reminder if 0 , from 1-N.. Complixity = O(n) so we go with other info 
        private static void Divisors(int v)
        {
            for(int i =1;  i<= Math.Sqrt(v); i++)
            {
                if(v%i==0)
                {
                    Console.WriteLine(v / i);
                    if(v/i!=i)
                        Console.WriteLine(i);
                }
                
            }

        }

        private static bool ArmstrongNumber(int v)
        {
            int x = v;
            int y = 0;
            double num = 0;
            while(x!=0)
            {
                y = x % 10;
                x = x / 10;
                num = num + Math.Pow(y, 3);
            }
            if (num == v)
                return true;
            else
                return false;

        }

        private static bool CheckPalindrom(int v)
        {

            int x = v;
            int y = v;
            int num = 0;
            while (x != 0)
            {
                y = x % 10;
                x = x / 10;
                num = num * 10 + y;
                Console.WriteLine(y);
            }
            if (num == v)
                return true;
            else
                return false;
        }

        private static int Reversenumber(int v)
        {
            int x = v;
            int y = v;
            int num = 0;
            while (x != 0)
            {
                y = x % 10;
                x = x / 10;
                num = num*10 + y;
                Console.WriteLine(y);
            }
            return num;
        }

        //print number in reverse order - time complexity = log10(n)
        private static int ReverseOrder(int v)
        {
            int x = v;
            int y = v;
            int count = 0;
            while(x!=0)
            {
                y = x % 10;
                x = x / 10;
                count++;
                Console.WriteLine(y);
            }
            return count;
        }

        //print name n times using recursion

        static void printname(string name, int times)
        {
            if (times == 0)
                return;
            Console.WriteLine(name);
            printname(name, times - 1);
        }

        static void print1_N(int times)
        {
            //int i = 1;
            if (times == 0)
                return;
            print1_N(times - 1);
            Console.WriteLine(times);
            
        }

        static void printN_1(int times)
        {
            //int i = 1;
            if (times == 0)
                return;
            Console.WriteLine(times);
            printN_1(times - 1);
            

        }

        static int Sum_N(int N)
        {
            int sum = 0;

            if (N == 1)
                return 1;
            return (N + Sum_N(N - 1));
        }

        static int Fact_N(int N)
        {
            //int sum = 0;

            if (N == 1)
                return 1;
            return (N * Fact_N(N - 1));
        }

        static void reverse_array(int []arr, int s, int e)
        {
            if (s > e)
                return;
            swap(arr, s, e);
            reverse_array(arr, s + 1, e - 1);
        }

        static int string_pal(string name, int s)
        {
            if (s > name.Length - s - 1)
                return 1;
            if (name[s] != name[name.Length - s - 1])
                return 0;


            return string_pal(name, s + 1);
        }

        static int FibNumber(int N)
        {
            if (N <=1)
                return N;
            return FibNumber(N - 1) + FibNumber(N - 2);
        }

        //hashing




        static void Main(string[] args)
        {

            int x = FibNumber(3);
            Console.WriteLine(x);

        }


    }



}
