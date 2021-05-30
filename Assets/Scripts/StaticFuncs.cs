using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticFuncs
{
    public static Component GetClosestComponent(Component[] components, Vector2 position){
        if(components.Length<=0) return null;
        float dist = float.MaxValue;
        Component closest = null;
        foreach(Component comp in components){
            float localDist = Vector2.Distance(position, comp.transform.position);
            if(localDist<dist) {
                dist = localDist;
                closest = comp;
            }
        }
        return closest;
    }
}
