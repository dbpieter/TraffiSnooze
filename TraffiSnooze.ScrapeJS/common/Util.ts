///<reference path="../typings/lodash/lodash.d.ts" />
///<reference path="../typings/node/node.d.ts" />

import _ = require('lodash');

export module Util {

    export function StripNonAlphaNumeric(str: string) {
        let out = str.replace(/[^a-zA-Z0-9\s]/g, '');
        return out;
    }

    export function StripWhiteSpace(str: string) {
        let out = str.replace(/[\s+]/g, '');
        return out;
    }    
}

module.exports = Util
