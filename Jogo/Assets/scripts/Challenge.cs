using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    public float speed;

    public int show;

    public GameObject spr1;
    public GameObject spr2;
    public GameObject spr3;

    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        show = 0;
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = tr.position - (tr.right*speed);
        if(tr.position.x <= -9.5f){
            show++;
            Restart();
        }
    }

    void Restart(){
        tr.position = new Vector2(9.5f,0);
        spr1.SetActive(false);
        spr2.SetActive(false);
        spr3.SetActive(false);
        if(show % 3 == 0){
            spr1.SetActive(true);
        }else if(show % 3== 1){
            spr2.SetActive(true);
        }else if(show % 3 == 2){
            spr3.SetActive(true);
        }else{
            spr1.SetActive(false);
            spr2.SetActive(false);
            spr3.SetActive(false);
        }
    }
}
