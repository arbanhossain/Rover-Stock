using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouseXSensitivity;
    [SerializeField]
    private float mouseYSensitivity; 

    private Vector3 movementUpdate;
    private Vector3 lookUpdate;

    public WebXRController controller;

    public Camera cam;

    void Start() {
        // controller = GetComponent<WebXRController>();
        // System.Reflection.MethodInfo[] methods = typeof(WebXRManager).GetMethods();
        // System.Reflection.PropertyInfo[] property = typeof(WebXRManager).GetProperties(); 
        // // foreach (System.Reflection.MethodInfo method in methods) {
        // //     Debug.Log($"{method.Name} - {method.ReturnType}");
        // // }
        // foreach (System.Reflection.PropertyInfo prop in property) {
        //     Debug.Log($"{prop.Name} - {prop.PropertyType}");
        // }
        // Debug.Log(WebXRManager.Instance.isSupportedVR);
    }

    void FixedUpdate()
    {
        // this.UpdateLook();
        // check if the current client is webxr
        // if (WebXRManager.Instance.isSupportedVR) {
        //     // if so, use the webxr controller
        //     this.UpdateControls();
        // } else {
        //     // otherwise, use the mouse and keyboard
        //     this.UpdateLook();
        //     this.UpdateMovement();
        // }
        UpdateControls();
    }

    private void UpdateLook()
    {
        float xRot = Input.GetAxis("Mouse Y") * this.mouseYSensitivity;
        float yRot = Input.GetAxis("Mouse X") * this.mouseXSensitivity;

        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        Camera.main.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
    }

    private void UpdateMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");                

        if (h != 0 || v != 0)
        {
            this.transform.position += (this.transform.forward * v + this.transform.right * h) * this.speed * Time.deltaTime; 
        }
    }

    internal void SetForward(Vector3 forward)
    {
        this.transform.localRotation = Quaternion.LookRotation(forward, Vector3.up);
        Camera.main.transform.localRotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);                    
    }

    private void UpdateControls() {
        // listen for analog stick movement and move transform
        float h = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick).x;
        float v = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick).y;

        if (h != 0 || v != 0)
        {
            this.transform.position += (cam.transform.forward * v + cam.transform.right * h) * this.speed * Time.deltaTime; 
        }
    }

}
