using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Linq;
using UnityEngine.Events;
using TMPro;
using System;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Singleton Init 

    public static GameManager instance = null;
    private void Awake() {
        if (instance == null) {
	    instance = this;
	    } else if(instance != this) {
            Destroy(gameObject);
            return;
	    }
	    //DontDestroyOnLoad(gameObject);
	    InitializeManager();
    }

    private void InitializeManager(){ 
    }

    #endregion
    [SerializeField] private string userToken = "";
    private void Start() {
        if(gameOver!=null) {gameOver.SetActive(false);
        UpdateTime();
        if(userToken=="")
            userToken = GetString("user");
        }
            Debug.Log(userToken);
            int ind = userToken.IndexOf("\"access\":\"");
            Debug.Log(ind+10);
            Debug.Log(userToken.Length-ind);
            //Debug.LogError(userToken.Substring(ind+10, userToken.LastIndexOf("\"")-ind-10));
            // userToken = /*JsonUtility.FromJson<Models.Access>(*/JsonUtility.FromJson<Models.Token>(userToken)
            // .access
            // .access/*).access*/;
            userToken = userToken.Substring(ind+10, userToken.LastIndexOf("\"")-ind-10);
            Debug.Log("accesstoken: " + userToken);
    }
    public static string GetString(string key) {
      Debug.Log(string.Format("Jammer.PlayerPrefs.GetString(key: {0})", key));

      #if UNITY_WEBGL
      string s = ";";
      try{
        s = LoadFromLocalStorage(key: key);
      } catch(Exception){
          instance.scoreText.text = "error";
      }
        return s;
      #else
        return (UnityEngine.PlayerPrefs.GetString(key: key));
      #endif
    }
    #if UNITY_WEBGL

      [DllImport("__Internal")]
      private static extern string LoadFromLocalStorage(string key);

    #endif
    int score = 0;
    [SerializeField] public Food[] foods;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public int time = 30;
    [SerializeField] public GameObject gameOver;
    public void AddScore(int score){
        if(this.score+score < 0) this.score = 0;
        else
            this.score += score;
        Debug.Log("NewScore: " + this.score);
        UpdateScore();
    }
    public void UpdateScore(){
        scoreText.text = "Score: " + score;
    }
    public void UpdateTime(){
        Debug.Log("Update");
        if(timerText==null) return;
        timerText.text = "Time left: " + time;
        time--;
        if(time>0) Invoke("UpdateTime", 1f);
        else {
            timerText.text = "Time left: " + time;
            GameOver();
        }
    }
    public async void GameOver(){
        Debug.Log(userToken + " " + score);
        await RestManager.RestScore(userToken, score);
        gameOver.SetActive(true);
    }
    public void LoadScene(int scene){
        SceneManager.LoadScene(scene);
    }

    // #region Loader Init
    // GameLoader loader;
    // public GameLoader Loader { get { return loader; } }
    // private void InitializeLoader() {
    //     loader = GetComponent<GameLoader>();
    //     if(loader == null) Debug.LogError("Loader is null!");
    // }
    // #endregion
}