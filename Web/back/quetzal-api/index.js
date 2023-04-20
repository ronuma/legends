import express from "express";
import {
   itemsRoute,
   charactersRoute,
   usersRoute,
   statsRoute,
} from "./routes/routesIndex.js";
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

app.use("/items", itemsRoute); // has 1 route (GET /items) DONE
app.use("/characters", charactersRoute); // has 2 routes (GET /characters/NPCs, GET /characters/enemies DONE)
app.use("/users", usersRoute);
app.use("/stats", statsRoute);

app.listen(PORT, () => {
   console.log(`Server running on port ${PORT}`);
});

// Export connectToDB
export default connectToDB;
