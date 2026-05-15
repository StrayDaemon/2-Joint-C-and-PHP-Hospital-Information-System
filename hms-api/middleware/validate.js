// ── Standard JSON response helper ───────────────────────────
const sendResponse = (res, success, message, data = null, statusCode = 200) => {
    return res.status(statusCode).json({
        success,
        message,
        data
    });
};

// ── Check required POST fields ───────────────────────────────
const requireFields = (fields) => {
    return (req, res, next) => {
        const missing = fields.filter(f =>
            !req.body[f] || req.body[f].toString().trim() === ""
        );

        if (missing.length > 0) {
            return sendResponse(
                res,
                false,
                `Missing required fields: ${missing.join(", ")}`,
                null,
                400
            );
        }
        next();
    };
};

module.exports = { sendResponse, requireFields };