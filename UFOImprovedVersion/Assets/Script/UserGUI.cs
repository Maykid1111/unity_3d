using UnityEngine;
using System.Collections;

public class UserGUI : MonoBehaviour {
    private int state = -1;//-1没开始，0开始，1结束
    private int round = 0;
    private string grate ="Grade:";


    public UserGUI()
    {
        state = -1;
    }
    // Use this for initialization
    
    public int getround()
    {
        return round;
    }
    public void display()
    {
        OnGUI();
    }
    // Update is called once per frame
    void Update () {
	
	}

    

    void OnGUI()
    {

        if (state == -1)
        {
            if(GUI.Button(new Rect(300, 100, 100, 50), "Start"))
            {
                state = 0;
            }
        }

        else if (state == 1)
        {
            if (GUI.Button(new Rect(300, 100, 100, 50), "NextRound"))
            {
                round++;
                state = 0;
                grate = "Grade:";
            }
            if (GUI.Button(new Rect(200, 100, 100, 50), grate))
            {
                round++;
                state = 0;
            }

        }
        
        
        
        //if (round!=10&&state==1)
        

    }

    public int getstate()
    {
        return state;
    }

    public int setstate()
    {
        state = 1;
        return state;
    }

    public int setgrate(int i)
    {
        grate += i.ToString();
        Debug.Log(grate);
        
        return i;
        
    }
}
