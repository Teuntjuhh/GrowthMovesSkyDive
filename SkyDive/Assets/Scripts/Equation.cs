using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equation : MonoBehaviour
{
    

    //the operator refers to the type of the equation, e.g. Addition, Subtraction, Multiplication or Division
    public enum Operator { Add, Subtract, Multiply, Divide}

    public enum BarekaTopic { AdditionTill10, SubtractionTill10, AdditionTill20, SubtractionTill20, BuildingBlocksTill100, MultiplicationTillMax, DivisionTillMax, MultiplicationOfNumber, DivisionOfNumber }

    public int GetMaxNumber(int maxNumber)
    {
        return maxNumber;
    }

    //the firstNumber and secondNumber are calculated together to form the answerNumber
    public int firstNumber { get; protected set; }
    public int secondNumber { get; protected set; }

    public Operator op;

    public int GivenAnswer { get; set; }

    public abstract void GenerateEquation();

    public int GetCorrectAnswer()
    {

        switch (op)
        {
            case Operator.Add:
                {
                    return firstNumber + secondNumber;
                }
            case Operator.Subtract:
                {
                    return firstNumber - secondNumber;
                }
            case Operator.Multiply:
                {
                    return firstNumber * secondNumber;
                }
            case Operator.Divide:
                {
                    return firstNumber / secondNumber;
                }
            default:
                {
                    return 0;
                }
        }
    }

    public int GetSimilarAnswer()
    {
        return 0; //TODO
    }

    public bool isCorrect()
    {
        if(GivenAnswer == GetCorrectAnswer())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
