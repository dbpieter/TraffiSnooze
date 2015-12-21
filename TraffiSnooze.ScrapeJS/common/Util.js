///<reference path="../typings/lodash/lodash.d.ts" />
///<reference path="../typings/node/node.d.ts" />
var Util;
(function (Util) {
    function StripNonAlphaNumeric(str) {
        var out = str.replace(/[^a-zA-Z0-9\s]/g, '');
        return out;
    }
    Util.StripNonAlphaNumeric = StripNonAlphaNumeric;
    function StripWhiteSpace(str) {
        var out = str.replace(/[\s+]/g, '');
        return out;
    }
    Util.StripWhiteSpace = StripWhiteSpace;
})(Util = exports.Util || (exports.Util = {}));
module.exports = Util;
