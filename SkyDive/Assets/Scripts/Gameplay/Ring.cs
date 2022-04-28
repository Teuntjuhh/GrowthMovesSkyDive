using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    public bool IsSelected { get; private set; }

    [SerializeField]
    private Renderer renderer;
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

    private int answer;

    //Player has dived through a different ring but this one was correct
    public void Highlight()
    {
        renderer.material = highlightMaterial;
    }

    //Player moves onto this ring
    private void Select()
    {
        IsSelected = true;
        renderer.material = hoverMaterial;
    }

    //Player leaves this ring
    private void Deselect()
    {
        IsSelected = false;
        renderer.material = defaultMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        Select();
    }

    private void OnTriggerExit(Collider other)
    {
        Deselect();
    }
}
