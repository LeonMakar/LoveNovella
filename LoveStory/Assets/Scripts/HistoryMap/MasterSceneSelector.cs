using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

[RequireComponent(typeof(VideoPlayer))]
public class MasterSceneSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private RenderTexture _renderRexture;
    [SerializeField] private SceneStartData _sceneStartData;

    private VideoPlayer _videoPlayer;
    private RawImage _image;
    private MainSceneObjects _mainSceneObjects;
    private StaticImageFactory _staticImageFactory;

    [Inject]
    private void Construct(MainSceneObjects mainSceneObjects, StaticImageFactory staticImageFactory)
    {
        _mainSceneObjects = mainSceneObjects;
        _staticImageFactory = staticImageFactory;

    }


    private void Start()
    {
        InitAsync().Forget();
    }

    private async UniTaskVoid InitAsync()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _image = GetComponent<RawImage>();
        _videoPlayer.targetTexture = _renderRexture;
        _videoPlayer.clip = _sceneStartData.FirstVideo;
        _videoPlayer.Play();
        await UniTask.Delay(500);
        _image.texture = _renderRexture;
        _videoPlayer.Pause();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _staticImageFactory.PrepareFactoryForWork(_sceneStartData.FirstImagePrefab, _mainSceneObjects.MainImageParrent.transform);
        _videoPlayer.Stop();
        _videoPlayer.Play();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _videoPlayer.Stop();
        //_videoPlayer.Play();
        //_videoPlayer.Pause();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _mainSceneObjects.MainVideoCanvas.SetActive(true);
        _mainSceneObjects.MainVideoPlayer.loopPointReached += ShowStaticImageOnEndOfVideo;
        _mainSceneObjects.MainVideoPlayer.clip = _sceneStartData.FirstVideo;
        _mainSceneObjects.MainVideoPlayer.Play();
    }

    private void ShowStaticImageOnEndOfVideo(VideoPlayer source)
    {
        _mainSceneObjects.MainVideoPlayer.loopPointReached -= ShowStaticImageOnEndOfVideo;
        _staticImageFactory.Create();
        var clone = _staticImageFactory.Create();
        _mainSceneObjects.MainImageParrent.SetActive(true);
    }
}
