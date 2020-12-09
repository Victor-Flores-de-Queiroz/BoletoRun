using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float moveY;
    
    public float life;
    public float PlayerMaxValue;

    public bool Dead;
    private int countDead;// contador para a próxima cena n aparecer imediatamente

    public int points;
    public int lightTax;
    public bool so_luz;
    public bool boolLight;
    public int waterTax;

    public float limitLight;
    private float countLight;

    public Slider sl;
    private Transform tr;
    public Text txtTop;
    public Text txtBottom;
    public Animator anim;
    public Challenge cll;
    public SpriteMask sprM;
    private Transform T_sprM;
    public SceneLoader scl;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        T_sprM = sprM.GetComponent<Transform>();
        T_sprM.localScale = new Vector3(350,350,1);
        cll.so_luz = so_luz;
        upLight(2);
        sl.maxValue = PlayerMaxValue;
        sl.value = 0;
        points = 0;
        UpdateTextBottom();
        UpdateTextTop();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead",false);
        countLight = 0;
        Dead = false;
        countDead = 600;
    }

    // Update is called once per frame
    void Update()
    {
        if(sl.value < sl.maxValue){
            
            movimentarPlayer();

            sl.value+=life;
            
            funcLight();

        }else{
            if(!Dead){
                anim.SetBool("Dead",true);
                cll.parar=true;
                Dead = true;
            }else{
                countDead--;
                if(countDead<=1){
                    scl.LoadScene(1);
                }
            }
            
            
        }
    }

    void movimentarPlayer(){
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
    }

    void funcLight(){
        if(lightTax>0&&boolLight){
            countLight++;
            if(countLight == limitLight){
                upLight(-1);
                countLight=0;
            }
        }
        moveLigth();
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
        if(lgt>0){
            sl.value+=lgt*10;
        }
        UpdateTextTop();
    }

    public void moveLigth(){
        if(lightTax<1){
            if(T_sprM.localScale.x>50&&T_sprM.localScale.y>50){
                T_sprM.localScale = new Vector3(T_sprM.localScale.x-0.05f,T_sprM.localScale.y-0.05f,1);
                boolLight = false;
            }
        }else{
            if(T_sprM.localScale.x<350&&T_sprM.localScale.y<350){
                T_sprM.localScale = new Vector3(T_sprM.localScale.x+0.5f,T_sprM.localScale.y+0.5f,1);
            }else{
                boolLight = true;
            }
        }
    }

    public void upWater(int wtr){
        waterTax+=wtr;
        if(wtr>0){
            sl.value+=wtr*10;
        }
        UpdateTextTop();
    }
}
