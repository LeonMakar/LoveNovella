using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "SceneStartData", menuName ="SceneData/SceneStartData")]
public class SceneStartData : ScriptableObject
{
    public VideoClip FirstVideo;
    public GameObject FirstImagePrefab;
}
