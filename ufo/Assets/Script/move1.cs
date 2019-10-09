using UnityEngine;
using System.Collections;

public class move1 : MonoBehaviour {
    public float speedX = 5.0F;
    public float speedY = 5.0F;
    public float speedZ = 5.0F;
    // Use this for initialization
    float rand1 = Random.Range(-1.0f, 1.0f);
    float rand2 = Random.Range(-1.0f, 1.0f);
    float rand3 = Random.Range(-1.0f, 1.0f);

    float randx;
    float randy;
    


    void Start () {
        randx = Random.Range(-1.0f, 1.0f);
        randy = Random.Range(-1.0f, 1.0f);
        //Debug.Log(randx);
        //Debug.Log(randy);
        if (randx>0)
            randx = 1.0f;
        else
            randx = -1.0f;

        if (randy >0)
            randy = 1.0f;
        else
            randy = -1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        
        float translationY = 1 * speedY*rand1*randx;
        
        float translationX = 1 * speedX*rand2*randy;
        
        float translationZ = 1 * speedZ;
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;
        //transform.Translate(0, translationY, 0);
        //transform.Translate(translationX, 0, 0);
        transform.Translate(translationX, translationY, translationZ);
        
    }
    

}
