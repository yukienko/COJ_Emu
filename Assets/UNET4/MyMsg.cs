using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyMsg
{
	public const short Hoge = MsgType.Highest + 1;
	public const short Fuga = MsgType.Highest + 2;
	public const short Int = MsgType.Highest + 3;
	public const short String = MsgType.Highest + 4;
	public const short Custom = MsgType.Highest + 5;
}
