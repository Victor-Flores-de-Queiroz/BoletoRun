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

    public int value;

    public int count;
    public bool next;
    // Start is called before the first frame update
    void Start()
    {
        sprR = GetComponent<SpriteRenderer>();
        next = false;
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
        count = Random.Range(0,7);
        if(count == 0){
            sprR.sprite = duzentos_reais;
            value = 200;
        }else if(count == 1){
            sprR.sprite = cinco_reais;
            value = 5;
        }else if(count == 2){
            sprR.sprite = dez_reais;
            value = 10;
        }else if(count == 3){
            sprR.sprite = cem_reais;
            value = 100;
        }else if(count == 4){
            sprR.sprite = cinquenta_reais;
            value = 50;
        }else if(count == 5){
            sprR.sprite = vinte_reais;
            value = 20;
        }else{
            sprR.sprite = dois_reais;
            value = 2;
        }
    }
    //TODO: Fix the collision with player
    void OnTriggerEnter2D(Collider2D other){
        //other.GetComponent<Player>().takeDamage(value);
        //GetComponent<Transform>().GameObject.SetActive(false);
        Debug.Log("Tocou no valor: "+value);
    }
}
