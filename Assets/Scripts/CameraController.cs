using UnityEngine;
/*
public class CameraController : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 forwardForce;
    float camSens = 0.5f;
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

       // forwardForce = transform.forward * 100;


		rb.velocity = transform.forward * 100;
	
       
      //  rb.AddForce(forwardForce);

        if (Input.GetMouseButton(1))
        {
            rb.velocity = Vector3.zero;
        }



	
    }
}
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class CameraController : MonoBehaviour {
	public int pizzaSpeed;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;
	private List<float> rotArrayY = new List<float>();
	float rotAverageY = 0F;
	public float frameCounter = 20;
	Quaternion originalRotation;
	public Rigidbody rb;



	void Update ()
	{

		if (Input.GetKey (KeyCode.Escape)) {
			//Screen.lockCursor = false;
			Cursor.visible = true;
		} else {
			Cursor.visible = false;

			Cursor.lockState = CursorLockMode.Locked;
			//Cursor.lockState = CursorLockMode.None;

			//Screen.lockCursor = true;

			if (axes == RotationAxes.MouseXAndY) {
				//Resets the average rotation
				rotAverageY = 0f;
				rotAverageX = 0f;

				//Gets rotational input from the mouse
				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
				rotationX += Input.GetAxis ("Mouse X") * sensitivityX;

				//Adds the rotation values to their relative array
				rotArrayY.Add (rotationY);
				rotArrayX.Add (rotationX);

				//If the arrays length is bigger or equal to the value of frameCounter remove the first value in the array
				if (rotArrayY.Count >= frameCounter) {
					rotArrayY.RemoveAt (0);
				}
				if (rotArrayX.Count >= frameCounter) {
					rotArrayX.RemoveAt (0);
				}

				//Adding up all the rotational input values from each array
				for (int j = 0; j < rotArrayY.Count; j++) {
					rotAverageY += rotArrayY [j];
				}
				for (int i = 0; i < rotArrayX.Count; i++) {
					rotAverageX += rotArrayX [i];
				}

				//Standard maths to find the average
				rotAverageY /= rotArrayY.Count;
				rotAverageX /= rotArrayX.Count;

				//Clamp the rotation average to be within a specific value range
				rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
				rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);

				//Get the rotation you will be at next as a Quaternion
				Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
				Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);

				//Rotate
				transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			} else if (axes == RotationAxes.MouseX) {        
				rotAverageX = 0f;
				rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
				rotArrayX.Add (rotationX);
				if (rotArrayX.Count >= frameCounter) {
					rotArrayX.RemoveAt (0);
				}
				for (int i = 0; i < rotArrayX.Count; i++) {
					rotAverageX += rotArrayX [i];
				}
				rotAverageX /= rotArrayX.Count;
				rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
				Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
				transform.localRotation = originalRotation * xQuaternion;        
			} else {        
				rotAverageY = 0f;
				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
				rotArrayY.Add (rotationY);
				if (rotArrayY.Count >= frameCounter) {
					rotArrayY.RemoveAt (0);
				}
				for (int j = 0; j < rotArrayY.Count; j++) {
					rotAverageY += rotArrayY [j];
				}
				rotAverageY /= rotArrayY.Count;
				rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
				Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
				transform.localRotation = originalRotation * yQuaternion;
			}

		}

		if (Input.GetMouseButton (0)) {
			rb.velocity = transform.forward * pizzaSpeed * 5;
		} else {
			rb.velocity = transform.forward * pizzaSpeed;
		}


		//  rb.AddForce(forwardForce);

		if (Input.GetMouseButton(1))
		{
			rb.velocity = Vector3.zero;
		}
	}
	void Start ()
	{    
		Rigidbody rb = GetComponent<Rigidbody>();
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}        
		}
		return Mathf.Clamp (angle, min, max);
	}
}

