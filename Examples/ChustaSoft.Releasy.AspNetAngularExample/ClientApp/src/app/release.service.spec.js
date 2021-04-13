"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var release_service_1 = require("./release.service");
describe('ReleaseService', function () {
    beforeEach(function () { return testing_1.TestBed.configureTestingModule({}); });
    it('should be created', function () {
        var service = testing_1.TestBed.get(release_service_1.ReleaseService);
        expect(service).toBeTruthy();
    });
});
//# sourceMappingURL=release.service.spec.js.map