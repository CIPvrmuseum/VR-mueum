using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractDescription : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController xrController;

    [SerializeField]
    private XRInteractorLineVisual lineVisual;

    [SerializeField]
    private GameObject uiCanvas;

    [SerializeField]
    private GameObject uiObjectParent;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Text descriptionText;

    private bool isHovering;
    private Color validColor = Color.white;
    private Color invalidColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        uiCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (xrController)
        {
            RaycastHit hit;
            // Perform a raycast from the controller
            if (Physics.Raycast(xrController.transform.position, xrController.transform.forward, out hit))
            {
                // Check if the hit object has the hasDescription component
                hasDescription interactable = hit.collider.GetComponent<hasDescription>();
                if (interactable)
                {
                    // Change the color of the ray when hovering over an interactable object
                    SetLineVisualColor(validColor);

                    // Set the hover flag to true
                    isHovering = true;
                }
                else 
                {
                    SetLineVisualColor(invalidColor);
                    isHovering = false;
                }
            }
            else
            {
                SetLineVisualColor(invalidColor);
                isHovering = false;
            }

            //activateAction is the trigger, in XR Device Simulator it is the left mouse button
            if (xrController.activateAction.action.triggered && isHovering)
            {
                // Update UI content based on the interacted object
                UpdateUIContent(hit.collider.gameObject);

                // Toggle the UI Canvas
                uiCanvas.SetActive(!uiCanvas.activeSelf);
            }
            else if (xrController.activateAction.action.triggered && uiCanvas.activeSelf)
            {
                // Deactivate UI with same button
                uiCanvas.SetActive(false);
            }
        }
    }
    void UpdateUIContent(GameObject interactedObject) 
    {
        // Switch case based on the name of the interactedObject
        switch (interactedObject.name)
        {
            case "ammunition_box":
                // Handle actions for ObjectName1
                titleText.text = "Ammunition Box";
                descriptionText.text = "The weathered wooden ammunition box, displaying signs of age, is a vintage container likely used for transporting or storing ammunition. The presence of an address adds a personal touch, hinting at its historical journey or ownership.";
                ResetUI();
                ShowUIObject("ammunition_boxUI");
                break;

            case "coffeegrinder":
                // Handle actions for ObjectName2
                titleText.text = "Coffee Grinder";
                descriptionText.text = "The old metal coffee grinder, worn with age, boasts a timeless design and durable construction. Its manual operation and vintage appearance add a nostalgic touch to the coffee brewing experience.";
                ResetUI();
                ShowUIObject("coffeegrinderUI");
                break;

            case "flak_gun":
                // Handle actions for ObjectName2
                titleText.text = "Flak Gun";
                descriptionText.text = "A flak gun is a powerful anti-aircraft artillery piece designed to defend against aerial threats. Mounted on the ground or naval vessels, it rapidly fires explosive shells to intercept and destroy enemy aircraft, playing a crucial role in wartime air defense.";
                ResetUI();
                ShowUIObject("flak_gunUI");
                break;

            case "flakkaserne plank":
                // Handle actions for ObjectName2
                titleText.text = "Flakkaserne Plank";
                descriptionText.text = "...";
                ResetUI();
                ShowUIObject("flakkaserne plankUI");
                break;
            
            case "photobook":
                // Handle actions for ObjectName2
                titleText.text = "Photobook";
                descriptionText.text = "The photobook featuring Kanonier Reinhardt provides a visual account of his military experiences. Filled with photographs, it captures moments from battles, locations, and personal interactions, offering a unique perspective on the war through his eyes.";
                ResetUI();
                ShowUIObject("photobookUI");
                break;
            
            case "photobook.001":
                // Handle actions for ObjectName2
                titleText.text = "Photobook";
                descriptionText.text = "The photobook featuring Kanonier Reinhardt provides a visual account of his military experiences. Filled with photographs, it captures moments from battles, locations, and personal interactions, offering a unique perspective on the war through his eyes.";
                ResetUI();
                ShowUIObject("photobookUI");
                break;
            
            case "photobook.002":
                // Handle actions for ObjectName2
                titleText.text = "Photobook";
                descriptionText.text = "The photobook featuring Kanonier Reinhardt provides a visual account of his military experiences. Filled with photographs, it captures moments from battles, locations, and personal interactions, offering a unique perspective on the war through his eyes.";
                ResetUI();
                ShowUIObject("photobookUI");
                break;

            case "stamm_object":
                // Handle actions for ObjectName2
                titleText.text = "Stamm Object";
                descriptionText.text = "...";
                ResetUI();
                ShowUIObject("stamm_objectUI");
                break;

            case "wappen":
                // Handle actions for ObjectName2
                titleText.text = "Wappen";
                descriptionText.text = "A wappen is a decorative emblem or insignia typically made of metal, featuring intricate designs, symbols, or images. This type of item often resembles a small shield or plaque and may showcase a coat of arms, heraldic elements, or commemorative motifs.";
                ResetUI();
                ShowUIObject("wappenUI");
                break;

            case "music_studio_sign":
                // Handle actions for ObjectName2
                titleText.text = "Music Studio Sign";
                descriptionText.text = "The sign indicates the presence of the Heeresmusikkorps 11 Bremen-Grohn, a military music corps located in Bremen-Grohn.";
                ResetUI();
                ShowUIObject("music_studio_signUI");
                break;

            case "swift can":
                // Handle actions for ObjectName2
                titleText.text = "Swift Can";
                descriptionText.text = "Swift's Bland Lard can with \"Swift'ning\" on the front is a classic cooking fat container, likely formulated for baking and cooking. The label includes essential product information.";
                ResetUI();
                ShowUIObject("swift canUI");
                break;
            

            default:
                // Handle the default case (if the name doesn't match any specific case)
                titleText.text = "Unknown Object";
                descriptionText.text = "No specific description available.";
                ResetUI();
                Debug.Log("Interacted Object: " + interactedObject.name);
                break;
        }
    }
    void ShowUIObject(string specificObjectName)
    {
        // Find the specific object by name
        GameObject specificObject = uiObjectParent.transform.Find(specificObjectName)?.gameObject;

        // Check if the object is found
        if (specificObject != null)
        {
            // Do something with the specific object
            specificObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Specific object not found!");
        }
    }
    void ResetUI()
    {
        // Iterate through all child objects and deactivate them
        foreach (Transform child in uiObjectParent.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void SetLineVisualColor(Color color) 
    {
        if (lineVisual != null)
        {
            // Create a gradient with a single color key and alpha set to 1.0f
            Gradient gradient = new Gradient();
            gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(color, 0f) }, new GradientAlphaKey[] { new GradientAlphaKey(color.a, 0f) });

            // Set the invalidColorGradient property of the XRInteractorLineVisual
            lineVisual.invalidColorGradient = gradient;
        }
    }
}
