import express from "express";
import {itemsRoute, charactersRoute} from "./routes/routesIndex.js";
import mysql from "mysql2/promise";

const app = express();
const PORT = 8000;

// Helper function to connect to the database
async function connectToDB() {
   return await mysql.createConnection({
      host: "localhost",
      user: "userdb",
      password: "userdb",
      database: "quetzal",
   });
}
app.get("/", (req, res) => {
   res.send("Hello World!");
});

app.use("/items", itemsRoute);
app.use("/characters", charactersRoute);

app.listen(PORT, () => {
   console.log(`Server running on port ${PORT}`);
});

// Export connectToDB
export default connectToDB;
