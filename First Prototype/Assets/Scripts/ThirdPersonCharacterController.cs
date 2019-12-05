using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public Interactable focus;
    public float Speed;
    Rigidbody rb;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        if(Input.GetMouseButtonDown(0))
        {
            RemoveFocus();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RaycastHit[] hits;

            hits = Physics.RaycastAll(ray, 10.0f);

            //Debug.Log("Right Click Confirm");
            if (hits.Length > 0)
            {
                for(int i = 0; i < hits.Length; i++)
                {
                    hit = hits[i];
                    //Debug.Log("Interacting with " + hit.collider.name);
                    if(hit.collider.GetComponent<Interactable>())
                    {
                        Interactable interactable = hit.collider.GetComponent<Interactable>();
                        //Debug.Log("Interacting with " + hit.collider.name);
                        if(interactable != null)
                        {
                            SetFocus(interactable);
                        }
                    }
                }
            }
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * Speed * Time.deltaTime;
        rb.transform.Translate(playerMovement, Space.Self);
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}
