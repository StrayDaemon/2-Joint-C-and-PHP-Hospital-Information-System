const express           = require("express");
const router            = express.Router();
const db                = require("../config/db");
const { sendResponse,
        requireFields } = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  GET /api/patients
//  Returns all patients from patreg
//  patreg: pid | fname | lname | gender | email | contact
// ════════════════════════════════════════════════════════════
router.get("/", async (req, res) => {
    try {
        const [rows] = await db.execute(
            `SELECT pid, fname, lname, gender, email, contact
             FROM patreg
             ORDER BY pid ASC`
        );

        return sendResponse(
            res, true,
            "Patients fetched successfully.",
            rows
        );

    } catch (err) {
        console.error("Get patients error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch patients.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  GET /api/patients/:pid
//  Returns single patient by pid
// ════════════════════════════════════════════════════════════
router.get("/:pid", async (req, res) => {
    const pid = parseInt(req.params.pid);

    if (isNaN(pid)) {
        return sendResponse(
            res, false,
            "Invalid patient ID.",
            null, 400
        );
    }

    try {
        const [rows] = await db.execute(
            `SELECT pid, fname, lname, gender, email, contact
             FROM patreg
             WHERE pid = ?`,
            [pid]
        );

        if (rows.length === 0) {
            return sendResponse(
                res, false,
                "Patient not found.",
                null, 404
            );
        }

        return sendResponse(
            res, true,
            "Patient fetched.",
            rows[0]
        );

    } catch (err) {
        console.error("Get patient error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch patient.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  POST /api/patients
//  Creates new patient in patreg
//  Body: { fname, lname, gender, email, contact,
//          password, cpassword }
// ════════════════════════════════════════════════════════════
router.post(
    "/",
    requireFields([
        "fname", "lname", "gender",
        "email", "contact", "password"
    ]),
    async (req, res) => {
        const {
            fname, lname, gender,
            email, contact, password
        } = req.body;

        const cpassword = req.body.cpassword || password;

        try {
            // ── Duplicate email check ────────────────────────
            const [existing] = await db.execute(
                "SELECT pid FROM patreg WHERE email = ?",
                [email]
            );

            if (existing.length > 0) {
                return sendResponse(
                    res, false,
                    "A patient with this email already exists.",
                    null, 409
                );
            }

            // ── Insert ───────────────────────────────────────
            const [result] = await db.execute(
                `INSERT INTO patreg
                    (fname, lname, gender, email,
                     contact, password, cpassword)
                 VALUES (?, ?, ?, ?, ?, ?, ?)`,
                [fname, lname, gender, email,
                 contact, password, cpassword]
            );

            return sendResponse(
                res, true,
                "Patient added successfully.",
                { pid: result.insertId }
            );

        } catch (err) {
            console.error("Add patient error:", err.message);
            return sendResponse(
                res, false,
                "Failed to add patient.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  PUT /api/patients/:pid
//  Updates existing patient in patreg
//  Body: { fname, lname, gender, email, contact }
// ════════════════════════════════════════════════════════════
router.put(
    "/:pid",
    requireFields(["fname", "lname", "gender", "email", "contact"]),
    async (req, res) => {
        const pid = parseInt(req.params.pid);

        if (isNaN(pid)) {
            return sendResponse(
                res, false,
                "Invalid patient ID.",
                null, 400
            );
        }

        const { fname, lname, gender, email, contact } = req.body;

        try {
            // ── Check patient exists ─────────────────────────
            const [existing] = await db.execute(
                "SELECT pid FROM patreg WHERE pid = ?",
                [pid]
            );

            if (existing.length === 0) {
                return sendResponse(
                    res, false,
                    "Patient not found.",
                    null, 404
                );
            }

            // ── Update ───────────────────────────────────────
            await db.execute(
                `UPDATE patreg
                 SET fname=?, lname=?, gender=?,
                     email=?, contact=?
                 WHERE pid=?`,
                [fname, lname, gender, email, contact, pid]
            );

            return sendResponse(
                res, true,
                "Patient updated successfully."
            );

        } catch (err) {
            console.error("Update patient error:", err.message);
            return sendResponse(
                res, false,
                "Failed to update patient.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  DELETE /api/patients/:pid
//  Deletes patient from patreg
// ════════════════════════════════════════════════════════════
router.delete("/:pid", async (req, res) => {
    const pid = parseInt(req.params.pid);

    if (isNaN(pid)) {
        return sendResponse(
            res, false,
            "Invalid patient ID.",
            null, 400
        );
    }

    try {
        const [existing] = await db.execute(
            "SELECT pid FROM patreg WHERE pid = ?",
            [pid]
        );

        if (existing.length === 0) {
            return sendResponse(
                res, false,
                "Patient not found.",
                null, 404
            );
        }

        await db.execute(
            "DELETE FROM patreg WHERE pid = ?",
            [pid]
        );

        return sendResponse(
            res, true,
            "Patient deleted successfully."
        );

    } catch (err) {
        console.error("Delete patient error:", err.message);
        return sendResponse(
            res, false,
            "Failed to delete patient.",
            null, 500
        );
    }
});

module.exports = router;