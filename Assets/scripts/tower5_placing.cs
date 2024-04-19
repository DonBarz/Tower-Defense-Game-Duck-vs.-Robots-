using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tower5_placing : MonoBehaviour, IPointerDownHandler
{
    public GameObject tower5Prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (!tower_placing.is_placing & game_logic.game_has_started)
        {
            tower_placing.is_placing = true;
            Instantiate(tower5Prefab, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), transform.rotation);
        }
    }
}
