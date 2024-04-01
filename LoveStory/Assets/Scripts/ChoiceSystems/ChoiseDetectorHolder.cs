using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiseDetectorHolder : MonoBehaviour
{
    [field: SerializeField] public ChoiseDetector[] ChoiseDetectors {  get; private set; }
}
