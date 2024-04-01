using UnityEngine;
using UnityEngine.Video;

public class MainSceneObjects : MonoBehaviour
{
    [field: SerializeField] public GameObject MainVideoCanvas { get; private set; }
    [field: SerializeField] public VideoPlayer MainVideoPlayer { get; private set; }
    [field: SerializeField] public GameObject MainImageParrent { get; private set; }

}
