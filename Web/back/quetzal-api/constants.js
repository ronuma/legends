export const DEV = {
   host: "localhost",
   user: "userdb",
   password: "userdb",
   database: "quetzal",
};

export const PROD = {
   host: "quet.cby19a4j2vf8.us-east-1.rds.amazonaws.com",
   user: "test-quetzal",
   password: "quetzal123",
   database: "quetzal",
};

export const ADMIN = {
   host: "quet.cby19a4j2vf8.us-east-1.rds.amazonaws.com",
   user: "admin-quetzalcoatl",
   password: "X9#sT@4fW^qL",
   database: "quetzal",
};

// Please switch according to the environment you are using
export const ENV = ADMIN;
export const PORT = 8000;

// Límites de estadísticas
export const statLimits = {
   health: {min: 1, max: 1000},
   mana: {min: 0, max: 300},
   defense: {min: 0, max: 250},
   damage: {min: 0, max: 125},
   speed: {min: 1, max: 8},
};
