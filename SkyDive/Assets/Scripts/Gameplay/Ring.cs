using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ring : MonoBehaviour
{
    public bool IsSelected { get; private set; }

    public Renderer renderer;

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
}
