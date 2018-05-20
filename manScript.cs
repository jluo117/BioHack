using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manScript : MonoBehaviour {
    public  Texture bloodyCloth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "towel")
        {
            other.GetComponent<Material>().SetTexture(name: "_MainTex", value: bloodyCloth);
        }
    }
}
//0.07652575
//0.4203942