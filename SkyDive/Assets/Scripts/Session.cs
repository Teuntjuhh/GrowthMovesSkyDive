using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BalanceExercise
{
    Wide,
    LegsTogether,
    Ball,
    OneLegLow,
    OneLegRaised
}

public class Session : MonoBehaviour
{
    public List<Equation> Equations { get; private set; }
    public BalanceExercise BalanceExercise { get; private set; }
    public int Score { get; set; }

    public GameObject LevelSegmentGameObject;
    public TextMeshProUGUI equationText;

    private List<LevelSegment> levelSegments = new List<LevelSegment>();
    private float thinkDuration = 1;
    private float ringDuration = 3;
    private float showAnswerDuration = 1.5f;

    private void Awake()
    {
        Equations = new List<Equation>();
    }

    public void Generate(int equationCount, List<Equation> topics)
    {
        if(Equations.Count == 0)
        {
            for (int i = 0; i < equationCount; i++)
            {
                Equation nextEquationTopic = topics[Random.Range(0, topics.Count)];

                GameObject newSegmentObject = Instantiate(LevelSegmentGameObject, this.transform);
                LevelSegment nextSegment = newSegmentObject.GetComponent<LevelSegment>();

                switch (nextEquationTopic)
                {
                    case AdditionTill10:
                        nextSegment.equation = new AdditionTill10();
                        break;
                    case SubtractionTill10:
                        nextSegment.equation = new SubtractionTill10();
                        break;
                    case Addition10Till20:
                        nextSegment.equation = new Addition10Till20();
                        break;
                    case Subtraction10Till20:
                        nextSegment.equation = new Subtraction10Till20();
                        break;
                    case BuildingBlocksTill100:
                        nextSegment.equation = new BuildingBlocksTill100();
                        break;
                    case MultiplicationTables:
                        nextSegment.equation = new MultiplicationTables();
                        MultiplicationTables nextMultiplicationTables = nextSegment.equation as MultiplicationTables;
                        nextMultiplicationTables.UpdateListSelectedNumbers(((MultiplicationTables)nextEquationTopic).selectedNumbers);
                        Debug.Log(nextSegment.equation);
                        break;
                    case DivisionTables:
                        nextSegment.equation = new DivisionTables();
                        DivisionTables nextDivisionTables = nextSegment.equation as DivisionTables;
                        nextDivisionTables.UpdateListSelectedNumbers(((DivisionTables)nextEquationTopic).selectedNumbers);
                        break;
                    default:
                        break;
                }

                nextSegment.equation.GenerateEquation();
                Equations.Add(nextSegment.equation);
                levelSegments.Add(nextSegment);
            }
        }
        else
        {
            Debug.LogError("Session was already generated!");
        }
    }

    public IEnumerator StartSession()
    {
        //Loop through all levelSegments
        for (int i = 0; i < levelSegments.Count; i++)
        {
            //Show the equation
            equationText.text = levelSegments[i].equation.GenerateEquationToString();

            float currentDuration = 0;
            while (currentDuration < thinkDuration)
            {
                currentDuration += Time.deltaTime;
                yield return null;
            }

            //Show the rings
            levelSegments[i].gameObject.SetActive(true);

            currentDuration = 0;
            while (currentDuration < ringDuration)
            {
                currentDuration += Time.deltaTime;
                yield return null;
            }


            bool answerCorrect = levelSegments[i].CheckAnswer();
            equationText.text = levelSegments[i].equation.GenerateEquationToString() + levelSegments[i].equation.GetCorrectAnswer();
            currentDuration = 0;
            while (currentDuration < showAnswerDuration)
            {
                currentDuration += Time.deltaTime;
                yield return null;
            }

            //Check if the selected ring was the correct answer
            if (!answerCorrect)
            {
                //If not, repeat the question later
                int newIndex = i + 3;
                if(newIndex > levelSegments.Count)
                {
                    newIndex = levelSegments.Count;
                }

                levelSegments[i].gameObject.SetActive(false);

                LevelSegment repeatSegment = Instantiate(levelSegments[i], this.transform);
                repeatSegment.equation = levelSegments[i].equation.Clone() as Equation;
                levelSegments.Insert(newIndex, repeatSegment);
            }
            else
            {
                levelSegments[i].gameObject.SetActive(false);
            }    
        }      
    }
}
