const express = require("express")
const fs = require("fs").promises
const path = require("path")
const open = require('open');
// const windows1251 = require("windows-1251")
const app = new express()

app.use(express.static("public"))

app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname, "index.html"))
})
app.listen(3000)
open('http://localhost:3000/');