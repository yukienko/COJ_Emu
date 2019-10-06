using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
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
    void InitPhase()
    {
        Debug.Log("InitPhase");
        //デッキの生成

        //現在のプレイヤー
        phase = Phase.DRAW;
    }
    void DrawPhase()
    {
        Debug.Log("DrawPhase");
        phase = Phase.STANDBY;
    }
    void StandbyPhase()
    {
        Debug.Log("StandbyPhase");
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
