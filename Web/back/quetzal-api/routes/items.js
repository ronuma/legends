import { Router } from "express";

import { getItems } from "../helper";

const router = Router();

router.get("/", async (req, res) => {
  try {
    const data = await getItems();
    if (!data) {
      res.status(404).json({
        msg: "No items found",
      });
      return;
    }
    res.status(200).json(data);
  } catch (error) {
    console.log("GET items error: ", error);
    res.status(500).json({
      msg: "GET items error",
      error,
    });
  }
});

export default router;
