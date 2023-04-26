import {Router} from "express";

import {
   getStats,
   getData,
   addData,
   selectItem,
   getCurrentSession,
   createSession,
   getUser,
} from "../helpers/users.js";

const router = Router();

// gets all users data
router.get("/", async (req, res) => {
   try {
      const data = await getData();
      if (!data) {
         res.status(404).json({
            msg: "No users data found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET users data error: ", error);
      res.status(500).json({
         msg: "GET users data error",
         error,
      });
   }
});

router.get("/:email", async (req, res) => {
   try {
      const {email} = req.params;
      const data = await getUser(email);
      if (!data) {
         res.status(404).json({
            status: 404,
            msg: "No user data found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET user data error: ", error);
      res.status(500).json({
         msg: "GET user data error",
         error,
      });
   }
});

// gets session data by session id
router.get("/getSessionData/:id", async (req, res) => {
   try {
      const data = await getCurrentSession(req.params.id);
      if (!data) {
         res.status(404).json({
            msg: "No session data found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET session data error: ", error);
      res.status(500).json({
         msg: "GET session data error",
         error,
      });
   }
});

// gets all sessions
router.get("/stats/sessions", async (req, res) => {
   try {
      const data = await getStats();
      if (!data) {
         res.status(404).json({
            msg: "No user stats found",
         });
         return;
      }
      res.status(200).json(data);
   } catch (error) {
      console.log("GET user stats error: ", error);
      res.status(500).json({
         msg: "GET user stats error",
         error,
      });
   }
});

// adds user data
router.post("/add", async (req, res) => {
   try {
      const {email, user_name} = req.body;
      const data = await addData(email, user_name);
      if (!data) {
         res.status(404).json({
            msg: "User data not added",
         });
         return;
      }
      res.status(200).json({
         msg: "User data added",
         data,
      });
   } catch (error) {
      console.log("POST user data error: ", error);
      res.status(500).json({
         msg: "POST user data error",
         error,
      });
   }
});

// initialize a session (when starting a new game in a slot, after selecting slot and character)
router.post("/createSession", async (req, res) => {
   try {
      const data = await createSession(req.body);
      if (!data) {
         res.status(404).json({
            msg: "Session not created",
         });
         return;
      }
      res.status(200).json({
         msg: "Session created",
         data,
      });
   } catch (error) {
      console.log("POST session error: ", error);
      res.status(500).json({
         msg: "POST session error",
         error,
      });
   }
});

// updates user stats (when saving a session)
router.patch("/selectItem", async (req, res) => {
   try {
      const data = await selectItem(req.body);
      if (!data) {
         res.status(404).json({
            msg: "User data not added",
         });
         return;
      }
      res.status(200).json({
         msg: "User data added",
         data,
      });
   } catch (error) {
      console.log("UPDATE user stats error: ", error);
      res.status(500).json({
         msg: "UPDATE user stats error",
         error,
      });
   }
});

export default router;
