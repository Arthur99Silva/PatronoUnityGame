using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class PatronoInterface : MonoBehaviour
{
    public MousePatrono mousePatrono = new MousePatrono();
    public PatronoDescriptionPanel descriptionPanel;
    public GameObject photo;
    public InventoryPatrono inventoryP;
    public PlayerP player;

    public Dictionary<GameObject, PatronoSlot> patronosDisplayed = new Dictionary<GameObject, PatronoSlot>();
    //Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventoryP.ContainerP.Patronos.Length; i++)
        {
            inventoryP.ContainerP.Patronos[i].parent = this;
        }
        CreateSlotsP();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    void Update()
    {
        UpdateSlots();
    }

    // Update is called once per frame
    void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, PatronoSlot> _slot in patronosDisplayed)
        {
            if (_slot.Value.IDP >= 0)//bem aqqqq
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventoryP.database.GetItem[_slot.Value.patrono.idP].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                //_slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public abstract void CreateSlotsP();

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        if (obj != null)
        {
            Debug.Log("Antes de adicionar eventos. Objeto é nulo?ADD " + (obj == null));
            EventTrigger trigger = obj.GetComponent<EventTrigger>();
            var eventTrigger = new EventTrigger.Entry();
            eventTrigger.eventID = type;
            eventTrigger.callback.AddListener(action);
            trigger.triggers.Add(eventTrigger);
        }
    }

    public void OnEnter(GameObject obj)
{
    Debug.Log("OnEnter called with obj: " + obj.name);
    mousePatrono.hoverObjP = obj;
    if(patronosDisplayed.ContainsKey(obj))
    {
        mousePatrono.hoverPatrono = patronosDisplayed[obj];
        Debug.Log("Hover patrono found: " + mousePatrono.hoverPatrono);
    }
    else
    {
        Debug.LogWarning("Hover patrono not found for obj: " + obj.name);
    }
}


    public void OnExit(GameObject obj)
    {
        mousePatrono.hoverObjP = null;
        mousePatrono.hoverPatrono = null;
    }

    public void OnEnterInterface(GameObject obj)
    {
        player.mousePatrono.ui = obj.GetComponent<PatronoInterface>();
    }

    public void OnExitInterface(GameObject obj)
    {
        player.mousePatrono.ui = null;
    }

    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(50, 50);
        mouseObject.transform.SetParent(transform.parent);
        if (patronosDisplayed[obj].IDP >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventoryP.database.GetItem[patronosDisplayed[obj].IDP].uiDisplay;
            img.raycastTarget = false;
        }
        mousePatrono.obj = mouseObject;
        mousePatrono.patrono = patronosDisplayed[obj];
    }

    public void OnDragEnd(GameObject obj)
    {
        var patronoOnMouse = player.mousePatrono;
        var mouseHoverPatrono = patronoOnMouse.hoverPatrono;
        var mouseHoverObj = patronoOnMouse.hoverObjP;
        var GetPatronoObject = inventoryP.database.GetItem;
        if (patronoOnMouse.ui != null)
        {
            if (mouseHoverObj)
                if (mouseHoverPatrono.CanPlaceInSlotP(GetPatronoObject[patronosDisplayed[obj].IDP]) && (mouseHoverPatrono.patrono.idP <= -1 || (mouseHoverPatrono.patrono.idP >= 0 && patronosDisplayed[obj].CanPlaceInSlotP(GetPatronoObject[mouseHoverPatrono.patrono.idP]))))
                    inventoryP.MovePatrono(patronosDisplayed[obj], mouseHoverPatrono.parent.patronosDisplayed[patronoOnMouse.hoverObjP]);
        }
        else
        {
            inventoryP.RemovePatrono(patronosDisplayed[obj]);

        }
        Destroy(patronoOnMouse.obj);
        patronoOnMouse.patrono = null;
    }

    public void OnDrag(GameObject obj)
    {
        if (player.mousePatrono.obj != null)
        {
            player.mousePatrono.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }


public void OnItemClick(GameObject obj)
    {
        if (patronosDisplayed.ContainsKey(obj))
        {
            PatronoSlot clickedSlot = patronosDisplayed[obj];
            Image imageComponent = photo.GetComponent<Image>();
            PatronoObject patronoObject = inventoryP.database.GetItem[clickedSlot.patrono.idP];
            imageComponent.sprite = inventoryP.database.GetItem[clickedSlot.patrono.idP].uiDisplay;

            if (descriptionPanel != null)
            {
                // Atualiza a descrição no painel de descrição
                descriptionPanel.UpdateDescription(patronoObject.idP);
            }
            else
            {
                Debug.LogWarning("Description panel is not assigned.");
            }
        }
    }
}

public class MousePatrono
{
    public PatronoInterface ui;
    public GameObject obj;
    public PatronoSlot patrono;
    public PatronoSlot hoverPatrono;
    public GameObject hoverObjP;
}
