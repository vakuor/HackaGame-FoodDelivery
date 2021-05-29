using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStash : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] sprites;
    Stack<Food> foodStack = new Stack<Food>();
    [SerializeField] int maxFood = 4;
    public bool AddFood(Food food){
        if(foodStack.Count >= maxFood -1) return false;
        foodStack.Push(food);
        sprites[foodStack.Count].sprite = food.sprite;
        return true;
    }
}
