using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Test2 : MonoBehaviour {


    AssetBundle prefab;
    AssetBundle atlas;
    void Start()
    {
        SpriteAtlasManager.atlasRequested += AA;
        //先加载png，因为atlas和prefab依赖png
        AssetBundle png = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/png");

        atlas = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/atlas");

        prefab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/prefab");
    }
    private void AA(string s, Action<SpriteAtlas> action)
    {
        SpriteAtlas at = atlas.LoadAsset<SpriteAtlas>("aa");
        action(at);

        GameObject go = Instantiate(prefab.LoadAsset<GameObject>("Panel"));
        go.transform.SetParent(transform, false);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //加载这个panel后，触发SpriteAtlasManager.atlasRequested的回调
            //只是触发该panel对应的SpriteAtlas的回调
            GameObject panel = prefab.LoadAsset<GameObject>("Panel");
        }
    }
}
