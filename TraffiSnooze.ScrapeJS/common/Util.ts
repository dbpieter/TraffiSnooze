import _ = require('lodash');

module Util {

    export function StripNonAlphaNumeric(str: string) {
        let out = str.replace(/[^a-zA-Z0-9\s]/g, '');
        return out;
    }

    export function StripWhiteSpace(str: string) {
        let out = str.replace(/[\s+]/g, '');
        return out;
    }
    
}

module.exports = Util;
