using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public SpriteRenderer sprR;
    public Sprite duzentos_reais;
    public Sprite cinco_reais;
    public Sprite dois_reais;
    public Sprite dez_reais;
    public Sprite cinquenta_reais;
    public Sprite cem_reais;
    public Sprite vinte_reais;
    public Sprite icone_luz;
    public Sprite icone_agua;
    public Transform tr;

    public int value;
    public int type;

    public int count;
    public bool next;
    public bool touch;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        sprR = GetComponent<SpriteRenderer>();
        next = false;
        touch = false;
        type = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(next){
            NextSprite();
            next = false;
        }
    }

    void NextSprite()
    {
        count = Random.Range(0,9);
        if(count == 0){
            sprR.sprite = duzentos_reais;
            value = 200;
            type = 0;
        }else if(count == 1){
            sprR.sprite = cinco_reais;
            value = 5;
            type = 0;
        }else if(count == 2){
            sprR.sprite = dez_reais;
            value = 10;
            type = 0;
        }else if(count == 3){
            sprR.sprite = cem_reais;
            value = 100;
            type = 0;
        }else if(count == 4){
            sprR.sprite = cinquenta_reais;
            value = 50;
            type = 0;
        }else if(count == 5){
            sprR.sprite = vinte_reais;
            value = 20;
            type = 0;
        }else if(count == 6){
            sprR.sprite = dois_reais;
            value = 2;
            type = 0;
        }else if(count == 7){
            sprR.sprite = icone_luz;
            value = 1;
            type = 1;
        }else{
            sprR.sprite = icone_agua;
            value = 1;
            type = 2;
        }
    }
    //TODO: Fix the collision with player
    void OnTriggerEnter2D(Collider2D other){
        if(type == 1){
            other.GetComponent<Player>().upLight(value);
        }else if(type == 2){
            other.GetComponent<Player>().upWater(value);
        }else {
            other.GetComponent<Player>().setScore(value);
        }
        GetComponent<Transform>().gameObject.SetActive(false);
    }
}
