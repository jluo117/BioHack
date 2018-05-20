using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class Logic : MonoBehaviour {
    public AudioClip gunshot;
    public AudioSource gunshotSource;
    public AudioClip beat;
    public AudioSource beatSource;
    public AudioClip siren;
    public AudioClip policeCall;
    public GameObject deadPerson;
    public GameObject towel;
    public GameObject phone;
    public float countDown = 27.0f;
    public bool inScene = false;
    public float startTime = 1.1f;
    public bool start = false;
    public bool police = false;
    public bool pulse = false;
    public bool win = false;
	// Use this for initialization
	void Start () {
        gunshotSource.clip = gunshot;
        gunshotSource.Play();
        beatSource.clip = beat;
        towel.name = "towel";
        deadPerson.name = "gotShot";
	}
	
	// Update is called once per frame
	void Update () {
        if (!inScene)
        {
            startTime -= Time.deltaTime;
            if (startTime < 0.0)
            {
                gunshotSource.clip = gunshot;
                gunshotSource.Play();
                this.transform.position = new Vector3((float)-0.089, 0, (float)7.36);
                inScene = true;
                return;
            }
            return;
        }
		if (phone.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (!start)
            {
                gunshotSource.clip = policeCall;
                gunshotSource.Play();
                start = true;
                
            }
        }
        if (!pulse)
        {
            if (deadPerson.GetComponent<OVRGrabbable>().isGrabbed)
            {

                if (!pulse)
                {
                    pulse = true;
                    beatSource.Play();
                    Destroy(deadPerson);
                }
            }
        }
        
     
        if (start)
        {
            countDown -= Time.deltaTime;
           // print(countDown);
        }
       
           
            
        

        if ((countDown < 17.0f) && (!police) )
        {
            police = true;
            gunshotSource.clip = siren;
            gunshotSource.Play();
            return;
        }
        if ((!win) && (countDown < -1.0f))
        {
            this.transform.position = new Vector3((float)7732, (float)1.0, (float)-525);
            win = true;
        }

    }
   
}
//7732
//0.5034597
//-525
