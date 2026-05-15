const express           = require("express");
const router            = express.Router();
const db                = require("../config/db");
const { sendResponse,
        requireFields } = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  GET /api/prescriptions
//  Query params:
//    ?pid=4          ← all prescriptions for a patient
//    ?doctor=Ganesh  ← all prescriptions by a doctor
//    ?id=8           ← single prescription by appointment ID
// ════════════════════════════════════════════════════════════
router.get("/", async (req, res) => {
    try {
        const { pid, doctor, id } = req.query;

        let sql    = `SELECT doctor, pid, ID, fname, lname,
                             appdate, apptime, disease,
                             allergy, prescription
                      FROM prestb
                      WHERE 1=1`;
        let params = [];

        // ── Filter by patient pid ────────────────────────────
        // prestb: pid links to patreg.pid
        if (pid) {
            sql += " AND pid = ?";
            params.push(parseInt(pid));
        }

        // ── Filter by doctor username ────────────────────────
        // prestb: doctor links to doctb.username
        if (doctor) {
            sql += " AND doctor = ?";
            params.push(doctor);
        }

        // ── Filter by appointment ID ─────────────────────────
        // prestb: ID links to appointmenttb.ID
        if (id) {
            sql += " AND ID = ?";
            params.push(parseInt(id));
        }

        sql += " ORDER BY appdate DESC, apptime DESC";

        const [rows] = await db.execute(sql, params);

        if (rows.length === 0) {
            return sendResponse(
                res, false,
                "No prescriptions found.",
                []
            );
        }

        // ── Map to clean objects ─────────────────────────────
        const prescriptions = rows.map(row => ({
            doctor           : row.doctor,
            pid              : row.pid,
            ID               : row.ID,
            fname            : row.fname,
            lname            : row.lname,
            fullName         : `${row.fname} ${row.lname}`,
            appdate          : row.appdate,
            apptime          : row.apptime,
            disease          : row.disease,
            allergy          : row.allergy,
            prescriptionText : row.prescription
        }));

        return sendResponse(
            res, true,
            "Prescriptions fetched successfully.",
            prescriptions
        );

    } catch (err) {
        console.error("Get prescriptions error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch prescriptions.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  GET /api/prescriptions/:id
//  Returns single prescription by appointment ID
//  Optional query: ?pid=4 for patient-scoped security check
// ════════════════════════════════════════════════════════════
router.get("/:id", async (req, res) => {
    const id  = parseInt(req.params.id);
    const pid = req.query.pid ? parseInt(req.query.pid) : null;

    if (isNaN(id)) {
        return sendResponse(
            res, false,
            "Invalid appointment ID.",
            null, 400
        );
    }

    try {
        let sql    = `SELECT doctor, pid, ID, fname, lname,
                             appdate, apptime, disease,
                             allergy, prescription
                      FROM prestb
                      WHERE ID = ?`;
        let params = [id];

        // ── Optionally scope to patient ──────────────────────
        if (pid) {
            sql += " AND pid = ?";
            params.push(pid);
        }

        const [rows] = await db.execute(sql, params);

        if (rows.length === 0) {
            return sendResponse(
                res, false,
                "Prescription not found.",
                null, 404
            );
        }

        const row = rows[0];

        return sendResponse(
            res, true,
            "Prescription fetched.",
            {
                doctor           : row.doctor,
                pid              : row.pid,
                ID               : row.ID,
                fname            : row.fname,
                lname            : row.lname,
                fullName         : `${row.fname} ${row.lname}`,
                appdate          : row.appdate,
                apptime          : row.apptime,
                disease          : row.disease,
                allergy          : row.allergy,
                prescriptionText : row.prescription
            }
        );

    } catch (err) {
        console.error("Get prescription error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch prescription.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  POST /api/prescriptions
//  Saves a new prescription into prestb
//  Body: { doctor, pid, ID, fname, lname,
//          appdate, apptime, disease,
//          allergy, prescription }
//  If prescription for this ID already exists → UPDATE
// ════════════════════════════════════════════════════════════
router.post(
    "/",
    requireFields([
        "doctor", "pid", "ID",
        "fname",  "lname",
        "appdate", "apptime",
        "disease", "allergy", "prescription"
    ]),
    async (req, res) => {
        const {
            doctor, pid, ID,
            fname,  lname,
            appdate, apptime,
            disease, allergy, prescription
        } = req.body;

        try {
            // ── Check if prescription exists for this appt ───
            // prestb has no primary key — use ID (appointmenttb.ID)
            // and doctor as unique combination
            const [existing] = await db.execute(
                `SELECT ID FROM prestb
                 WHERE ID = ? AND doctor = ?`,
                [parseInt(ID), doctor]
            );

            if (existing.length > 0) {
                // ── UPDATE existing prescription ─────────────
                await db.execute(
                    `UPDATE prestb
                     SET disease=?, allergy=?, prescription=?
                     WHERE ID=? AND doctor=?`,
                    [
                        disease, allergy, prescription,
                        parseInt(ID), doctor
                    ]
                );

                return sendResponse(
                    res, true,
                    "Prescription updated successfully."
                );

            } else {
                // ── INSERT new prescription ──────────────────
                await db.execute(
                    `INSERT INTO prestb
                        (doctor, pid, ID, fname, lname,
                         appdate, apptime, disease,
                         allergy, prescription)
                     VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`,
                    [
                        doctor,
                        parseInt(pid),
                        parseInt(ID),
                        fname, lname,
                        appdate, apptime,
                        disease, allergy,
                        prescription
                    ]
                );

                return sendResponse(
                    res, true,
                    "Prescription saved successfully."
                );
            }

        } catch (err) {
            console.error("Save prescription error:", err.message);
            return sendResponse(
                res, false,
                "Failed to save prescription.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  PUT /api/prescriptions/:id
//  Updates prescription by appointment ID
//  Body: { disease, allergy, prescription, doctor }
// ════════════════════════════════════════════════════════════
router.put(
    "/:id",
    requireFields(["disease", "allergy", "prescription", "doctor"]),
    async (req, res) => {
        const id = parseInt(req.params.id);

        if (isNaN(id)) {
            return sendResponse(
                res, false,
                "Invalid appointment ID.",
                null, 400
            );
        }

        const { disease, allergy, prescription, doctor } = req.body;

        try {
            const [existing] = await db.execute(
                "SELECT ID FROM prestb WHERE ID = ? AND doctor = ?",
                [id, doctor]
            );

            if (existing.length === 0) {
                return sendResponse(
                    res, false,
                    "Prescription not found for this doctor.",
                    null, 404
                );
            }

            await db.execute(
                `UPDATE prestb
                 SET disease=?, allergy=?, prescription=?
                 WHERE ID=? AND doctor=?`,
                [disease, allergy, prescription, id, doctor]
            );

            return sendResponse(
                res, true,
                "Prescription updated successfully."
            );

        } catch (err) {
            console.error("Update prescription error:", err.message);
            return sendResponse(
                res, false,
                "Failed to update prescription.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  DELETE /api/prescriptions/:id
//  Deletes prescription by appointment ID
//  Query: ?doctor=Ganesh (scope to doctor)
// ════════════════════════════════════════════════════════════
router.delete("/:id", async (req, res) => {
    const id     = parseInt(req.params.id);
    const doctor = req.query.doctor || null;

    if (isNaN(id)) {
        return sendResponse(
            res, false,
            "Invalid appointment ID.",
            null, 400
        );
    }

    try {
        let sql    = "DELETE FROM prestb WHERE ID = ?";
        let params = [id];

        // ── Scope delete to doctor if provided ───────────────
        if (doctor) {
            sql += " AND doctor = ?";
            params.push(doctor);
        }

        const [result] = await db.execute(sql, params);

        if (result.affectedRows === 0) {
            return sendResponse(
                res, false,
                "Prescription not found.",
                null, 404
            );
        }

        return sendResponse(
            res, true,
            "Prescription deleted successfully."
        );

    } catch (err) {
        console.error("Delete prescription error:", err.message);
        return sendResponse(
            res, false,
            "Failed to delete prescription.",
            null, 500
        );
    }
});

module.exports = router;