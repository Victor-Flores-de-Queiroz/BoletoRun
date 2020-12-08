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
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        T_sprM = sprM.GetComponent<Transform>();
        upLight(5);
        sl.maxValue = PlayerMaxValue;
        sl.value = 0;
        points = 0;
        UpdateTextBottom();
        UpdateTextTop();
        anim = GetComponent<Animator>();
        anim.SetBool("Dead",false);
        countLight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sl.value < sl.maxValue){
            if(Input.GetKeyDown(KeyCode.W)){
                if(tr.position.y < 0){
                    tr.position = new Vector2(tr.position.x,(tr.position.y+moveY));
                    //T_sprM.position = new Vector2(tr.position.x,(tr.position.y+moveY));
                }
            }

            if(Input.GetKeyDown(KeyCode.S)){
                if(tr.position.y > -1){
                    tr.position = new Vector2(tr.position.x,(tr.position.y-moveY));
                    //T_sprM.position = new Vector2(tr.position.x,(tr.position.y-moveY));
                }
            }

            sl.value+=life;
            
            funcLight();

            
            if(cash){
                setScore(50);
                cash = false;
            }
        }else{
            anim.SetBool("Dead",true);
            cll.parar=true;
        }
    }

    void funcLight(){
        if(lightTax>0){
            countLight++;
            if(countLight == limitLight){
                upLight(-1);
                countLight=0;
            }
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
        if(lgt>0){
            sl.value=lgt*10;
        }
        T_sprM.localScale = new Vector2((50*(lightTax+1))+(50*lightTax),50*(lightTax+1)+(50*lightTax));
        UpdateTextTop();
    }

    public void upWater(int wtr){
        waterTax+=wtr;
        if(wtr>0){
            sl.value+=wtr*10;
        }
        UpdateTextTop();
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Here");
    }
}
