using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFood : Pickable
{
    SpriteRenderer sprite;
    [SerializeField] public Food food;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = food.sprite;
    }
    public override Object Pick(){
        return food;
    }
    public override void OnPicked()
    {
        Debug.Log("Ground food picked!");
        base.OnPicked();
    }
    public override bool CanPick()
    {
        return true;
    }
}
