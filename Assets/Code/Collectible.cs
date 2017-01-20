using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	
	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
