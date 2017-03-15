using UnityEngine;
using System.Collections;

public class OuroRotacao : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(0,0,45 * Time.deltaTime);
        
	}
}
