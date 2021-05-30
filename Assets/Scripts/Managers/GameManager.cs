using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

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

    private void Start() {
        if(gameOver!=null) {gameOver.SetActive(false);
        UpdateTime();}
    }
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
    public void GameOver(){
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