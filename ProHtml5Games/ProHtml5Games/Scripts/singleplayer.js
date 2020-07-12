﻿var singleplayer = {

    // Begin single player campaign
    start: function ()
    {
        // Hide the starting menu screen
        game.hideScreens();

        // Begin with the first level
        singleplayer.currentLevel = 0;

        // Start initializing the level
        singleplayer.initLevel();
    },

    currentLevel: 0,
    initLevel: function ()
    {
        game.type = "singleplayer";
        game.team = "blue";

        // Don't allow player to enter mission until all assets for the level are loaded
        var enterMissionButton = document.getElementById("entermission");

        enterMissionButton.disabled = true;

        // Load all the items for the level
        var level = levels.singleplayer[singleplayer.currentLevel];

        game.loadLevelData(level);

        fog.initLevel();

        // Set player starting location
        game.offsetX = level.startX * game.gridSize;
        game.offsetY = level.startY * game.gridSize;

        game.createTerrainGrid();

        // Enable the enter mission button once all assets are loaded
        loader.onload = function ()
        {
            enterMissionButton.disabled = false;
        };

        // Update the mission briefing text and show briefing screen
        this.showMissionBriefing(level.briefing);
    },

    showMissionBriefing: function (briefing)
    {
        var missionBriefingText = document.getElementById("missionbriefing");

        // Replace \n in briefing text with two <br> to create next paragraph
        missionBriefingText.innerHTML = briefing.replace(/\n/g, "<br><br>");

        // Display the mission briefing screen
        game.showScreen("missionbriefingscreen");
    },

    exit: function ()
    {
        // Display the main game menu
        game.hideScreens();
        game.showScreen("gamestartscreen");
    },

    play: function ()
    {
        // Run the animation loop once
        game.animationLoop();

        // Start the animation loop interval
        game.animationInterval = setInterval(game.animationLoop, game.animationTimeout);

        game.start();
    },

    sendCommand: function (uids, details)
    {
        game.processCommand(uids, details);
    },

    endLevel: function (success)
    {
        clearInterval(game.animationInterval);
        game.end();

        if (success)
        {
            let moreLevels = (singleplayer.currentLevel < levels.singleplayer.length - 1);

            if (moreLevels)
            {
                game.showMessageBox("Mission Accomplished.", function ()
                {
                    game.hideScreens();
                    // Start the next level
                    singleplayer.currentLevel++;
                    singleplayer.initLevel();
                });
            } else
            {
                game.showMessageBox("Mission Accomplished.\nThis was the last mission in the campaign.\nThank You for playing.", function ()
                {
                    game.hideScreens();
                    // Return to the main menu
                    game.showScreen("gamestartscreen");
                });
            }
        } else
        {
            game.showMessageBox("Mission Failed.\nTry again?", function ()
            {
                game.hideScreens();
                // Restart the current level
                singleplayer.initLevel();
            }, function ()
            {
                game.hideScreens();
                // Return to the main menu
                game.showScreen("gamestartscreen");
            });
        }
    }

};