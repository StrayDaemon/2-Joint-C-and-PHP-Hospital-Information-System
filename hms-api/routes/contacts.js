const express           = require("express");
const router            = express.Router();
const db                = require("../config/db");
const { sendResponse,
        requireFields } = require("../middleware/validate");

// ════════════════════════════════════════════════════════════
//  GET /api/contacts
//  Returns all contact messages
//  contact: name | email | contact | message
//  Query params:
//    ?search=keyword ← search by name or email
// ════════════════════════════════════════════════════════════
router.get("/", async (req, res) => {
    try {
        const { search } = req.query;

        let sql    = `SELECT name, email, contact, message
                      FROM contact`;
        let params = [];

        // ── Optional keyword search ──────────────────────────
        if (search && search.trim() !== "") {
            sql   += ` WHERE name LIKE ?
                       OR email LIKE ?`;
            const keyword = `%${search.trim()}%`;
            params.push(keyword, keyword);
        }

        sql += " ORDER BY name ASC";

        const [rows] = await db.execute(sql, params);

        // ── Map contact field name ───────────────────────────
        // DB column is 'contact' but C# model uses 'contactNo'
        const contacts = rows.map(row => ({
            name      : row.name,
            email     : row.email,
            contactNo : row.contact,
            message   : row.message
        }));

        return sendResponse(
            res, true,
            `${contacts.length} contact(s) fetched.`,
            contacts
        );

    } catch (err) {
        console.error("Get contacts error:", err.message);
        return sendResponse(
            res, false,
            "Failed to fetch contacts.",
            null, 500
        );
    }
});

// ════════════════════════════════════════════════════════════
//  POST /api/contacts
//  Saves a new contact message
//  Body: { name, email, contact, message }
//  Used by System 1 (PHP web contact form)
//  and can be used by System 2 (C# WinForms)
// ════════════════════════════════════════════════════════════
router.post(
    "/",
    requireFields(["name", "email", "contact", "message"]),
    async (req, res) => {
        const { name, email, contact, message } = req.body;

        // ── Validate contact length ──────────────────────────
        if (contact.length > 10) {
            return sendResponse(
                res, false,
                "Contact number must be 10 digits or less.",
                null, 400
            );
        }

        // ── Validate message length ──────────────────────────
        if (message.length > 200) {
            return sendResponse(
                res, false,
                "Message must be 200 characters or less.",
                null, 400
            );
        }

        try {
            await db.execute(
                `INSERT INTO contact
                    (name, email, contact, message)
                 VALUES (?, ?, ?, ?)`,
                [name, email, contact, message]
            );

            return sendResponse(
                res, true,
                "Message sent successfully. We will get back to you!"
            );

        } catch (err) {
            console.error("Save contact error:", err.message);
            return sendResponse(
                res, false,
                "Failed to send message.",
                null, 500
            );
        }
    }
);

// ════════════════════════════════════════════════════════════
//  DELETE /api/contacts
//  Deletes a contact message by email + name combo
//  Query: ?email=anu@gmail.com&name=Anu
//  Admin only operation
// ════════════════════════════════════════════════════════════
router.delete("/", async (req, res) => {
    const { email, name } = req.query;

    if (!email || !name) {
        return sendResponse(
            res, false,
            "Both email and name are required to delete a contact.",
            null, 400
        );
    }

    try {
        const [result] = await db.execute(
            "DELETE FROM contact WHERE email = ? AND name = ?",
            [email, name]
        );

        if (result.affectedRows === 0) {
            return sendResponse(
                res, false,
                "Contact message not found.",
                null, 404
            );
        }

        return sendResponse(
            res, true,
            "Contact message deleted successfully."
        );

    } catch (err) {
        console.error("Delete contact error:", err.message);
        return sendResponse(
            res, false,
            "Failed to delete contact.",
            null, 500
        );
    }
});

module.exports = router;