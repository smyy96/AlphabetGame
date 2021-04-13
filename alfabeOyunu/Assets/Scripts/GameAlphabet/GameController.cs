using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static char Letter = 'a';
    static int _correctAnswers = 5;
    static int _correctClicks;

    private void OnEnable()
    {
        GenerateBoard();
        UpdateDiplayLetters();

    }

    private static void GenerateBoard() //paneldeki harflerin olusturulmasý
    {
        var cliclables = FindObjectsOfType<ClickableLetter>();
        
        List<char> charsList = new List<char>();

        for (int i = 0; i < _correctAnswers; i++)
        {
            charsList.Add(Letter);
        }

        for (int i = _correctAnswers; i < cliclables.Length; i++)
        {
            var chosenletter = ChooseInvalidRandomLetter();
            charsList.Add(chosenletter);
        }

        charsList = charsList
            .OrderBy(t => UnityEngine.Random.Range(0, 10000))
            .ToList();

        for (int i = 0; i < cliclables.Length; i++)
        {
            cliclables[i].SetLetter(charsList[i]);
        }

        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
    }


    internal static void HandleCorrectLetterClick()
    {
        
        _correctClicks++;
        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
        if (_correctClicks >= _correctAnswers)
        {
            Letter++;
            UpdateDiplayLetters();
            _correctClicks = 0;
            GenerateBoard();
        }
    }

    private static void UpdateDiplayLetters()
    {
        foreach (var displayletter in FindObjectsOfType<DisplayLetter>())
        {
            displayletter.SetLetter(Letter);
            //if (Letter=='c')
            //{
            //    Letter = 'ç';
            //    displayletter.SetLetter(Letter);                
            //}
            //else if (Letter == 'ç')
            //{
            //    Letter = 'd';
            //    displayletter.SetLetter(Letter);
            //}

            if (Letter=='z')
            {
                Letter = 'a';
            }
            
        }
    }

    private static char ChooseInvalidRandomLetter()
    {
        int a = UnityEngine.Random.Range(0, 26);
        var randomLetter = (char)('a' + a);

        while (randomLetter==Letter)
        {
            a = UnityEngine.Random.Range(0, 26);
            randomLetter = (char)('a' + a);
        }

        return randomLetter;
    }
}
