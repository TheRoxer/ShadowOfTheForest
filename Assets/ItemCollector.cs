using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    
    private int coins = 0;
    [SerializeField] private Text coinsText;

    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.CompareTag("Coin")) {

            Destroy(col.gameObject);
            coins++;
            coinsText.text = coins.ToString();

        }

        if (coins >= 25) {
                
                SceneManager.LoadScene("Win");
        }

    }

}
