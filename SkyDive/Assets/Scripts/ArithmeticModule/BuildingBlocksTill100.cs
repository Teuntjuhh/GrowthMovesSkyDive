using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlocksTill100 : Equation
{ 
    public override void GenerateEquation()
    {
        int additionOrSubtraction = Random.Range(0, 2);

        if(additionOrSubtraction == 0)
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
}
