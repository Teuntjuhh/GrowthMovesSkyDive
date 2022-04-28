using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    private Equation equation;

    private List<Ring> rings;

    private List<Bounds> ringAreas;

    private void Generate()
    {
        //TODO
        //rings[0].Answer = equation.GetCorrectAnswer();

        for (int i = 1; i < rings.Count; i++)
        {
            //rings[i].Answer = equation.GetSimilarAnswer();
        }

        //Assign each ring a random location without overlap
        List<Bounds> availableAreas = ringAreas;
        foreach (Ring ring in rings)
        {
            int areaIndex = Random.Range(0, availableAreas.Count);

            ring.transform.localPosition = new Vector3(
                Random.Range(availableAreas[areaIndex].min.x, availableAreas[areaIndex].max.x),
                0,
                Random.Range(availableAreas[areaIndex].min.z, availableAreas[areaIndex].max.z));
            availableAreas.RemoveAt(areaIndex);
        }
    }
}
