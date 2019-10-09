﻿using UnityEngine;
using System.Collections;

public class PickupMultiObjects : MonoBehaviour
{

    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fired Pressed");
            Debug.Log(Input.mousePosition);

            Vector3 mp = Input.mousePosition; //get Screen Position

            //create ray, origin is camera, and direction to mousepoint
            Camera ca;
            if (cam != null) ca = cam.GetComponent<Camera>();
            else ca = Camera.main;

            Ray ray = ca.ScreenPointToRay(Input.mousePosition);

            //Return the ray's hits
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits)
            {
                print(hit.transform.gameObject.name);
                if (hit.collider.gameObject.tag.Contains("Finish"))
                { //plane tag
                    Debug.Log("hit " + hit.collider.gameObject.name + "!");
                }
                Destroy(hit.transform.gameObject);
                
            }
            Destroy(this);
        }
    }
}