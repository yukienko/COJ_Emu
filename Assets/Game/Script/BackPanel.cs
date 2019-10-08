using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BackPanel : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        
        //Userフォルダパス
        var pathname = Environment.CurrentDirectory;
        pathname = Path.Combine(pathname, "User");
        //UserフォルダのBackPanelをテクスチャとしてBackPanelに張り付け
        var BackPanelPath = Path.Combine(pathname, "BP.jpg");
        //テクスチャ変更
        Texture BackPanel_texture = this.GetComponent<Texture>();
        if (!File.Exists(BackPanelPath))
        {
            Debug.Log("error");
            //BackPanel_texture = ReadTexture(pathname + "/NotFound.jpg", 150, 150);
        }
        else
        {
            BackPanel_texture = ReadTexture(BackPanelPath, 1920, 1080);
        }
        // テクスチャーを適用
        GetComponent<Renderer>().material.mainTexture = BackPanel_texture;
        // 下地の色は白にしておく (そうしないと下地の色と乗算みたいになる)
        GetComponent<Renderer>().material.color = Color.white;
        // 下地の色は白にしておく (そうしないと下地の色と乗算みたいになる)
        // Thumbnail_obj.GetComponent<Te>().material.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //フォルダ内のJPGを読み込む
    Texture ReadTexture(string path, int width, int height)
    {
        byte[] readBinary = ReadJpgFile(path);

        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(readBinary);

        return texture;
    }

    byte[] ReadJpgFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }

}
