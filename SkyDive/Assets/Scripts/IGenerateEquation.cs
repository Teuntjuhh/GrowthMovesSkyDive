using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerateEquation 
{
    public enum Operator { Add, Subtract, Multiply, Divide }
    Operator equationOperator { get; set; }
    string Generate();
}
