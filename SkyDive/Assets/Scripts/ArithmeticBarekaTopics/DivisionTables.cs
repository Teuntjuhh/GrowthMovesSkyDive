using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionTables : Equation
{ 
    //public static GameObject inputField;

    //public string maxValue = inputField.GetComponent<TMP_InputField>().text;

    [SerializeField]
    private int tableOf;

    public override void GenerateEquation()
    {
        firstNumber = tableOf;

        if (tableOf <= 10)
        {
            secondNumber = Random.Range(1, 11);
        }
        else
        {
            secondNumber = Random.Range(1, tableOf + 1);
        }

        op = Operator.Divide;
    }
}
