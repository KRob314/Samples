const OFFLINE_VERSION = 1.1;
const CACHE_PREFIX = 'offline';
const CACHE_NAME = `${CACHE_PREFIX}${OFFLINE_VERSION}`;
const OFFLINE_URL = 'offline.html';
const urlsToCache = [
    '/',
    '/css/bootstrap/bootstrap.min.css',
    '/css/app.css',
    '/WeatherForecast.styles.css',
    '/css/open-iconic/font/css/open-iconic-bootstrap.min.css',
    '/scripts/bweInterop.js',
    '/_framework/blazor.webassembly.js',
    '/_framework/dotnet.5.0.9.js'
];

self.addEventListener('install', event => event.waitUntil(onInstall(event)));

self.addEventListener('activate', event => event.waitUntil(onActivate(event)));

self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

async function onInstall(event)
{
    console.info('Service worker: Install');
    const cache = await caches.open(CACHE_NAME);

    await cache.add(new Request(OFFLINE_URL));

    //event.waitUntil(
    //    caches.open(CACHE_NAME)
    //        .then(function (cache)
    //        {
    //            console.log('Opened cache');
    //            return cache.addAll(urlsToCache);
    //        })
    //);
}

async function onActivate(event)
{
    console.info('Service worker: Activate');
    const cacheKeys = await caches.keys();

    await Promise.all(cacheKeys.filter(key => key.startsWith(CACHE_PREFIX) && key !== CACHE_NAME).map(key => caches.delete(key)));

}

async function onFetch(event)
{
    if (event.request.method === 'GET')
    {
        try
        {
            return await fetch(event.request);
            //event.respondWith(
            //    caches.match(event.request)
            //        .then(function (response)
            //        {
            //            // Cache hit - return response
            //            if (response)
            //            {
            //                return response;
            //            }
            //            return fetch(event.request);
            //        })
            //);
        }
        catch (error)
        {
            const cache = await caches.open(CACHE_NAME);

            return await cache.match(OFFLINE_URL);
        }
    }
}