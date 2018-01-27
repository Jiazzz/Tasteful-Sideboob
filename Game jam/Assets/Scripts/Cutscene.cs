using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new cutscene", menuName = "Cutscene")]
public class Cutscene : ScriptableObject {

    [SerializeField]
    public GameObject[] cutsceneImages;

}
