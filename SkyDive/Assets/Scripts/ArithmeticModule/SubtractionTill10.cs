using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionTill10 : Equation
{
    public override void GenerateEquation()
    {
        //first number must be between 0 and 10
        firstNumber = Random.Range(1, 11);

        //second number must be lower than first number to prevent negative value answer
        secondNumber = Random.Range(1, firstNumber);
        op = Operator.Subtract;
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