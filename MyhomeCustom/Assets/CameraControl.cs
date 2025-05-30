using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraMode
{
    FirstPerson,
    TopDown,
    Orbit360
}

public class CameraControl : MonoBehaviour
{
    CameraMode currentMode = CameraMode.TopDown;        // 시작시 기본 모드는 탑 다운 뷰w

    Quaternion dir;
    public GameObject Firstperson_position;
    public GameObject TopDown_position;
    public GameObject Orbit360;

    public float speed = 0.5f;
    public float rotate_speed = 2.0f;
    public float wheel_speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        dir = transform.localRotation;
        //Debug.Log("dir" + dir);

        switch (currentMode)
        {
            case CameraMode.FirstPerson:
                FirstPersonControl();
                break;

            case CameraMode.TopDown:
                TopDownControl();
                break;

            case CameraMode.Orbit360:
                Orbit360Control();
                break;
        }
    }


    void FirstPersonControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1f, 0) * rotate_speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1f, 0) * rotate_speed, Space.Self);
        }
    }

    void TopDownControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * speed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed, Space.World);
        }
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel"); 

        if (wheelInput > 0)
        {
            this.transform.Translate(Vector3.up * wheel_speed, Space.World);
        }    
        else if (wheelInput < 0)    
        {
            this.transform.Translate(Vector3.down * wheel_speed, Space.World);
        }
        
    }

    void Orbit360Control()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * speed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.back * speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1f, 0) * rotate_speed, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 1f, 0) * rotate_speed, Space.Self);
        }
    }

    public void ButtonEventFirstPerson()
    {
        currentMode = CameraMode.FirstPerson;
        this.transform.position = Firstperson_position.transform.position;
        this.transform.rotation = Firstperson_position.transform.rotation;
    }

    public void ButtonEvenTopDown()
    {
        currentMode = CameraMode.TopDown;
        this.transform.position = TopDown_position.transform.position;
        this.transform.rotation = TopDown_position.transform.rotation;
    }

    public void ButtonEventOrbit()
    {
        currentMode = CameraMode.Orbit360;
        this.transform.position = Orbit360.transform.position;
        this.transform.rotation = Orbit360.transform.rotation;
    }

}
