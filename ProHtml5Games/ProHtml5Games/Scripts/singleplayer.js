/// <reference path="game_lastcolony.js" />

var singleplayer =
{
    start: function ()
    {
        game.hideScreens();

        singleplayer.currentLevel = 0;

        singleplayer.initLevel();
    },

    currentLevel: 0, 

    initLevel: function ()
    {
        game.type = "singleplayer";
        game.team = "blue";

        var enterMissionButton = document.getElementById("entermission");
        enterMissionButton.disabled = true;

        var level = levels.singleplayer[singleplayer.currentLevel];

        game.loadLevelData(level);

        game.offsetX = level.startX * game.gridSize;
        game.offsetY = level.startY * game.gridSize;

        loader.onload = function ()
        {
            enterMissionButton.disabled = false;
        }

        this.showMissionBriefing(level.briefing);
    },

    showMissionBriefing: function (briefing)
    {
        var missionBriefingText = document.getElementById("missionbriefing");
        missionBriefingText.innerHTML = briefing.replace(/\n/g, "<br><br>");

        game.showScreen("missionbriefingscreen");
    },

    exit: function ()
    {
        game.hideScreens();
        game.showScreen("gamestartscreen");
    }, 

    play: function ()
    {
        game.animationLoop();
        game.animationInterval = setInterval(game.animationLoop, game.animationTimeout);

        game.start();
    }
};