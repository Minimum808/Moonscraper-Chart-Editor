﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SectionPropertiesPanelController : PropertiesPanelController {
    public Section currentSection { get { return (Section)currentSongObject; } set { currentSongObject = value; } }
    public InputField sectionName;

    protected override void Update()
    {
        base.Update();
        if (currentSection != null)
        {
            positionText.text = "Position: " + currentSection.position.ToString();
            sectionName.text = currentSection.title;
        }
    }

    void OnEnable()
    {       
        bool edit = ChartEditor.editOccurred;

        if (currentSection != null)
            sectionName.text = currentSection.title;

        ChartEditor.editOccurred = edit;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        currentSection = null;
    }

    public void UpdateSectionName (string name)
    {
        string prevName = currentSection.title;
        if (currentSection != null)
        {
            currentSection.title = name;
            UpdateInputFieldRecord();
        }

        if (prevName != currentSection.title)
            ChartEditor.editOccurred = true;
    }
}
