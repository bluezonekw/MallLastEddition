Thanks for purchase Photon Friend List.

Requiered:
Unity 5.1++
Photon Unity Networking (Free or Plus) 1.53++

Get Started:----------------------------------------------------------------------------
- Import the package in your project.
- In the scene that you want add the friend list (example lobby), drag the prefab "FriendList" located in
FriendList -> Content -> Prefab -> FriendList.
- Edit the position of Panel to your taste and Ready!.

Requiered in scene to work:----------------------------------------------------------------

- For Friend List work, need to be connected to a photon lobby, which requires that the scene 
found a script responsible for this, the package contains a sample script (bl_AutoJoin.cs) 
with basics of how to connect to the lobby, but it is recommended that this only 
Use to test because it is very basic.

- while scene is not connect FriendList will not be visible, when connect to Master / Lobby, 
this will be enable automatically.

- Also you need sure that in the script that you use to connect with photon, 
you must send the name of the player (PhotonNetwork.playerName) before connecting, this is very important because if it does,
Friend List will not work correctly.

Some data:----------------------------------------------------------------------------------

- the button "Join room" appears when: a friend in the list is connected to a room.
- Currently, the friends list is stored in a 'PlayerPrefab' locally, it is recommended that you store them in external database to the release version.

Contact / Support:-------------------------------------------------------------------------
Forum: http://lovattostudio.com/Forum/index.php
Email: brinerjhonson.lc@gmail.com
