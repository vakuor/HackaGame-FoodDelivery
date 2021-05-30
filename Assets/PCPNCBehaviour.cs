using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPNCBehaviour : MonoBehaviour
{
    [SerializeField] int facing;
    [SerializeField] GameObject msgBox;
    [SerializeField] SpriteRenderer wishSprite;
    [SerializeField] Food testFood;
    public int FaceRight { set { facing = value; UpdateFacing(); } get { return facing; } }
    private AnimateController animate;
    private new Rigidbody2D rigidbody2D;
    private void Awake() {
        animate = GetComponent<AnimateController>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        facing = Random.Range(1,4);
    }
    void Start()
    {
        UpdateFacing();
        
        Invoke("RandomizeWanted",Random.Range(0, 15));
    }
    private void RandomizeWanted(){
        int r = Random.Range(1, 5);
        SetWanted(r, GameManager.instance.foods[r-1]);
        
        Invoke("RandomizeWanted",Random.Range(5, 15));
    }
    void UpdateFacing(){
        if(facing==1)
            animate.SetMoveState(AnimateState.Sit, AnimateDirection.Right);
        else if(facing==3)
            animate.SetMoveState(AnimateState.Sit, AnimateDirection.Left);
        else
            animate.SetMoveState(AnimateState.Idle, AnimateDirection.Down);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            SetWanted(testFood.id, testFood);
        }
    }
    public bool TakeFood(Food food){
        if(food==null) { Debug.LogError("Food null!"); return false; }
        if(!CanTakeFood()) { Debug.Log("Not want!"); return false; }
        if(wantsID == food.id){
            GameManager.instance.AddScore(1);
        } else {
            GameManager.instance.AddScore(-1);
        }
        SetWanted(0);
        return true;
    }
    public bool CanTakeFood(){
        return wantsID != 0;
    }
    [SerializeField] int wantsID = 0;
    public void SetWanted(int want, Food f = null){
        if(want!=0)
            wishSprite.sprite = f.sprite;
        msgBox.SetActive(want!=0);
        wantsID = want;
    }
}
