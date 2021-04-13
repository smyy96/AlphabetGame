using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class ClickableLetter : MonoBehaviour, IPointerClickHandler

{
    char _randomLetter;
    public void OnPointerClick(PointerEventData eventData)// harflere t�klan�ld�g�nda renklerinin yesile d�nmesi
    {
        Debug.Log($"T�klad�g�n�z harf {_randomLetter}");

        if (_randomLetter == GameController.Letter)
        {
            GetComponent<TMP_Text>().color = Color.green;
            enabled = false;
            GameController.HandleCorrectLetterClick();
            
        }
    }

    //private void OnEnable()//rastgele harfleri �retme
    //{

    //    int a = Random.Range(0, 26);
    //    _randomLetter = (char)('a' + a);

    //    if(Random.Range(0,100)>50)
    //        GetComponent<TMP_Text>().text = _randomLetter.ToString();
    //    else
    //        GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
    //}

    public void SetLetter(char letter)
    {
        enabled = true;
        GetComponent<TMP_Text>().color = Color.white;
        _randomLetter = letter;

        if (Random.Range(0, 100) > 50)
        {
            //_upperCase = false;
            GetComponent<TMP_Text>().text = _randomLetter.ToString();
        }
        else
        {
            //_upperCase = true;
            GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
        }
    }
}



