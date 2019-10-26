using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Patrols;

public class HeroStatus : MonoBehaviour {
    public int state = -1;

	void Start () {
		
	}
	
	void Update () {
        ifyStandOnArea();
	}

    void ifyStandOnArea() {
        float posX = this.gameObject.transform.position.x;
        float posY = this.gameObject.transform.position.y;
        float posZ = this.gameObject.transform.position.z;
        if (posZ >= FenchLocation.FenchHori) {
            if (posX < FenchLocation.FenchVertLeft)
                state = 0;
            else if (posX > FenchLocation.FenchVertRight)
                state = 2;
            else
                state = 1;
        }
        else {
            if (posX < FenchLocation.FenchVertLeft)
                state = 3;
            else if (posX > FenchLocation.FenchVertRight)
                state = 5;
            else
                state = 4;
        }

        if (posY < -1f)
        {
            state = -1;
        }
    }
}
