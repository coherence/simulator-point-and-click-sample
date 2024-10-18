# Simulator Point-and-click Sample Project

Sample project demonstrating how to create a setup where Clients click to request to move a character, but the movement is executed on a [Simulator](https://docs.coherence.io/manual/simulation-server).
Requests are done by Clients using [NetworkCommands](https://docs.coherence.io/manual/networking-state-changes/commands).
The Simulator uses a NavMeshAgent to chart the path, and then syncs position, rotation and animation parameters to the connected Clients.

### Unity version
This project is set to be opened in Unity 6, and is setup to use Multiplay Play Mode Scenarios. Choose Simulator or Simulator + 1 Client to run a working version of the game.
Downgrade to 2022 or 2021 should be possible, but it might require manual work.

### Graphics
This project contains open-source 3D graphics by Kenney Vleugels [(kenney.nl)](https://kenney.nl/)
