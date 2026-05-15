const express           = require("express");
const router            = express.Router();
const db                = require("../config/db");
const { sendResponse,
        requireFields } = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  GET /api/appointments
//  Query params:
//    ?pid=4          ← filter by patient
//    ?doctor=Ganesh  ← filter by doctor
//    ?filter=1       ← 1=pending, 2=confirmed, 0=all
// ════════════════════════════════════════════════════════════
router.get("/", async (req, res) => {
    try {
        const { pid, doctor, filter } = req.query;

        let sql    = `SELECT * FROM appointmenttb WHERE 1=1`;
        let params = [];

        // ── Filter by patient pid ────────────────────────────
        if (pid) {
            sql   += " AND pid = ?";
            params.push(parseInt(pid));
        }

        // ── Filter by doctor username ────────────────────────
        if (doctor) {
            sql   += " AND doctor = ?";
            params.push(doctor);
        }

        // ── Filter by status ─────────────────────────────────
        // filter=1 → pending (either side)
        // filter=2 → fully confirmed (both sides)
        if (filter === "1") {
            sql += " AND (userStatus = 0 OR doctorStatus = 0)";
        } else if (filter === "2") {
            sql += " AND userStatus = 1 AND doctorStatus = 1";
        }

        sql += " ORDER BY appdate DESC, apptime DESC";

        const [rows] = await db.execute(sql, params);

        // ── Map rows to clean object ─────────────────────────
        const appointments = rows.map(row => ({
            pid          : row.pid,
            ID           : row.ID,
            fname        : row.fname,
            lname        : row.lname,
            gender       : row.gender,
            email        : row.email,
            contact      : row.contact,
            doctor       : row.doctor,
            docFees      : row.docFees,
            appdate      : row.appdate,
            apptime      : row.apptime,
            userStatus   : row.userStatus,
            doctorStatus : row.doctorStatus
        }));

        return sendResponse(
            res, true,
            "Appointments fetched successfully.",
            appointments
        );

    } catch (err) {
        console.error("Get appointments error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch appointments.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  GET /api/appointments/:id
//  Returns single appointment by ID
// ════════════════════════════════════════════════════════════
router.get("/:id", async (req, res) => {
    const id = parseInt(req.params.id);

    if (isNaN(id)) {
        return sendResponse(
            res, false,
            "Invalid appointment ID.",
            null, 400
        );
    }

    try {
        const [rows] = await db.execute(
            "SELECT * FROM appointmenttb WHERE ID = ?",
            [id]
        );

        if (rows.length === 0) {
            return sendResponse(
                res, false,
                "Appointment not found.",
                null, 404
            );
        }

        return sendResponse(
            res, true,
            "Appointment fetched.",
            rows[0]
        );

    } catch (err) {
        console.error("Get appointment error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch appointment.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  POST /api/appointments
//  Books a new appointment into appointmenttb
//  Body: { pid, fname, lname, gender, email, contact,
//          doctor, docFees, appdate, apptime }
// ════════════════════════════════════════════════════════════
router.post(
    "/",
    requireFields([
        "pid", "fname", "lname", "gender",
        "email", "contact", "doctor",
        "docFees", "appdate", "apptime"
    ]),
    async (req, res) => {
        const {
            pid, fname, lname, gender,
            email, contact, doctor,
            docFees, appdate, apptime
        } = req.body;

        // userStatus=1 patient confirmed
        // doctorStatus=0 awaiting doctor
        const userStatus   = 1;
        const doctorStatus = 0;

        try {
            const [result] = await db.execute(
                `INSERT INTO appointmenttb
                    (pid, fname, lname, gender, email,
                     contact, doctor, docFees, appdate,
                     apptime, userStatus, doctorStatus)
                 VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
                [
                    parseInt(pid),
                    fname, lname, gender,
                    email, contact, doctor,
                    parseInt(docFees),
                    appdate, apptime,
                    userStatus, doctorStatus
                ]
            );

            return sendResponse(
                res, true,
                "Appointment booked successfully.",
                { appointmentId: result.insertId }
            );

        } catch (err) {
            console.error("Book appointment error:", err.message);
            return sendResponse(
                res, false,
                "Failed to book appointment.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  PUT /api/appointments/:id/status
//  Updates appointment status flags
//  Body: { userStatus?, doctorStatus? }
//  Used by: Admin (both), Doctor (doctorStatus),
//           Patient (userStatus)
// ════════════════════════════════════════════════════════════
router.put("/:id/status", async (req, res) => {
    const id = parseInt(req.params.id);

    if (isNaN(id)) {
        return sendResponse(
            res, false,
            "Invalid appointment ID.",
            null, 400
        );
    }

    const { userStatus, doctorStatus } = req.body;

    // At least one status must be provided
    if (userStatus === undefined && doctorStatus === undefined) {
        return sendResponse(
            res, false,
            "Provide at least one of: userStatus, doctorStatus.",
            null, 400
        );
    }

    try {
        // ── Check appointment exists ─────────────────────────
        const [existing] = await db.execute(
            "SELECT ID FROM appointmenttb WHERE ID = ?",
            [id]
        );

        if (existing.length === 0) {
            return sendResponse(
                res, false,
                "Appointment not found.",
                null, 404
            );
        }

        // ── Build dynamic update query ───────────────────────
        let setClauses = [];
        let params     = [];

        if (userStatus !== undefined) {
            setClauses.push("userStatus = ?");
            params.push(parseInt(userStatus));
        }

        if (doctorStatus !== undefined) {
            setClauses.push("doctorStatus = ?");
            params.push(parseInt(doctorStatus));
        }

        params.push(id);

        await db.execute(
            `UPDATE appointmenttb
             SET ${setClauses.join(", ")}
             WHERE ID = ?`,
            params
        );

        return sendResponse(
            res, true,
            "Appointment status updated successfully."
        );

    } catch (err) {
        console.error("Update status error:", err.message);
        return sendResponse(
            res, false,
            "Failed to update appointment status.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  DELETE /api/appointments/:id
//  Deletes appointment from appointmenttb
// ════════════════════════════════════════════════════════════
router.delete("/:id", async (req, res) => {
    const id = parseInt(req.params.id);

    if (isNaN(id)) {
        return sendResponse(
            res, false,
            "Invalid appointment ID.",
            null, 400
        );
    }

    try {
        const [existing] = await db.execute(
            "SELECT ID FROM appointmenttb WHERE ID = ?",
            [id]
        );

        if (existing.length === 0) {
            return sendResponse(
                res, false,
                "Appointment not found.",
                null, 404
            );
        }

        await db.execute(
            "DELETE FROM appointmenttb WHERE ID = ?",
            [id]
        );

        return sendResponse(
            res, true,
            "Appointment deleted successfully."
        );

    } catch (err) {
        console.error("Delete appointment error:", err.message);
        return sendResponse(
            res, false,
            "Failed to delete appointment.",
            null, 500
        );
    }
});

module.exports = router;