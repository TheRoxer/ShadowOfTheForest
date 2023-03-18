using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicscript : MonoBehaviour
{
    public int wynik;
    public Text textwyniku;

    [ContextMenu("dodaj punkty")]
    public void addScore()
    {
        wynik += 1;
        textwyniku.text = wynik.ToString();
    }
}
