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

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.tag == "Interactable")
        {
            Interactable interactable = coll.collider.GetComponent<Interactable>();
            //Debug.Log("Interacting with " + hit.collider.name);
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }
}
