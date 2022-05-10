using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subtraction10Till20 : Equation
{
    [SerializeField]
    private int minAnswerValue = 1;
    

    public override void GenerateEquation()
    {
        //first number must be between 0 and 10
        firstNumber = Random.Range(11, 21);

        //second number must be lower than the first number to prevent negative value answer, second number will also never become zero for now (too easy)
        secondNumber = Random.Range(1, firstNumber);
        op = Operator.Subtract;
    }


    //public int GenerateSecondNumber(int firstNumber, int minAnswerValue, int maxAnswerValue)
    //{
    //    int secondNumber = Random.Range(0, maxAnswerValue);

    //    bool SumEqualsBetween10And20 = false;

    //    while (!SumEqualsBetween10And20)
    //    {
    //        int sum = firstNumber + secondNumber;
    //        if (sum < minAnswerValue && sum > maxAnswerValue)
    //        {
    //            secondNumber = Random.Range(0, maxAnswerValue);
    //        }
    //        else
    //        {
    //            SumEqualsBetween10And20 = true;
    //        }
    //    }
    //    return secondNumber;
    //}
}
