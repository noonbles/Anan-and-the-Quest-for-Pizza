Matthew Crowe:
implemented level design (placing houses, added all NPCs, pizza restaurant, and invisible walls to perimeter of map to stop player from running out of bounds)
implemented character animations, added animation controllers to player and all NPC prefabs (IRS, mini chibi kid, low poly toon modular character, puppet kid) and created the FSMs for them
implemented nav meshes for all NPCs (floor nav mesh and park nav mesh)
created and wrote all NPC code scripts (IRS.cs, SpawnIRS.cs, GenericNPC.cs, ParkNPC.cs)
coded character movement controls and animation state changes in Player.cs
wrote ShouldSpawnIRS function in DataWriter.cs

Jicheng Li:


Adam Trac:
implemented powerup functionality and animations (TimePowerUp.cs, StaminaPowerUp.cs, Player.cs)
implemented stamina, timer, game over, tax menu, and start menu UI (designed, implemented in various .cs files)
implemented UI animations (TaxMenuScript.cs, Player.cs, TimePowerUp.cs, StartMenu.cs, PlayAgain.cs)
implemented timer and gameplay logic (Player.cs, House.cs, Shop.cs)
implemented the tax menu, start menu, game over functionality (PlayAgain.cs, TaxMenuScript.cs, StartMenu.cs)
implemented level design (added and distributed powerups among the levels)
implemented win conditions, and collision code (TimePowerUp.cs, Player.cs, StaminaPowerUp.cs, CarNav.cs)
implemented the data writing/reading code and the file reading functionality (DataWriter.cs, Player.cs, PlayAgain.cs, StartMenu.cs, TaxMenuScript.cs)
implemented audio and music (added the music in all scenes, added sound effects for cars, getting pizza, delivering pizza, etc.)

GITHUB REPO FOR GAME PROJECT:
https://github.com/noonbles/Anan-and-the-Quest-for-Pizza