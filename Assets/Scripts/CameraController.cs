using UnityEngine;

public class CameraController : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 forwardForce;
    float camSens = 0.25f;
    public Vector3 lastMouse = new Vector3(255, 255, 255);

	// Use this for initialization
	void Start () {
       
       
      
	}
	
	// Update is called once per frame
	void Update () {
       
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        forwardForce = transform.forward * 4;
       
        rb.AddForce(forwardForce);

        if (Input.GetMouseButton(1))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
