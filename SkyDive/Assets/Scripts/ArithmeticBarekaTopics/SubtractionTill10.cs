using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractionTill10 : Equation
{
    public override void GenerateEquation()
    {
        //first number must be between 0 and 10
        firstNumber = Random.Range(1, 11);

        //second number must be lower than first number to prevent negative value answer, second number will also never become zero for now (too easy)
        secondNumber = Random.Range(1, firstNumber);            
        op = Operator.Subtract; 
    }

    //unnecessary implementation
    //public int GenerateSecondNumber(int firstNumber, int minAnswerValue)
    //{
    //    int secondNumber = Random.Range(0, 11);

    //    bool SumIsMoreThanZero = false;

    //    while (!SumIsMoreThanZero)
    //    {
    //        int sum = firstNumber + secondNumber;
    //        if (sum < minAnswerValue - 1)
    //        {
    //            secondNumber = Random.Range(0, 11);
    //        }
    //        else
    //        {
    //            SumIsMoreThanZero = true;
    //        }
    //    }
    //    return secondNumber;
    //}
}
