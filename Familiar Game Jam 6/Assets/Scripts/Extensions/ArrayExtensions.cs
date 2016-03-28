using System;

namespace Extensions.System.SequentialArray
{
    public static class ArrayExtensions
    {
        public static bool IndexInRange(this Array array, params int[] indexes)
        {
            for (int i = 0; i < array.Rank; i++)
            {
                if ((indexes[i] < array.GetLowerBound(i)) || (indexes[i] > array.GetUpperBound(i)))
                    return false;
            }
            return true;
        }
    }
    
}