var buildings =
{
    list: {
        "base": {
            name: "base", 
            //dimensions of individual sprite
            pixelWidth: 60,
            pixelHeight: 60,

            //dimensions of the base area
            baseWidth: 40,
            baseHeight: 40,

            //offset of the base area from the top left corner of the sprite
            pixelOffsetX: 0,
            pixelOffsetY: 20,

            //grid squares necessary for constructing the building 
            buildableGrid: [
                [1, 1],
                [1,1]
            ],

            //grids that are passable or obstructed for pathfinding
            passableGrid: [
                [1, 1],
                [1,1]
            ],

            //how far the building can see through fog of war
            sight: 3,
            hitPoints: 500,
            cost: 5000, 

            spriteImages: [
                { name: "healthy", count: 4 },
                { name: "damaged", count: 1 },
                { name: "constructing", count: 3 }
            ],
        },
    },

    defaults: {
        type: "buildings",
    },

    load: loadItem,
    add: addItem
};