using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class results : MonoBehaviour
{
    [SerializeField] Transform winner;
    [SerializeField] Transform loser;
    [SerializeField] GameObject player1obj;
    [SerializeField] GameObject player2obj;
    [SerializeField] GameObject text;
    [SerializeField] GameObject textp1;
    [SerializeField] GameObject textp2;
    [SerializeField] GameObject panel;
    List<float> player1;
    List<float> player2;

    void Start()
    {
        player1 = GameMaster.instance.player1times;
        player2 = GameMaster.instance.player2times;

        player1.Add(99999999.0f);
        player2.Add(99999999.0f);

        StartCoroutine(Showtimes());


    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        return string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    private IEnumerator Showtimes()
    {
        yield return new WaitForSeconds(0.4f);

        float besttime1 = player1.Min();
        float besttime2 = player2.Min();

        if(besttime1 < besttime2){

            player1obj.transform.position = winner.position;
            player2obj.transform.position = loser.position;
            player1obj.transform.rotation = winner.rotation;
            player2obj.transform.rotation = loser.rotation;
            text.GetComponent<TextMeshProUGUI>().text = "PLAYER 1 HAS WON WITH A TIME OF " + FormatTime(besttime1);

        }
        else{

            player2obj.transform.position = winner.position;
            player1obj.transform.position = loser.position;
            player2obj.transform.rotation = winner.rotation;
            player1obj.transform.rotation = loser.rotation;
            text.GetComponent<TextMeshProUGUI>().text = "PLAYER 2 HAS WON WITH A TIME OF " + FormatTime(besttime2);

        }

        yield return new WaitForSeconds(5f);

        panel.SetActive(true);
        textp1.SetActive(true);
        textp2.SetActive(true);

        string p1texttimes = "PLAYER 1 \n\n";

        foreach(float time in player1){
            if(time < 99999998.0f){
                p1texttimes = p1texttimes + FormatTime(time) + "\n";
            }
        }

        string p2texttimes = "PLAYER 2 \n\n";

        foreach(float time in player2){
            if(time < 99999998.0f){
                p2texttimes = p2texttimes + FormatTime(time) + "\n";
            }
        }

        textp1.GetComponent<TextMeshProUGUI>().text = p1texttimes;
        textp2.GetComponent<TextMeshProUGUI>().text = p2texttimes;
    }
}
