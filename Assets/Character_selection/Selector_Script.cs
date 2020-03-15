using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_Script : MonoBehaviour{
    public GameObject nak;
    public GameObject beer_cool;
    public GameObject beer_ugly;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer nakRenderer, beer_coolRenderer, beer_uglyRenderer;

    private void Awake(){
        CharacterPosition = nak.transform.position;
        OffScreen = beer_cool.transform.position;
        nakRenderer = nak.GetComponent<SpriteRenderer>();
        beer_coolRenderer = beer_cool.GetComponent<SpriteRenderer>();
        beer_uglyRenderer = beer_ugly.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter(){
        switch(CharacterInt)
        {
            case 1:
                nakRenderer.enabled = false;
                nak.transform.position = OffScreen;
                beer_cool.transform.position = CharacterPosition;
                beer_coolRenderer.enabled = true;
                CharacterInt++;
                break;
            case 2:
                beer_coolRenderer.enabled = false;
                beer_cool.transform.position = OffScreen;
                beer_ugly.transform.position = CharacterPosition;
                beer_uglyRenderer.enabled = true;
                CharacterInt++;
                break;
            case 3:
                beer_uglyRenderer.enabled = false;
                beer_ugly.transform.position = OffScreen;
                nak.transform.position = CharacterPosition;
                nakRenderer.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }

        
    }

    public void PreviousCharacter(){
        switch (CharacterInt)
        {
            case 1:
                nakRenderer.enabled = false;
                nak.transform.position = OffScreen;
                beer_ugly.transform.position = CharacterPosition;
                beer_uglyRenderer.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                beer_coolRenderer.enabled = false;
                beer_cool.transform.position = OffScreen;
                nak.transform.position = CharacterPosition;
                nakRenderer.enabled = true;
                CharacterInt--;
                break;
            case 3:
                beer_uglyRenderer.enabled = false;
                beer_ugly.transform.position = OffScreen;
                beer_cool.transform.position = CharacterPosition;
                beer_coolRenderer.enabled = true;
                CharacterInt--;
                break;
        }
    }
    private void ResetInt()
    {
        if (CharacterInt >= 3)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 3;
        }
    }
}
