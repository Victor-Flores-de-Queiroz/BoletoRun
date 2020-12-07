using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    

    public float moveY;
    
    public float life;
    public float PlayerMaxValue;

    public bool cash;

    public int points;
    public int lightTax;
    public int waterTax;

    public Slider sl;
    private Transform tr;
    public Text txtTop;
    public Text txtBottom;
    public Animator anim;
    public Challenge cll;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        sl.maxValue = PlayerMaxValue;
        sl.value = 0;
        points = 0;
        UpdateTextBottom();
        UpdateTextTop();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead",false);
    }

    // Update is called once per frame
    void Update()
    {
        if(sl.value < sl.maxValue){
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
                setScore(50);
                cash = false;
            }
        }else{
            anim.SetBool("Dead",true);
            cll.parar=true;
        }
    }

    void UpdateTextBottom(){
        txtBottom.text = "Score: "+points;
    }

    void UpdateTextTop(){
        txtTop.text = "Light: "+lightTax+" /Water: "+waterTax+"";
    }

    public void setScore(int scr){
        points+=scr;
        sl.value-=scr;
        UpdateTextBottom();
    }

    public void upLight(int lgt){
        lightTax+=lgt;
        UpdateTextTop();
    }

    public void upWater(int wtr){
        waterTax+=wtr;
        UpdateTextTop();
    }
}
