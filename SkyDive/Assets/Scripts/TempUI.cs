using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUI : MonoBehaviour
{
    public Session session;

    private MultiplicationTables hardTables;

    public bool MoeilijkeTafels = false;
    public bool Optellen = false;

    private void Start()
    {
        hardTables = new MultiplicationTables();
        hardTables.UpdateListSelectedNumbers(new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
    }

    private void Update()
    {
        if (MoeilijkeTafels)
        {
            MoeilijkeTafels = false;
            session.Generate(15, new List<Equation> { hardTables });
            StartCoroutine(session.StartSession());
        }
        if(Optellen)
        {
            Optellen = false;
            session.Generate(15, new List<Equation> { new AdditionTill10(), new Addition10Till20(), new BuildingBlocksTill100() });
            StartCoroutine(session.StartSession());
        }
    }
}
