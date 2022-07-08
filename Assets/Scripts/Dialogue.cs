using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public TextMeshPro textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    //Getting reference from the ChangeScenewithButtonScript
    ChangeScenewithButton sceneChange;

    PressableButton button;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();

        //button component
        button = GameObject.FindGameObjectWithTag("Button").GetComponent<PressableButton>();

        sceneChange = FindObjectOfType<ChangeScenewithButton>();
    }

    void Click()
    {
         if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
            StopAllCoroutines();
            //Get current line and instantlly fill out 
            textComponent.text = lines[index];

        }

    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Type each character 1 by 1
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //Change to landing scene
            sceneChange.LoadScene("LandingScene");
            
        }
    }
}

