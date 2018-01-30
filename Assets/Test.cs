using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public Image img;
    public Image img1;
//    public SpriteAtlas atlas;

    void Awake()
    {
        SpriteAtlasManager.atlasRequested += AA;
    }

    private void AA(string s, Action<SpriteAtlas> action)
    {
        Debug.Log("Tag:"+s);
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>(s);
        action(atlas);
    }

    // Update is called once per frame
	void Update () {

	    if (Input.anyKeyDown)
	    {
//            AA("aa",ChangeSprite);
//	        img1.sprite = LoadSprite("startBtn");
	    }
	}

    public void ChangeSprite(SpriteAtlas atlas)
    {
        img.sprite = atlas.GetSprite("4");
        Debug.Log("11111");
    }

//
//    Sprite LoadSprite(string name)
//    {
//#if UNITY_EDITOR
//        return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Res/Atlas/Login/" + name + ".png");
//#endif
//    }
}
