using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    public float speed;

    public int show;

    public bool parar;
    public bool done;

    public GameObject spr1;
    public GameObject spr2;
    public GameObject spr3;
    public Player player;

    private Block block1;
    private Block block2;
    private Block block3;

    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        block1 = spr1.GetComponent<Block>();
        block2 = spr2.GetComponent<Block>();
        block3 = spr3.GetComponent<Block>();
        show = 0;
        Restart();
        parar = false;
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = tr.position - (tr.right*speed);
        if(!parar){
            if(tr.position.x <= -14){
                Restart();
            }
        }else{
            if(speed>0.00000001f){
                speed-=0.000075f;
            }else{
                speed = 0;
            }
            
        }
        
    }

    void Restart(){
        tr.position = new Vector2(14,-1);
        DeactiveAll();
        show++;
        ActiveThisCase();
        done = false;
    }

    void DeactiveAll(){
        spr1.SetActive(false);
        spr2.SetActive(false);
        spr3.SetActive(false);
    }

    void ActiveAll(){
        spr1.SetActive(true);
        spr2.SetActive(true);
        spr3.SetActive(true);
    }

    void ActiveThisCase(){
        if(show % 7 == 0){
            spr1.SetActive(true);
            block1.next = true;
        }else if(show % 7 == 1){
            spr2.SetActive(true);
            block2.next = true;
        }else if(show % 7 == 2){
            spr3.SetActive(true);
            block3.next = true;
        }else if(show % 7 == 3){
            spr1.SetActive(true);
            block1.next = true;
            spr2.SetActive(true);
            block2.next = true;
        }else if(show % 7 == 4){
            spr1.SetActive(true);
            block1.next = true;
            spr3.SetActive(true);
            block3.next = true;
        }else if(show % 7 == 5){
            spr2.SetActive(true);
            block2.next = true;
            spr3.SetActive(true);
            block3.next = true;
        }else{
            spr2.SetActive(true);
            block2.next = true;
            spr3.SetActive(true);
            block3.next = true;
        }
    }
}
