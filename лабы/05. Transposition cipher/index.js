const express = require("express")
const fs = require("fs").promises
const path = require("path")
const app = new express()
const open = require('open');   

app.use(express.static("public"))
app.use(express.json());

app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, "index.html"))
})

app.get("/text", async (req, res) => {
    fs.readFile("text/strata.txt", 'utf8').then(result => {
        result = result.toString().toUpperCase();
        res.send(result);

    });
})

app.get("/textEn", async (req, res) => {
    fs.readFile("text/MarshEncr.txt", 'utf8').then(result => {
        result = result.toString().toUpperCase();
        res.send(result);

    });
})

const pathToFile = './text/result.txt';

app.post("/tofile", async (req, res) => {
    const chunks = [];
    req.on("data", (chunk) => {
      chunks.push(chunk);
    });
    req.on("end", () => {
        const data = Buffer.concat(chunks);
        console.log("Data: ", data.toString().split(' ')[0]);
        fs.writeFile('./text/'+data.toString().split(' --- ')[0]+'.txt', data.toString().split(' --- ')[1], 'utf8')
      });

})

app.listen(3000)
open('http://localhost:3000/');