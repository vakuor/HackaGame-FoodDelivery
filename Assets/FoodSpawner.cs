using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoodStash))]
public class FoodSpawner : Pickable
{
    FoodStash stash;
    [SerializeField] int initStashSize = 4;
    [SerializeField] Food food;
    private Food ReceiveFood(){
        return stash.PopFood();
    }
    private void Awake() {
        stash = GetComponent<FoodStash>();
        stash.maxFood = initStashSize;
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
        stash.PushFood(food);
    }
    public override Object Pick()
    {
        Debug.Log("Pick");
        return ReceiveFood();
    }
    public override void OnPicked()
    {
        Debug.Log("Food stash picked!");
    }
    public override bool CanPick()
    {
        return stash.CanPopFood();
    }
}
