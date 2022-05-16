using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    [SerializeField]
    private Equation equation;

    [SerializeField]
    private List<Ring> rings;

    [SerializeField]
    private List<AreaGroup> areaGroupsList;

    [System.Serializable]
    public class AreaGroup
    {
        public List<Bounds> ringAreas;
    }

    public void Generate()
    {
        rings[0].Answer = equation.GetCorrectAnswer();

        for (int i = 1; i < rings.Count; i++)
        {
            rings[i].Answer = equation.GetSimilarAnswer();
        }

        //Select a random group of ring Areas. We copy the list so we can remove entries from it as we iterate through it
        List<Bounds> availableAreas = new List<Bounds>(areaGroupsList[Random.Range(0, areaGroupsList.Count)].ringAreas);

        //Assign each ring a random location without overlap
        foreach (Ring ring in rings)
        {
            int areaIndex = Random.Range(0, availableAreas.Count);

            ring.transform.position = new Vector3(
                Random.Range(availableAreas[areaIndex].min.x + ring.renderer.bounds.extents.x, 
                    availableAreas[areaIndex].max.x - ring.renderer.bounds.extents.x),
                0,
                Random.Range(availableAreas[areaIndex].min.z + ring.renderer.bounds.extents.z, 
                    availableAreas[areaIndex].max.z - ring.renderer.bounds.extents.z));
            availableAreas.RemoveAt(areaIndex);
        }
    }
}
