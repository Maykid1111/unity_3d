using UnityEngine;
using System.Collections;
using SimpleFactory;

public class FirstController : MonoBehaviour, SceneController
{
    //private Role[] Priests;
    //private Role[] Devils;
    
    private const float TIME= 2.0f;
    private float timer = TIME;

    private const float TIME1 = 20.0f;
    private float timer1 = TIME1;


    private int roundd;
    private int grade=0;//1~5分别为1~5分

    private UserGUI mygui;
    UFO1Factory fctory1;
    UFO2Factory fctory2;
    UFO3Factory fctory3;
    UFO4Factory fctory4;
    UFO5Factory fctory5;
    // Update is called once per frame
    float[] probArray = { 0.5f, 0.25f, 0.2f, 0.05f };
    
    public int Choose(float[] probe)
    {
        float total = 0.0f;
        for (int i = 0; i < probe.Length; i++)
        {
            total += probe[i];
        }

        // Random.value方法返回一个0—1的随机数
        float randomPoint = Random.value * total;

        for (int i = 0; i < probe.Length; i++)
        {
            if (randomPoint < probe[i])
                return i;
            else
                randomPoint -= probe[i];
        }

        return probe.Length - 1;
    }

    // Use this for initialization
    void Start () {
        //初始化
        roundd = 1;
        Director director = Director.GetInstance();
        director.scene = this;
        //Debug.Log("123");
        fctory1 = new UFO1Factory();
        fctory2 = new UFO2Factory();
        fctory3 = new UFO3Factory();
        fctory4 = new UFO4Factory();
        fctory5 = new UFO5Factory();
        this.load();
        /*while (roundd != 10)
        {
            if (mygui.getstate()==0)
            {
                game(roundd);
            }
        }*/
        


    }
    void OnGUI()
    {
        mygui.display();

    }
    public void load()
    {
        mygui = new UserGUI();
    }
	// Update is called once per frame
	void Update () {

        //roundd = mygui.getround();     
        timer -= Time.deltaTime;
        timer1 -= Time.deltaTime;
        if (timer <= 0)
        {
            game(roundd);
            timer = TIME;
                 
        }
        if (timer1 <= 0)
        {
            GameObject[] obj; //定义
            obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
            

            for (int i = 0; i < obj.Length; i++)
            {
                Debug.Log(obj[i]);
                if (obj[i] != null)
                {
                    if (obj[i].name == "UFO_body1")
                    {
                        grade -= 1;
                        Destroy(obj[i]);
                        continue;
                    }

                    if (obj[i].name == "UFO_body2")
                    {
                        grade -= 2;
                        Destroy(obj[i]);
                        continue;
                    }
                    if (obj[i].name == "UFO_body3")
                    {
                        grade -= 3;
                        Destroy(obj[i]);
                        continue;
                    }
                    if (obj[i].name == "UFO_body4")
                    {
                        grade -= 4;
                        Destroy(obj[i]);
                        continue;
                    }
                    if (obj[i].name == "UFO_body5")
                    {
                        grade -= 5;
                        Destroy(obj[i]);
                        continue;
                    }
                    if (obj[i].name == "UFO5"|| obj[i].name == "UFO4" || obj[i].name == "UFO3" || obj[i].name == "UFO2" || obj[i].name == "UFO1" )
                    {
                        Destroy(obj[i]);
                        continue;
                    }

                }
            }


            timer1 = TIME1;
            mygui.setstate();
            roundd++;
            mygui.setgrate(grade);
            Debug.Log(roundd);
            Debug.Log(grade);
            

            grade = 0;
        }
        
    }
    
    public void game(int Round)
    {
        if (mygui.getstate()!=0)
        {
            return;
        }
        UFO ufo1 = fctory1.Create();
        UFO ufo2 = fctory2.Create();
        UFO ufo3 = fctory3.Create();
        UFO ufo4 = fctory4.Create();
        UFO ufo5 = fctory5.Create();
        int random=0;

        random = Choose(probArray);

        switch (random)
        {
            case 0:
                ufo1.Version(Round);
                grade += 1;
                break;
            case 1:
                grade += 2;
                ufo2.Version(Round);
                break;
            case 2:
                grade += 3;
                ufo3.Version(Round);
                break;
            case 3:
                grade += 4;
                ufo5.Version(Round);
                break;
            default:
                grade += 5;
                ufo5.Version(Round);
                break;
        }
    }
    

}
