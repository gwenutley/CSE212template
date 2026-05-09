using System.Globalization;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Create an array to store the results
        double[] multiples = new double[length];
        multiples[0] = number;

        //loop from 0 to count -1
        for (int i = 0; i < length; i++)
        {
            //for each index do starting number * (index + 1)
            multiples[i] = number * (i + 1);
        }

        //return the array
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        //split the list amount - 1
        int listCount = data.Count;
        int splitList = listCount - amount;
        //put part one of list in a new list1
        //put part two of list in a new list2
        List<int> list1 = data.GetRange(0, splitList);
        List<int> list2 = data.GetRange(splitList, listCount - splitList);
        //create new list with new list2 + new list1
        List<int> newList = new List<int>();
        newList.AddRange(list2);    
        newList.AddRange(list1);
        //copy new list back to data        
        data.Clear();
        data.AddRange(newList);
        //return new list   
        return;
    }
}
