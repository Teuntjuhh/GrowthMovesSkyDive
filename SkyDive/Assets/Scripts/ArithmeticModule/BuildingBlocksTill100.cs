using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlocksTill100 : Equation
{
    public override void GenerateEquation()
    {
        int additionOrSubtraction = Random.Range(0, 2);

        if (additionOrSubtraction == 0)
        {
            GenerateAdditionEquation();
        }
        else
        {
            GenerateSubtractionEquation();
        }

    }

    private void GenerateAdditionEquation()
    {
        //first number must be between 10 and 100
        firstNumber = Random.Range(10, 101);

        //second number must be the value of (first number - 10) or lower, but the sum must also not be more than 100

        //secondNumber = Random.Range(10, 101 - firstNumber);

        secondNumber = GenerateSecondNumberAddition(firstNumber);
        op = Operator.Add;
    }

    //implementation of a sum equaling 100 or less
    public int GenerateSecondNumberAddition(int firstNumber)
    {
        int secondNumber = Random.Range(1, firstNumber);

        bool SumEqualsHundredOrLess = false;

        while (!SumEqualsHundredOrLess)
        {
            int sum = firstNumber + secondNumber;
            if (sum > 100)
            {
                secondNumber = Random.Range(1, firstNumber);
            }
            else
            {
                SumEqualsHundredOrLess = true;
            }
        }
        return secondNumber;
    }
    private void GenerateSubtractionEquation()
    {
        //first number must be between 10 and 100
        firstNumber = Random.Range(10, 101);

        //second number must be the value of first number or lower, but the sum must also not be more than 100

        secondNumber = Random.Range(10, firstNumber);
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
