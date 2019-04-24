using UnityEngine;
using UnityEngine.Networking;

namespace Shooter2D
{
    public class CustomNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            int playerCount = NetworkServer.connections.Count;
            if (playerCount <= startPositions.Count)
            {
                GameObject player = Instantiate(playerPrefab, startPositions[playerCount - 1].position, Quaternion.identity);
                NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            }
            else
            {
                conn.Disconnect();
            }
        }
    }
}
