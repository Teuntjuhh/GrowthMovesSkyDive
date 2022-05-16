using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionTables : Equation
{
    [SerializeField]
    private List<int> selectedNumbers;

    public void UpdateListSelectedNumbers(List<int> selectedNumbers)
    {
        this.selectedNumbers = selectedNumbers;
    }

    public override void GenerateEquation()
    {
        int randomIndex = Random.Range(0, selectedNumbers.Count);
        firstNumber = selectedNumbers[randomIndex];

        if (firstNumber <= 10)
        {
            secondNumber = Random.Range(1, 11);
        }
        else
        {
            secondNumber = Random.Range(1, firstNumber + 1);
        }

        op = Operator.Divide;
    }
}
