Matthew Crowe:
implemented level design (placing houses, added all NPCs, pizza restaurant, and invisible walls to perimeter of map to stop player from running out of bounds)
implemented character animations, added animation controllers to player and all NPC prefabs (IRS, mini chibi kid, low poly toon modular character, puppet kid) and created the FSMs for them
implemented nav meshes for all NPCs (floor nav mesh and park nav mesh)
created and wrote all NPC code scripts (IRS.cs, SpawnIRS.cs, GenericNPC.cs, ParkNPC.cs)
coded character movement controls and animation state changes in Player.cs
wrote ShouldSpawnIRS function in DataWriter.cs

Jicheng Li:
Implemented level design in all level scenes w.r.t the delivery locations--Houses--. Editing select assets in all scene to have house tags --Houses and NPCs--.
Added the all cars to the map, and colliders to them to prompt GameOver with Adam's Code.
Implemented the NavMesh for the Car Assets(Road Nav Mesh)
Wrote the logic for the Car Movement, setting the destinations and having them loop around the map(CarNav.cs)
Set up the collider boxes for houses, the shop, and the NPCs that are being delivered to.
Wrote the Pizza pickup and delivery logic. i.e. updating status of isHoldingPizza and heldPizzaName(Delivery Location) when Player Collides with the shop(looping through all gameobjects with the tag house to choose a destination) and the destination NPC/House (Shop.cs, House.cs)
Added the UI for the magnitude for the player to know the direction they should head to get the Pizza to its destination on the canvas.
Wrote the handleDist() function that updates the UI component to show the magnitude of the player to Pizza delivery destination. Also some of the logic for setting UI components and gameobjects active or not based on isHoldingPizza status (Player.cs)
Helped add audio in the scenes. Mainly when adding new delivery locations in later scene when setting up them up as delivery destinations

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