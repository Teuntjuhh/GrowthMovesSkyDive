using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addition10Till20 : Equation
{
    [SerializeField]
    private int minAnswerValue = 10;
    [SerializeField]
    private int maxAnswerValue = 20;

    public override void GenerateEquation()
    {
        //first number must be between 1 and 19
        firstNumber = Random.Range(1, 20);

        //the sum of the first number and the second number must be between 10 and 20
        secondNumber = GenerateSecondNumber(firstNumber);


        op = Operator.Add;
    }

    //implementation of a sum that ranges between 10 and 20
    public int GenerateSecondNumber(int firstNumber)
    {

        int secondNumber = Random.Range(1, 20);

        bool SumEqualsBetween10And20 = false;

        while (!SumEqualsBetween10And20)
        {
            //count the sum
            int sum = firstNumber + secondNumber;

            //the sum is not between 10 and 20
            if (sum < 10 || sum > 20)
            {
                //re-randomize the second number, and run the while loop again
                secondNumber = Random.Range(1, 20);
            }
            //the sum is between 10 and 20, kill the while loop 
            else
            {
                SumEqualsBetween10And20 = true;
            }
        }
        return secondNumber;

    }
}
