import {Router} from "express";

import {getItems, getItem} from "../helpers/items.js";

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

router.get("/:id", async (req, res) => {
   try {
      const data = await getItem(req.params.id);
      if (!data) {
         res.status(404).json({
            msg: "No item found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET item error: ", error);
      res.status(500).json({
         msg: "GET item error",
         error,
      });
   }
});

export default router;
