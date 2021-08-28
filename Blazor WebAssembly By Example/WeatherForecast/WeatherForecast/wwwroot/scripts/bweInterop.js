var bweInterop = {};

bweInterop.getPosition = async function ()
{
    function getPositionAsync()
    {
        return new Promise((success, error) =>
        {
            navigator.geolocation.getCurrentPosition(success, error);
        });
    }

    if (navigator.geolocation)
    {
        var position = await getPositionAsync();
        var coords = {
            latitude: position.coords.latitude,
            longitude: position.coords.longitude
        };
        return coords;
    }
    else
    {
        throw Error("Geolocation is not supported by this browser");
    }
}

bweInterop.getWeatherForecastKey = async function ()
{
    return config.WeatherForecast_Key;
}

bweInterop.setLocalStorage = function (key, data)
{
    localStorage.setItem(key, data);
}

bweInterop.getLocalStorage = function (key)
{
    return localStorage.getItem(key);
}