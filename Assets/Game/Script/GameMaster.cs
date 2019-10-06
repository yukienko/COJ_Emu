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

    //CardData(int _id, string _name, int _level, int _cost)

    List<CardData> player1CardDataList = new List<CardData>()
    {
        new CardData(0,"name0",1,2),
        new CardData(1,"name1",2,2),
        new CardData(2,"name2",3,1),
    };
    List<CardData> player2CardDataList = new List<CardData>()
    {
        new CardData(0,"name0",1,2),
        new CardData(1,"name1",1,2),
        new CardData(2,"name2",1,2),
    };

    void InitPhase()
    {
        Debug.Log("InitPhase");
        //デッキの生成
        deckGenerater.Generate(player1CardDataList, playerList[0].deck);
        deckGenerater.Generate(player2CardDataList, playerList[1].deck);

        //現在のプレイヤー
        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        Debug.Log("DrawPhase");
        //カードのドロー
        phase = Phase.STANDBY;
    }
    void StandbyPhase()
    {
        Debug.Log("StandbyPhase");
        //CP回復+1(上限７)、行動権回復
        phase = Phase.BATTLE;
    }
    void BattlePhase()
    {
        Debug.Log("BattlePhase");
        phase = Phase.END;
    }
    void EndPhase()
    {
        Debug.Log("EndPhase");
        phase = Phase.DRAW;
    }
}
