using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStats : MonoBehaviour
{
    [Header("Game Stats")]
    public TextMeshProUGUI totalEnemiText;
    public TextMeshProUGUI currentWaveText;
    [SerializeField] private GameObject gameMode;
    private HordeMode hordeMode;



    // Start is called before the first frame update
    void Start()
    {
        gameMode = GameObject.Find("GameMode");
        hordeMode = gameMode.GetComponent<HordeMode>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaveText.text = hordeMode.currentWave.ToString();
        totalEnemiText.text = hordeMode.killTotal.ToString();
    }
}
