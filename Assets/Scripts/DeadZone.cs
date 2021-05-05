using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    public SceneChanger sceneChanger;

    public AudioSource pointAudio;

    private void OnTriggerEnter2D(Collider2D ball)
    {
        //Deteccion que atraviesa la pared
        
        //Las dos condicionales de abajo son comparaciones por tag. Ambas funciones hacen lo mismo
        //aunque se escriben diferente.

        if( gameObject.tag == "Left")
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        }
        else if(gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }

        ball.GetComponent<BallBehaviour>().gameStarted = false;
        CheckScore();
        pointAudio.Play();
    }

    void CheckScore()  //Funcion que evalua el puntaje y lanza la escene de Win o Lose
    {
        if (scorePlayerQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("WinScene");
        }
        else if (scoreEnemyQuantity >= 3)
        {
            sceneChanger.ChangeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score) // Funcion que cambia el texto segun el puntaje
    {
        label.text = score.ToString();
    }

}
