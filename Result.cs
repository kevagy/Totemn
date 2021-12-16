using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Result : MonoBehaviour
{
    public Questions questions;
    public GameObject correctSprite;
    public GameObject incorrectSprite;


    public Scores scores;

    public Button box1;
    public Button box2;
    public Button box3;
    public Button box4;

    public UnityEvent onNextQuestion;

    // Start is called before the first frame update
    void Start()
    {
        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);

    }

    public void ShowResults(bool answer)
    {
        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].option1 == answer);
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].option1 != answer);


        if (questions.questionsList[questions.currentQuestion].option1 == answer)
            scores.Addscore();

        else
            scores.Deductscore();


        box1.interactable = false;
        box2.interactable = false;
        box3.interactable = false;
        box4.interactable = false;

        StartCoroutine(ShowResult());

    }

    public void ShowResults2(bool answer2)
    {

        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].option2 == answer2);
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].option2 != answer2);

        if (questions.questionsList[questions.currentQuestion].option2 == answer2)
            scores.Addscore();

        else
            scores.Deductscore();


        box1.interactable = false;
        box2.interactable = false;
        box3.interactable = false;
        box4.interactable = false;

        StartCoroutine(ShowResult());

    }

    public void ShowResults3(bool answer3)
    {

        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].option3 == answer3);
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].option3 != answer3);



        if (questions.questionsList[questions.currentQuestion].option3 == answer3)
            scores.Addscore();

        else
            scores.Deductscore();


        box1.interactable = false;
        box2.interactable = false;
        box3.interactable = false;
        box4.interactable = false;

        StartCoroutine(ShowResult());

    }

    public void ShowResults4(bool answer4)
    {

        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].option4 == answer4);
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].option4 != answer4);


        if (questions.questionsList[questions.currentQuestion].option4 == answer4)
            scores.Addscore();
        else
            scores.Deductscore();


        box1.interactable = false;
        box2.interactable = false;
        box3.interactable = false;
        box4.interactable = false;

        StartCoroutine(ShowResult());

    }


    private IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1.0f);

        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);


        box1.interactable = true;
        box2.interactable = true;
        box3.interactable = true;
        box4.interactable = true;

        onNextQuestion.Invoke();

    }



}
