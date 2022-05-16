using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionTill10 : Equation
{

    public override void GenerateEquation()
    {
        //first number must be between 1 and 9
        firstNumber = Random.Range(1, 10);

        //the sum of the first number and the second number must not be more than 10
        
        secondNumber = Random.Range(1, 11 - firstNumber);
        op = Operator.Add;

        //different implementation
        //secondNumber = GenerateSecondNumber(firstNumber);

    }


    //different implementation of a sum equaling 10 or less
    public int GenerateSecondNumber(int firstNumber)
    {
        int secondNumber = Random.Range(1, 10);

        bool SumEqualsTenOrLess = false;

        while (!SumEqualsTenOrLess)
        {
            //count the sum
            int sum = firstNumber + secondNumber;

            //the sum is more than 10
            if (sum > 10)
            {
                //randomize the second number again
                secondNumber = Random.Range(1, 10);
            }
            //the sum is not more than 10
            else
            {
                SumEqualsTenOrLess = true;
            }
        }
        return secondNumber;
    }

}
