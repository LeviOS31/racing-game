using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class startfinishline : MonoBehaviour
{
    [SerializeField] GameObject player1timevis;
    [SerializeField] GameObject player2timevis;

    float player1time = 0f;
    float player2time = 0f;

    bool isracing1 = false;
    bool isracing2 = false;

    void Update()
    {
        if (isracing1){
            player1time += Time.deltaTime;

            player1timevis.GetComponent<TextMeshProUGUI>().text = FormatTime(player1time);
        }

        if (isracing2){
            player2time += Time.deltaTime;
            
            player2timevis.GetComponent<TextMeshProUGUI>().text = FormatTime(player2time);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("done");
        }
    }

    private string FormatTime(float time)
    {
    int minutes = Mathf.FloorToInt(time / 60F);
    int seconds = Mathf.FloorToInt(time % 60);
    int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

    return string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("car")){
            if (other.transform.parent.gameObject.name == "player1"){
                if(isracing1){
                    GameMaster.instance.player1times.Add(player1time);
                    player1time = 0f;
                }
                isracing1 = true;
            }
            if (other.transform.parent.gameObject.name == "player2"){
                if(isracing2){
                    GameMaster.instance.player2times.Add(player2time);
                    player2time = 0f;
                }
                isracing2 = true;
            }
        }
    }
}
