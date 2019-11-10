using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Player player;
	public Deck deck;
	public ReadText readText;
	DeckGenerater deckGenerater;
	CardGenerater cardGenerater;


	enum Phase
    {
        INIT,
        DRAW,
        MAIN,
        BATTLE,
        END,
    };

    Phase phase;
    void Start()
    {
        deckGenerater = GetComponent<DeckGenerater>();
        phase = Phase.INIT;


		//=====CardDataからすべてのカードを一度生成する=====

		cardGenerater = GetComponent<CardGenerater>();
		//CardDataの存在する枚数分繰り返す
		for (int i = 0; i < readText.textWords.GetLength(0); i++)
		{
			//クリックされたときに呼び出す。
			//カードの表示だけ行う
			//CardData_DE(int _id, string _name, int _section, int _cp, int _color, int _race1, int _race2, int _bp1, int _bp2, int _bp3, string _effectText,string _flavorText)
			CardData generateCardList = new CardData(int.Parse(readText.textWords[i, 0]), readText.textWords[i, 1], int.Parse(readText.textWords[i, 2]), int.Parse(readText.textWords[i, 3]), int.Parse(readText.textWords[i, 4]), int.Parse(readText.textWords[i, 5]), int.Parse(readText.textWords[i, 6]), int.Parse(readText.textWords[i, 7]), int.Parse(readText.textWords[i, 8]), int.Parse(readText.textWords[i, 9]), readText.textWords[i, 10], readText.textWords[i, 11]);

			cardGenerater.Generate(generateCardList, player.cardList);
		}
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
            case Phase.MAIN:
                MainPhase();
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
        //deckGenerater.Generate(player1CardDataList, playerList[0].deck);
        //deckGenerater.Generate(player2CardDataList, playerList[1].deck);

        //現在のプレイヤー
        //currentPlayer = playerList[0];
        //waitPlayer    = playerList[1];

        phase = Phase.DRAW;
    }

    void DrawPhase()
    {
        //Debug.Log("DrawPhase");
        //カードのドロー
        
        phase = Phase.MAIN;
    }

    //今はボタン制御でカードドロー。ターン制御にする
    public void DrawButton()
    {
		player.Draw();
		player.Draw();
    }
    void MainPhase()
    {
        //Debug.Log("StandbyPhase");
        //CP回復+1(上限７)、行動権回復
        phase = Phase.BATTLE;
    }

    //プレイヤーの移動させたカードにする
    public void SummonButton()
    {
        player.MainPhaseAction();
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
