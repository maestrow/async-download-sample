/**
 * Require Browsersync
 */
var browserSync = require('browser-sync');

/**
 * Run Browsersync with server config
 */
browserSync({
    server: {
        baseDir: "public",
        directory: true
    },
});