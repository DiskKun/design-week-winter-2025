using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitStarZone : MonoBehaviour
{

    public BedroomZoneBehaviour zoneBehaviour;
    public GameObject interactMessage;

    bool interact = false;
    TextMeshProUGUI interactMessageText;

    // Start is called before the first frame update
    void Start()
    {
        interactMessageText = interactMessage.GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {


        if (interact && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (zoneBehaviour.seenState >= 9)
        {
            interactMessageText.text = "Press E to wake up";
            interactMessage.SetActive(true);
            interact = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactMessage.SetActive(false);
        interact = false;
    }
}

