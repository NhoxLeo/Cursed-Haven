using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionInstruction : MonoBehaviour
{

    public string[] instructions;
    public TextMeshProUGUI instructionText;


    // Start is called before the first frame update
    void Start()
    {
        RandomInstruction();

        instructionText.text = instructions[RandomInstruction()].ToString();
    }


    public int RandomInstruction() {

        int randomIndexInstructions = Random.Range(0, instructions.Length);
        return randomIndexInstructions;

    }


}
