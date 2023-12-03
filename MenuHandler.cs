using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private RectTransform selector;
    [SerializeField]
    private List<MenuButton> buttons;

    private int indexNow;
    
    public MenuButton buttonAdd
    {
        set
        {
            buttons.Add(value);
            buttons[buttons.Count - 1].Set(buttons.Count - 1, this);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < buttons.Count; ++i)
        {
            buttons[i].Set(i, this);
        }

        indexNow = 0;
        CheckButtonSelected(indexNow);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton(int index)
    {
        if (CheckButtonSelected(index))
        {
            buttons[index].events.Invoke();
        }
    }

    private bool CheckButtonSelected(int index)
    {
        if (!gameObject.activeSelf || !enabled || buttons.Count < 1)
            return false;

        if (indexNow == index)
            return true;

        indexNow = index;

        if (indexNow < 0)
            indexNow = buttons.Count - 1;
        if (indexNow >= buttons.Count)
            indexNow = 0;

        selector.SetParent(buttons[index].rectTransform);
        selector.anchorMin = new Vector2(0, 0);
        selector.anchorMax = new Vector2(1, 1);
        selector.offsetMin = new Vector2(0, 0);
        selector.offsetMax = new Vector2(1, 1);
        return false;
    }

    public void SelectMenu()
    {
        if (gameObject.activeSelf && enabled)
            buttons[indexNow].events.Invoke();
    }
}
