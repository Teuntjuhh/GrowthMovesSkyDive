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

    //get a fake answer whose value is similar to the correct answer by a randomized margin between 1 and 2
    public override int GetSimilarAnswer()
    {
        //first get the correct answer
        int correctAnswer = GetCorrectAnswer();

        //the correct answer will later be incremented or decremented by this randomized value
        int randomValue = Random.Range(1, 3);
        int maxSum = 0;

        //first check if answer is below/equal to 10
        if (correctAnswer <= 10)
        {
            //the fake answer cannot go above 10
            maxSum = 10;
        }
        //answer goes above 10, so...
        else
        {
            //the fake answer cannot go above 20
            maxSum = 20;
        }
        //make sure the fake answer's decrease can't go lower than 1
        if (correctAnswer - randomValue < 1)
        {
            return correctAnswer + randomValue;
        }
        //also make sure the fake answer's increase cannot be higher than the maxSum
        else if (correctAnswer + randomValue >= maxSum)
        {
            return correctAnswer - randomValue;
        }
        //if both conditions are fine, 50% chance the answer will be increased or decreased by the random value, return fake answer
        else
        {
            if (Random.value < 0.5f)
            {
                return correctAnswer + randomValue;
            }
            else
            {
                return correctAnswer - randomValue;
            }
        }
    }

}
