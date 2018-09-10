# C# Async Download Demo

This sample uses browser-sync server, that has network throttle configuration ability to emulate low network speed, so 1MB test file won't be downloaded immediatelly and you can see progress. 

*Setup and start server:*

    cd server
    npm i
    npm start

*Setup network throttle:* Open http://localhost:3001, go to Network Throttle tab, choose 2g, click "create server". Ensure that url in client is correct. Run client, press "start" button to start download test file from browser-sync server. 
