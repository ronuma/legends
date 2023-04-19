import express from "express"
import itemsRoute from "./routes/items.js"

const app = express()
const PORT = 8000

app.get("/", (req, res) => {
   res.send("Hello World!")
})

app.use("/items", itemsRoute)

app.listen(PORT, () => {
   console.log(`Server running on port ${PORT}`)
})
