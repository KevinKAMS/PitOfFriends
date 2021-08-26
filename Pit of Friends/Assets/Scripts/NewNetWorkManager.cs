using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NewNetWorkManager : NetworkManager
{
    int clientIndex;
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        OnServerAddPlayerDelayed(conn);
    }

    // This delay is mostly for the host player that loads too fast for the
    // server to have subscenes async loaded from OnStartServer ahead of it.
    public void OnServerAddPlayerDelayed(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        PlayerScoreB playerScore = conn.identity.GetComponent<PlayerScoreB>();
        playerScore.playerNumber = clientIndex;
        playerScore.scoreIndex = clientIndex;

        clientIndex++;
    }
}
