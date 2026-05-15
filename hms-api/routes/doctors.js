const express           = require("express");
const router            = express.Router();
const db                = require("../config/db");
const { sendResponse,
        requireFields } = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  GET /api/doctors
//  Returns all doctors from doctb
//  doctb: username | email | spec | docFees (no password)
// ════════════════════════════════════════════════════════════
router.get("/", async (req, res) => {
    try {
        const [rows] = await db.execute(
            `SELECT username, email, spec, docFees
             FROM doctb
             ORDER BY username ASC`
        );

        return sendResponse(
            res, true,
            "Doctors fetched successfully.",
            rows
        );

    } catch (err) {
        console.error("Get doctors error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch doctors.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  GET /api/doctors/:username
//  Returns single doctor by username
// ════════════════════════════════════════════════════════════
router.get("/:username", async (req, res) => {
    const { username } = req.params;

    try {
        const [rows] = await db.execute(
            `SELECT username, email, spec, docFees
             FROM doctb
             WHERE username = ?`,
            [username]
        );

        if (rows.length === 0) {
            return sendResponse(
                res, false,
                "Doctor not found.",
                null, 404
            );
        }

        return sendResponse(
            res, true,
            "Doctor fetched.",
            rows[0]
        );

    } catch (err) {
        console.error("Get doctor error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch doctor.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  POST /api/doctors
//  Creates new doctor in doctb
//  Body: { username, password, email, spec, docFees }
// ════════════════════════════════════════════════════════════
router.post(
    "/",
    requireFields([
        "username", "password", "email", "spec", "docFees"
    ]),
    async (req, res) => {
        const {
            username, password,
            email, spec, docFees
        } = req.body;

        const fees = parseInt(docFees);

        if (isNaN(fees)) {
            return sendResponse(
                res, false,
                "docFees must be a valid number.",
                null, 400
            );
        }

        try {
            // ── Duplicate username check ─────────────────────
            const [existing] = await db.execute(
                "SELECT username FROM doctb WHERE username = ?",
                [username]
            );

            if (existing.length > 0) {
                return sendResponse(
                    res, false,
                    "A doctor with this username already exists.",
                    null, 409
                );
            }

            // ── Insert into doctb ────────────────────────────
            await db.execute(
                `INSERT INTO doctb
                    (username, password, email, spec, docFees)
                 VALUES (?, ?, ?, ?, ?)`,
                [username, password, email, spec, fees]
            );

            return sendResponse(
                res, true,
                "Doctor added successfully.",
                { username }
            );

        } catch (err) {
            console.error("Add doctor error:", err.message);
            return sendResponse(
                res, false,
                "Failed to add doctor.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  PUT /api/doctors/:username
//  Updates existing doctor in doctb
//  Body: { email, spec, docFees, password? }
//  Password is optional — only updated if provided
// ════════════════════════════════════════════════════════════
router.put(
    "/:username",
    requireFields(["email", "spec", "docFees"]),
    async (req, res) => {
        const { username } = req.params;
        const { email, spec, docFees, password } = req.body;

        const fees = parseInt(docFees);

        if (isNaN(fees)) {
            return sendResponse(
                res, false,
                "docFees must be a valid number.",
                null, 400
            );
        }

        try {
            // ── Check doctor exists ──────────────────────────
            const [existing] = await db.execute(
                "SELECT username FROM doctb WHERE username = ?",
                [username]
            );

            if (existing.length === 0) {
                return sendResponse(
                    res, false,
                    "Doctor not found.",
                    null, 404
                );
            }

            // ── Update with or without password ──────────────
            if (password && password.trim() !== "") {
                await db.execute(
                    `UPDATE doctb
                     SET email=?, spec=?, docFees=?, password=?
                     WHERE username=?`,
                    [email, spec, fees, password, username]
                );
            } else {
                await db.execute(
                    `UPDATE doctb
                     SET email=?, spec=?, docFees=?
                     WHERE username=?`,
                    [email, spec, fees, username]
                );
            }

            return sendResponse(
                res, true,
                "Doctor updated successfully."
            );

        } catch (err) {
            console.error("Update doctor error:", err.message);
            return sendResponse(
                res, false,
                "Failed to update doctor.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  DELETE /api/doctors/:username
//  Deletes doctor from doctb
// ════════════════════════════════════════════════════════════
router.delete("/:username", async (req, res) => {
    const { username } = req.params;

    try {
        const [existing] = await db.execute(
            "SELECT username FROM doctb WHERE username = ?",
            [username]
        );

        if (existing.length === 0) {
            return sendResponse(
                res, false,
                "Doctor not found.",
                null, 404
            );
        }

        await db.execute(
            "DELETE FROM doctb WHERE username = ?",
            [username]
        );

        return sendResponse(
            res, true,
            "Doctor deleted successfully."
        );

    } catch (err) {
        console.error("Delete doctor error:", err.message);
        return sendResponse(
            res, false,
            "Failed to delete doctor.",
            null, 500
        );
    }
});

module.exports = router;