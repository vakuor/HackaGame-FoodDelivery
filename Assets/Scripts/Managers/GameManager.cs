using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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

    // #region Loader Init
    // GameLoader loader;
    // public GameLoader Loader { get { return loader; } }
    // private void InitializeLoader() {
    //     loader = GetComponent<GameLoader>();
    //     if(loader == null) Debug.LogError("Loader is null!");
    // }
    // #endregion
}