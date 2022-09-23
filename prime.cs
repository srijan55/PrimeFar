// C# program to find a prime number pair whose 
// sum is equal to given number 
// C# program to print super primes less than 
// or equal to n. 
using System;

class GFG
{
    // Generate all prime numbers less than n. 
    // https://www.geeksforgeeks.org/find-two-prime-numbers-with-given-sum/
    // does not work for 65

    // TO DO:
    // 1/2/2019: 
    // 1. If new number is lesser or equal than previous one, use existing sieve.
    // 2. If new number is higher than previous one, extend existing sieve. Do not start from scratch.
    // 3. If number is bigger than what can be handled, use the divisibility rules (for 2, 3, 5, 7)  to give info that the number is not a prime number.
    //    http://www.savory.de/maths1.htm
    //    2: number ends with digit 2
    //    3: digits add up recursively to multiple of 3
    //    5: number ends with digit 5, or 0.
    //    7:  Remove the last digit, double it, subtract it from the truncated original number and continue doing this until only one digit remains. If this is 0 or 7, then the original number is divisible by 7. For example, to test divisibility of 12264 by 7, we simply perform the following manipulations: 
    //      1226 - 8 = 1218 
    //      121 - 16 = 105 
    //      10 - 10 = 0 
    //      Thus, 12264 is divisible by 7.
    //    11: Take the alternating sum of the digits in the number, read from left to right. If that is divisible by 11, so is the original number.
    //          So, for instance, 2728 has alternating sum of digits 2-7+2-8 = -11. Since -11 is divisible by 11, so is 2728.
    //*
    //    Divisibility by prime numbers under 50.
    //© Stu Savory, 2003 & 2004.
    //A number is divisible by 2 if its last digit is also(i.e. 0,2,4,6 or 8).

    //A number is divisible by 3 if the sum of its digits is also.Example: 534: 5+3+4=12 and 1+2=3 so 534 is divisible by 3.

    //A number is divisible by 5 if the last digit is 5 or 0.

    //Most people know(only) those 3 rules.Here are my rules for divisibility by the PRIMES up to 50. Why only primes and not also composite numbers? A number is divisible by a composite if it is also divisible by all the prime factors(e.g. is divisible by 21 if divisible by 3 AND by 7). Small numbers are used in these worked examples, so you could have used a pocket calculator.But my rules apply to any number of digits, whereas you cannot test a 30 or more digit number on your pocket calculator otherwise.

    //Test for divisibility by 7. Double the last digit and subtract it from the remaining leading truncated number.If the result is divisible by 7, then so was the original number. Apply this rule over and over again as necessary.Example: 826. Twice 6 is 12. So take 12 from the truncated 82. Now 82-12=70. This is divisible by 7, so 826 is divisible by 7 also.

    //There are similar rules for the remaining primes under 50, i.e. 11,13, 17,19,23,29,31,37,41,43 and 47.


    //Test for divisibility by 11. Subtract the last digit from the remaining leading truncated number. If the result is divisible by 11, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 19151--> 1915-1 =1914 -->191-4=187 -->18-7=11, so yes, 19151 is divisible by 11.


    //Test for divisibility by 13. Add four times the last digit to the remaining leading truncated number. If the result is divisible by 13, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 50661-->5066+4=5070-->507+0=507-->50+28=78 and 78 is 6*13, so 50661 is divisible by 13.


    //Test for divisibility by 17. Subtract five times the last digit from the remaining leading truncated number. If the result is divisible by 17, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 3978-->397-5*8=357-->35-5*7=0. So 3978 is divisible by 17.


    //Test for divisibility by 19. Add two times the last digit to the remaining leading truncated number. If the result is divisible by 19, then so was the first number. Apply this rule over and over again as necessary.
    //EG: 101156-->10115+2*6=10127-->1012+2*7=1026-->102+2*6=114 and 114=6*19, so 101156 is divisible by 19.


    //My original divisibilty webpage stopped here. However, I have had a number of mails asking for divisibility tests for larger primes, so I've extended the list up to 50. Actually even with 37 most people cannot do the necessary mental arithmetic easily, because they cannot recognise even single-digit multiples of two-digit numbers on sight. People are no longer taught the multiplication table up to 20*20 as I was as a child. Nowadays we are lucky if they know it up to 10*10.


    //Test for divisibility by 23. 3*23=69, ends in a 9, so ADD. Add 7 times the last digit to the remaining leading truncated number. If the result is divisible by 23, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 17043-->1704+7*3=1725-->172+7*5=207 which is 9*23, so 17043 is also divisible by 23.


    //Test for divisibility by 29. Add three times the last digit to the remaining leading truncated number. If the result is divisible by 29, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 15689-->1568+3*9=1595-->159+3*5=174-->17+3*4=29, so 15689 is also divisible by 29.


    //Test for divisibility by 31. Subtract three times the last digit from the remaining leading truncated number. If the result is divisible by 31, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 7998-->799-3*8=775-->77-3*5=62 which is twice 31, so 7998 is also divisible by 31.


    //Test for divisibility by 37. This is (slightly) more difficult, since it perforce uses a double-digit multiplier, namely eleven. People can usually do single digit multiples of 11, so we can use the same technique still. Subtract eleven times the last digit from the remaining leading truncated number. If the result is divisible by 37, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 23384-->2338-11*4=2294-->229-11*4=185 which is five times 37, so 23384 is also divisible by 37.


    //Test for divisibility by 41. Subtract four times the last digit from the remaining leading truncated number. If the result is divisible by 41, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 30873-->3087-4*3=3075-->307-4*5=287-->28-4*7=0, remainder is zero and so 30873 is also divisible by 41.


    //Test for divisibility by 43. Now it starts to get really difficult for most people, because the multiplier to be used is 13, and most people cannot recognise even single digit multiples of 13 at sight. You may want to make a little list of 13*N first. Nevertheless, for the sake of completeness, we will use the same method. Add thirteen times the last digit to the remaining leading truncated number. If the result is divisible by 43, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 3182-->318+13*2=344-->34+13*4=86 which is recognisably twice 43, and so 3182 is also divisible by 43. 
    //Update : Bill Malloy has pointed out that, since we are working to modulo43, instead of adding factor 13 times the last digit, we can subtract 30 times it, because 13+30=43. Why didn't I think of that!!! :-(


    //Finally, the Test for divisibility by 47. This too is difficult for most people, because the multiplier to be used is 14, and most people cannot recognise even single digit multiples of 14 at sight. You may want to make a little list of 14*N first. Nevertheless, for the sake of completeness, we will use the same method. Subtract fourteen times the last digit from the remaining leading truncated number. If the result is divisible by 47, then so was the first number. Apply this rule over and over again as necessary.
    //Example: 34827-->3482-14*7=3384-->338-14*4=282-->28-14*2=0 , remainder is zero and so 34827 is divisible by 47.


    //I've stopped here at the last prime below 50, for arbitrary but pragmatic reasons as explained above.


    //Other blogreaders (sadly even people from.edu domains, who should be able to do the elementary algebra themselves) have asked why I sometimes say ADD and for other primes say SUBTRACT, and ask where the apparently arbitrary factors come from.So let us do some algebra to show the method in my madness.


    //We have displayed the recursive divisibility test of number N as f-M* r where f are the front digits of N, r is the rear digit of N and M is some multiplier. And we want to see if N is divisible by some prime P.We need a method to work out the values of M. What you do is to calculate (mentally) the smallest multiple of P which ends in a 9 or a 1. If it's a 9 we are going to ADD, Then we will use the leading digit(s) of the multiple +1 as our multiplier M. If it's a 1 we are going to SUBTRACT later. then we will use the leading digit(s) of the multiple as our multiplier M.

    //Example for P= 17 : three times 17 is 51 which is the smallest multiple of 17 that ends in a 1 or 9. Since it's a 1 we are going to SUBTRACT later. The leading digit is a 5, so we are going to SUBTRACT five times the remainder r. The algorithm was stated above. Now let's do the algebraic proof.Writing N = 10f + r, we can multiply by -5 (as shown in the example for 17), getting -5N=-50f-5r.Now we add 51f to both sides(because 51 was the smallest multiple of P = 17 to end in a 1 or a 9), giving one f(which we want), so 51f-5N=f-5r.Now if N is divisible by P(here P = 17), we can substitute to get 51f-5*17*x=f-5r and rearrange the left side as 17*(3f-5x)=f-5r and therefore f-5r is a multiple of P = 17 also.Q.E.D.

    //  Site Meter Now go visit my blog please, or look at other interesting maths stuff :-)

    static bool SieveOfEratosthenes(int n, bool[] isPrime)
    {
        // Initialize all entries of boolean 
        // array as true. A value in isPrime[i] 
        // will finally be false if i is Not a 
        // prime, else true bool isPrime[n+1]; 
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i <= n; i++)
            isPrime[i] = true;

        for (int p = 2; p * p <= n; p++)
        {
            // If isPrime[p] is not changed, 
            // then it is a prime 
            if (isPrime[p] == true)
            {
                // Update all multiples of p 
                for (int i = p * 2; i <= n; i += p)
                    isPrime[i] = false;
            }
        }
        return false;
    }

    // Prints a prime pair with given sum 
    static void findPrimePair(int n, bool[] isPrime)
    {

        //Traversing all numbers to find first
        // pair
        for (int i = 0; i < n; i++)
        {
            if (isPrime[i] && isPrime[n - i])
            {
                Console.Write($"{n} is sum of prime numbers ");
                Console.WriteLine(i + " and " + (n - i));
                return;
            }
        }
    }


    static void findPrimePair2(int n, bool[] isPrime)
    {
        // Generating primes using Sieve 
        int save_i = 0;
        for (int j = 4; j < n; j = j + 2)
        {
            for (int i = 0; i < j; i++)
            {
                if (isPrime[i] && isPrime[j - i])
                {
                    if (i > save_i && i <= (j - i))
                    {
                        Console.Write($"{j} is sum of prime numbers ");
                        Console.WriteLine(i + " and " + (j - i));
                        Console.WriteLine(j + "," + i + "," + (j - i));

                        save_i = i;
                        break;
                    }
                    else
                        break;
                }

            }
        }

    }

    static int findPrimeLower(int n, bool[] isPrime)
    {
            for (int i = n; i > 0; i--)
            {
                if (isPrime[i])
                {
                    Console.Write($"{i} is a prime number closest to {n} which is less than {n} ");
                    return i;
                }
                else return 0;
            }
        return 0;
    }

    static void findPrimeHigher(int n, bool[] isPrime)
    {
        int maxInt = 1000000010;
        if (isPrime[n])
        {
            Console.WriteLine($"{n} is a prime number ");
        }
        else
        {
            Console.WriteLine($"{n} is not a prime number ");
            for (int i = n; i < maxInt; i++)
            {
                if (isPrime[i])
                {
                    Console.Write($"{i} is a prime number closest to {n} which is higher than {n} ");
                    return;
                }
            }
        }

    }

    static int findPrimeLowerHigher(int n, bool[] isPrime, int maxMissed)
    {
        int maxInt = 1000000010;
        int lowPrime = 0, highPrime = 0;
        if (isPrime[n])
        {
            //Console.WriteLine($"{n} is a prime number ");
            Console.WriteLine($"{n} is a prime number. You hit a bulls eye ");
        }
        else
        {
            for (int i = n; i < maxInt; i++)
            {
                if (isPrime[i])
                {
                    //Console.Write($"{i} is a prime number closest to {n} which is higher than {n} ");
                    highPrime = i;
                    break;
                }
            }

            for (int i = n; i > 0; i--)
            {
                if (isPrime[i])
                {
                    //Console.Write($"{i} is a prime number closest to {n} which is less than {n} ");
                    lowPrime = i;
                    break;
                }
            }

            // find the distance to the closest prime number
            //Console.WriteLine($"{lowPrime} < {n} > {highPrime} ");

            if ((n - lowPrime) > (highPrime - n))
            {
                Console.WriteLine($"Closest prime number is {highPrime}. You missed it only by {(highPrime - n)}.");
                if ((highPrime - n) > maxMissed)
                    maxMissed = (highPrime - n);
            }
            else
            {
                Console.WriteLine($"Closest prime number is {lowPrime}. You missed it only by {(n - lowPrime)}.");
                if ((n - lowPrime) > maxMissed)
                    maxMissed = (n - lowPrime);
            }
        }
        Console.WriteLine($"Largest miss so far has been {maxMissed}.");
        return maxMissed;

    }

    // Driver code 
    public static void Main()
    {

        Console.Write("Enter a number with less than 10 digits, Enter 0 to quit: ");

        int intTemp;
        if (int.TryParse(Console.ReadLine(), out intTemp))
        {
            //do something with the data. 

            //int intTemp = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"{intTemp} is the number you entered");

            int maxInt = 1000000010;
            //int maxInt = 1010;
            //int lowPrime = 0, highPrime = 0;
            int maxMissed = 0;
            bool[] isPrime = new bool[maxInt + 1];
            SieveOfEratosthenes(maxInt, isPrime);
            while ((intTemp != 0))
            {
                if (intTemp % 2 != 0)
                {
                    //lowPrime = findPrimeLower(intTemp, isPrime);
                    //System.Console.WriteLine($"{lowPrime}");
                    //findPrimeHigher(intTemp, isPrime);
                    //System.Console.WriteLine();
                    maxMissed = findPrimeLowerHigher(intTemp, isPrime, maxMissed);
                    System.Console.WriteLine();
                }
                else
                {
                    findPrimePair(intTemp, isPrime);
                    System.Console.WriteLine();
                    //findPrimePair2(intTemp, isPrime);
                    //System.Console.WriteLine();
                    //findPrimeLower(intTemp, isPrime);
                    //System.Console.WriteLine();
                    maxMissed = findPrimeLowerHigher(intTemp, isPrime, maxMissed);
                    System.Console.WriteLine();
                }
                Console.Write("Enter a number with less than 10 digits, Enter 0 to quit: ");
                if (int.TryParse(Console.ReadLine(), out intTemp))
                {
                    intTemp = Convert.ToInt32(Console.ReadLine());
                }   
                else
                {
                    Console.Write("Number you entered is incorrect. Enter a number with less than 10 digits, Enter 0 to quit: ");
                }
            }
        }
        else
        {
            Console.Write("Number you entered is incorrect. Enter a number with less than 10 digits, Enter 0 to quit: ");
        }

    }
}

// This code is contributed by vt_m. 
