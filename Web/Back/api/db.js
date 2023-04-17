"use strict";

import express from "express";
import mysql from "mysql2/promise";

import fs from "fs";

const app = express();
const port = 8000;

app.use(express.json());
app.use(express.static("public"));

app.get("/", (req, res) => {
  fs.readFile("./public/html/mysqlUseCases.html", "utf8", (err, html) => {
    if (err) {
      res.status(500).send("There was an error: " + err);
      return;
    }

    console.log("Sending page...");
    res.send(html);
    console.log("Page sent!");
  });
});

app.get("/api/hello", (req, res) => {
  if (req.query.hasOwnProperty("name") && req.query.hasOwnProperty("surname"))
    res.send(`Hello ${req.query.name} ${req.query.surname}`);
  else res.send("Hello!");
});

app.get("/api/users", async (req, res) => {
  let connection = null;

  try {
    connection = await mysql.createConnection({
      host: "localhost",
      user: "userdb",
      password: "userdb",
      database: "api_game_db",
    });

    console.log("Connection stablished!");

    const [rows, fields] = await connection.execute("select * from users");

    res.json(rows);
  } catch (error) {
    res.status(500);
    res.send(error);
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log("Connection closed succesfully!");
    }
  }
});

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});
