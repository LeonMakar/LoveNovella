using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMoovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool _canMove;
    public float _speed;
    [SerializeField]private Camera _camera;

    private void Start()
    {
    }

    private void OnEnable()
    {
        Test.AndrewAction += Foo;
    }
    private void Dispouse()
    {
        Test.AndrewAction -= Foo;
    }
    private void Foo(GameObject gameObject, int num, Test test)
    {
        throw new NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canMove = true;
        Debug.Log("Start");
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canMove = false;
    }
    private void OnMouseDrag()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            if(Input.GetAxis("Mouse X") > 0)
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
        }
    }
}



public class Test : MonoBehaviour
{
   static public Action<GameObject, int, Test> AndrewAction;
    public void Foo()
    {
        AndrewAction.Invoke(gameObject,5, this);
    }
}
