using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ObjectMaker : MonoBehaviour
{
    public Texture2D cursurIcon;
    public GameObject target;
    public GameObject wall;

    int on_click_button_wall =0;

    Vector3 firstClick;
    Vector3 SecondeClick;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.SetCursor(cursurIcon, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        ObjMakeWall();

    }

    void ObjMakeWall()
    {
        if(on_click_button_wall > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Hit Object : " + hit.collider.gameObject.name);

                    Debug.Log("HIt Point (World Position) : " + hit.point);

                    Vector3 point = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
                    Instantiate(target, point, Quaternion.identity);
                    Debug.Log("Hit Point (World Position : )" + point);
                    if(on_click_button_wall == 2)
                    {
                        firstClick = point;
                    }
                    else if(on_click_button_wall == 1)
                    {
                        SecondeClick = point;
                        float angle = Mathf.Atan2(firstClick.x - SecondeClick.x, firstClick.z - SecondeClick.z) * Mathf.Rad2Deg;
                        Vector3 ObjPoint = new Vector3((firstClick.x + SecondeClick.x) * 0.5f, (firstClick.y + SecondeClick.y) * 0.5f, (firstClick.z + SecondeClick.z) * 0.5f);
                        Quaternion rot = Quaternion.Euler(0f, angle, 0f);

                        float distance = Vector3.Distance(firstClick, SecondeClick);
                        Debug.Log("distance" + distance);
                        wall.transform.localScale = new Vector3(0.1f, transform.localScale.y, distance);
                        Instantiate(wall, ObjPoint, rot);
                    }
                }
                on_click_button_wall--;
            }
        }
        else if(on_click_button_wall <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void ButtonClickWall()
    {
        on_click_button_wall = 2;
        Vector2 hotspot = new Vector2(cursurIcon.width / 2f, cursurIcon.height / 2f);

        Cursor.SetCursor(cursurIcon, hotspot, CursorMode.Auto);
    }
}
