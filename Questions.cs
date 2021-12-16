using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]

public class Questions : ScriptableObject
{
    [System.Serializable]
    public class QuestionData
    {
        public string question = string.Empty;
        public bool option1 = false; //whenever the country has been guessed
        public bool option2 = false; //whenever the country has been guessed
        public bool option3 = false; //whenever the country has been guessed
        public bool option4 = false; //whenever the country has been guessed
        public bool questioned = false;
    }

    public int currentQuestion = 0;
    public List<QuestionData> questionsList;

    public void AddQuestion()
    {
        questionsList.Add(new QuestionData());
    }

}