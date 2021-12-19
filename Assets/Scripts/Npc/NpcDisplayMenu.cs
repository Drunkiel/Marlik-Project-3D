using UnityEngine;
using TMPro;

public class NpcDisplayMenu : MonoBehaviour
{
    [Header("Informations")]
    public string Name;
    public string Job;

    [Header("Data")]
    public bool isOpen;

    [Header("Menu")]
    public GameObject NpcMenu;

    public TMP_Text DName;
    public TMP_Text DJob;

    public void OpenMenu(){
        if(!isOpen){
            NpcMenu.SetActive(true);
            isOpen = true;
            OverWrite();
        }   else{
            OverWrite();
        }
    }

    public void CloseMenu(){
        isOpen = false;
        NpcMenu.SetActive(false);
    }

    void OverWrite(){
        DName.text = Name;
        DJob.text = Job;
    }
}
