import {Router} from "express";

import {getStats, getTop10} from "../helpers/stats.js";

const router = Router();

router.get("/", async (req, res) => {
   try {
      const data = await getStats();
      if (!data) {
         res.status(404).json({
            msg: "No stats found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET stats error: ", error);
      res.status(500).json({
         msg: "GET stats error",
         error,
      });
   }
});

// Top 10 players by number of finished runs
router.get("/top10", async (req, res) => {
   try {
      const data = await getTop10();
      if (!data) {
         res.status(404).json({
            msg: "No stats found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET top10 error: ", error);
      res.status(500).json({
         msg: "GET top10 error",
         error,
      });
   }
});

export default router;
