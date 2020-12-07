using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Transform tr;

    public float moveY;
    
    public float life;

    public bool cash;

    public float PlayerMaxValue;
    public Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        sl.maxValue = PlayerMaxValue;
        sl.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            if(tr.position.y < 0){
                tr.position = new Vector2(tr.position.x,(tr.position.y+moveY));
            }
        }

        if(Input.GetKeyDown(KeyCode.S)){
            if(tr.position.y > -1){
                tr.position = new Vector2(tr.position.x,(tr.position.y-moveY));
            }
        }

        sl.value+=life;

        if(cash){
            sl.value-=50;
            cash = false;
        }
    }
}
