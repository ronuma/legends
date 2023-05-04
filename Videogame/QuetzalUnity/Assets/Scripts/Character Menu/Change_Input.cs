using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Change_Input : MonoBehaviour
{
    // Declare variables
    EventSystem system;             // Used to track currently selected UI element
    public Selectable firstInput;   // The first input field to select when the scene starts
    public Button submitButton;     // The submit button

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the EventSystem
        system = EventSystem.current;
        
        // Select the first input field when the scene starts
        firstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "Tab" key is pressed along with the "Left Shift" key
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift)){
            // Get the selectable object above the currently selected object
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (next != null){
                // Select the next object
                next.Select();
            }
        }
        // Check if the "Tab" key is pressed
        else if (Input.GetKeyDown(KeyCode.Tab)){
            // Get the selectable object below the currently selected object
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null){
                // Select the next object
                next.Select();
            }
        }
        // Check if the "Return" key is pressed
        else if (Input.GetKeyDown(KeyCode.Return)){
            // Invoke the "OnClick" event of the submit button
            submitButton.onClick.Invoke();
            // Print a debug message to the console
            Debug.Log("Submit");
        }
    }
}
