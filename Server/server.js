const express = require("express");

const app = express();

app.get("/", function(req, res){
    res.send("Hello and welcome!");
});

app.listen(port=8080, "0.0.0.0", function(){
    console.log("Server is running on port 8080");
});