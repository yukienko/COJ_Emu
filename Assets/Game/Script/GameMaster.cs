using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Player[] playerList;
    DeckGenerater deckGenerater;

    enum Phase
    {
        INIT,
        DRAW,
        STANDBY,
        BATTLE,
        END,
    };

    Phase phase;
    void Start()
    {
        deckGenerater = GetComponent<DeckGenerater>();
        phase = Phase.INIT;
    }
    void Update()
    {
        switch (phase)
        {
            case Phase.INIT:
                InitPhase();
                break;
            case Phase.DRAW:
                DrawPhase();
                break;
            case Phase.STANDBY:
                StandbyPhase();
                break;
            case Phase.BATTLE:
                BattlePhase();
                break;
            case Phase.END:
                EndPhase();
                break;
        }
    }

    //CardData(int _id, string _name, int _cp, int _color, int _race1, int _race2, int _level, int _bp1, int _bp2, int _bp3, string _effectText)

    List<CardData> player1CardDataList = new List<CardData>()
    {
        new CardData(1,"name0",1,1,1,0,1,1000,2000,3000,"このユニットはテスト用です。効果なんてないよおおおおお"),
        new CardData(2,"name1",2,2,2,0,1,2000,3000,4000,"このユニットはテスト2用です。効果なんてないよおおおおお"),
        new CardData(3,"name2",3,3,3,8,1,3000,4000,5000,"このユニットはテスト3用です。効果なんてないよおおおおお"),
    };
    List<CardData> player2CardDataList = new List<CardData>()
    {
        new CardData(4,"name3",4,4,4,0,1,4000,5000,6000,"このユニットはテスト4用です。効果なんてないよおおおおお"),
        new CardData(5,"name4",5,5,5,0,1,5000,6000,7000,"このユニットはテスト5用です。効果なんてないよおおおおお"),
        new CardData(6,"name5",6,0,0,0,1,0,0,0,"このユニットはテスト6用です。効果なんてないよおおおおお"),
    };

    Player currentPlayer;
    Player waitPlayer;

    void InitPhase()
    {
        Debug.Log("InitPhase");
        //デッキの生成
        deckGenerater.Generate(player1CardDataList, playerList[0].deck);
        deckGenerater.Generate(player2CardDataList, playerList[1].deck);

        //現在のプレイヤー
        currentPlayer = playerList[0];
        waitPlayer    = playerList[1];

        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        //Debug.Log("DrawPhase");
        //カードのドロー
        
        phase = Phase.STANDBY;
    }
    public void DrawButton()
    {
        currentPlayer.Draw();
    }
    void StandbyPhase()
    {
        //Debug.Log("StandbyPhase");
        //CP回復+1(上限７)、行動権回復
        phase = Phase.BATTLE;
    }
    void BattlePhase()
    {
        //Debug.Log("BattlePhase");
        phase = Phase.END;
    }
    void EndPhase()
    {
        //Debug.Log("EndPhase");
        phase = Phase.DRAW;
    }
}
