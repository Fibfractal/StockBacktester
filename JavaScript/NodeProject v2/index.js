// THIS IS MY SERVER CODE!

// -- In node --
// In folder type 'npm init' to configure the project
// 'npm install express' to get all good packages
// To save in database 'npm install nedb'
// you can see it in the package.js as 'nedb'
// Nebd is a subset of mongo db

// -- In text editor --
// To use the express package; we need to import it
// Put it in a variable called express
// I import the NeDb package and creating a datastore
// I want to create an web app, by calling the function

// First thing I want to do as a web sever, is listening if
// anyone wants to connect?
// Pick a port to connect to and callback a message

// To see my html file in browser i have to 
// get express to host static files
// Make up a folder name 'public', anything here is public accessable

// Move the html file in that folder and re-run 'node index.js' in node
// type 'localhost:3000' alt --"--/index.html

const express = require('express');
const Datastore = require('nedb');
const app = express();
app.listen(3000, () => console.log('listeing at 3000'));
app.use(express.static('public'));
app.use(express.json({limit:'1mb'}));

// A global variabel thats starts out empty when
// server starts.
// When new data, I push it in to the database
// const database = [];
const database = new Datastore('database.db');

// Load previous data, if not created it will create one when server is started
database.loadDatabase();
// To save in database use insert function. Here saves an java script object
// Ex.
// database.insert({name:'Robert',status:'fine'});
// database.insert({name:'Santa',status:'busy'});

// The endpoint for this route is called api , or anything you want
// THen setup a callback ; request response är the argument in the function
// request all i need to know from client sending the information
// response is a variable sedning back to the client
// All that I want to rquest is the body of the request of the body
// Every time a change, 'node index.js', but you could install
// 'npm install -g nodemon' as in node monitor, anytime a change the code its
// rerun the server automatic, activate it by 'nodemon index.js'
// Have to tell the server to parse it as json, similar to static
// tell express that, option to limit size
// Normaly end with a resonse ex. end, or json object
// which i send back as .js
app.post('/api', (request,response) => {
    console.log('I got a request');
    // We send the same data back
    const data = request.body;
    const timestamp = Date.now();
    data.timestamp = timestamp;

    // Push into an array
    // database.push(data);

    // Put it into an NeDb
    // Insert data from client
    database.insert(data);

    response.json({
        status:'success',
        timestamp: timestamp,
        latitude: data.lat,
        longitude: data.long,
        vegetable: data.vegetable
    });
});
















