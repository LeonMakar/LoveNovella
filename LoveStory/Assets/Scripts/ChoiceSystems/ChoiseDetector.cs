using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

[RequireComponent(typeof(Image))]
public class ChoiseDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private Image _sign;
    [SerializeField] private VideoClip _clipToPlay;
    private MainSceneObjects _mainSceneObjects;
    private VideoPlayer _mainScenePlayer;

    public void Init(MainSceneObjects mainSceneObjects)
    {
        _mainSceneObjects = mainSceneObjects;
        _mainScenePlayer = mainSceneObjects.MainVideoPlayer;
    }

    private void ActionOnVideoFinished(VideoPlayer source)
    {

        _mainSceneObjects.MainImageParrent.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mainSceneObjects.MainImageParrent.SetActive(false);
        _mainScenePlayer.clip = _clipToPlay;
        _mainScenePlayer.Play();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _sign.color = Color.green;
        _mainScenePlayer.loopPointReached += ActionOnVideoFinished;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _sign.color = Color.white;
        _mainScenePlayer.loopPointReached -= ActionOnVideoFinished;

    }
}
