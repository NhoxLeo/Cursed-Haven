using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{

    public List<TabButton> tabButtons;
    public TabButton selectedTab;
    private Color colorTabIdle;
    private Color colorTabHover;
    private Color colorTabActive;
    public List<GameObject> contentsToSwap;


    private void Start()
    {
        colorTabIdle = new Color32(255, 255, 255, 100);
        colorTabHover = new Color(255, 255, 255, 255);
        colorTabActive = new Color(255, 255, 255, 255);
    }


    public void Subscribe(TabButton button) { 
    
    if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);  
    }


    public void OnTabEnter(TabButton button) {
        ResetTab();
        if (selectedTab == null || button != selectedTab) {
            button.textMesh.color = colorTabHover;
        }

    }

    public void OnTabExit(TabButton button) {
        ResetTab();

    }


    public void OnTabSelected(TabButton button) {
        selectedTab = button;
        ResetTab();
        button.textMesh.color = colorTabActive;
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < contentsToSwap.Count; i++) {

            if (i == index)
            {

                contentsToSwap[i].SetActive(true);
            }
            else {

                contentsToSwap[i].SetActive(false);
            }
        }


    }

    public void ResetTab() {

        foreach (TabButton button in tabButtons) {

            if (selectedTab != null && button == selectedTab) {
                continue;
            }

            button.textMesh.color = colorTabIdle;

        }
    }
}
