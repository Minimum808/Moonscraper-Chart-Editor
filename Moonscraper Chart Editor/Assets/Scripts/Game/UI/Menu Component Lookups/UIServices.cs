﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIServices : MonoBehaviour {

    public EditorPanels editorPanels { get; private set; }
    Camera _uiCamera;
    public Camera uiCamera
    {
        get
        {
            if (_uiCamera == null)
                _uiCamera = GetComponent<Canvas>().worldCamera;

            return _uiCamera;
        }
    }

	// Use this for initialization
	void Start () {
        editorPanels = GetComponentInChildren<EditorPanels>();

        Debug.Assert(editorPanels, "Unable to locate Editor Panels script");
    }

    public Vector2 GetUIMousePosition()
    {
        return uiCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
