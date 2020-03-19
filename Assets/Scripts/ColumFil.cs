using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SimpleJSON;

public class ColumFil : MonoBehaviour
{
    [SerializeField]
    public string TextFile, textColum;
    public string[] DataList, TitleList;
    public int ListSize,TitleSize;
    public int ListPosition, TitlePosition;


    public Text titleMain, ColumValue;
    public int NameValue;

    public string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json");


    void Start()
    {


        // TextFile = File.ReadAllText("Assets/StreamingAssets/JsonChallenge.json");
        TextFile = File.ReadAllText(filePath);

        StartCoroutine(LectorColumna());

        DataList = new string[ListSize];
        TitleList = new string[TitleSize];

        StopAllCoroutines();
    }

     void FixedUpdate()
    {
        NameValue = int.Parse(gameObject.name);


        StartCoroutine(LectorColumna());

        // StopAllCoroutines();

        titleMain.text = TitleList[NameValue];
        ColumValue.text = textColum;
    }

    public IEnumerator LectorColumna()
    {
        var DATA = JSON.Parse(TextFile);
       

        ListSize = DATA["Data"].Count;
        TitleSize = DATA["ColumnHeaders"].Count;

        if (TitlePosition < TitleSize)
        {
            TitleList[TitlePosition] = DATA["ColumnHeaders"][TitlePosition].Value;//titulos
            TitlePosition++;
        }

        if (ListPosition < ListSize)
        {

            DataList[ListPosition] = DATA["Data"][ListPosition][TitleList[NameValue]].Value; //lista
            // textColum += DataList[ListPosition] = DATA["Data"][ListPosition][TitleList[NameValue]].Value +"\n"; //lista

            textColum += DataList[ListPosition] + "\n";
            ListPosition++;
        }
        
        

       
        yield return null;
    }

}
