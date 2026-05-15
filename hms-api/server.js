const express = require("express");
const cors    = require("cors");
require("dotenv").config();

const app = express();

// ── Middleware ──────────────────────────────────────────────
app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

// ── Routes ──────────────────────────────────────────────────
app.use("/api/auth",         require("./routes/auth"));
app.use("/api/patients",     require("./routes/patients"));
app.use("/api/doctors",      require("./routes/doctors.js"));
app.use("/api/appointments", require("./routes/appointments"));
app.use("/api/prescriptions",require("./routes/prescriptions"));
app.use("/api/contacts",     require("./routes/contacts"));

// ── Health check ────────────────────────────────────────────
app.get("/", (req, res) => {
    res.json({
        success : true,
        message : "HMS Node.js API is running",
        version : "1.0.0",
        port    : process.env.PORT
    });
});

// ── 404 Handler ─────────────────────────────────────────────
app.use((req, res) => {
    res.status(404).json({
        success : false,
        message : `Route not found: ${req.method} ${req.originalUrl}`
    });
});

// ── Global error handler ────────────────────────────────────
app.use((err, req, res, next) => {
    console.error("❌ Server Error:", err.message);
    res.status(500).json({
        success : false,
        message : "Internal server error",
        error   : err.message
    });
});

// ── Start server ────────────────────────────────────────────
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`🚀 HMS API running at http://localhost:${PORT}`);
    console.log(`📋 Routes:`);
    console.log(`   POST   /api/auth/login`);
    console.log(`   GET    /api/patients`);
    console.log(`   GET    /api/doctors`);
    console.log(`   GET    /api/appointments`);
    console.log(`   GET    /api/prescriptions`);
    console.log(`   GET    /api/contacts`);
});