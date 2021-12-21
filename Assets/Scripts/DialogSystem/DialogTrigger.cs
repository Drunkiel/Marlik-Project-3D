using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    public void TriggerDialog(){
        dialog.name = GetComponent<NpcDisplayMenu> ().Name;
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
