"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReleaseInfoService = void 0;
const cs_common_1 = require("@chustasoft/cs-common");
class ReleaseInfoService {
    constructor(authorizationApiUrl) {
        this.apiUrl = authorizationApiUrl;
        this.httpService = new cs_common_1.HttpService();
    }
    getAll() {
        return __awaiter(this, void 0, void 0, function* () {
            const authHeader = this.getAuthentication();
            return this.httpService.get(`${this.apiUrl}/release`, authHeader);
        });
    }
    get(identifier) {
        return __awaiter(this, void 0, void 0, function* () {
            const authHeader = this.getAuthentication();
            return this.httpService.get(`${this.apiUrl}/release/${identifier}`, authHeader);
        });
    }
    getFrom(filter) {
        return __awaiter(this, void 0, void 0, function* () {
            const filterUrlPart = this.getFilterUrlPart(filter);
            const authHeader = this.getAuthentication();
            return this.httpService.get(`${this.apiUrl}/release/${filterUrlPart}/${filter}`, authHeader);
        });
    }
    getFilterUrlPart(filter) {
        if (filter instanceof Date)
            return `/from-date`;
        else
            return `/from-identifier`;
    }
}
exports.ReleaseInfoService = ReleaseInfoService;
