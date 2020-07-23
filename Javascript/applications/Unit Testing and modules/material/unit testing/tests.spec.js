const mod = require('./functions');
const expect = require('chai').expect;
const assert = require('assert');


describe("My sum function", function() {
     it('1+3=4', function(){
     assert.equal(mod.sum(1,3),4);
     })
     it('3+5=8', function(){
     assert.equal(mod.sum(3,5),8);
     });
});


describe("My sum function 2", function() {
     it("1+3 is 4", function() {
     expect(mod.sum(1,3)).to.be.equal(4);})
     it("3+5 is 8", function() {
     expect(mod.sum(3,5)).to.be.equal(7, 'bollocks');})
     it('yes', function(){
     expect(mod.sum('a','b')).to.be.string;
     })
});

//cd to containing folder
//npm init
//npm add chai mocha
//check package.json for scripts and dependancies