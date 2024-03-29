﻿var bweInterop = {};

bweInterop.setDocumentTitle = function (title)
{
    document.title = title;
}

bweInterop.getWindowSize = function ()
{
    var size = {
        width: window.innerWidth,
        height: window.innerHeight
    };

    return size;
}

bweInterop.registerResizeHandler = function (dotNetObjectRef)
{
    function resizeHandler()
    {
        console.log('resize handler');
        dotNetObjectRef.invokeMethodAsync('GetWindowSize',
            {
                width: window.innerWidth,
                height: window.innerHeight
            });
    };

    resizeHandler();

    window.addEventListener("resize", resizeHandler);
}

bweInterop.setLocalStorage = function (key, data)
{
    localStorage.setItem(key, data);
}

bweInterop.getLocalStorage = function (key)
{
    return localStorage.getItem(key);
}