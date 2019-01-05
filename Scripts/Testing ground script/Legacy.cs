using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legacy : MonoBehaviour {

	public void ButtonOnClick(string parameters)
    {
        /* Once you need more then 1 parameter. Default unity will not show you your public
         * method. Thus only ask for a string parameter and in the funtion split it up.
         * Look example below. 
         */
        string[] splitPar = parameters.Split(","[0]); //gain string parameter and split eg. left, 3
        string direction = splitPar[0]; //assign to each variable to local one
        int lives = int.Parse(splitPar[1]);

        Debug.Log("Direction: " + direction + "\n Lives: " + lives);

        //Some logic
    }

    private int[] myArr = { 5, 9, 2, 55, 1, 33, 21, 7, 1, 44, 6 };

    public void PowerOfQuickSort()
    {
        /*Just derped around with sorting stuff. Came across the ability to sort by just
         * copying code from elsewhere
         */

        Quick_Sort(myArr, 0, myArr.Length - 1);

        for (int i = 0; i <= myArr.Length - 1; i++)
        {
            Debug.Log("All the nr: " + myArr[i]);
        }
    }

    // both sortation from the www.
    private static void Quick_Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                Quick_Sort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(arr, pivot + 1, right);
            }
        }

    }
    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true)
        {

            while (arr[left] < pivot)
            {
                left++;
            }

            while (arr[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;


            }
            else
            {
                return right;
            }
        }
    }
}
