const mysql = require("mysql2");
require("dotenv").config();

// ── Connection Pool ─────────────────────────────────────────
// Pool handles multiple simultaneous requests cleanly
const pool = mysql.createPool({
    host     : process.env.DB_HOST,
    port     : process.env.DB_PORT,
    user     : process.env.DB_USER,
    password : process.env.DB_PASSWORD,
    database : process.env.DB_NAME,

    waitForConnections : true,
    connectionLimit    : 10,
    queueLimit         : 0
});

// ── Test connection on startup ──────────────────────────────
pool.getConnection((err, connection) => {
    if (err) {
        console.error("❌ DB Connection Failed:", err.message);
        process.exit(1);
    }
    console.log("✅ MySQL Connected — myhmsdb");
    connection.release();
});

// ── Export promise-based pool ───────────────────────────────
module.exports = pool.promise();