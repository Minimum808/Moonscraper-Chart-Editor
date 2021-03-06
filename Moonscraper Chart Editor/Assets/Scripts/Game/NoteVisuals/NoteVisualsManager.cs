﻿// Copyright (c) 2016-2017 Alexander Ong
// See LICENSE in project root for license information.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteVisualsManager : MonoBehaviour {
    public NoteController nCon;
    [SerializeField]
    protected bool isTool = false;
    protected Renderer noteRenderer;

    [HideInInspector]
    public Note.NoteType noteType = Note.NoteType.Strum;
    [HideInInspector]
    public Note.SpecialType specialType = Note.SpecialType.None;

    Note prevNote;

    // Use this for initialization
    protected virtual void Awake () {
        noteRenderer = GetComponent<Renderer>();
    }

    void LateUpdate()
    {        
        Animate();
    }

    public virtual void UpdateVisuals() {
        Note note = nCon.note;
        if (note != null)
        {
            noteType = note.type;

            // Star power?
            specialType = IsStarpower(note);

            // Update note visuals
            if (!noteRenderer)
                noteRenderer = GetComponent<Renderer>();
            noteRenderer.sortingOrder = -(int)note.tick;

            if (Globals.drumMode && note.guitarFret == Note.GuitarFret.Open)
                noteRenderer.sortingOrder -= 1;
        }
    }

    protected virtual void Animate() {}

    public static Note.NoteType GetTypeWithViewChange(Note note)
    {
        if (Globals.viewMode == Globals.ViewMode.Chart)
        {
            return note.type;
        }
        else
        {
            // Do this simply because the HOPO glow by itself looks pretty cool
            return Note.NoteType.Hopo;
        }
    }

    public static Note.SpecialType IsStarpower(Note note)
    {
        Note.SpecialType specialType = Note.SpecialType.None;
 
        foreach (Starpower sp in note.chart.starPower)
        {
            if (sp.tick == note.tick || (sp.tick <= note.tick && sp.tick + sp.length > note.tick))
            {
                specialType = Note.SpecialType.StarPower;
            }
            else if (sp.tick > note.tick)
                break;
        }

        return specialType;
    }
}
