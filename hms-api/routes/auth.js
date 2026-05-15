const express             = require("express");
const router              = express.Router();
const db                  = require("../config/db");
const { sendResponse,
        requireFields }   = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  POST /api/auth/login
//  Body: { username, password, role }
//  role: "admin" | "doctor" | "patient"
// ════════════════════════════════════════════════════════════
router.post(
    "/login",
    requireFields(["username", "password", "role"]),
    async (req, res) => {
        const { username, password, role } = req.body;

        try {
            let query  = "";
            let params = [];
            let table  = "";

            // ── Route to correct table by role ───────────────
            switch (role.toLowerCase()) {

                // admintb: username | password
                case "admin":
                    table  = "admintb";
                    query  = `SELECT username
                              FROM admintb
                              WHERE username = ? AND password = ?`;
                    params = [username, password];
                    break;

                // doctb: username | password | email | spec | docFees
                case "doctor":
                    table  = "doctb";
                    query  = `SELECT username, email, spec, docFees
                              FROM doctb
                              WHERE username = ? AND password = ?`;
                    params = [username, password];
                    break;

                // patreg: pid | fname | lname | email | contact
                // Patient logs in with email as username
                case "patient":
                    table  = "patreg";
                    query  = `SELECT pid, fname, lname,
                                     gender, email, contact
                              FROM patreg
                              WHERE email = ? AND password = ?`;
                    params = [username, password];
                    break;

                default:
                    return sendResponse(
                        res, false,
                        "Invalid role. Use admin, doctor, or patient.",
                        null, 400
                    );
            }

            const [rows] = await db.execute(query, params);

            if (rows.length === 0) {
                return sendResponse(
                    res, false,
                    "Invalid credentials. Please try again.",
                    null, 401
                );
            }

            // ── Build response payload by role ───────────────
            let payload = { role };

            switch (role.toLowerCase()) {
                case "admin":
                    payload.username = rows[0].username;
                    break;

                case "doctor":
                    payload.username = rows[0].username;
                    payload.email    = rows[0].email;
                    payload.spec     = rows[0].spec;
                    payload.docFees  = rows[0].docFees;
                    break;

                case "patient":
                    payload.pid      = rows[0].pid;
                    payload.fname    = rows[0].fname;
                    payload.lname    = rows[0].lname;
                    payload.gender   = rows[0].gender;
                    payload.email    = rows[0].email;
                    payload.contact  = rows[0].contact;
                    payload.fullName = `${rows[0].fname} ${rows[0].lname}`;
                    break;
            }

            return sendResponse(
                res, true,
                `${role} login successful.`,
                payload
            );

        } catch (err) {
            console.error("Login error:", err.message);
            return sendResponse(
                res, false,
                "Server error during login.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  POST /api/auth/register
//  Body: { fname, lname, gender, email, contact,
//          password, cpassword }
//  Registers a new patient into patreg
// ════════════════════════════════════════════════════════════
router.post(
    "/register",
    requireFields([
        "fname", "lname", "gender",
        "email", "contact", "password", "cpassword"
    ]),
    async (req, res) => {
        const {
            fname, lname, gender,
            email, contact, password, cpassword
        } = req.body;

        try {
            // ── Password match check ─────────────────────────
            if (password !== cpassword) {
                return sendResponse(
                    res, false,
                    "Passwords do not match.",
                    null, 400
                );
            }

            // ── Duplicate email check ────────────────────────
            const [existing] = await db.execute(
                "SELECT pid FROM patreg WHERE email = ?",
                [email]
            );

            if (existing.length > 0) {
                return sendResponse(
                    res, false,
                    "An account with this email already exists.",
                    null, 409
                );
            }

            // ── Insert into patreg ───────────────────────────
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
                "Registration successful. You can now login.",
                { pid: result.insertId }
            );

        } catch (err) {
            console.error("Register error:", err.message);
            return sendResponse(
                res, false,
                "Server error during registration.",
                null, 500
            );
        }
    }
);

module.exports = router;