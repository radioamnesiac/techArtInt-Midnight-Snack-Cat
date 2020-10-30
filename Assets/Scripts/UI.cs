using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public static UI instance;
    
    public Slider slider;
    public Text[] roundText, scoreText, timerText, totalScoreText, finalRoundText;
    Animator anim;

    void Awake() => instance = this;
    void Update() => VariableText();
   private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    /* 
    *   Dynamic UI text change during the gameplay
    */
    void VariableText() {
        scoreText[0].text = GameManager.instance.score + " /" + GameManager.instance.scoreRoundGoal;
       
        roundText[0].text = "Lunch #" + GameManager.instance.round;
        
        timerText[0].text = Mathf.Round(GameManager.instance.timer) + "";
        slider.value = GameManager.instance.timer;
    }
    /* 
    *   Activates popup and decrease alpha gradually to 0 
    */
    public IEnumerator PopUpFadeAway(GameObject obj, float time) {
        obj.SetActive(true);
        Color originalcolor = obj.GetComponent<Text>().color;
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime / time) {
            Color newColor = new Color(originalcolor.r, originalcolor.g, originalcolor.b, t);
            obj.GetComponent<Text>().color = newColor;
            yield return null;
        }
        obj.SetActive(false);
    }

    public void AdditionPopUp(GameObject obj, float time, int scoreAdd) {
        if (scoreAdd > 0) {
            obj.GetComponent<Text>().text = "+" + scoreAdd + "pts.";
        }
        StartCoroutine(PopUpFadeAway(obj, time));
    }

    public void DisplayGameOverText() {
        totalScoreText[0].text = GameManager.instance.totalScore + "";
        totalScoreText[1].text = GameManager.instance.totalScore + "";

        finalRoundText[0].text = GameManager.instance.round + "";
        finalRoundText[1].text = GameManager.instance.round + "";
    }

}
