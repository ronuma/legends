import {Router} from "express";

import {getNPCs, getEnemies} from "../helpers/characters.js";

const router = Router();

router.get("/NPCs", async (req, res) => {
   try {
      const data = await getNPCs();
      if (!data) {
         res.status(404).json({
            msg: "No npcs found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET npcs error: ", error);
      res.status(500).json({
         msg: "GET npcs error",
         error,
      });
   }
});

router.get("/enemies", async (req, res) => {
   try {
      const data = await getEnemies();
      if (!data) {
         res.status(404).json({
            msg: "No enemies found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET enemies error: ", error);
      res.status(500).json({
         msg: "GET enemies error",
         error,
      });
   }
});

export default router;
