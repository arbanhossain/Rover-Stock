using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraRay : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    [SerializeField] private TMP_Text Title;
    [SerializeField] private TMP_Text Desc;
    [SerializeField] private GameObject group;

    [SerializeField] private TMP_Text BottomHUD;

    // Start is called before the first frame update
    void Start()
    {
        group.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit)) {
            // Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.tag == "Finish") {
                HolderScript holder = hit.transform.gameObject.GetComponent<HolderScript>();
                if(holder.inRange) {
                    if (!group.activeSelf) BottomHUD.SetText($"<color=\"yellow\">Press to read more.</color>");
                    // Debug.Log($"You are looking at {hit.transform.gameObject.name}");
                    if (Input.GetMouseButtonDown(0)) {
                        if (group.activeSelf) {
                            group.SetActive(false);
                        } else {
                            BottomHUD.SetText("");
                            Title.SetText(holder.getTitle());
                            Desc.SetText(holder.getDesc());
                            group.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    public void Close() {
        BottomHUD.SetText("");
        group.SetActive(false);
    }
}
