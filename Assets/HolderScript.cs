using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HolderScript : MonoBehaviour
{
    [HideInInspector]
    public bool inRange = false;
    
    public string infoTitle = "";
    [TextArea]
    public string infoDesc = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getTitle() { return infoTitle; }

    public string getDesc() { return infoDesc; }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            inRange = false;
            Camera.main.GetComponent<CameraRay>().Close();
        }
    }
}
