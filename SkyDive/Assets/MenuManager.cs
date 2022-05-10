using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject barekaTopicsMenu;
    public GameObject arithmeticSession;

    public TMP_Text equationText;

    //[SerializeField]
    //private Button[] buttons;

    //public Button thisButton;
    public Button btnAdditionTill10;
    public Button btnSubtractionTill10;
    public Button btnAddition10Till20;
    public Button btnSubtraction10Till20;
    public Button btnBuildingBlocksTill100;
    public Button btnMultiplicationTables;
    public Button btnDivisionTables;

    public Button generateButton;
   


    public bool ButtonPressed = false;

    private void Start()
    {
        //InitializeButtons();
    }

    //private void InitializeButtons()
    //{
    //    for (int i = 0; i < buttons.Length; i++)
    //    {
    //        Button button = buttons[i];

    //        //change it 
    //        button.onClick.AddListener(BeenClicked);
    //    }
    //}

    public void GoToArithmeticSession()
    {
        barekaTopicsMenu.SetActive(false);
        arithmeticSession.SetActive(true);
    }

    public void GenerateEquationUI(Equation eq)
    {
        if (barekaTopicsMenu.activeSelf)
        {
            GoToArithmeticSession();
        }
        eq.GenerateEquation();
        equationText.text = eq.GenerateEquationToString();
    }

    

    public void GenerateAdditionTill10()
    {
        AdditionTill10 additionTill10 = new AdditionTill10();
        GenerateEquationUI(additionTill10);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(additionTill10); });
    }

    public void GenerateSubtractionTill10()
    {
        SubtractionTill10 subtractionTill10 = new SubtractionTill10();
        GenerateEquationUI(subtractionTill10);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(subtractionTill10); });
    }

    public void GenerateAddition10Till20()
    {
        
        Addition10Till20 addition10Till20 = new Addition10Till20();
        GenerateEquationUI(addition10Till20);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(addition10Till20); });
    }

    public void GenerateSubtraction10Till20()
    {
        Subtraction10Till20 subtraction10Till20 = new Subtraction10Till20();
        GenerateEquationUI(subtraction10Till20);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(subtraction10Till20); });
    }

    public void GenerateBuildingBlocksTill100()
    {
        BuildingBlocksTill100 buildingBlocksTill100 = new BuildingBlocksTill100();
        GenerateEquationUI(buildingBlocksTill100);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(buildingBlocksTill100); });
    }

    public void GenerateMultiplicationTables()
    {
        MultiplicationTables multiplicationTables = new MultiplicationTables();
        GenerateEquationUI(multiplicationTables);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(multiplicationTables); });
    }

    public void GenerateDivisionTables()
    {
        DivisionTables divisionTables = new DivisionTables();
        GenerateEquationUI(divisionTables);
        generateButton.onClick.AddListener(delegate { GenerateEquationUI(divisionTables); });
    }

    public void BtnBack()
    {
        arithmeticSession.SetActive(false);
        barekaTopicsMenu.SetActive(true);
        generateButton.onClick.RemoveAllListeners();
    }

 
}
