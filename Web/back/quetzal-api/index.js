import express from "express";
import cors from "cors";
import {
   itemsRoute,
   charactersRoute,
   usersRoute,
   statsRoute,
} from "./routes/routesIndex.js";
import mysql from "mysql2/promise";
import {ENV, PORT} from "./constants.js";

const app = express();

app.use(express.json());
app.use(cors());

// Helper function to connect to the database
async function connectToDB() {
   return await mysql.createConnection(ENV);
}
app.get("/", (req, res) => {
   res.send("Hello World!");
});

app.use("/items", itemsRoute);
app.use("/characters", charactersRoute);
app.use("/users", usersRoute);
app.use("/stats", statsRoute);

app.listen(PORT, () => {
   console.log(`Server running on port ${PORT}`);
});

// Export connectToDB
export default connectToDB;
