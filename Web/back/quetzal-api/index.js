import express from "express";
import itemsRoute from "./routes/items.js";

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

app.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`);
});

// Export connectToDB
export default connectToDB;
