using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUI : MonoBehaviour
{
    public Session session;

    private AdditionTill10 tables;

    public bool TEMPGenerate = false;

    private void Start()
    {
        //tables = gameObject.AddComponent<AdditionTill10>();
        tables = new AdditionTill10();
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
