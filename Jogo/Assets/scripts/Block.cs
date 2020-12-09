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

    public bool so_luz;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        sprR = GetComponent<SpriteRenderer>();
        next = false;
        touch = false;
        type = 0;
        so_luz = true;
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
        if(so_luz){
            count = Random.Range(0,31);
            if(count == 0){
                sprR.sprite = duzentos_reais;
                value = 200;
                type = 0;
            }else if(count == 1|| count == 8){
                sprR.sprite = cem_reais;
                value = 100;
                type = 0;
            }else if(count == 2|| count == 9 || count == 15){
                sprR.sprite = cinquenta_reais;
                value = 50;
                type = 0;
            }else if(count == 3|| count == 10 || count == 16 || count == 21){
                sprR.sprite = vinte_reais;
                value = 20;
                type = 0;
            }else if(count == 4|| count == 11 || count == 17 || count == 22){
                sprR.sprite = dez_reais;
                value = 10;
                type = 0;
            }else if(count == 5|| count == 12 || count == 18 || count == 23 || count == 26){
                sprR.sprite = cinco_reais;
                value = 5;
                type = 0;
            }else if(count == 6||count == 13 || count == 19 || count == 24 || count == 27){
                sprR.sprite = dois_reais;
                value = 2;
                type = 0;
            }else {// 7 || 14 || 20 || 25 || 28 || 29 || 30
                sprR.sprite = icone_luz;
                value = 1;
                type = 1;
            }    
        }else{
            count = Random.Range(0,37);
        if(count == 0){
            sprR.sprite = duzentos_reais;
            value = 200;
            type = 0;
        }else if(count == 1|| count == 9){
            sprR.sprite = cem_reais;
            value = 100;
            type = 0;
        }else if(count == 2|| count == 10 || count == 17){
            sprR.sprite = cinquenta_reais;
            value = 50;
            type = 0;
        }else if(count == 3|| count == 11 || count == 18 || count == 25){
            sprR.sprite = vinte_reais;
            value = 20;
            type = 0;
        }else if(count == 4|| count == 12 || count == 19 || count == 26){
            sprR.sprite = dez_reais;
            value = 10;
            type = 0;
        }else if(count == 5|| count == 13 || count == 20 || count == 27 || count == 31){
            sprR.sprite = cinco_reais;
            value = 5;
            type = 0;
        }else if(count == 6||count == 14 || count == 21 || count == 28 || count == 32){
            sprR.sprite = dois_reais;
            value = 2;
            type = 0;
        }else if(count == 7|| count == 15 || count == 22 || count == 29 || count == 33 || count == 35){
            sprR.sprite = icone_luz;
            value = 1;
            type = 1;
        }else{//8 || 16 || 23 || 30 || 34 || 36
            sprR.sprite = icone_agua;
            value = 1;
            type = 2;
        }
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
