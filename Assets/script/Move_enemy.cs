using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_enemy : MonoBehaviour{
    public int serialID=1;
    public float speed=5.0f;
    void Update(){
        if(serialID==1){
            transform.Translate(Vector3.forward* Time.deltaTime*speed);
        }if(serialID==2){
            transform.Translate(Vector3.back* Time.deltaTime*speed);
        }
        
        }
         
    }

