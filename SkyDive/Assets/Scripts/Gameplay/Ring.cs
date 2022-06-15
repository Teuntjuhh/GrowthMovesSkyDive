using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    public bool IsSelected { get; private set; }

    public Renderer renderer;
    public GameObject FallRing;
    private Vector3 FallRingStartPosition;

    [SerializeField]
    private Collider collider;

    [SerializeField]
    private TMP_Text answerText;

    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material hoverMaterial;
    [SerializeField]
    private Material highlightMaterial;

    public int Answer {
        get
        {
            return answer;
        }
        set
        {
            answerText.text = value.ToString();
            answer = value;
        }
    }

    public void Awake()
    {
        FallRingStartPosition = FallRing.transform.position;
    }

    private int answer;

    //This Ring was correct
    public void Highlight()
    {
        renderer.material = highlightMaterial;
    }

    //Player moves onto this ring
    public void Select()
    {
        IsSelected = true;
        renderer.material = hoverMaterial;
    }

    //Player leaves this ring
    public void Deselect()
    {
        IsSelected = false;
        renderer.material = defaultMaterial;
    }

    public void Lock()
    {
        collider.enabled = false;
    }

    private void OnEnable()
    {
        collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Select();
    }

    private void OnTriggerExit(Collider other)
    {
        Deselect();
    }

    public IEnumerator Fall(float duration)
    {
        float currentDuration = 0;
        while (currentDuration < duration)
        {
            currentDuration += Time.deltaTime;
            float lerpAmount = currentDuration / duration;
            FallRing.transform.position = Vector3.Lerp(FallRingStartPosition, transform.position, lerpAmount);
            yield return null;
        }

        //uncomment this to have the rings not disappear when flying through
        /*while (currentDuration < duration + 1)
        {
            currentDuration += Time.deltaTime;
            float lerpAmount = currentDuration / duration;
            FallRing.transform.position = Vector3.LerpUnclamped(FallRingStartPosition, transform.position, lerpAmount);
            yield return null;
        }*/

        FallRing.transform.position = FallRingStartPosition;
    }
}
