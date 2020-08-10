'use strict';

import {add as sum, changeT} from './module-es6.mjs';
//import * as module from './module-es6';

changeT(5);
console.log(sum(1,2));


//nvm use 12.1 (or 14.5)npm
//node --experimental-modules <dir file>
//.\material\modules\module-es6.mjs 