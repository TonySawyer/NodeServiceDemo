var sharp = require('sharp');

module.exports = function(result, physicalPath, maxWidth) {
    // invoke the 'sharp' NPM module
    sharp(physicalPath)
        .resize(maxWidth)
        .pipe(result.stream);
}