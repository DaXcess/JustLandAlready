# Just Land Already

This mod for Lethal Company adds an arbitrary maximum wait time to certain events within the game.

If you are hosting a lobby with MoreCompany and LateCompany, you might have had an issue with the game not wanting to save or the map just not wanting to load. This is caused by the game no longer properly tracking how many players have successfully loaded, which can make a game softlock.

This mod aims to fix that by setting an arbitrary time limit on these events, which when exceeded stop waiting on other players to signal that they're ready.

## Configuration

**GenerateMapMaxWaitTime**: The time (in seconds) to wait for other players to finish generating the dungeon. Default: 30

**RevivePlayersMaxWaitTime**: The time (in seconds) to wait for every player to be revived. Default: 5
