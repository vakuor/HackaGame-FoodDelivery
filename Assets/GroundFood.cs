using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFood : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] public Food food;
    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = food.sprite;
    }
    
}
