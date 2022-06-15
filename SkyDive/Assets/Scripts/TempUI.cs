using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUI : MonoBehaviour
{
    public Session session;

    private MultiplicationTables tables;

    public bool TEMPGenerate = false;

    private void Start()
    {
        tables = new MultiplicationTables();
        tables.UpdateListSelectedNumbers(new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
    }

    private void Update()
    {
        if (TEMPGenerate)
        {
            TEMPGenerate = false;
            session.Generate(10, new List<Equation> { tables });
            StartCoroutine(session.StartSession());
        }
    }
}
