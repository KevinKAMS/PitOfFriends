using UnityEngine;
using Mirror;
public class PlayerScoreB : NetworkBehaviour
{
    [SyncVar]
    public int playerNumber;

    [SyncVar]
    public int scoreIndex;

    [SyncVar]
    public int matchIndex;

    [SyncVar]
    public uint score;

    public int clientMatchIndex = -1;

    void OnGUI()
    {
        if (!isServerOnly && !isLocalPlayer && clientMatchIndex < 0)
            clientMatchIndex = NetworkClient.connection.identity.GetComponent<PlayerScoreB>().matchIndex;

        if (isLocalPlayer || matchIndex == clientMatchIndex)
            GUI.Box(new Rect(10f + (scoreIndex * 110), 10f, 100f, 25f), $"P{playerNumber}: {score}");
    }
}
