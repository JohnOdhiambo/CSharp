using System;
using System.Collections.Generic;

public class Test
{
    public static void checkMax(int num)
    {
        List<int> oddNumbers = new List<int>() { 1, 3, 5, 7, 9};
        																
        foreach(int num in oddNumbers)
        {
            if(num % 3 == 0){
            	Console.Write(num);
            	return;
            }
        }
    }
    
	public static void Main()
	{
        int[] array = { 1, 2, 3, 4, 5, 6 };
        Console.WriteLine(checkMax(oddNumbers));
	}
}